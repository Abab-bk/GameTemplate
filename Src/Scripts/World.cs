using Godot;

namespace Game.Scripts;

public partial class World : Node2D
{
    public override void _Ready()
    {
        Global.World = this;
        Logger.Log("[World] Ready");
    }
}