using Game.Scripts;
using GDPanelFramework.Panels;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class PauseMenu : UIPanel
{
    public override void _Ready()
    {
        Global.TryPause();
        
        ResumeBtn.Pressed += Destroy;
        SettingsBtn.Pressed += () =>
        {
            // UiSystem.Open_Settings();
        };
        BackToStartMenuBtn.Pressed += () =>
        {
            Destroy();
            EventBus.RequestBackToStartMenu.Invoke();
        };
        ExitBtn.Pressed += () =>
        {
            EventBus.RequestQuitGame.Invoke();
        };
    }

    public void Destroy()
    {
        Global.TryResume();
        QueueFree();
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        if (!@event.IsActionPressed("Pause")) return;
        if (!Global.IsPaused) return;
        Destroy();
    }

    protected override void _OnPanelOpen()
    {
    }
}
