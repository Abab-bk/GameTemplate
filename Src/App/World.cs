using Game.Extensions;
using Game.Ui;
using GDPanelFramework;
using Godot;
using ZeroLog;

namespace Game.App;

[SceneTree]
public partial class World : Node2D
{
    private static readonly Log Logger = LogManager.GetLogger<World>();
    private PackedScene HudScene { get; set; } = Wizard.LoadPackedScene(Hud.TscnFilePath);

    public override void _Ready()
    {
#if IMGUI
        AddChild(new Debugger());
#endif

        var gameManager = new GameManager();
        Locator.Register(gameManager);
        gameManager.NewGame();

        HudScene.CreatePanel<Hud>().OpenPanel();

        Logger.Info("Ready");
    }

    public void Destroy()
    {
        Logger.Info("Destroy");
        QueueFree();
    }
}