using Godot;
using System;
using DataBase.Items;
using Game.Items;

namespace Game.UI;

[SceneTree]
public partial class ItemCellUi : PanelContainer
{
    public Item Item { get; private set; } = default!;
    public IItemContainer ItemContainer { get; private set; } = default!;

    private event Action OnClick = delegate { };

    public override void _Ready()
    {
        base._Ready();

        Button.Pressed += OnClick.Invoke;

        UpdateUi();
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        Button.Pressed -= OnClick.Invoke;
    }

    [OnInstantiate]
    private void Init(Item item, IItemContainer itemContainer)
    {
        Item = item;
        ItemContainer = itemContainer;
        UpdateUi();
    }

    private void UpdateUi()
    {
        Icon.Texture = GD.Load<Texture2D>(Item.GetIconPath());
        CountLabel.Text = Item.Count.ToString();
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
        SetDragPreview(Item.MakePreview());
        return new ItemWrapper
        {
            Item = Item,
            Source = ItemContainer
        };
    }
}