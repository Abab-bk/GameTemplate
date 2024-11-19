using Game.Scripts.Configs;

namespace Game.Scripts.Ui.Modal;

public partial class ModalPanel : Modal
{
    public ModalPanel Config(ModalConfig config)
    {
        S_CancelBtn.Instance.Visible = config.OnCancel != null;
        
        S_ConfirmBtn.Instance.Pressed += () =>
        {
            if (config.OnConfirm != null)
            {
                config.OnConfirm();
            }
            
            Destroy();
        };
        S_CancelBtn.Instance.Pressed += () =>
        {
            if (config.OnCancel != null)
            {
                config.OnCancel();
            }
            
            Destroy();
        };
        
        S_ConfirmBtn.Instance.Text = config.ConfirmText;
        S_CancelBtn.Instance.Text = config.CancelText;
        
        S_TitleLabel.Instance.Text = config.Title;
        S_TextLabel.Instance.Text = config.Text;
        
        return this;
    }
}
