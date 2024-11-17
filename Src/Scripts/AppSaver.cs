using System;
using System.IO;
using Game.Scripts.Models;
using MemoryPack;

namespace Game.Scripts;

public class AppSaver
{
    public string UserPreferencesPath { get; set; } = "UserPreferences.bin";
    public string GameSavePath { get; set; } = "GameSave.bin";
    
    public UserPreferences UserPreferences { get; private set; }
    public GameSave GameSave { get; private set; }

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
    
    private void SaveItem(ISavableModel saveModel, string savePath, string logName)
    {
        try
        {
            Logger.Log($"[AppSaver]: Saving {logName}...");
            var bin = MemoryPackSerializer.Serialize(saveModel);
            File.WriteAllBytes(savePath, bin);
            Logger.Log($"[AppSaver]: Save {logName} ok. {saveModel}");
        }
        catch (Exception e)
        {
            Logger.LogError($"[AppSaver Error]: {e} while saving {logName}");
            throw;
        }
    }
    private void LoadItem<T>(string savePath, string logName) where T : ISavableModel, new()
    {
        try
        {
            if (File.Exists(savePath))
            {
                Logger.Log($"[AppSaver]: Loading {logName}...");
                var data = File.ReadAllBytes(savePath);
                var saveModel = MemoryPackSerializer.Deserialize<T>(data);
                Logger.Log($"[AppSaver]: Load {logName} ok. {saveModel}");
                return;
            }
            Logger.Log($"[AppSaver]: {logName} not exists. Create new one.");
        }
        catch (Exception e)
        {
            Logger.LogError($"[AppSaver Error]: {e} while loading {logName}");
            throw;
        }
    }
    
    public void SaveGameSave()
    {
        SaveItem(GameSave, GameSavePath, "GameSave");
    }
    
    private void LoadGameSave()
    {
        LoadItem<GameSave>(GameSavePath, "GameSave");
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
        LoadItem<UserPreferences>(UserPreferencesPath, "UserPreferences");
    }
}