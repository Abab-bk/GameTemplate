namespace DsUi;

// 该类为自动生成的, 请不要手动编辑, 以免造成代码丢失
public static partial class UiManager
{

    public static class UiName
    {
        public const string Settings = "Settings";
    }

    /// <summary>
    /// 创建 Settings, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static Game.Scripts.Ui.Settings.SettingsPanel Create_Settings()
    {
        return CreateUi<Game.Scripts.Ui.Settings.SettingsPanel>(UiName.Settings);
    }

    /// <summary>
    /// 打开 Settings, 并返回UI实例
    /// </summary>
    public static Game.Scripts.Ui.Settings.SettingsPanel Open_Settings()
    {
        return OpenUi<Game.Scripts.Ui.Settings.SettingsPanel>(UiName.Settings);
    }

    /// <summary>
    /// 隐藏 Settings 的所有实例
    /// </summary>
    public static void Hide_Settings()
    {
        var uiInstance = Get_Settings_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 Settings 的所有实例
    /// </summary>
    public static void Destroy_Settings()
    {
        var uiInstance = Get_Settings_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 Settings 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static Game.Scripts.Ui.Settings.SettingsPanel[] Get_Settings_Instance()
    {
        return GetUiInstance<Game.Scripts.Ui.Settings.SettingsPanel>(nameof(Game.Scripts.Ui.Settings.Settings));
    }

}
