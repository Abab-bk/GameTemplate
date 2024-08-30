using Game.Scripts.Classes;
using Godot;

namespace cfg;

public static class ExternalTypeUtil
{
    public static Godot.Vector2 NewVector2(cfg.Vector2 v) => new Godot.Vector2(v.X, v.Y);
}