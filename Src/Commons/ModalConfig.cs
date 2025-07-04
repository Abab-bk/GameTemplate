using System;

namespace Game.Commons;

public class ModalConfig(
    string title,
    string text,
    Action? onConfirm = null,
    Action? onCancel = null,
    string confirmText = "confirm",
    string cancelText = "cancel"
    )
{
    public string Title { get; set; } = title;
    public string Text { get; set; } = text;
    public string ConfirmText { get; set; } = confirmText;
    public string CancelText { get; set; } = cancelText;
    public Action? OnConfirm { get; set; } = onConfirm;
    public Action? OnCancel { get; set; } = onCancel;
}