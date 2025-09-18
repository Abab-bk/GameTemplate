using System.Collections.Generic;
using Game.Persistent;
using Game.Ui;

namespace Game.App;

public static class Global
{
    public static readonly List<string> Flags = [];
    public static LaunchConfig LaunchConfig { get; set; } = null!;

    public static World World { get; set; } = null!;
    public static Application Application { get; set; } = null!;
    public static GameManager Game { get; set; } = null!;
    public static SaveManager SaveManager { get; set; } = null!;
    public static SoundsManager SoundsManager { get; set; } = null!;
    public static Hud Hud { get; set; } = null!;

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