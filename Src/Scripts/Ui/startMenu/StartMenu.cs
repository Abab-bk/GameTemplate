namespace Game.Scripts.Ui.StartMenu;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class StartMenu : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: StartMenu.MarginContainer
    /// </summary>
    public MarginContainer L_MarginContainer
    {
        get
        {
            if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer((StartMenuPanel)this, GetNode<Godot.MarginContainer>("MarginContainer"));
            return _L_MarginContainer;
        }
    }
    private MarginContainer _L_MarginContainer;


    public StartMenu() : base(nameof(StartMenu))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: StartMenu.MarginContainer.VBoxContainer.GameTitle
    /// </summary>
    public class GameTitle : UiNode<StartMenuPanel, Godot.Label, GameTitle>
    {
        public GameTitle(StartMenuPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override GameTitle Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: StartMenu.MarginContainer.VBoxContainer.VBoxContainer.StartBtn
    /// </summary>
    public class StartBtn : UiNode<StartMenuPanel, Godot.Button, StartBtn>
    {
        public StartBtn(StartMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override StartBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: StartMenu.MarginContainer.VBoxContainer.VBoxContainer.SettingsBtn
    /// </summary>
    public class SettingsBtn : UiNode<StartMenuPanel, Godot.Button, SettingsBtn>
    {
        public SettingsBtn(StartMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override SettingsBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: StartMenu.MarginContainer.VBoxContainer.VBoxContainer.CreditsBtn
    /// </summary>
    public class CreditsBtn : UiNode<StartMenuPanel, Godot.Button, CreditsBtn>
    {
        public CreditsBtn(StartMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CreditsBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: StartMenu.MarginContainer.VBoxContainer.VBoxContainer.ExitBtn
    /// </summary>
    public class ExitBtn : UiNode<StartMenuPanel, Godot.Button, ExitBtn>
    {
        public ExitBtn(StartMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ExitBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: StartMenu.MarginContainer.VBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<StartMenuPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.StartBtn
        /// </summary>
        public StartBtn L_StartBtn
        {
            get
            {
                if (_L_StartBtn == null) _L_StartBtn = new StartBtn(UiPanel, Instance.GetNode<Godot.Button>("StartBtn"));
                return _L_StartBtn;
            }
        }
        private StartBtn _L_StartBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.SettingsBtn
        /// </summary>
        public SettingsBtn L_SettingsBtn
        {
            get
            {
                if (_L_SettingsBtn == null) _L_SettingsBtn = new SettingsBtn(UiPanel, Instance.GetNode<Godot.Button>("SettingsBtn"));
                return _L_SettingsBtn;
            }
        }
        private SettingsBtn _L_SettingsBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.CreditsBtn
        /// </summary>
        public CreditsBtn L_CreditsBtn
        {
            get
            {
                if (_L_CreditsBtn == null) _L_CreditsBtn = new CreditsBtn(UiPanel, Instance.GetNode<Godot.Button>("CreditsBtn"));
                return _L_CreditsBtn;
            }
        }
        private CreditsBtn _L_CreditsBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.ExitBtn
        /// </summary>
        public ExitBtn L_ExitBtn
        {
            get
            {
                if (_L_ExitBtn == null) _L_ExitBtn = new ExitBtn(UiPanel, Instance.GetNode<Godot.Button>("ExitBtn"));
                return _L_ExitBtn;
            }
        }
        private ExitBtn _L_ExitBtn;

        public VBoxContainer_1(StartMenuPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: StartMenu.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<StartMenuPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: StartMenu.MarginContainer.GameTitle
        /// </summary>
        public GameTitle L_GameTitle
        {
            get
            {
                if (_L_GameTitle == null) _L_GameTitle = new GameTitle(UiPanel, Instance.GetNode<Godot.Label>("GameTitle"));
                return _L_GameTitle;
            }
        }
        private GameTitle _L_GameTitle;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer
        /// </summary>
        public VBoxContainer_1 L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer_1(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer_1 _L_VBoxContainer;

        public VBoxContainer(StartMenuPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: StartMenu.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<StartMenuPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: StartMenu.VBoxContainer
        /// </summary>
        public VBoxContainer L_VBoxContainer
        {
            get
            {
                if (_L_VBoxContainer == null) _L_VBoxContainer = new VBoxContainer(UiPanel, Instance.GetNode<Godot.VBoxContainer>("VBoxContainer"));
                return _L_VBoxContainer;
            }
        }
        private VBoxContainer _L_VBoxContainer;

        public MarginContainer(StartMenuPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.GameTitle
    /// </summary>
    public GameTitle S_GameTitle => L_MarginContainer.L_VBoxContainer.L_GameTitle;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.VBoxContainer.StartBtn
    /// </summary>
    public StartBtn S_StartBtn => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_StartBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.VBoxContainer.SettingsBtn
    /// </summary>
    public SettingsBtn S_SettingsBtn => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_SettingsBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.VBoxContainer.CreditsBtn
    /// </summary>
    public CreditsBtn S_CreditsBtn => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_CreditsBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: StartMenu.MarginContainer.VBoxContainer.VBoxContainer.ExitBtn
    /// </summary>
    public ExitBtn S_ExitBtn => L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_ExitBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: StartMenu.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_MarginContainer;

}
