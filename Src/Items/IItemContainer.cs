using System;
using System.Collections.Generic;

namespace Game.Items;

public interface IItemContainer
{
    public event Action OnItemsChanged;
    public bool AddItem(Item item);
    public bool RemoveItem(Item item);
    public bool CanAddItem(Item item);
    public bool HasItem(Item item);
    public IEnumerable<Item> GetItems();
}