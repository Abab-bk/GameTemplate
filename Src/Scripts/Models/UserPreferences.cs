using System;
using Game.Scripts.Enums;
using Godot;
using MemoryPack;

namespace Game.Scripts.Models;

[MemoryPackable]
public partial class UserPreferences : ISavableModel
{
    public event Action TryApplyChanged;

    public Language Language { get; set; } = OS.GetLocaleLanguage() switch
    {
        "en" => Language.English,
        "zh" => Language.Chinese,
        "ja" => Language.Japanese,
        _ => Language.Chinese
    };

    public float MasterVolume { get; set; } = 0.8f;
    public float MusicVolume { get; set; } = 0.8f;
    public float SoundVolume { get; set; } = 0.8f;
    
    public bool Fullscreen { get; set; }
    public bool VSync { get; set; }
    public Vector2I Resolution { get; set; } = new (1280, 720);

    public void Apply()
    {
        TryApplyChanged?.Invoke();
    }
    
    public DisplayServer.VSyncMode GetVSyncMode() =>
        VSync ? DisplayServer.VSyncMode.Enabled : DisplayServer.VSyncMode.Disabled;

    public DisplayServer.WindowMode GetWindowMode() =>
        Fullscreen ? DisplayServer.WindowMode.Fullscreen : DisplayServer.WindowMode.Windowed;
    
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