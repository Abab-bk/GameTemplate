using System.Collections.Generic;
using System.Text.Json;
using AcidWallStudio;
using Godot;

namespace Game.Scripts.Ui.BootSplash;

public partial class BootSplashPanel : BootSplash
{
    public override void OnCreateUi()
    {
        Play();
    }

    private async void Play()
    {
        var data = JsonSerializer.Deserialize<Dictionary<string, string>>(
            Wizard.ReadAllText("res://Assets/BootSplash.json"));

        foreach (var (_, value) in data)
        {
            var icon = new TextureRect
            {
                Texture = ResourceLoader.Load<Texture2D>(value),
                ExpandMode = TextureRect.ExpandModeEnum.KeepSize,
                StretchMode = TextureRect.StretchModeEnum.KeepAspectCentered,
                Modulate = new Color("#ffffff00")
            };
            S_CenterContainer.AddChild(icon);
            
            var tween = CreateTween();
            tween.TweenProperty(icon, "modulate", Colors.White, 1f);
            tween.TweenInterval(1.0);
            tween.TweenProperty(icon, "modulate", new Color("#ffffff00"), 1f);
            tween.Play();
            
            await ToSignal(tween, Tween.SignalName.Finished);
            
            icon.QueueFree();
        }
        
        Destroy();
    }
}
