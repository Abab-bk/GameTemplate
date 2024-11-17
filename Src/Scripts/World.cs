using DsUi;
using Godot;

namespace Game.Scripts;

public partial class World : Node2D
{
    public override void _Ready()
    {
        Global.World = this;
        UiManager.Open_Hud();

        var saveData = Global.AppSaver.GameSave;
        
        Logger.Log("[World] Ready");
    }
    
    public void Destroy()
    {
        Global.World = null;
        UiManager.Destroy_Hud();
        
        Global.AppSaver.UnloadGameSave();
        
        Logger.Log("[World] Destroy");
        QueueFree();
    }
}