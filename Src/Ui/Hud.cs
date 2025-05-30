using AcidWallStudio;
using Game.Scripts;
using GDPanelFramework;
using GDPanelFramework.Panels;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class Hud : UIPanel
{
    private PackedScene PauseMenuScene { get; set; } = Wizard
        .LoadPackedScene(PauseMenu.TscnFilePath);

    protected override void _OnPanelInitialize()
    {
        base._OnPanelInitialize();
        EventBus.RequestBackToStartMenu += ClosePanel;
    }

    public override void _Input(InputEvent @event)
    {
        if (!@event.IsActionPressed("Pause")) return;
        if (!Global.IsPaused) PauseMenuScene.CreatePanel<PauseMenu>().OpenPanel();
    }

    protected override void _OnPanelOpen()
    {
    }
}
