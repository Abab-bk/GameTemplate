namespace Game.Scripts.Ui.Settings;

using DsUi;

/// <summary>
/// Ui代码, 该类是根据ui场景自动生成的, 请不要手动编辑该类, 以免造成代码丢失
/// </summary>
public abstract partial class Settings : UiBase
{
    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Settings.ColorRect
    /// </summary>
    public ColorRect L_ColorRect
    {
        get
        {
            if (_L_ColorRect == null) _L_ColorRect = new ColorRect((SettingsPanel)this, GetNode<Godot.ColorRect>("ColorRect"));
            return _L_ColorRect;
        }
    }
    private ColorRect _L_ColorRect;

    /// <summary>
    /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: Settings.PanelContainer
    /// </summary>
    public PanelContainer L_PanelContainer
    {
        get
        {
            if (_L_PanelContainer == null) _L_PanelContainer = new PanelContainer((SettingsPanel)this, GetNode<Godot.PanelContainer>("PanelContainer"));
            return _L_PanelContainer;
        }
    }
    private PanelContainer _L_PanelContainer;


    public Settings() : base(nameof(Settings))
    {
    }

    public sealed override void OnInitNestedUi()
    {

    }

    /// <summary>
    /// 类型: <see cref="Godot.ColorRect"/>, 路径: Settings.ColorRect
    /// </summary>
    public class ColorRect : UiNode<SettingsPanel, Godot.ColorRect, ColorRect>
    {
        public ColorRect(SettingsPanel uiPanel, Godot.ColorRect node) : base(uiPanel, node) {  }
        public override ColorRect Clone() => new (UiPanel, (Godot.ColorRect)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer.Label
    /// </summary>
    public class Label : UiNode<SettingsPanel, Godot.Label, Label>
    {
        public Label(SettingsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.OptionButton"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer.LanguageMenu
    /// </summary>
    public class LanguageMenu : UiNode<SettingsPanel, Godot.OptionButton, LanguageMenu>
    {
        public LanguageMenu(SettingsPanel uiPanel, Godot.OptionButton node) : base(uiPanel, node) {  }
        public override LanguageMenu Clone() => new (UiPanel, (Godot.OptionButton)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer
    /// </summary>
    public class HBoxContainer : UiNode<SettingsPanel, Godot.HBoxContainer, HBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.Label
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.OptionButton"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.LanguageMenu
        /// </summary>
        public LanguageMenu L_LanguageMenu
        {
            get
            {
                if (_L_LanguageMenu == null) _L_LanguageMenu = new LanguageMenu(UiPanel, Instance.GetNode<Godot.OptionButton>("LanguageMenu"));
                return _L_LanguageMenu;
            }
        }
        private LanguageMenu _L_LanguageMenu;

        public HBoxContainer(SettingsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer4.Label
    /// </summary>
    public class Label_1 : UiNode<SettingsPanel, Godot.Label, Label_1>
    {
        public Label_1(SettingsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_1 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.OptionButton"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer4.ResolutionMenu
    /// </summary>
    public class ResolutionMenu : UiNode<SettingsPanel, Godot.OptionButton, ResolutionMenu>
    {
        public ResolutionMenu(SettingsPanel uiPanel, Godot.OptionButton node) : base(uiPanel, node) {  }
        public override ResolutionMenu Clone() => new (UiPanel, (Godot.OptionButton)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer4
    /// </summary>
    public class HBoxContainer4 : UiNode<SettingsPanel, Godot.HBoxContainer, HBoxContainer4>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.Label
        /// </summary>
        public Label_1 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_1(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_1 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.OptionButton"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.ResolutionMenu
        /// </summary>
        public ResolutionMenu L_ResolutionMenu
        {
            get
            {
                if (_L_ResolutionMenu == null) _L_ResolutionMenu = new ResolutionMenu(UiPanel, Instance.GetNode<Godot.OptionButton>("ResolutionMenu"));
                return _L_ResolutionMenu;
            }
        }
        private ResolutionMenu _L_ResolutionMenu;

        public HBoxContainer4(SettingsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer4 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer2.Label
    /// </summary>
    public class Label_2 : UiNode<SettingsPanel, Godot.Label, Label_2>
    {
        public Label_2(SettingsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_2 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.CheckBox"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer2.FullscreenCheckbox
    /// </summary>
    public class FullscreenCheckbox : UiNode<SettingsPanel, Godot.CheckBox, FullscreenCheckbox>
    {
        public FullscreenCheckbox(SettingsPanel uiPanel, Godot.CheckBox node) : base(uiPanel, node) {  }
        public override FullscreenCheckbox Clone() => new (UiPanel, (Godot.CheckBox)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer2
    /// </summary>
    public class HBoxContainer2 : UiNode<SettingsPanel, Godot.HBoxContainer, HBoxContainer2>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.Label
        /// </summary>
        public Label_2 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_2(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_2 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.CheckBox"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.FullscreenCheckbox
        /// </summary>
        public FullscreenCheckbox L_FullscreenCheckbox
        {
            get
            {
                if (_L_FullscreenCheckbox == null) _L_FullscreenCheckbox = new FullscreenCheckbox(UiPanel, Instance.GetNode<Godot.CheckBox>("FullscreenCheckbox"));
                return _L_FullscreenCheckbox;
            }
        }
        private FullscreenCheckbox _L_FullscreenCheckbox;

        public HBoxContainer2(SettingsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer2 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer3.Label
    /// </summary>
    public class Label_3 : UiNode<SettingsPanel, Godot.Label, Label_3>
    {
        public Label_3(SettingsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_3 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.CheckBox"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer3.VSyncCheckbox
    /// </summary>
    public class VSyncCheckbox : UiNode<SettingsPanel, Godot.CheckBox, VSyncCheckbox>
    {
        public VSyncCheckbox(SettingsPanel uiPanel, Godot.CheckBox node) : base(uiPanel, node) {  }
        public override VSyncCheckbox Clone() => new (UiPanel, (Godot.CheckBox)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer3
    /// </summary>
    public class HBoxContainer3 : UiNode<SettingsPanel, Godot.HBoxContainer, HBoxContainer3>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.Label
        /// </summary>
        public Label_3 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_3(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_3 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.CheckBox"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.VSyncCheckbox
        /// </summary>
        public VSyncCheckbox L_VSyncCheckbox
        {
            get
            {
                if (_L_VSyncCheckbox == null) _L_VSyncCheckbox = new VSyncCheckbox(UiPanel, Instance.GetNode<Godot.CheckBox>("VSyncCheckbox"));
                return _L_VSyncCheckbox;
            }
        }
        private VSyncCheckbox _L_VSyncCheckbox;

        public HBoxContainer3(SettingsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer3 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer5.Label
    /// </summary>
    public class Label_4 : UiNode<SettingsPanel, Godot.Label, Label_4>
    {
        public Label_4(SettingsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_4 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HSlider"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer5.MasterVolumeSlider
    /// </summary>
    public class MasterVolumeSlider : UiNode<SettingsPanel, Godot.HSlider, MasterVolumeSlider>
    {
        public MasterVolumeSlider(SettingsPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override MasterVolumeSlider Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer5
    /// </summary>
    public class HBoxContainer5 : UiNode<SettingsPanel, Godot.HBoxContainer, HBoxContainer5>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.Label
        /// </summary>
        public Label_4 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_4(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_4 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.MasterVolumeSlider
        /// </summary>
        public MasterVolumeSlider L_MasterVolumeSlider
        {
            get
            {
                if (_L_MasterVolumeSlider == null) _L_MasterVolumeSlider = new MasterVolumeSlider(UiPanel, Instance.GetNode<Godot.HSlider>("MasterVolumeSlider"));
                return _L_MasterVolumeSlider;
            }
        }
        private MasterVolumeSlider _L_MasterVolumeSlider;

        public HBoxContainer5(SettingsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer5 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer6.Label
    /// </summary>
    public class Label_5 : UiNode<SettingsPanel, Godot.Label, Label_5>
    {
        public Label_5(SettingsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_5 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HSlider"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer6.MusicVolumeSlider
    /// </summary>
    public class MusicVolumeSlider : UiNode<SettingsPanel, Godot.HSlider, MusicVolumeSlider>
    {
        public MusicVolumeSlider(SettingsPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override MusicVolumeSlider Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer6
    /// </summary>
    public class HBoxContainer6 : UiNode<SettingsPanel, Godot.HBoxContainer, HBoxContainer6>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.Label
        /// </summary>
        public Label_5 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_5(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_5 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.MusicVolumeSlider
        /// </summary>
        public MusicVolumeSlider L_MusicVolumeSlider
        {
            get
            {
                if (_L_MusicVolumeSlider == null) _L_MusicVolumeSlider = new MusicVolumeSlider(UiPanel, Instance.GetNode<Godot.HSlider>("MusicVolumeSlider"));
                return _L_MusicVolumeSlider;
            }
        }
        private MusicVolumeSlider _L_MusicVolumeSlider;

        public HBoxContainer6(SettingsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer6 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Label"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer7.Label
    /// </summary>
    public class Label_6 : UiNode<SettingsPanel, Godot.Label, Label_6>
    {
        public Label_6(SettingsPanel uiPanel, Godot.Label node) : base(uiPanel, node) {  }
        public override Label_6 Clone() => new (UiPanel, (Godot.Label)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HSlider"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer7.SoundVolumeSlider
    /// </summary>
    public class SoundVolumeSlider : UiNode<SettingsPanel, Godot.HSlider, SoundVolumeSlider>
    {
        public SoundVolumeSlider(SettingsPanel uiPanel, Godot.HSlider node) : base(uiPanel, node) {  }
        public override SoundVolumeSlider Clone() => new (UiPanel, (Godot.HSlider)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer7
    /// </summary>
    public class HBoxContainer7 : UiNode<SettingsPanel, Godot.HBoxContainer, HBoxContainer7>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Label"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.Label
        /// </summary>
        public Label_6 L_Label
        {
            get
            {
                if (_L_Label == null) _L_Label = new Label_6(UiPanel, Instance.GetNode<Godot.Label>("Label"));
                return _L_Label;
            }
        }
        private Label_6 _L_Label;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.SoundVolumeSlider
        /// </summary>
        public SoundVolumeSlider L_SoundVolumeSlider
        {
            get
            {
                if (_L_SoundVolumeSlider == null) _L_SoundVolumeSlider = new SoundVolumeSlider(UiPanel, Instance.GetNode<Godot.HSlider>("SoundVolumeSlider"));
                return _L_SoundVolumeSlider;
            }
        }
        private SoundVolumeSlider _L_SoundVolumeSlider;

        public HBoxContainer7(SettingsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer7 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels
    /// </summary>
    public class Labels : UiNode<SettingsPanel, Godot.VBoxContainer, Labels>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.HBoxContainer
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

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.HBoxContainer4
        /// </summary>
        public HBoxContainer4 L_HBoxContainer4
        {
            get
            {
                if (_L_HBoxContainer4 == null) _L_HBoxContainer4 = new HBoxContainer4(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer4"));
                return _L_HBoxContainer4;
            }
        }
        private HBoxContainer4 _L_HBoxContainer4;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.HBoxContainer2
        /// </summary>
        public HBoxContainer2 L_HBoxContainer2
        {
            get
            {
                if (_L_HBoxContainer2 == null) _L_HBoxContainer2 = new HBoxContainer2(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer2"));
                return _L_HBoxContainer2;
            }
        }
        private HBoxContainer2 _L_HBoxContainer2;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.HBoxContainer3
        /// </summary>
        public HBoxContainer3 L_HBoxContainer3
        {
            get
            {
                if (_L_HBoxContainer3 == null) _L_HBoxContainer3 = new HBoxContainer3(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer3"));
                return _L_HBoxContainer3;
            }
        }
        private HBoxContainer3 _L_HBoxContainer3;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.HBoxContainer5
        /// </summary>
        public HBoxContainer5 L_HBoxContainer5
        {
            get
            {
                if (_L_HBoxContainer5 == null) _L_HBoxContainer5 = new HBoxContainer5(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer5"));
                return _L_HBoxContainer5;
            }
        }
        private HBoxContainer5 _L_HBoxContainer5;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.HBoxContainer6
        /// </summary>
        public HBoxContainer6 L_HBoxContainer6
        {
            get
            {
                if (_L_HBoxContainer6 == null) _L_HBoxContainer6 = new HBoxContainer6(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer6"));
                return _L_HBoxContainer6;
            }
        }
        private HBoxContainer6 _L_HBoxContainer6;

        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.HBoxContainer7
        /// </summary>
        public HBoxContainer7 L_HBoxContainer7
        {
            get
            {
                if (_L_HBoxContainer7 == null) _L_HBoxContainer7 = new HBoxContainer7(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer7"));
                return _L_HBoxContainer7;
            }
        }
        private HBoxContainer7 _L_HBoxContainer7;

        public Labels(SettingsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override Labels Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.ScrollContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer
    /// </summary>
    public class ScrollContainer : UiNode<SettingsPanel, Godot.ScrollContainer, ScrollContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.Labels
        /// </summary>
        public Labels L_Labels
        {
            get
            {
                if (_L_Labels == null) _L_Labels = new Labels(UiPanel, Instance.GetNode<Godot.VBoxContainer>("Labels"));
                return _L_Labels;
            }
        }
        private Labels _L_Labels;

        public ScrollContainer(SettingsPanel uiPanel, Godot.ScrollContainer node) : base(uiPanel, node) {  }
        public override ScrollContainer Clone() => new (UiPanel, (Godot.ScrollContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer.ConfirmBtn
    /// </summary>
    public class ConfirmBtn : UiNode<SettingsPanel, Godot.Button, ConfirmBtn>
    {
        public ConfirmBtn(SettingsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override ConfirmBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.Button"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer.CancelBtn
    /// </summary>
    public class CancelBtn : UiNode<SettingsPanel, Godot.Button, CancelBtn>
    {
        public CancelBtn(SettingsPanel uiPanel, Godot.Button node) : base(uiPanel, node) {  }
        public override CancelBtn Clone() => new (UiPanel, (Godot.Button)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.HBoxContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer
    /// </summary>
    public class HBoxContainer_1 : UiNode<SettingsPanel, Godot.HBoxContainer, HBoxContainer_1>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ConfirmBtn
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.Button"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.CancelBtn
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

        public HBoxContainer_1(SettingsPanel uiPanel, Godot.HBoxContainer node) : base(uiPanel, node) {  }
        public override HBoxContainer_1 Clone() => new (UiPanel, (Godot.HBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.VBoxContainer"/>, 路径: Settings.PanelContainer.MarginContainer.VBoxContainer
    /// </summary>
    public class VBoxContainer : UiNode<SettingsPanel, Godot.VBoxContainer, VBoxContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.ScrollContainer
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
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.HBoxContainer
        /// </summary>
        public HBoxContainer_1 L_HBoxContainer
        {
            get
            {
                if (_L_HBoxContainer == null) _L_HBoxContainer = new HBoxContainer_1(UiPanel, Instance.GetNode<Godot.HBoxContainer>("HBoxContainer"));
                return _L_HBoxContainer;
            }
        }
        private HBoxContainer_1 _L_HBoxContainer;

        public VBoxContainer(SettingsPanel uiPanel, Godot.VBoxContainer node) : base(uiPanel, node) {  }
        public override VBoxContainer Clone() => new (UiPanel, (Godot.VBoxContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.MarginContainer"/>, 路径: Settings.PanelContainer.MarginContainer
    /// </summary>
    public class MarginContainer : UiNode<SettingsPanel, Godot.MarginContainer, MarginContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Settings.PanelContainer.VBoxContainer
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

        public MarginContainer(SettingsPanel uiPanel, Godot.MarginContainer node) : base(uiPanel, node) {  }
        public override MarginContainer Clone() => new (UiPanel, (Godot.MarginContainer)Instance.Duplicate());
    }

    /// <summary>
    /// 类型: <see cref="Godot.PanelContainer"/>, 路径: Settings.PanelContainer
    /// </summary>
    public class PanelContainer : UiNode<SettingsPanel, Godot.PanelContainer, PanelContainer>
    {
        /// <summary>
        /// 使用 Instance 属性获取当前节点实例对象, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Settings.MarginContainer
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

        public PanelContainer(SettingsPanel uiPanel, Godot.PanelContainer node) : base(uiPanel, node) {  }
        public override PanelContainer Clone() => new (UiPanel, (Godot.PanelContainer)Instance.Duplicate());
    }


    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ColorRect"/>, 节点路径: Settings.ColorRect
    /// </summary>
    public ColorRect S_ColorRect => L_ColorRect;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.OptionButton"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer.LanguageMenu
    /// </summary>
    public LanguageMenu S_LanguageMenu => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer.L_LanguageMenu;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.OptionButton"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer4.ResolutionMenu
    /// </summary>
    public ResolutionMenu S_ResolutionMenu => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer4.L_ResolutionMenu;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer4
    /// </summary>
    public HBoxContainer4 S_HBoxContainer4 => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer4;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.CheckBox"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer2.FullscreenCheckbox
    /// </summary>
    public FullscreenCheckbox S_FullscreenCheckbox => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer2.L_FullscreenCheckbox;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer2
    /// </summary>
    public HBoxContainer2 S_HBoxContainer2 => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer2;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.CheckBox"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer3.VSyncCheckbox
    /// </summary>
    public VSyncCheckbox S_VSyncCheckbox => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer3.L_VSyncCheckbox;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer3
    /// </summary>
    public HBoxContainer3 S_HBoxContainer3 => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer3;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer5.MasterVolumeSlider
    /// </summary>
    public MasterVolumeSlider S_MasterVolumeSlider => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer5.L_MasterVolumeSlider;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer5
    /// </summary>
    public HBoxContainer5 S_HBoxContainer5 => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer5;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer6.MusicVolumeSlider
    /// </summary>
    public MusicVolumeSlider S_MusicVolumeSlider => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer6.L_MusicVolumeSlider;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer6
    /// </summary>
    public HBoxContainer6 S_HBoxContainer6 => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer6;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HSlider"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer7.SoundVolumeSlider
    /// </summary>
    public SoundVolumeSlider S_SoundVolumeSlider => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer7.L_SoundVolumeSlider;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.HBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels.HBoxContainer7
    /// </summary>
    public HBoxContainer7 S_HBoxContainer7 => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels.L_HBoxContainer7;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer.Labels
    /// </summary>
    public Labels S_Labels => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer.L_Labels;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.ScrollContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.ScrollContainer
    /// </summary>
    public ScrollContainer S_ScrollContainer => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_ScrollContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer.ConfirmBtn
    /// </summary>
    public ConfirmBtn S_ConfirmBtn => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_ConfirmBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.Button"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer.HBoxContainer.CancelBtn
    /// </summary>
    public CancelBtn S_CancelBtn => L_PanelContainer.L_MarginContainer.L_VBoxContainer.L_HBoxContainer.L_CancelBtn;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.VBoxContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer.VBoxContainer
    /// </summary>
    public VBoxContainer S_VBoxContainer => L_PanelContainer.L_MarginContainer.L_VBoxContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.MarginContainer"/>, 节点路径: Settings.PanelContainer.MarginContainer
    /// </summary>
    public MarginContainer S_MarginContainer => L_PanelContainer.L_MarginContainer;

    /// <summary>
    /// 场景中唯一名称的节点, 节点类型: <see cref="Godot.PanelContainer"/>, 节点路径: Settings.PanelContainer
    /// </summary>
    public PanelContainer S_PanelContainer => L_PanelContainer;

}
