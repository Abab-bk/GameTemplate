using System;
using System.Collections.Generic;
using cfg.Items;

namespace Game.Items;

public class ItemSlot : IItemContainer
{
    private Item? Item { get; set; }
    
    public required ItemType AllowedItemType { get; set; }
    
    public event Action? OnItemsChanged;
    
    public bool AddItem(Item item)
    {
        if (!CanAddItem(item)) return false;
        
        Item = item;
        OnItemsChanged?.Invoke();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (!HasItem(item)) return false;
        
        Item = null;
        OnItemsChanged?.Invoke();
        return true;
    }

    public bool CanAddItem(Item item) => Item == null && AllowedItemType.HasFlag(item.Template.ItemType);

    public bool HasItem(Item item) => Item?.Template == item.Template;

    public IEnumerable<Item> GetItems() => Item == null ? [] : [Item];
}