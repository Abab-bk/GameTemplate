using DataBase.Items;
using Godot;

namespace Game.Items;

public static class ItemExtensions
{
    public static Control MakePreview(this Item item)
    {
        var texture = GD.Load<Texture2D>(item.GetIconPath());
        return new TextureRect { Texture = texture };
    }
    
    public static string GetIconPath(this Item item)
    {
        return "res://icon.svg";
    }
}