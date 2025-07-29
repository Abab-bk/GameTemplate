using Chickensoft.GameTools;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class LoadingScreen : Control
{
    private Loader? Loader { get; set; }

    private void FadeIn()
    {
        AnimationPlayer.Play("FadeIn");
    }

    private void FadeOut()
    {
        AnimationPlayer.PlayBackwards("FadeIn");
    }

    public void Init(Loader loader)
    {
        Loader = loader;
        Loader.Progress += f => { ProgressBar.Value = f * 100f; };
        Loader.Completed += QueueFree;
        Loader.Load();
    }

    public override void _Process(double delta)
    {
        if (Loader is { IsCompleted: false }) Loader.Update();
    }
}