using Godot;

namespace Game.Extensions;

public static class Vector2Extension
{
    public static Vector2 ReverseVectorX(this Vector2 vector)
    {
        return new Vector2(-vector.X, vector.Y);
    }

    public static Vector2 ReverseVectorY(this Vector2 vector)
    {
        return new Vector2(vector.X, -vector.Y);
    }
    
    public static Vector2 Reverse(this Vector2 vector)
    {
        return new Vector2(-vector.X, -vector.Y);
    }
}