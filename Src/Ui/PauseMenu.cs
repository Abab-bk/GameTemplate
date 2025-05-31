using AcidWallStudio;
using Game.Scripts;
using GDPanelFramework;
using GDPanelFramework.Panels;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class PauseMenu : Control
{
    public override void _Ready()
    {
        base._Ready();
        ResumeBtn.Pressed += Hide;
        SettingsBtn.Pressed += () =>
        {
            Wizard.LoadPackedScene(Settings.TscnFilePath)
                .CreatePanel<Settings>()
                .OpenPanel();
        };
        BackToStartMenuBtn.Pressed += () =>
        {
            Hide();
            EventBus.RequestBackToStartMenu.Invoke();
        };
        ExitBtn.Pressed += () =>
        {
            EventBus.RequestQuitGame.Invoke();
        };
        VisibilityChanged += () =>
        {
            if (Visible)
            {
                Global.TryPause();
                return;
            }
            Global.TryResume();
        };
    }
}
