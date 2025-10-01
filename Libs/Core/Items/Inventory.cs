namespace Core.Items;

public class Inventory : IItemContainer
{
    private List<Item> Items { get; set; } = [];

    public event Action? OnItemsChanged;

    public bool AddItem(Item item)
    {
        var existingItem = Items.Find(i => i.Template == item.Template);

        if (existingItem != null)
        {
            var availableSpace = existingItem.Template.MaxStack - existingItem.Count;

            if (item.Count <= availableSpace)
            {
                existingItem.Count += item.Count;
                OnItemsChanged?.Invoke();
                return true;
            }

            existingItem.Count = existingItem.Template.MaxStack;

            var remainingCount = item.Count - availableSpace;
            if (remainingCount <= 0)
            {
                OnItemsChanged?.Invoke();
                return true;
            }

            var newItemStack = new Item
            {
                Template = item.Template,
                Count = remainingCount
            };
            Items.Add(newItemStack);

            OnItemsChanged?.Invoke();
            return true;
        }

        Items.Add(item);
        OnItemsChanged?.Invoke();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        var existingItem = Items.Find(i => i.Template == item.Template);
        if (existingItem == null) return false;

        if (existingItem.Count - item.Count < 0)
        {
            Items.Remove(existingItem);
            OnItemsChanged?.Invoke();
            return true;
        }

        existingItem.Count -= item.Count;
        if (existingItem.Count == 0) Items.Remove(existingItem);
        OnItemsChanged?.Invoke();
        return true;
    }

    public bool CanAddItem(Item item)
    {
        return true;
    }

    public bool HasItem(Item item)
    {
        return Items.Any(i => i.Template == item.Template);
    }

    public IEnumerable<Item> GetItems()
    {
        return Items;
    }
}