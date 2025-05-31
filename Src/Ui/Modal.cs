using Game.Scripts.Configs;
using GDPanelFramework.Panels;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class Modal : UIPanel
{
    public Modal Config(ModalConfig config)
    {
        CancelBtn.Visible = config.OnCancel != null;
        
        ConfirmBtn.Pressed += () =>
        {
            config.OnConfirm?.Invoke();
            QueueFree();
        };
        CancelBtn.Pressed += () =>
        {
            config.OnCancel?.Invoke();
            QueueFree();
        };
        
        ConfirmBtn.Text = config.ConfirmText;
        CancelBtn.Text = config.CancelText;
        
        TitleLabel.Text = config.Title;
        TextLabel.Text = config.Text;
        
        return this;
    }

    protected override void _OnPanelOpen()
    {
    }

    protected override void _OnPanelClose()
    {
        base._OnPanelClose();
        QueueFree();
    }
}
