using cfg.Items;

namespace Game.Items;

public class Item
{
    public required ItemTemplate Template { get; set; }

    public string GetIconPath()
    {
        return "res://icon.svg";
    }

    public int Count { get; set; }
}