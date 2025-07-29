using Godot;
using System;
using Game.Items;

namespace Game.UI;

[SceneTree]
public partial class ItemCellUi : PanelContainer
{
    public Item Item { get; private set; } = default!;
    
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
    private void Init(Item item)
    {
        Item = item;
        UpdateUi();
    }

    private void UpdateUi()
    {
        Icon.Texture = GD.Load<Texture2D>(Item.GetIconPath());
        CountLabel.Text = Item.Count.ToString();
    }
}
