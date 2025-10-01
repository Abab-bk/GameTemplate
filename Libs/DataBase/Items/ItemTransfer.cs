namespace DataBase.Items;

public static class ItemTransfer
{
    public static void Transfer(IItemContainer from, IItemContainer to, Item item)
    {
        if (!from.HasItem(item)) return;
        if (!to.CanAddItem(item)) return;
        if (!from.RemoveItem(item)) return;
        to.AddItem(item);
    }
}