using System.Collections.Generic;
using System.Text.Json;
using AcidWallStudio;
using Game.Scripts.Prefabs;
using GodotTask;

namespace Game.Scripts.Ui.Credits;

public partial class CreditsPanel : Credits
{
    public override void OnCreateUi()
    {
        var data = JsonSerializer.Deserialize<Dictionary<string, string[]>>(
            Wizard.ReadAllText("res://Assets/Credits.json"));
        
        foreach (var keyPair in data)
        {
            var item = CreditItem.Create();
            S_Items.Instance.AddChild(item);
            item.Config(keyPair.Key, data[keyPair.Key]);
        }

        GDTask.Delay(2000).ContinueWith(() =>
        {
            var tween = CreateTween();
            tween.TweenProperty(
                S_ScrollContainer.Instance,
                "scroll_vertical",
                (int)S_ScrollContainer.Instance.GetVScrollBar().MaxValue,
                10
            );
            tween.Play();
        });
        
        S_CancelBtn.Instance.Pressed += Destroy;
    }
}
