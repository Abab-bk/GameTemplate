using System;
using DataBase;
using Game.Persistent;
using Game.Scripts.I18n;
using GDPanelFramework.Panels;
using Godot;
using GodotTask;
using UserPreferences = Game.Persistent.Models.UserPreferences;

namespace Game.Ui;

[SceneTree]
public partial class Settings : UIPanelArg<UserPreferences, bool>
{
    private string Vector2ToString(Vector2 vector2) => $"{vector2.X} * {vector2.Y}";
    
    private void Close() => ClosePanel(true);

    protected override void _OnPanelOpen(UserPreferences openArg)
    {
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
            openArg.Language = (Language)Enum.Parse(
                typeof(Language),
                LanguageMenu.GetPopup().GetItemText(
                    LanguageMenu.Selected
                )
            );
            openArg.Fullscreen = FullscreenCheckbox.ButtonPressed;
            openArg.VSync = VSyncCheckbox.ButtonPressed;
            
            openArg.MasterVolume = (float)MasterVolumeSlider.Value / 100f;
            openArg.MusicVolume = (float)MusicVolumeSlider.Value / 100f;
            openArg.SoundVolume = (float)SoundVolumeSlider.Value / 100f;
            
            openArg.Resolution = (Vector2I)Data.Constants.Resolutions[ResolutionMenu.Selected];
            
            SaveManager.Instance.SaveUserPreferences().Forget();
            openArg.Apply();
            
            UpdateUi(openArg);
        };

        CancelBtn.Pressed += Close;
        
        UpdateUi(openArg);
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
            Array.IndexOf(Data.Constants.Resolutions, userPreferences.Resolution)
            );
        
        FullscreenCheckbox.ButtonPressed = userPreferences.Fullscreen;
        VSyncCheckbox.ButtonPressed = userPreferences.VSync;
        
        MasterVolumeSlider.Value = userPreferences.MasterVolume * 100f;
        MusicVolumeSlider.Value = userPreferences.MusicVolume * 100f;
        SoundVolumeSlider.Value = userPreferences.SoundVolume * 100f;
    }
}
