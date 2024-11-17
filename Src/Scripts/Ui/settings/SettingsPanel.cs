using System;
using Game.Scripts.Enums;
using Game.Scripts.Models;

namespace Game.Scripts.Ui.Settings;

public partial class SettingsPanel : Settings
{
    private UserPreferences _userPreferences;

    public override void _Ready()
    {
        var languagePopupMenu = S_LanguageMenu.Instance.GetPopup();
        foreach (var name in Enum.GetNames<Language>())
        {
            languagePopupMenu.AddItem(
                name,
                (int)Enum.Parse(typeof(Language), name)
                );
        }

        var resolutionPopupMenu = S_ResolutionMenu.Instance.GetPopup();
        foreach (var resolution in Data.Constants.Resolutions)
        {
            resolutionPopupMenu.AddItem(
                resolution.ToString(),
                Array.IndexOf(Data.Constants.Resolutions, resolution)
                );
        }

        S_ConfirmBtn.Instance.Pressed += () =>
        {
            _userPreferences.Language = (Language)Enum.Parse(
                typeof(Language),
                S_LanguageMenu.Instance.GetPopup().GetItemText(
                    S_LanguageMenu.Instance.Selected
                    )
                );
            _userPreferences.Fullscreen = S_FullscreenCheckbox.Instance.ButtonPressed;
            _userPreferences.VSync = S_VSyncCheckbox.Instance.ButtonPressed;
            
            _userPreferences.MasterVolume = (float)S_MasterVolumeSlider.Instance.Value / 100f;
            _userPreferences.MusicVolume = (float)S_MusicVolumeSlider.Instance.Value / 100f;
            _userPreferences.SoundVolume = (float)S_SoundVolumeSlider.Instance.Value / 100f;
            
            EventBus.RequestSaveAppSaver?.Invoke();
            
            UpdateUi();
        };

        S_CancelBtn.Instance.Pressed += Destroy;
    }

    public void Load(UserPreferences userPreferences)
    {
        _userPreferences = userPreferences;
        UpdateUi();
    }

    private void UpdateUi()
    {
        S_LanguageMenu.Instance.Select((int)_userPreferences.Language);
        S_ResolutionMenu.Instance.Select(
            Array.IndexOf(Data.Constants.Resolutions, _userPreferences.Resolution)
            );
        
        S_FullscreenCheckbox.Instance.ButtonPressed = _userPreferences.Fullscreen;
        S_VSyncCheckbox.Instance.ButtonPressed = _userPreferences.VSync;
        
        S_MasterVolumeSlider.Instance.Value = _userPreferences.MasterVolume * 100f;
        S_MusicVolumeSlider.Instance.Value = _userPreferences.MusicVolume * 100f;
        S_SoundVolumeSlider.Instance.Value = _userPreferences.SoundVolume * 100f;
    }
}
