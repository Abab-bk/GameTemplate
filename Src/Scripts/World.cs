using DsUi;
using Godot;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Game.Scripts;

public partial class World : Node2D
{
    private ILogger<World> _logger;
    
    public override void _Ready()
    {
        Global.World = this;
        UiManager.Open_Hud();
        _logger = LogManager.GetLogger<World>();
        
        var saveData = Global.AppSaver.GameSave;
        
        _logger.ZLogInformation($"Ready");
    }
    
    public void Destroy()
    {
        Global.World = null;
        UiManager.Destroy_Hud();
        
        Global.AppSaver.UnloadGameSave();
        _logger.ZLogInformation($"Destroy");
        QueueFree();
    }
}