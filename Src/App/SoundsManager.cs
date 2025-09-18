using Godot;
using ZeroLog;

namespace Game.App;

public partial class SoundsManager : Node
{
    private static readonly Log Logger = LogManager.GetLogger<SoundsManager>();

    private AudioStreamPlayer UiSoundPlayer { get; set; } = null!;

    public override void _Ready()
    {
        if (Locator.TryGet<SoundsManager>(out _))
        {
            Logger.Error("SoundsManager already exists.");
            QueueFree();
            return;
        }

        Locator.Register(this);
        UiSoundPlayer = new AudioStreamPlayer
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