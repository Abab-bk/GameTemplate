using DsUi;

namespace Game.Scripts.Ui.StartMenu;

public partial class StartMenuPanel : StartMenu
{
    public override void OnCreateUi()
    {
        S_GameTitle.Instance.Text = Data.Constants.GameName;

        S_StartBtn.Instance.Pressed += () => EventBus.RequestStartGame?.Invoke();
        S_ExitBtn.Instance.Pressed += () => EventBus.RequestQuitGame?.Invoke();
        S_SettingsBtn.Instance.Pressed += () =>
        {
            var panel = UiManager.Open_Settings();
            panel.Load(Global.AppSaver.UserPreferences);
        };
    }
}
