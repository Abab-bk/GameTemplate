using Game.App;
using Game.Extensions;
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
        ExitBtn.Pressed += Locator.Get<Application>().Quit;

        EnableCloseWithCancelKey();

        Locator.Get<Application>().TryPause();
    }

    protected override void _OnPanelClose()
    {
        base._OnPanelClose();

        ResumeBtn.Pressed -= ClosePanel;
        SettingsBtn.Pressed -= OpenSettingsPanel;
        BackToStartMenuBtn.Pressed -= BackToStartMenu;
        ExitBtn.Pressed -= Locator.Get<Application>().Quit;

        Locator.Get<Application>().TryResume();

        QueueFree();
    }

    private void OpenSettingsPanel()
    {
        Wizard.LoadPackedScene(Settings.TscnFilePath)
            .CreatePanel<Settings>()
            .OpenPanel(Locator.Get<SaveManager>());
    }

    private void BackToStartMenu()
    {
        ClosePanel();
        Locator.Get<Application>().BackToStartMenu();
    }
}