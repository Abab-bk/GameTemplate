using System;
using System.IO;
using Game.Scripts.Models;
using MemoryPack;

namespace Game.Scripts;

public class AppSaver
{
    public string UserPreferencesPath { get; set; } = "UserPreferences.bin";
    
    public UserPreferences UserPreferences { get; private set; }

    public void Save()
    {
        Logger.Log("[AppSaver]: Saving UserPreferences...");
        SaveUserPreferences();
    }

    public void Load()
    {
        Logger.Log("[AppSaver]: Loading UserPreferences...");
        LoadUserPreferences();
    }

    private void SaveUserPreferences()
    {
        try
        {
            var bin = MemoryPackSerializer.Serialize(UserPreferences);
            File.WriteAllBytes(UserPreferencesPath, bin);
            Logger.Log($"[AppSaver]: Save UserPreferences ok. {UserPreferences}");
        }
        catch (Exception e)
        {
            Logger.LogError($"[AppSaver Error]: {e}");
            throw;
        }
    }
    
    private void LoadUserPreferences()
    {
        try
        {
            if (File.Exists(UserPreferencesPath))
            {
                var data = File.ReadAllBytes(UserPreferencesPath);
                UserPreferences = MemoryPackSerializer.Deserialize<UserPreferences>(data);
                
                Logger.Log($"[AppSaver]: Load UserPreferences ok. {UserPreferences}");
                
                return;
            }
            UserPreferences = new UserPreferences();
            Logger.Log("[AppSaver]: UserPreferences not exists. Create new one.");
        }
        catch (Exception e)
        {
            UserPreferences = new UserPreferences();
            Logger.LogError($"[AppSaver Error]: {e}");
            throw;
        }
    }
}