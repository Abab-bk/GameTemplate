using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Game.App;
using Game.Commons;
using Game.Persistent.Models;
using Godot;
using GodotTask;
using ZeroLog;

namespace Game.Persistent;

public partial class SaveManager(
    string saveFolderPath,
    ISaveSystem saveSystem
) : Node
{
    private const string FileExtension = ".bin";
    private const string UserPreferencesFileName = "UserPreferences";
    private const string GameSaveFilePrefix = "GameSave";

    public event Action? OnSaveGameSave;
    public event Action? OnSaveGameSaveFinished;

    private static Log Logger { get; } = LogManager.GetLogger<SaveManager>();
    public GameSave CurrentSave { get; private set; } = null!;
    public UserPreferences UserPreferences { get; private set; } = null!;

    private const float MinSaveIntervalSeconds = 5f;
    private DateTime LastSaveTime { get; set; } = DateTime.MinValue;

    public override void _Ready()
    {
        base._Ready();
        if (!Locator.TryGet<SaveManager>(out _))
        {
            Locator.Register(this);
            return;
        }

        Logger.Error("SaveManager already exists.");
        QueueFree();
    }

    public async GDTask LoadUserPreferencesAsync()
    {
        UserPreferences = await LoadOrCreateAsync(
            UserPreferencesFileName,
            () => new UserPreferences(),
            "Flower",
            "UserPreferences"
        );
        Logger.Info($"UserPreferences loaded: {UserPreferences.ToString()}");
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
            Logger.Info("Save skipped: not enough time has passed since last save.");
            return;
        }

        LastSaveTime = DateTime.UtcNow;
        SaveGameSaveAsync("Flower").Forget();
    }

    public async GDTask SaveCurrentGameSaveAsync()
    {
        if ((DateTime.UtcNow - LastSaveTime).TotalSeconds < MinSaveIntervalSeconds)
        {
            Logger.Info("Save skipped: not enough time has passed since last save.");
            return;
        }

        LastSaveTime = DateTime.UtcNow;
        await SaveGameSaveAsync("Flower");
    }

    public async GDTask SaveGameSaveAsync(string slotId)
    {
        OnSaveGameSave?.Invoke();
        await saveSystem.SaveAsync(GetSlotPath(GetGameSaveFileName(slotId)), CurrentSave);
        OnSaveGameSaveFinished?.Invoke();
        Logger.Info("GameSave saved.");
    }

    public async GDTask SaveUserPreferences()
    {
        await saveSystem.SaveAsync(GetSlotPath(UserPreferencesFileName), UserPreferences);
        ApplyUserPreferences();
        Logger.Info($"UserPreferences saved: {UserPreferences.ToString()}");
    }

    private async GDTask<T> LoadOrCreateAsync<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
        T>
    (
        string fileName,
        Func<T> createDefault,
        string slotId,
        string label
    ) where T : ISavableModel
    {
        var filePath = GetSlotPath(fileName);

        if (!File.Exists(filePath))
        {
            Logger.Info($"{label} file not found for slot {slotId} at {filePath}. Create one.");
            var defaultValue = createDefault();
            await saveSystem.SaveAsync(filePath, defaultValue);
            return defaultValue;
        }

        var model = await saveSystem.LoadAsync<T>(filePath);
        if (model == null)
        {
            Logger.Warn($"{label} file found for slot {slotId} but it's null.");
            return createDefault();
        }

        Logger.Info($"{label} file found for slot {slotId}.");
        return model;
    }

    private string GetSlotPath(string fileName)
    {
        if (!fileName.EndsWith(FileExtension, StringComparison.OrdinalIgnoreCase))
            fileName += FileExtension;

        var fullPath = Path.Combine(saveFolderPath, fileName);
        var directoryPath = Path.GetDirectoryName(fullPath)!;

        if (Directory.Exists(directoryPath)) return fullPath;

        Directory.CreateDirectory(directoryPath);
        Logger.Info($"Created save directory: {directoryPath}");

        return fullPath;
    }

    private string GetGameSaveFileName(string slotId)
    {
        return $"{slotId}.{GameSaveFilePrefix}";
    }

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