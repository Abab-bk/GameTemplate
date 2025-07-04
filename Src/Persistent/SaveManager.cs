using System;
using System.IO;
using Game.Commons;
using Game.Persistent.Models;
using Game.Scripts;
using Godot;
using GodotTask;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Game.Persistent;

public partial class SaveManager(ISaveSystem saveSystem) : Node
{
    private const string FileExtension = ".bin";
    private const string UserPreferencesFileName = "UserPreferences";
    private const string GameSaveFilePrefix = "GameSave";
    
    public event Action OnSaveGameSave = delegate { };
    public event Action OnSaveGameSaveFinished = delegate { };
    
    private static ILogger<SaveManager> Logger { get; } = LogManager.GetLogger<SaveManager>();
    public static SaveManager Instance { get; private set; } = default!;
    public GameSave CurrentSave { get; private set; } = default!;
    public UserPreferences UserPreferences { get; private set; } = default!;

    private const float MinSaveIntervalSeconds = 5f;
    private DateTime LastSaveTime { get; set; } = DateTime.MinValue;
    
    public override void _Ready()
    {
        base._Ready();
        if (IsInstanceValid(Instance))
        {
            Logger.ZLogError($"SaveManager already exists.");
            return;
        }

        Instance = this;
    }
    
    public async GDTask LoadUserPreferencesAsync()
    {
        UserPreferences = await LoadOrCreateAsync(
            UserPreferencesFileName,
            () => new UserPreferences(),
            "Flower",
            "UserPreferences"
        );
        Logger.ZLogInformation($"UserPreferences loaded: {UserPreferences.ToString()}");
    }

    public async GDTask LoadGameSaveAsync(string slotId)
    {
        CurrentSave = await LoadOrCreateAsync(
            GetGameSaveFileName(slotId),
            () => new GameSave(),
            slotId,
            "GameSave"
        );
    }

    public void SaveCurrentGameSave()
    {
        if ((DateTime.UtcNow - LastSaveTime).TotalSeconds < MinSaveIntervalSeconds)
        {
            Logger.ZLogInformation($"Save skipped: not enough time has passed since last save.");
            return;
        }

        LastSaveTime = DateTime.UtcNow;
        SaveGameSaveAsync("Flower").Forget();
    }

    public async GDTask SaveCurrentGameSaveAsync()
    {
        if ((DateTime.UtcNow - LastSaveTime).TotalSeconds < MinSaveIntervalSeconds)
        {
            Logger.ZLogInformation($"Save skipped: not enough time has passed since last save.");
            return;
        }

        LastSaveTime = DateTime.UtcNow;
        await SaveGameSaveAsync("Flower");
    }

    public async GDTask SaveGameSaveAsync(string slotId)
    {
        OnSaveGameSave();
        await saveSystem.SaveAsync(GetSlotPath(GetGameSaveFileName(slotId)), CurrentSave);
        OnSaveGameSaveFinished();
        Logger.ZLogInformation($"GameSave saved.");
    }
    
    public async GDTask SaveUserPreferences()
    {
        await saveSystem.SaveAsync(GetSlotPath(UserPreferencesFileName), UserPreferences);
        ApplyUserPreferences();
        Logger.ZLogInformation($"UserPreferences saved: {UserPreferences.ToString()}");
    }

    private async GDTask<T> LoadOrCreateAsync<T>(
        string fileName,
        Func<T> createDefault,
        string slotId,
        string label
    ) where T : ISavableModel
    {
        var filePath = GetSlotPath(fileName);

        if (!File.Exists(filePath))
        {
            Logger.ZLogInformation($"{label} file not found for slot {slotId}. Create one.");
            var defaultValue = createDefault();
            await saveSystem.SaveAsync(filePath, defaultValue);
            return defaultValue;
        }

        var model = await saveSystem.LoadAsync<T>(filePath);
        if (model == null)
        {
            Logger.ZLogWarning($"{label} file found for slot {slotId} but it's null.");
            return createDefault();
        }

        Logger.ZLogInformation($"{label} file found for slot {slotId}.");
        return model;
    }
    
    private string GetSlotPath(string fileName) 
    {
        if (!fileName.EndsWith(FileExtension, StringComparison.OrdinalIgnoreCase))
        {
            fileName += FileExtension;
        }
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
    }

    private string GetGameSaveFileName(string slotId) => $"{slotId}.{GameSaveFilePrefix}";

    public void ApplyUserPreferences()
    {
        AudioServer.SetBusVolumeDb(0, Mathf.LinearToDb(UserPreferences.MasterVolume));
        AudioServer.SetBusVolumeDb(1, Mathf.LinearToDb(UserPreferences.SoundVolume));
        AudioServer.SetBusVolumeDb(2, Mathf.LinearToDb(UserPreferences.MusicVolume));

        if (DisplayServer.WindowGetMode() != UserPreferences.GetWindowMode())
            DisplayServer.WindowSetMode(UserPreferences.GetWindowMode());

        if (DisplayServer.WindowGetVsyncMode() != UserPreferences.GetVSyncMode())
            DisplayServer.WindowSetVsyncMode(UserPreferences.GetVSyncMode());

        if (DisplayServer.WindowGetSize() != UserPreferences.Resolution)
            DisplayServer.WindowSetSize(UserPreferences.Resolution);

        var locale = Utils.GetLanguageLocaleCode(UserPreferences.Language);
        if (TranslationServer.GetLocale() != locale)
            TranslationServer.SetLocale(locale);
    }
}