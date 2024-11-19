using System;

namespace Game.Scripts.Configs;

public class ModalConfig(
    string title,
    string text,
    Action onConfirm = null,
    Action onCancel = null,
    string confirmText = null,
    string cancelText = null
    )
{
    public string Title { get; set; } = title;
    public string Text { get; set; } = text;
    public string ConfirmText { get; set; } = confirmText ?? Translator.GetMessage("confirm");
    public string CancelText { get; set; } = cancelText ?? Translator.GetMessage("cancel");
    public Action OnConfirm { get; set; } = onConfirm;
    public Action OnCancel { get; set; } = onCancel;
}