using System;
using Game.Commons;
using Godot;
using MemoryPack;

namespace Game.Persistent.Models;

[MemoryPackable]
public partial class UserPreferences : ISavableModel
{
    public event Action TryApplyChanged = delegate { };

    public Language Language { get; set; } = Language.English;

    public float MasterVolume { get; set; } = 0.8f;
    public float MusicVolume { get; set; } = 0.8f;
    public float SoundVolume { get; set; } = 0.8f;

    public bool Fullscreen { get; set; }
    public bool VSync { get; set; }
    public Vector2I Resolution { get; set; } = new(1280, 720);

    public void Apply()
    {
        TryApplyChanged?.Invoke();
    }

    public DisplayServer.VSyncMode GetVSyncMode()
    {
        return VSync ? DisplayServer.VSyncMode.Enabled : DisplayServer.VSyncMode.Disabled;
    }

    public DisplayServer.WindowMode GetWindowMode()
    {
        return Fullscreen ? DisplayServer.WindowMode.Fullscreen : DisplayServer.WindowMode.Windowed;
    }

    public override string ToString()
    {
        return $"""
                Language: {Language},
                MasterVolume: {MasterVolume},
                MusicVolume: {MusicVolume},
                SoundVolume: {SoundVolume},
                Fullscreen: {Fullscreen},
                VSync: {VSync},
                Resolution: {Resolution}
                """;
    }
}