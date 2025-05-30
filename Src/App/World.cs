using AcidWallStudio;
using Game.Scripts;
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
        _logger.ZLogInformation($"Ready");
    }
    
    public void Destroy()
    {
        Global.World = null;
        _logger.ZLogInformation($"Destroy");
        QueueFree();
    }
}