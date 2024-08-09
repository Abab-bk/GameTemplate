using Godot;

namespace AcidUtilities;

public static class Node2DExtension
{
    public static T RSetGlobalPosition<T>(this T node, Vector2 position) where T : Node2D
    {
        node.GlobalPosition = position;
        return node;
    }

    public static Vector2 GetCanvasPosition(this Node2D node2D) => node2D.GetGlobalTransformWithCanvas().Origin;
}