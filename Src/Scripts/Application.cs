using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DsUi;
using Game.Scripts.Common;
using Game.Scripts.Models;
using Godot;
using GodotTask;
using Microsoft.Extensions.Logging;
using ZLogger;
using Environment = System.Environment;

namespace Game.Scripts;

public partial class Application : Node2D
{
    private HFSM _stateMachine;
    private ILogger<Application> _logger;
    
    private class GodotLoggerProcessor : IAsyncLogProcessor
    {
        public ValueTask DisposeAsync() => default;

        public void Post(IZLoggerEntry log)
        {
            GD.Print($"[{log.LogInfo.LogLevel}] [{log.LogInfo.Category}] {log.ToString()}");
            log.Return();
        }
    }
    
    public override void _Ready()
    {
        LogManager.SetLoggerFactory(LoggerFactory
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
            }));

        _logger = LogManager.GetLogger<Application>();

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
        _logger.ZLogInformation($"[Application]: {from.GetName()} -> {to.GetName()}");
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
                    _logger.ZLogInformation($"Has --SkipBootSplash");
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
                    _logger.ZLogInformation($"Has --SkipStartMenu");
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
        }
    }
}
