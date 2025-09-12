using System;
using Game.Commons;
using Godot;
using MessagePack;

namespace Game.Persistent.Models;

[MessagePackObject(true)]
public class UserPreferences : ISavableModel
{
    public event Action? OnTryApplyChanged;

    public Language Language { get; set; } = Language.English;

    public float MasterVolume { get; set; } = 0.8f;
    public float MusicVolume { get; set; } = 0.8f;
    public float SoundVolume { get; set; } = 0.8f;

    public bool Fullscreen { get; set; }
    public bool VSync { get; set; }
    public int ResolutionX { get; set; } = 1280;
    public int ResolutionY { get; set; } = 720;

    [IgnoreMember]
    public Vector2I Resolution
    {
        get => new(ResolutionX, ResolutionY);
        set
        {
            ResolutionX = value.X;
            ResolutionY = value.Y;
        }
    }

    public void Apply()
    {
        OnTryApplyChanged?.Invoke();
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