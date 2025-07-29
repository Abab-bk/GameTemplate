using AcidUtilities;
using Godot;
using Game.Items;

namespace Game.UI;

[SceneTree]
public partial class InventoryUi : PanelContainer
{
    public Inventory Inventory { get; private set; } = default!;
    
    public void SetInventory(Inventory inventory)
    {
        Inventory = inventory;
        Inventory.OnItemsChanged += UpdateUi;
        UpdateUi();
    }

    private void UpdateUi()
    {
        Items.RemoveAllChildren();

        foreach (var item in Inventory.GetItems())
        {
            var itemUi = ItemCellUi.Instantiate(item, Inventory);
            Items.AddChild(itemUi);
        }
    }

    public override bool _CanDropData(Vector2 atPosition, Variant data)
    {
        return (GodotObject)data is ItemWrapper itemWrapper && Inventory.CanAddItem(itemWrapper.Item);
    }

    public override void _DropData(Vector2 atPosition, Variant data)
    {
        if ((GodotObject)data is not ItemWrapper itemWrapper) return;
        ItemTransfer.Transfer(itemWrapper.Source, Inventory, itemWrapper.Item);
    }
}
