namespace DsUi;

// 该类为自动生成的, 请不要手动编辑, 以免造成代码丢失
public static partial class UiManager
{

    public static class UiName
    {
        public const string Hud = "Hud";
        public const string PauseMenu = "PauseMenu";
        public const string Settings = "Settings";
        public const string StartMenu = "StartMenu";
    }

    /// <summary>
    /// 创建 Hud, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static Game.Scripts.Ui.Hud.HudPanel Create_Hud()
    {
        return CreateUi<Game.Scripts.Ui.Hud.HudPanel>(UiName.Hud);
    }

    /// <summary>
    /// 打开 Hud, 并返回UI实例
    /// </summary>
    public static Game.Scripts.Ui.Hud.HudPanel Open_Hud()
    {
        return OpenUi<Game.Scripts.Ui.Hud.HudPanel>(UiName.Hud);
    }

    /// <summary>
    /// 隐藏 Hud 的所有实例
    /// </summary>
    public static void Hide_Hud()
    {
        var uiInstance = Get_Hud_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 Hud 的所有实例
    /// </summary>
    public static void Destroy_Hud()
    {
        var uiInstance = Get_Hud_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 Hud 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static Game.Scripts.Ui.Hud.HudPanel[] Get_Hud_Instance()
    {
        return GetUiInstance<Game.Scripts.Ui.Hud.HudPanel>(nameof(Game.Scripts.Ui.Hud.Hud));
    }

    /// <summary>
    /// 创建 PauseMenu, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static Game.Scripts.Ui.PauseMenu.PauseMenuPanel Create_PauseMenu()
    {
        return CreateUi<Game.Scripts.Ui.PauseMenu.PauseMenuPanel>(UiName.PauseMenu);
    }

    /// <summary>
    /// 打开 PauseMenu, 并返回UI实例
    /// </summary>
    public static Game.Scripts.Ui.PauseMenu.PauseMenuPanel Open_PauseMenu()
    {
        return OpenUi<Game.Scripts.Ui.PauseMenu.PauseMenuPanel>(UiName.PauseMenu);
    }

    /// <summary>
    /// 隐藏 PauseMenu 的所有实例
    /// </summary>
    public static void Hide_PauseMenu()
    {
        var uiInstance = Get_PauseMenu_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 PauseMenu 的所有实例
    /// </summary>
    public static void Destroy_PauseMenu()
    {
        var uiInstance = Get_PauseMenu_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 PauseMenu 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static Game.Scripts.Ui.PauseMenu.PauseMenuPanel[] Get_PauseMenu_Instance()
    {
        return GetUiInstance<Game.Scripts.Ui.PauseMenu.PauseMenuPanel>(nameof(Game.Scripts.Ui.PauseMenu.PauseMenu));
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

    /// <summary>
    /// 创建 StartMenu, 并返回UI实例, 该函数不会打开 Ui
    /// </summary>
    public static Game.Scripts.Ui.StartMenu.StartMenuPanel Create_StartMenu()
    {
        return CreateUi<Game.Scripts.Ui.StartMenu.StartMenuPanel>(UiName.StartMenu);
    }

    /// <summary>
    /// 打开 StartMenu, 并返回UI实例
    /// </summary>
    public static Game.Scripts.Ui.StartMenu.StartMenuPanel Open_StartMenu()
    {
        return OpenUi<Game.Scripts.Ui.StartMenu.StartMenuPanel>(UiName.StartMenu);
    }

    /// <summary>
    /// 隐藏 StartMenu 的所有实例
    /// </summary>
    public static void Hide_StartMenu()
    {
        var uiInstance = Get_StartMenu_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.HideUi();
        }
    }

    /// <summary>
    /// 销毁 StartMenu 的所有实例
    /// </summary>
    public static void Destroy_StartMenu()
    {
        var uiInstance = Get_StartMenu_Instance();
        foreach (var uiPanel in uiInstance)
        {
            uiPanel.Destroy();
        }
    }

    /// <summary>
    /// 获取所有 StartMenu 的实例, 如果没有实例, 则返回一个空数组
    /// </summary>
    public static Game.Scripts.Ui.StartMenu.StartMenuPanel[] Get_StartMenu_Instance()
    {
        return GetUiInstance<Game.Scripts.Ui.StartMenu.StartMenuPanel>(nameof(Game.Scripts.Ui.StartMenu.StartMenu));
    }

}
