using System;

namespace Game.Commons;

public record ModalConfig(
    string Title,
    string Text,
    Action? OnConfirm = null,
    Action? OnCancel = null,
    string ConfirmText = "confirm",
    string CancelText = "cancel"
);