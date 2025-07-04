using System.Collections.Generic;
using Game.Scripts;

namespace Game.App;

public static class Global
{
    public static readonly List<string> Flags = new();
    public static App.World? World { get; set; } = default!;
    public static App.Application Application { get; set; } = default!;
    
    private static int _pauseCount;
    public static bool IsPaused => _pauseCount > 0;
    
    public static void TryPause()
    {
        _pauseCount++;
        EventBus.PauseCountChanged.Invoke(_pauseCount);
        Application.GetTree().Paused = _pauseCount > 0;
    }
    
    public static void TryResume()
    {
        _pauseCount--;
        EventBus.PauseCountChanged.Invoke(_pauseCount);
        Application.GetTree().Paused = _pauseCount > 0;
    }
}