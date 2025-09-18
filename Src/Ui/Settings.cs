using System;
using Game.Commons;
using Game.Persistent;
using GDPanelFramework.Panels;
using Godot;
using GodotTask;
using UserPreferences = Game.Persistent.Models.UserPreferences;

namespace Game.Ui;

[SceneTree]
public partial class Settings : UIPanelArg<SaveManager, bool>
{
    private readonly Vector2I[] _resolutions =
    [
        new(1280, 720),
        new(1920, 1080)
    ];

    private void Close()
    {
        ClosePanel(true);
    }

    protected override void _OnPanelOpen(SaveManager saveManager)
    {
        var languagePopupMenu = LanguageMenu.GetPopup();
        foreach (var lang in Enum.GetValues<Language>()) languagePopupMenu.AddItem(lang.ToString(), (int)lang);

        var resolutionPopupMenu = ResolutionMenu.GetPopup();
        foreach (var resolution in _resolutions)
            resolutionPopupMenu.AddItem(
                $"{resolution.X} * {resolution.Y}",
                Array.IndexOf(_resolutions, resolution)
            );

        ConfirmBtn.Pressed += () =>
        {
            var userPreferences = saveManager.UserPreferences;

            userPreferences.Language = (Language)Enum.Parse(
                typeof(Language),
                LanguageMenu.GetPopup().GetItemText(
                    LanguageMenu.Selected
                )
            );
            userPreferences.Fullscreen = FullscreenCheckbox.ButtonPressed;
            userPreferences.VSync = VSyncCheckbox.ButtonPressed;

            userPreferences.MasterVolume = (float)MasterVolumeSlider.Value / 100f;
            userPreferences.MusicVolume = (float)MusicVolumeSlider.Value / 100f;
            userPreferences.SoundVolume = (float)SoundVolumeSlider.Value / 100f;

            userPreferences.Resolution = _resolutions[ResolutionMenu.Selected];

            saveManager.SaveUserPreferences().Forget();
            userPreferences.Apply();

            UpdateUi(userPreferences);
        };

        CancelBtn.Pressed += Close;

        UpdateUi(saveManager.UserPreferences);
    }

    protected override void _OnPanelClose(bool closeArg)
    {
        base._OnPanelClose(closeArg);
        QueueFree();
    }

    private void UpdateUi(UserPreferences userPreferences)
    {
        LanguageMenu.Select((int)userPreferences.Language);
        ResolutionMenu.Select(
            Array.IndexOf(_resolutions, userPreferences.Resolution)
        );

        FullscreenCheckbox.ButtonPressed = userPreferences.Fullscreen;
        VSyncCheckbox.ButtonPressed = userPreferences.VSync;

        MasterVolumeSlider.Value = userPreferences.MasterVolume * 100f;
        MusicVolumeSlider.Value = userPreferences.MusicVolume * 100f;
        SoundVolumeSlider.Value = userPreferences.SoundVolume * 100f;
    }
}