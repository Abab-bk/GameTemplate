using Godot;

namespace AcidUtilities;

public static class Vector2Extension
{
    public static Vector2 ToCanvasPos(this Vector2 position, Node node) => node
        .GetViewport()
        .GetCanvasTransform()
        .AffineInverse()
        .BasisXform(position);
}