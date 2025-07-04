using AcidWallStudio;
using Game.App;
using Game.Persistent;
using GDPanelFramework;
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
                .OpenPanel(SaveManager.Instance.UserPreferences);
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
