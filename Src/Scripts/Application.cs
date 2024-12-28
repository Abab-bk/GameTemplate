using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DsUi;
using Game.Scripts.Classes;
using Game.Scripts.Configs;
using Game.Scripts.I18n;
using Game.Scripts.Models;
using Godot;
using GodotTask;
using Linguini.Shared.Types.Bundle;
using Microsoft.Extensions.Logging;
using ZLogger;
using Environment = System.Environment;

namespace Game.Scripts;

public partial class Application : Node2D
{
    private HFSM _stateMachine;
    
    private class GodotLoggerProcessor : IAsyncLogProcessor
    {
        public ValueTask DisposeAsync() => default;

        public void Post(IZLoggerEntry log)
        {
            GD.Print($"[{log.LogInfo.LogLevel}] {log.ToString()}");
            log.Return();
        }
    }
    
    public override void _Ready()
    {
        Global.Logger = LoggerFactory
            .Create(logging =>
            {
                logging.AddZLoggerLogProcessor(new GodotLoggerProcessor());

                if (OS.HasFeature("template"))
                {
                    if (!Environment.GetCommandLineArgs().Contains("--LogToFile")) return;
                    logging.AddZLoggerFile(Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        ".Logs/GameLog.log"
                    ));
                }
                else
                {
                    if (!Environment.GetCommandLineArgs().Contains("--LogToFile")) return;
                    logging.AddZLoggerFile(Path.Combine(
                        OS.GetUserDataDir(),
                        ".Logs/GameLog.log"
                    ));
                }
            })
            .CreateLogger("Application");

        _stateMachine = HFSMUtils.TryConvert<HFSM>(GetNode<Node>("HFSM"));

        if (_stateMachine == null)
            throw new Exception("Initialize Application state machine failed.");

        _stateMachine.Transited += OnStateMachineTransition;
        _stateMachine.SetTrigger("Next");
        
        EventBus.RequestQuitGame += () => _stateMachine.SetTrigger("ToEnd");
        EventBus.RequestStartGame += () => _stateMachine.SetTrigger("ToGame");
        EventBus.RequestBackToStartMenu += () =>
        {
            if (Global.World != null)
            {
                Global.World.Destroy();
            }

            _stateMachine.SetTrigger("ToStartMenu");
        };
    }
    
    private async void OnStateMachineTransition(State from, State to)
    {
        Logger.Log($"[Application]: {from.GetName()} -> {to.GetName()}");
        switch (to.GetName())
        {
            case "PreBoot":
                Global.Application = this;

                Global.AppSaver = new AppSaver();
                Global.AppSaver.Load();
                
                await GDTask.NextFrame();
                _stateMachine.SetTrigger("Next");
                
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
                
                await GDTask.NextFrame();
                _stateMachine.SetTrigger("Next");
                break;
            case "InitGame":
#if IMGUI
                AddChild(new Debugger());
#endif
                await GDTask.NextFrame();
                _stateMachine.SetTrigger("Next");
                break;
            case "InBootSplash":
                if (
                    Environment.GetCommandLineArgs().Contains("--SkipBootSplash")
                )
                {
                    Logger.Log("[Application] Has --SkipBootSplash");
                    Global.Flags.Add("SkippedBootSplash");
                    await GDTask.NextFrame();
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
                    await GDTask.NextFrame();
                    _stateMachine.SetTrigger("ToGame");
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
