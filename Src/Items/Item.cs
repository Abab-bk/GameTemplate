using cfg.Items;
using Godot;

namespace Game.Items;

public class Item
{
    public required ItemTemplate Template { get; set; }

    public string GetIconPath()
    {
        return "res://icon.svg";
    }

    public Control MakePreview()
    {
        var texture = GD.Load<Texture2D>(GetIconPath());
        return new TextureRect { Texture = texture };
    }

    public int Count { get; set; }
}