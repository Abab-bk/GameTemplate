namespace Core.Items;

public class Item
{
    public required Tables.ItemTemplate Template { get; init; }
    public int Count { get; set; }
}