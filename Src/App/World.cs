using AcidWallStudio;
using Game.Commons;
using Game.Ui;
using GDPanelFramework;
using Godot;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Game.App;

[SceneTree]
public partial class World : Node2D
{
    private readonly ILogger<World> _logger = LogManager.GetLogger<World>();
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
        
        _logger.ZLogInformation($"Ready");
    }
    
    public void Destroy()
    {
        _logger.ZLogInformation($"Destroy");
        QueueFree();
    }
}