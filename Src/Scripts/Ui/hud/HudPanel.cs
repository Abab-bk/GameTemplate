using DsUi;
using Godot;

namespace Game.Scripts.Ui.Hud;

public partial class HudPanel : Hud
{
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("Pause"))
        {
            if (Global.IsPaused)
            {
                UiManager.Destroy_PauseMenu();
            }
            else
            {
                UiManager.Open_PauseMenu();
            }
        }
    }
}
