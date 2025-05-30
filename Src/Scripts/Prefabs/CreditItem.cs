using Godot;

namespace Game.Scripts.Prefabs;

public partial class CreditItem : VBoxContainer
{
    [Export] private Label _title;
    [Export] private Label _text;
    
    public CreditItem Config(string key, string[] data)
    {
        _title.Text = key;
        _text.Text = string.Join("\n", data);
        return this;
    }
    
    public static CreditItem Create() =>
        GD.Load<PackedScene>("res://Scenes/Prefabs/CreditItem.tscn").Instantiate<CreditItem>();
}
