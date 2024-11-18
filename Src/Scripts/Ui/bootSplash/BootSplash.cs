namespace Game.Scripts.Ui.BootSplash;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class BootSplash : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: BootSplash.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((BootSplashPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;


    public BootSplash() : base(nameof(BootSplash))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.CenterContainer"/>, 路径: BootSplash.ColorRect.CenterContainer
    /// </summary>
    public class CenterContainer : UiNode<BootSplashPanel, Godot.CenterContainer, CenterContainer>
    {
        public CenterContainer(BootSplashPanel uiPanel, Godot.CenterContainer node) : base(uiPanel, node) {  }
        public override CenterContainer Clone() => new (UiPanel, (Godot.CenterContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: BootSplash.ColorRect
    /// </summary>
    public class ColorRect : UiNode<BootSplashPanel, Godot.ColorRect, ColorRect>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.CenterContainer"/>, 节点路径: BootSplash.CenterContainer
        /// </summary>
        public CenterContainer L_CenterContainer
        {
            get
            {
                if (_L_CenterContainer == null) _L_CenterContainer = new CenterContainer(UiPanel, Instance.GetNode<Godot.CenterContainer>("CenterContainer"));
                return _L_CenterContainer;
            }
        }
        private CenterContainer _L_CenterContainer;

        public ColorRect(BootSplashPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.CenterContainer"/>, 节点路径: BootSplash.ColorRect.CenterContainer
    /// </summary>
    public CenterContainer S_CenterContainer => L_ColorRect.L_CenterContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: BootSplash.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

}
