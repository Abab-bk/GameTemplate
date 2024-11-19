namespace Game.Scripts.Ui.LoadingScreen;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class LoadingScreen : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: LoadingScreen.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((LoadingScreenPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.AnimationPlayer"/>, 节点路径: LoadingScreen.AnimationPlayer
    /// </summary>
    public AnimationPlayer L_AnimationPlayer
    {
        get
        {
            if (_L_AnimationPlayer == null) _L_AnimationPlayer = new AnimationPlayer((LoadingScreenPanel)this, GetNode<Godot.AnimationPlayer>("AnimationPlayer"));
            return _L_AnimationPlayer;
        }
    }
    private AnimationPlayer _L_AnimationPlayer;


    public LoadingScreen() : base(nameof(LoadingScreen))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: LoadingScreen.ColorRect.MarginContainer.VBoxContainer.Label
    /// </summary>
    public class Label : UiNode<LoadingScreenPanel, Godot.Label, Label>
    {
        public Label(LoadingScreenPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ProgressBar"/>, 路径: LoadingScreen.ColorRect.MarginContainer.VBoxContainer.ProgressBar
    /// </summary>
    public class ProgressBar : UiNode<LoadingScreenPanel, Godot.ProgressBar, ProgressBar>
    {
        public ProgressBar(LoadingScreenPanel uiPanel, Godot.ProgressBar node) : base(uiPanel, node) {  }
        public override ProgressBar Clone() => new (UiPanel, (Godot.ProgressBar)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: LoadingScreen.ColorRect.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<LoadingScreenPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: LoadingScreen.ColorRect.MarginContainer.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ProgressBar"/>, 节点路径: LoadingScreen.ColorRect.MarginContainer.ProgressBar
        /// </summary>
        public ProgressBar L_ProgressBar
        {
            get
            {
                if (_L_ProgressBar == null) _L_ProgressBar = new ProgressBar(UiPanel, Instance.GetNode<Godot.ProgressBar>("ProgressBar"));
                return _L_ProgressBar;
            }
        }
        private ProgressBar _L_ProgressBar;

        public VBoxContainer(LoadingScreenPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: LoadingScreen.ColorRect.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<LoadingScreenPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: LoadingScreen.ColorRect.VBoxContainer
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

        public MarginContainer(LoadingScreenPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: LoadingScreen.ColorRect
    /// </summary>
    public class ColorRect : UiNode<LoadingScreenPanel, Godot.ColorRect, ColorRect>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: LoadingScreen.MarginContainer
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

        public ColorRect(LoadingScreenPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.AnimationPlayer"/>, 路径: LoadingScreen.AnimationPlayer
    /// </summary>
    public class AnimationPlayer : UiNode<LoadingScreenPanel, Godot.AnimationPlayer, AnimationPlayer>
    {
        public AnimationPlayer(LoadingScreenPanel uiPanel, Godot.AnimationPlayer node) : base(uiPanel, node) {  }
        public override AnimationPlayer Clone() => new (UiPanel, (Godot.AnimationPlayer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Label"/>, 节点路径: LoadingScreen.ColorRect.MarginContainer.VBoxContainer.Label
    /// </summary>
    public Label S_Label => L_ColorRect.L_MarginContainer.L_VBoxContainer.L_Label;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ProgressBar"/>, 节点路径: LoadingScreen.ColorRect.MarginContainer.VBoxContainer.ProgressBar
    /// </summary>
    public ProgressBar S_ProgressBar => L_ColorRect.L_MarginContainer.L_VBoxContainer.L_ProgressBar;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: LoadingScreen.ColorRect.MarginContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_ColorRect.L_MarginContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: LoadingScreen.ColorRect.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_ColorRect.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: LoadingScreen.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.AnimationPlayer"/>, 节点路径: LoadingScreen.AnimationPlayer
    /// </summary>
    public AnimationPlayer S_AnimationPlayer => L_AnimationPlayer;

}
