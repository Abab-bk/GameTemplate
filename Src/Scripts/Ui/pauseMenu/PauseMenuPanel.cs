using DsUi;

namespace Game.Scripts.Ui.PauseMenu;

public partial class PauseMenuPanel : PauseMenu
{
    public override void OnCreateUi()
    {
        Global.TryPause();
        
        S_ResumeBtn.Instance.Pressed += Destroy;
        S_SettingsBtn.Instance.Pressed += () =>
        {
            UiManager.Open_Settings();
        };
        S_BackToStartMenuBtn.Instance.Pressed += () =>
        {
            Destroy();
            EventBus.RequestBackToStartMenu?.Invoke();
        };
        S_ExitBtn.Instance.Pressed += () =>
        {
            EventBus.RequestQuitGame?.Invoke();
        };
    }

    public override void OnDestroyUi()
    {
        base.OnDestroyUi();
        Global.TryResume();
    }
}
