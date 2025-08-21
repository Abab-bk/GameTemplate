using Godot;

namespace Game.Extensions;

public static class Sprite2DExtension
{
    public static Sprite2D RSetTexture(this Sprite2D sprite, Texture2D texture)
    {
        sprite.Texture = texture;
        return sprite;
    }
}