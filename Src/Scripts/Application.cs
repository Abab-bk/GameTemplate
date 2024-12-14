using System.Linq;
using DsUi;
using Game.Scripts.Classes;
using Game.Scripts.Configs;
using Game.Scripts.Models;
using Godot;
using Linguini.Shared.Types.Bundle;
using Environment = System.Environment;

namespace Game.Scripts;

public partial class Application : Node2D
{
    private StateMachine _stateMachine;
    
    public override void _Ready()
    {
        _stateMachine = new StateMachine(GetNode("StateMachinePlayer"), "ApplicationState");

        _stateMachine.OnTransition += OnStateMachineTransition;
        
        _stateMachine.SetTrigger("ToPreBoot");
        
        EventBus.RequestQuitGame += () => _stateMachine.SetTrigger("ToEnd");
        EventBus.RequestStartGame += () => _stateMachine.SetTrigger("ToInGame");
        EventBus.RequestBackToStartMenu += () =>
        {
            if (Global.World != null)
            {
                Global.World.Destroy();
            }

            _stateMachine.SetTrigger("ToStartMenu");
        };
    }
    
    private void OnStateMachineTransition(string from, string to)
    {
        switch (to)
        {
            case "PreBoot":
                Global.Application = this;

                Global.AppSaver = new AppSaver();
                Global.AppSaver.Load();
                
                _stateMachine.SetTrigger("ToBooting");
                break;
            case "Booting":
                // load language resources
                Translator.Setup();
                Translator.LanguageChanged += language =>
                {
                    UiManager
                        .Open_Modal()
                        .Config(new ModalConfig(
                            Translator.GetMessage("language_changed"),
                            Translator.GetAttrMessage(
                                "language_changed_text",
                                ("language", (FluentString)language.ToString())
                                ),
                            () =>
                            {
                                EventBus.RequestQuitGame?.Invoke();
                            }
                        ));
                };
                
                _stateMachine.SetTrigger("ToInitGame");
                break;
            case "InitGame":
#if IMGUI
                AddChild(new Debugger());
#endif
                _stateMachine.SetTrigger("ToBootSplash");
                break;
            case "InBootSplash":
                if (
                    Environment.GetCommandLineArgs().Contains("--SkipBootSplash")
                )
                {
                    Logger.Log("[Application] Has --SkipBootSplash");
                    Global.Flags.Add("SkippedBootSplash");
                    _stateMachine.SetTrigger("ToStartMenu");
                    return;
                }

                UiManager.Open_BootSplash().OnDestroyUiEvent += () =>
                {
                    _stateMachine.SetTrigger("ToStartMenu");
                };
                
                break;
            case "InStartMenu":
                if (
                    Environment.GetCommandLineArgs().Contains("--SkipStartMenu") &&
                    !Global.Flags.Contains("SkippedStartMenu")
                    )
                {
                    Logger.Log("[Application] Has --SkipStartMenu");
                    Global.Flags.Add("SkippedStartMenu");
                    _stateMachine.SetTrigger("ToInGame");
                    return;
                }
                UiManager.Open_StartMenu();
                break;
            case "InGame":
                UiManager.Destroy_StartMenu();
                AddChild(GD
                        .Load<PackedScene>("res://Scenes/World.tscn")
                        .Instantiate()
                );
                break;
            case "End":
                GetTree().Quit();
                break;
        }
    }
    
    public void ApplyUserPreferences(UserPreferences userPreferences)
    {
        AudioServer.SetBusVolumeDb(0, Mathf.LinearToDb(userPreferences.MasterVolume / 100f));
        AudioServer.SetBusVolumeDb(1, Mathf.LinearToDb(userPreferences.SoundVolume / 100f));
        AudioServer.SetBusVolumeDb(2, Mathf.LinearToDb(userPreferences.MusicVolume / 100f));
        
        if (DisplayServer.WindowGetMode() != userPreferences.GetWindowMode())
            DisplayServer.WindowSetMode(userPreferences.GetWindowMode());
        
        if (DisplayServer.WindowGetVsyncMode() != userPreferences.GetVSyncMode())
            DisplayServer.WindowSetVsyncMode(userPreferences.GetVSyncMode());
        
        if (DisplayServer.WindowGetSize() != userPreferences.Resolution)
            DisplayServer.WindowSetSize(userPreferences.Resolution);

        if (TranslationServer.GetLocale() != Utils.GetLanguageLocaleCode(userPreferences.Language))
        {
            TranslationServer.SetLocale(Utils.GetLanguageLocaleCode(userPreferences.Language));
            Translator.ChangeLanguage(userPreferences.Language);
        }
    }
}
