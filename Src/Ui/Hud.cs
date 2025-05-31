using Game.Scripts;
using GDPanelFramework.Panels;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class Hud : UIPanel
{
    protected override void _OnPanelInitialize()
    {
        base._OnPanelInitialize();
        EventBus.RequestBackToStartMenu += ClosePanel;
        PauseMenu.Visible = false;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);
        if (!@event.IsActionPressed("Pause")) return;
        PauseMenu.Visible = !PauseMenu.Visible;
    }

    protected override void _OnPanelOpen()
    {
    }

    protected override void _OnPanelClose()
    {
        base._OnPanelClose();
        QueueFree();
    }
}
