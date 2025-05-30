using System;
using System.Buffers;
using System.IO;
using Game.Scripts.Models;
using MemoryPack;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Game.Scripts;

public class AppSaver
{
    public string UserPreferencesPath { get; set; } = "UserPreferences.bin";
    public string GameSavePath { get; set; } = "GameSave.bin";
    
    public UserPreferences UserPreferences { get; private set; }
    public GameSave GameSave { get; private set; }

    private ILogger<AppSaver> _logger = LogManager.GetLogger<AppSaver>();
    
    public void Save()
    {
        SaveUserPreferences();
        SaveGameSave();
    }

    public void Load()
    {
        LoadUserPreferences();
        LoadGameSave();
    }
    
    private void SaveItem<T>(T saveModel, string savePath, string logName) where T : ISavableModel
    {
        try
        {
            _logger.ZLogInformation($"Saving {logName}...");
            
            var writer = new ArrayBufferWriter<byte>();
            MemoryPackSerializer.Serialize(in writer, in saveModel);
            File.WriteAllBytes(savePath, writer.WrittenMemory.ToArray());
            _logger.ZLogInformation($"Save {logName} ok. Model: {saveModel}");
        }
        catch (Exception e)
        {
            _logger.ZLogError($"{e} while saving {logName}");
            throw;
        }
    }
    private T LoadItem<T>(string savePath, string logName) where T : ISavableModel, new()
    {
        try
        {
            if (File.Exists(savePath))
            {
                _logger.ZLogInformation($"Loading {logName}...");
                var data = File.ReadAllBytes(savePath);
                var saveModel = MemoryPackSerializer.Deserialize<T>(data);
                _logger.ZLogInformation($"Load {logName} ok. {saveModel}");
                return saveModel;
            }
            _logger.ZLogInformation($"{logName} not exists. Create new one.");
            return new T();
        }
        catch (Exception e)
        {
            _logger.ZLogError($"{e} while loading {logName}");
            throw;
        }
    }
    
    public void SaveGameSave()
    {
        SaveItem(GameSave, GameSavePath, "GameSave");
    }
    
    private void LoadGameSave()
    {
        GameSave = LoadItem<GameSave>(GameSavePath, "GameSave");
        GameSave.TryApplyChanged += () =>
        {
            // TODO: Apply GameSave
        };
    }
    
    public void UnloadGameSave()
    {
        GameSave = null;
    }
    
    private void SaveUserPreferences()
    {
        SaveItem(UserPreferences, UserPreferencesPath, "UserPreferences");
    }
    
    private void LoadUserPreferences()
    {
        UserPreferences = LoadItem<UserPreferences>(UserPreferencesPath, "UserPreferences");
        UserPreferences.TryApplyChanged += () =>
        {
            Global.Application.ApplyUserPreferences(UserPreferences);
        };
        Global.Application.ApplyUserPreferences(UserPreferences);
    }
}