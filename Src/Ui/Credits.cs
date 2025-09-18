using System.Text.Json;
using Game.Commons;
using Game.Extensions;
using GDPanelFramework.Panels;
using Godot;
using GodotTask;

namespace Game.Ui;

[SceneTree]
public partial class Credits : UIPanel
{
    protected override void _OnPanelInitialize()
    {
        base._OnPanelInitialize();
        CancelBtn.Pressed += ClosePanel;
    }

    protected override void _OnPanelOpen()
    {
        var data = JsonSerializer.Deserialize(
            Wizard.ReadAllText("res://Assets/Credits.json"),
            MyJsonContext.Default.DictionaryStringStringArray
        );

        if (data != null)
            foreach (var keyPair in data)
            {
                var item = CreditItem.Instantiate(
                    keyPair.Key,
                    keyPair.Value
                    );
                Items.AddChild(item);
            }

        GDTask.Delay(2000).ContinueWith(() =>
        {
            var tween = CreateTween();
            tween.TweenProperty(
                ScrollContainer,
                "scroll_vertical",
                (int)ScrollContainer.GetVScrollBar().MaxValue,
                10
            );
            tween.Play();
        });
    }

    protected override void _OnPanelClose()
    {
        base._OnPanelClose();
        QueueFree();
    }
}