using System.Collections.Generic;
using Game.Events;
using Game.Ui;

namespace Game.App;

public static class Global
{
    public static readonly List<string> Flags = new();
    public static World World { get; set; } = default!;
    public static Application Application { get; set; } = default!;
    public static GameManager Game { get; set; } = default!;
    public static Hud Hud { get; set; } = default!;
    public static EventBus EventBus { get; } = new EventBus();

    private static int _pauseCount;
    public static bool IsPaused => _pauseCount > 0;

    public static void TryPause()
    {
        _pauseCount++;
        Application.GetTree().Paused = _pauseCount > 0;
    }

    public static void TryResume()
    {
        _pauseCount--;
        Application.GetTree().Paused = _pauseCount > 0;
    }
}