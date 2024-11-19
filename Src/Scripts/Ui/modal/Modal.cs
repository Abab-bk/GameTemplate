namespace Game.Scripts.Ui.Modal;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Modal : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Modal.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((ModalPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: Modal.PanelContainer
    /// </summary>
    public PanelContainer L_PanelContainer
    {
        get
        {
            if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer((ModalPanel)this, GetNode<Godot.PanelContainer>("PanelContainer"));
            return _L_PanelContainer;
        }
    }
    private PanelContainer _L_PanelContainer;


    public Modal() : base(nameof(Modal))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: Modal.ColorRect
    /// </summary>
    public class ColorRect : UiNode<ModalPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(ModalPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Modal.PanelContainer.MarginContainer.VBoxContainer.VBoxContainer.TitleLabel
    /// </summary>
    public class TitleLabel : UiNode<ModalPanel, Godot.Label, TitleLabel>
    {
        public TitleLabel(ModalPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override TitleLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Modal.PanelContainer.MarginContainer.VBoxContainer.VBoxContainer.TextLabel
    /// </summary>
    public class TextLabel : UiNode<ModalPanel, Godot.Label, TextLabel>
    {
        public TextLabel(ModalPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override TextLabel Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Modal.PanelContainer.MarginContainer.VBoxContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer_1 : UiNode<ModalPanel, Godot.VBoxContainer, VBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Modal.PanelContainer.MarginContainer.VBoxContainer.TitleLabel
        /// </summary>
        public TitleLabel L_TitleLabel
        {
            get
            {
                if (_L_TitleLabel == null) _L_TitleLabel = new TitleLabel(UiPanel, Instance.GetNode<Godot.Label>("TitleLabel"));
                return _L_TitleLabel;
            }
        }
        private TitleLabel _L_TitleLabel;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Modal.PanelContainer.MarginContainer.VBoxContainer.TextLabel
        /// </summary>
        public TextLabel L_TextLabel
        {
            get
            {
                if (_L_TextLabel == null) _L_TextLabel = new TextLabel(UiPanel, Instance.GetNode<Godot.Label>("TextLabel"));
                return _L_TextLabel;
            }
        }
        private TextLabel _L_TextLabel;

        public VBoxContainer_1(ModalPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer_1 Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Modal.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer.ConfirmBtn
    /// </summary>
    public class ConfirmBtn : UiNode<ModalPanel, Godot.Button, ConfirmBtn>
    {
        public ConfirmBtn(ModalPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ConfirmBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Modal.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer.CancelBtn
    /// </summary>
    public class CancelBtn : UiNode<ModalPanel, Godot.Button, CancelBtn>
    {
        public CancelBtn(ModalPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CancelBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Modal.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<ModalPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Modal.PanelContainer.MarginContainer.VBoxContainer.ConfirmBtn
        /// </summary>
        public ConfirmBtn L_ConfirmBtn
        {
            get
            {
                if (_L_ConfirmBtn == null) _L_ConfirmBtn = new ConfirmBtn(UiPanel, Instance.GetNode<Godot.Button>("ConfirmBtn"));
                return _L_ConfirmBtn;
            }
        }
        private ConfirmBtn _L_ConfirmBtn;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Modal.PanelContainer.MarginContainer.VBoxContainer.CancelBtn
        /// </summary>
        public CancelBtn L_CancelBtn
        {
            get
            {
                if (_L_CancelBtn == null) _L_CancelBtn = new CancelBtn(UiPanel, Instance.GetNode<Godot.Button>("CancelBtn"));
                return _L_CancelBtn;
            }
        }
        private CancelBtn _L_CancelBtn;

        public HBoxContainer(ModalPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Modal.PanelContainer.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<ModalPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Modal.PanelContainer.MarginContainer.VBoxContainer
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Modal.PanelContainer.MarginContainer.HBoxContainer
        /// </summary>
        public HBoxContainer L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer _L_HBoxContainer;

        public VBoxContainer(ModalPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: Modal.PanelContainer.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<ModalPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Modal.PanelContainer.VBoxContainer
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

        public MarginContainer(ModalPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: Modal.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<ModalPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Modal.MarginContainer
        /// </summary>
        public MarginContainer L_MarginContainer
        {
            get
            {
                if (_L_MarginContainer == null) _L_MarginContainer = new MarginContainer(UiPanel, Instance.GetNode<Godot.MarginContainer>("MarginContainer"));
                return _L_MarginContainer;
            }
        }
        private MarginContainer _L_MarginContainer;

        public PanelContainer(ModalPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Modal.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: Modal.PanelContainer.MarginContainer.VBoxContainer.VBoxContainer.TitleLabel
    /// </summary>
    public TitleLabel S_TitleLabel => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_TitleLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: Modal.PanelContainer.MarginContainer.VBoxContainer.VBoxContainer.TextLabel
    /// </summary>
    public TextLabel S_TextLabel => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_VBoxContainer.L_TextLabel;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Modal.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer.ConfirmBtn
    /// </summary>
    public ConfirmBtn S_ConfirmBtn => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_ConfirmBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Modal.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer.CancelBtn
    /// </summary>
    public CancelBtn S_CancelBtn => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_CancelBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Modal.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public HBoxContainer S_HBoxContainer => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_HBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Modal.PanelContainer.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_PanelContainer.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: Modal.PanelContainer
    /// </summary>
    public PanelContainer S_PanelContainer => L_PanelContainer;

}
