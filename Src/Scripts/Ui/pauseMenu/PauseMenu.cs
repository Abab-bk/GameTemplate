namespace Game.Scripts.Ui.PauseMenu;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class PauseMenu : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: PauseMenu.PanelContainer
    /// </summary>
    public PanelContainer L_PanelContainer
    {
        get
        {
            if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer((PauseMenuPanel)this, GetNode<Godot.PanelContainer>("PanelContainer"));
            return _L_PanelContainer;
        }
    }
    private PanelContainer _L_PanelContainer;


    public PauseMenu() : base(nameof(PauseMenu))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: PauseMenu.PanelContainer.VBoxContainer.ResumeBtn
    /// </summary>
    public class ResumeBtn : UiNode<PauseMenuPanel, Godot.Button, ResumeBtn>
    {
        public ResumeBtn(PauseMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ResumeBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: PauseMenu.PanelContainer.VBoxContainer.SettingsBtn
    /// </summary>
    public class SettingsBtn : UiNode<PauseMenuPanel, Godot.Button, SettingsBtn>
    {
        public SettingsBtn(PauseMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override SettingsBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: PauseMenu.PanelContainer.VBoxContainer.BackToStartMenuBtn
    /// </summary>
    public class BackToStartMenuBtn : UiNode<PauseMenuPanel, Godot.Button, BackToStartMenuBtn>
    {
        public BackToStartMenuBtn(PauseMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override BackToStartMenuBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: PauseMenu.PanelContainer.VBoxContainer.ExitBtn
    /// </summary>
    public class ExitBtn : UiNode<PauseMenuPanel, Godot.Button, ExitBtn>
    {
        public ExitBtn(PauseMenuPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ExitBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: PauseMenu.PanelContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<PauseMenuPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: PauseMenu.PanelContainer.ResumeBtn
        /// </summary>
        public ResumeBtn L_ResumeBtn
        {
            get
            {
                if (_L_ResumeBtn == null) _L_ResumeBtn = new ResumeBtn(UiPanel, Instance.GetNode<Godot.Button>("ResumeBtn"));
                return _L_ResumeBtn;
            }
        }
        private ResumeBtn _L_ResumeBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: PauseMenu.PanelContainer.SettingsBtn
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: PauseMenu.PanelContainer.BackToStartMenuBtn
        /// </summary>
        public BackToStartMenuBtn L_BackToStartMenuBtn
        {
            get
            {
                if (_L_BackToStartMenuBtn == null) _L_BackToStartMenuBtn = new BackToStartMenuBtn(UiPanel, Instance.GetNode<Godot.Button>("BackToStartMenuBtn"));
                return _L_BackToStartMenuBtn;
            }
        }
        private BackToStartMenuBtn _L_BackToStartMenuBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: PauseMenu.PanelContainer.ExitBtn
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

        public VBoxContainer(PauseMenuPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: PauseMenu.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<PauseMenuPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: PauseMenu.VBoxContainer
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

        public PanelContainer(PauseMenuPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: PauseMenu.PanelContainer.VBoxContainer.ResumeBtn
    /// </summary>
    public ResumeBtn S_ResumeBtn => L_PanelContainer.L_VBoxContainer.L_ResumeBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: PauseMenu.PanelContainer.VBoxContainer.SettingsBtn
    /// </summary>
    public SettingsBtn S_SettingsBtn => L_PanelContainer.L_VBoxContainer.L_SettingsBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: PauseMenu.PanelContainer.VBoxContainer.BackToStartMenuBtn
    /// </summary>
    public BackToStartMenuBtn S_BackToStartMenuBtn => L_PanelContainer.L_VBoxContainer.L_BackToStartMenuBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: PauseMenu.PanelContainer.VBoxContainer.ExitBtn
    /// </summary>
    public ExitBtn S_ExitBtn => L_PanelContainer.L_VBoxContainer.L_ExitBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: PauseMenu.PanelContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_PanelContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: PauseMenu.PanelContainer
    /// </summary>
    public PanelContainer S_PanelContainer => L_PanelContainer;

}
