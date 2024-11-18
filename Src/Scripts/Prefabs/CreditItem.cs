using Godot;
using OnReadyCs;

namespace Game.Scripts.Prefabs;

public partial class CreditItem : VBoxContainer
{
    [OnReady("Title")] private Label _title;
    [OnReady("Text")] private Label _text;

    public override void _Ready()
    {
        this.InitializeOnReadyFields();
    }

    public CreditItem Config(string key, string[] data)
    {
        _title.Text = key;
        _text.Text = string.Join("\n", data);
        return this;
    }
    
    public static CreditItem Create() =>
        GD.Load<PackedScene>("res://Scenes/Prefabs/CreditItem.tscn").Instantiate<CreditItem>();
}
