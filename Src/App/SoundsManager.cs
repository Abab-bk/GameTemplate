using System;
using Godot;
using ZeroLog;

namespace Game.App;

public partial class SoundsManager : Node
{
    private static readonly Log Logger = LogManager.GetLogger<SoundsManager>();

    public static SoundsManager Instance { get; private set; } = default!;

    private AudioStreamPlayer UiSoundPlayer { get; set; } = default!;

    public override void _Ready()
    {
        if (Instance != null) throw new Exception("SoundsManager already exists");
        Instance = this;

        UiSoundPlayer = new AudioStreamPlayer()
        {
            Bus = "Sound"
        };
        AddChild(UiSoundPlayer);
    }

    public void PlayUiSound(string soundName)
    {
        UiSoundPlayer.Stream = ResourceLoader.Load<AudioStream>
            ($"res://Assets/Audios/UiSounds/{soundName}.ogg");
        UiSoundPlayer.Play();
        Logger.Info($"Playing {soundName}");
    }
}