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
            var itemUi = ItemCellUi.Instantiate(item);
            Items.AddChild(itemUi);
        }
    }
}
