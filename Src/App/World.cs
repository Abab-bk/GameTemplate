using AcidWallStudio;
using Game.Ui;
using GDPanelFramework;
using Godot;
using ZeroLog;

namespace Game.App;

[SceneTree]
public partial class World : Node2D
{
    private static readonly Log Logger = LogManager.GetLogger<World>();

    private PackedScene HudScene { get; set; } =
        Wizard.LoadPackedScene(Hud.TscnFilePath);

    public override void _Ready()
    {
        Global.World = this;
        HudScene.CreatePanel<Hud>().OpenPanel();

#if IMGUI
        AddChild(new Debugger());
#endif

        Global.Game = new GameManager();
        Global.Game.NewGame();

        Logger.Info("Ready");
    }

    public void Destroy()
    {
        Logger.Info("Destroy");
        QueueFree();
    }
}