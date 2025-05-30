using System.Collections.Generic;

namespace Game.Scripts;

public static class Global
{
    public static readonly List<string> Flags = new();
    public static App.World? World { get; set; } = default!;
    public static App.Application Application { get; set; } = default!;
    
    private static AppSaver _appSaver = default!;
    public static AppSaver AppSaver {
        get => _appSaver; 
        set
        {
            _appSaver = value;
            EventBus.RequestSaveAppSaver += _appSaver.Save;
            EventBus.RequestSaveGameSave += _appSaver.SaveGameSave;
        }
    }

    private static int _pauseCount;
    public static bool IsPaused => _pauseCount > 0;
    
    public static void TryPause()
    {
        _pauseCount++;
        EventBus.PauseCountChanged?.Invoke(_pauseCount);
        Application.GetTree().Paused = _pauseCount > 0;
    }
    
    public static void TryResume()
    {
        _pauseCount--;
        EventBus.PauseCountChanged?.Invoke(_pauseCount);
        Application.GetTree().Paused = _pauseCount > 0;
    }
}