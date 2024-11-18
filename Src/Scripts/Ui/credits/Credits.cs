namespace Game.Scripts.Ui.Credits;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Credits : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Credits.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((CreditsPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;


    public Credits() : base(nameof(Credits))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Credits.ColorRect.MarginContainer.Content.Label
    /// </summary>
    public class Label : UiNode<CreditsPanel, Godot.Label, Label>
    {
        public Label(CreditsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Credits.ColorRect.MarginContainer.Content.ScrollContainer.Items
    /// </summary>
    public class Items : UiNode<CreditsPanel, Godot.VBoxContainer, Items>
    {
        public Items(CreditsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Items Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: Credits.ColorRect.MarginContainer.Content.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<CreditsPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Credits.ColorRect.MarginContainer.Content.Items
        /// </summary>
        public Items L_Items
        {
            get
            {
                if (_L_Items == null) _L_Items = new Items(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Items"));
                return _L_Items;
            }
        }
        private Items _L_Items;

        public ScrollContainer(CreditsPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Credits.ColorRect.MarginContainer.Content.CancelBtn
    /// </summary>
    public class CancelBtn : UiNode<CreditsPanel, Godot.Button, CancelBtn>
    {
        public CancelBtn(CreditsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CancelBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Credits.ColorRect.MarginContainer.Content
    /// </summary>
    public class Content : UiNode<CreditsPanel, Godot.VBoxContainer, Content>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Credits.ColorRect.MarginContainer.Label
        /// </summary>
        public Label L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: Credits.ColorRect.MarginContainer.ScrollContainer
        /// </summary>
        public ScrollContainer L_ScrollContainer
        {
            get
            {
                if (_L_ScrollContainer == null) _L_ScrollContainer = new ScrollContainer(UiPanel, Instance.GetNode<Godot.ScrollContainer>("ScrollContainer"));
                return _L_ScrollContainer;
            }
        }
        private ScrollContainer _L_ScrollContainer;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Credits.ColorRect.MarginContainer.CancelBtn
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

        public Content(CreditsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Content Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: Credits.ColorRect.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<CreditsPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Credits.ColorRect.Content
        /// </summary>
        public Content L_Content
        {
            get
            {
                if (_L_Content == null) _L_Content = new Content(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Content"));
                return _L_Content;
            }
        }
        private Content _L_Content;

        public MarginContainer(CreditsPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: Credits.ColorRect
    /// </summary>
    public class ColorRect : UiNode<CreditsPanel, Godot.ColorRect, ColorRect>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Credits.MarginContainer
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

        public ColorRect(CreditsPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: Credits.ColorRect.MarginContainer.Content.Label
    /// </summary>
    public Label S_Label => L_ColorRect.L_MarginContainer.L_Content.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Credits.ColorRect.MarginContainer.Content.ScrollContainer.Items
    /// </summary>
    public Items S_Items => L_ColorRect.L_MarginContainer.L_Content.L_ScrollContainer.L_Items;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: Credits.ColorRect.MarginContainer.Content.ScrollContainer
    /// </summary>
    public ScrollContainer S_ScrollContainer => L_ColorRect.L_MarginContainer.L_Content.L_ScrollContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Credits.ColorRect.MarginContainer.Content.CancelBtn
    /// </summary>
    public CancelBtn S_CancelBtn => L_ColorRect.L_MarginContainer.L_Content.L_CancelBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Credits.ColorRect.MarginContainer.Content
    /// </summary>
    public Content S_Content => L_ColorRect.L_MarginContainer.L_Content;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Credits.ColorRect.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_ColorRect.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Credits.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

}
