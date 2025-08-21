using Game.App;
using Game.Extensions;
using GDPanelFramework;
using GDPanelFramework.Panels;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class StartMenu : UIPanel
{
    private PackedScene SettingsScene { get; set; } =
        Wizard.LoadPackedScene(Settings.TscnFilePath);

    private PackedScene CreditsScene { get; set; } =
        Wizard.LoadPackedScene(Credits.TscnFilePath);

    protected override void _OnPanelInitialize()
    {
        base._OnPanelInitialize();

        StartBtn.Pressed += () =>
        {
            ClosePanel();
            Global.Application.StartGame();
        };
        ExitBtn.Pressed += Global.Application.Quit;
        CreditsBtn.Pressed += () => CreditsScene
            .CreatePanel<Credits>()
            .OpenPanel();

        SettingsBtn.Pressed += () =>
        {
            SettingsScene
                .CreatePanel<Settings>()
                .OpenPanel(Global.SaveManager);
        };
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