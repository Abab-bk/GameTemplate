namespace cfg;

public static class ExternalTypeUtil
{
    public static Godot.Vector2 NewVector2(Vector2 v)
    {
        return new Godot.Vector2(v.X, v.Y);
    }
}