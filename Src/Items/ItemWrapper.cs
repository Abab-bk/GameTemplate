using Godot;

namespace Game.Items;

public partial class ItemWrapper : RefCounted
{
    public required Item Item { get; set; }
    public required IItemContainer Source { get; set; }
}