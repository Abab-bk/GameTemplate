using Game.Scripts.Enums;
using Godot;
using MemoryPack;

namespace Game.Scripts.Models;

[MemoryPackable]
public partial class UserPreferences : ISavableModel
{
    public Language Language { get; set; } = Language.English;

    public float MasterVolume { get; set; } = 0.8f;
    public float MusicVolume { get; set; } = 0.8f;
    public float SoundVolume { get; set; } = 0.8f;
    
    public bool Fullscreen { get; set; }
    public bool VSync { get; set; }
    public Vector2I Resolution { get; set; } = new (1280, 720);

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