using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Game.Scripts;

public static class Global
{
    public static readonly List<string> Flags = new();
    public static World World { get; set; }
    public static Application Application { get; set; }
    
    public static ILogger Logger { get; set; }

    private static AppSaver _appSaver;
    
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