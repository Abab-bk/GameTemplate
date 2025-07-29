using Godot;

namespace Game.Ui;

[SceneTree]
public partial class CreditItem : VBoxContainer
{
    public CreditItem Config(string key, string[] data)
    {
        Title.Text = key;
        Text.Text = string.Join("\n", data);
        return this;
    }
}