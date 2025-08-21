using System.Collections.Generic;
using System.Text.Json;
using Game.Commons;
using Game.Extensions;
using GDPanelFramework.Panels;
using Godot;
using GodotTask;

namespace Game.Ui;

[SceneTree]
public partial class BootSplash : UIPanel
{
    public override void _Ready()
    {
        Play().Forget();
    }

    private async GDTask Play()
    {
        var data = JsonSerializer.Deserialize(
            Wizard.ReadAllText("res://Assets/BootSplash.json"),
            MyJsonContext.Default.DictionaryStringString
            );

        if (data != null)
            foreach (var (_, value) in data)
            {
                var icon = new TextureRect
                {
                    Texture = ResourceLoader.Load<Texture2D>(value),
                    ExpandMode = TextureRect.ExpandModeEnum.KeepSize,
                    StretchMode = TextureRect.StretchModeEnum.KeepAspectCentered,
                    Modulate = new Color("#ffffff00")
                };
                CenterContainer.AddChild(icon);

                var tween = CreateTween();
                tween.TweenProperty(icon, "modulate", Colors.White, 1f);
                tween.TweenInterval(1.0);
                tween.TweenProperty(icon, "modulate", new Color("#ffffff00"), 1f);
                tween.Play();

                await ToSignal(tween, Tween.SignalName.Finished);

                icon.QueueFree();
            }

        ClosePanel();
    }

    protected override void _OnPanelOpen()
    {
    }

    protected override void _OnPanelClose()
    {
        base._OnPanelClose();
        QueueFree();
    }
}