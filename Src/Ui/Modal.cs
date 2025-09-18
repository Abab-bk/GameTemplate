using Game.Commons;
using GDPanelFramework;
using GDPanelFramework.Panels;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class Modal : UIPanelArg<ModalConfig, Empty>
{
    protected override void _OnPanelOpen(ModalConfig config)
    {
        CancelBtn.Visible = config.OnCancel != null;

        ConfirmBtn.Pressed += () =>
        {
            config.OnConfirm?.Invoke();
            ClosePanel(Empty.Default);
        };
        CancelBtn.Pressed += () =>
        {
            config.OnCancel?.Invoke();
            ClosePanel(Empty.Default);
        };

        ConfirmBtn.Text = config.ConfirmText;
        CancelBtn.Text = config.CancelText;

        TitleLabel.Text = config.Title;
        TextLabel.Text = config.Text;
    }

    protected override void _OnPanelClose(Empty closeArg)
    {
        base._OnPanelClose(closeArg);
        QueueFree();
    }
}