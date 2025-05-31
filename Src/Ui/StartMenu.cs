using AcidWallStudio;
using Game.Scripts;
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
            EventBus.RequestStartGame.Invoke();
        };
        ExitBtn.Pressed += () => EventBus.RequestQuitGame.Invoke();
        CreditsBtn.Pressed += () => CreditsScene
            .CreatePanel<Credits>()
            .OpenPanel();
        
        SettingsBtn.Pressed += () =>
        {
            SettingsScene
                .CreatePanel<Settings>()
                .Load(Global.AppSaver.UserPreferences)
                .OpenPanel();
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
