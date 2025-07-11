using AcidWallStudio;
using Game.App;
using Game.Commons;
using GDPanelFramework;
using GDPanelFramework.Panels;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class Hud : UIPanel
{
    protected override void _OnPanelInitialize()
    {
        base._OnPanelInitialize();
        RegisterInput(
            Inputs.Pause,
            __ =>
            {
                Wizard.LoadPackedScene("res://Ui/PauseMenu.tscn")
                    .CreatePanel<PauseMenu>()
                    .OpenPanel();
            }
        );
    }
    
    public void Close() => ClosePanel();

    protected override void _OnPanelOpen()
    {
        Global.Hud = this;
    }

    protected override void _OnPanelClose()
    {
        base._OnPanelClose();
        QueueFree();
    }
}
