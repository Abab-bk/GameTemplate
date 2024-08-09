using Godot;

namespace AcidUtilities;

public static class ControlExtension
{
    public static Control RSetGlobalPosition(this Control node, Vector2 position)
    {
        node.GlobalPosition = position;
        return node;
    }
}