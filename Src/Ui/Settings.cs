using System;
using DataBase;
using Game.Scripts;
using Game.Scripts.I18n;
using Game.Scripts.Models;
using GDPanelFramework.Panels;
using Godot;

namespace Game.Ui;

[SceneTree]
public partial class Settings : UIPanel
{
    private UserPreferences UserPreferences { get; set; } = default!;

    private string Vector2ToString(Vector2 vector2) => $"{vector2.X} * {vector2.Y}";

    protected override void _OnPanelInitialize()
    {
        base._OnPanelInitialize();
        var languagePopupMenu = LanguageMenu.GetPopup();
        foreach (var name in Enum.GetNames<Language>())
        {
            languagePopupMenu.AddItem(
                name,
                (int)Enum.Parse(typeof(Language), name)
            );
        }

        var resolutionPopupMenu = ResolutionMenu.GetPopup();
        foreach (var resolution in Data.Constants.Resolutions)
        {
            resolutionPopupMenu.AddItem(
                Vector2ToString(resolution),
                Array.IndexOf(Data.Constants.Resolutions, resolution)
            );
        }

        ConfirmBtn.Pressed += () =>
        {
            UserPreferences.Language = (Language)Enum.Parse(
                typeof(Language),
                LanguageMenu.GetPopup().GetItemText(
                    LanguageMenu.Selected
                )
            );
            UserPreferences.Fullscreen = FullscreenCheckbox.ButtonPressed;
            UserPreferences.VSync = VSyncCheckbox.ButtonPressed;
            
            UserPreferences.MasterVolume = (float)MasterVolumeSlider.Value / 100f;
            UserPreferences.MusicVolume = (float)MusicVolumeSlider.Value / 100f;
            UserPreferences.SoundVolume = (float)SoundVolumeSlider.Value / 100f;
            
            UserPreferences.Resolution = (Vector2I)Data.Constants.Resolutions[ResolutionMenu.Selected];
            
            EventBus.RequestSaveAppSaver.Invoke();
            UserPreferences.Apply();
            
            UpdateUi();
        };

        CancelBtn.Pressed += ClosePanel;
    }

    public Settings Load(UserPreferences userPreferences)
    {
        UserPreferences = userPreferences;
        UpdateUi();
        return this;
    }

    private void UpdateUi()
    {
        LanguageMenu.Select((int)UserPreferences.Language);
        ResolutionMenu.Select(
            Array.IndexOf(Data.Constants.Resolutions, UserPreferences.Resolution)
            );
        
        FullscreenCheckbox.ButtonPressed = UserPreferences.Fullscreen;
        VSyncCheckbox.ButtonPressed = UserPreferences.VSync;
        
        MasterVolumeSlider.Value = UserPreferences.MasterVolume * 100f;
        MusicVolumeSlider.Value = UserPreferences.MusicVolume * 100f;
        SoundVolumeSlider.Value = UserPreferences.SoundVolume * 100f;
    }

    protected override void _OnPanelOpen()
    {
    }
}
