namespace Core.Items;

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

    public bool CanAddItem(Item item)
    {
        return Item == null && AllowedItemType.HasFlag(item.Template.ItemType);
    }

    public bool HasItem(Item item)
    {
        return Item?.Template == item.Template;
    }

    public IEnumerable<Item> GetItems()
    {
        return Item == null ? [] : [Item];
    }
}