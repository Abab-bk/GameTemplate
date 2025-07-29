using AcidWallStudio;
using Game.App;
using Game.Persistent;
using GDPanelFramework;
using GDPanelFramework.Panels;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class PauseMenu : UIPanel
{
    protected override void _OnPanelOpen()
    {
        base._Ready();

        ResumeBtn.Pressed += ClosePanel;
        SettingsBtn.Pressed += OpenSettingsPanel;
        BackToStartMenuBtn.Pressed += BackToStartMenu;
        ExitBtn.Pressed += Global.Application.Quit;

        EnableCloseWithCancelKey();

        Global.TryPause();
    }

    protected override void _OnPanelClose()
    {
        base._OnPanelClose();

        ResumeBtn.Pressed -= ClosePanel;
        SettingsBtn.Pressed -= OpenSettingsPanel;
        BackToStartMenuBtn.Pressed -= BackToStartMenu;
        ExitBtn.Pressed -= Global.Application.Quit;

        Global.TryResume();

        QueueFree();
    }

    private void OpenSettingsPanel()
    {
        Wizard.LoadPackedScene(Settings.TscnFilePath)
            .CreatePanel<Settings>()
            .OpenPanel(SaveManager.Instance.UserPreferences);
    }

    private void BackToStartMenu()
    {
        ClosePanel();
        Global.Application.BackToStartMenu();
    }
}