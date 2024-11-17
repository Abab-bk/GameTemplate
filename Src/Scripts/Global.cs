using System.Collections.Generic;

namespace Game.Scripts;

public static class Global
{
    public static List<string> Flags = new();
    public static World World { get; set; }
    public static Application Application { get; set; }

    private static AppSaver _appSaver;
    
    public static AppSaver AppSaver {
        get => _appSaver; 
        set
        {
            _appSaver = value;
            EventBus.RequestSaveAppSaver += _appSaver.Save;
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