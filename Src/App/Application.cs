using System;
using System.IO;
using System.Linq;
using AcidWallStudio;
using Game.Commons;
using Game.Persistent;
using Game.Ui;
using GDPanelFramework;
using GDPanelFramework.Panels.Tweener;
using Godot;
using GodotTask;
using Microsoft.Extensions.Logging;
using Stateless;
using ZLogger;
using Environment = System.Environment;

namespace Game.App;

public partial class Application : Node2D
{
    private enum State
    {
        Unknown,
        Booting,
        InBootSplash,
        InStartMenu,
        InGame,
        End
    }
    
    private enum Trigger
    {
        Next,
        ToGame,
        ToStartMenu,
        ToEnd
    }
    
    private StateMachine<State, Trigger> _stateMachine = default!;
    private ILogger<Application> _logger = default!;
    
    private PackedScene BootSplashScene { get; set; } = default!;
    private PackedScene StartMenuScene { get; set; } = default!;
    
    public override void _Ready()
    {
        LogManager.SetLoggerFactory(LoggerFactory
            .Create(logging =>
            {
                logging.AddZLoggerConsole(options =>
                {
                    options.UsePlainTextFormatter(formatter =>
                    {
                        formatter.SetPrefixFormatter(
                            $"[{0:local-timeonly}] [{1}] [{2}] ",
                            (in MessageTemplate template, in LogInfo info) =>
                                template.Format(info.Timestamp, info.LogLevel, info.Category)
                                );
                    });
                });
                
                if (!Environment.GetCommandLineArgs().Contains("--LogToFile")) return;
                var filePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    ".Logs/GameLog.log"
                );
                logging.AddZLoggerFile(
                    filePath,
                    options =>
                    {
                        options.UsePlainTextFormatter(formatter =>
                        {
                            formatter.SetPrefixFormatter(
                                $"[{0:local-timeonly}] [{1}] [{2}] ",
                                (in MessageTemplate template, in LogInfo info) =>
                                    template.Format(info.Timestamp, info.LogLevel, info.Category)
                            );
                        });
                    }
                );
            }));
        
        _logger = LogManager.GetLogger<Application>();
        
        _stateMachine = new StateMachine<State, Trigger>(State.Unknown);

        _stateMachine.Configure(State.Unknown)
            .Permit(Trigger.Next, State.Booting);
        
        _stateMachine.Configure(State.Booting)
            .Permit(Trigger.Next, State.InBootSplash)
            .OnEntry(() => { Booting().Forget(); });
        
        _stateMachine.Configure(State.InBootSplash)
            .Permit(Trigger.Next, State.InStartMenu)
            .OnEntry(InBootSplash);

        _stateMachine.Configure(State.InStartMenu)
            .Permit(Trigger.Next, State.InGame)
            .Permit(Trigger.ToEnd, State.End)
            .Permit(Trigger.ToGame, State.InGame)
            .OnEntry(InStartMenu);

        _stateMachine.Configure(State.InGame)
            .Permit(Trigger.ToEnd, State.End)
            .Permit(Trigger.ToStartMenu, State.InStartMenu)
            .OnEntry(InGame);
        
        _stateMachine.Configure(State.End)
            .OnEntry(() => { GetTree().Quit(); });
        
        _stateMachine.OnTransitionCompleted(transition =>
        {
            _logger.ZLogInformation(
                $"Transitioned from {transition.Source} to {transition.Destination}"
                );
        });
        
        _stateMachine.Fire(Trigger.Next);
    }

    private void InGame()
    {
        AddChild(Wizard.Instantiate<World>(World.TscnFilePath));
    }

    private async GDTask Booting()
    {
        Global.Application = this;
        AddChild(new SaveManager(new FileSaveSystem()));
        
        await SaveManager.Instance.LoadUserPreferencesAsync();
        SaveManager.Instance.ApplyUserPreferences();
        
        PanelManager.DefaultPanelTweener = new FadePanelTweener();
        
        BootSplashScene = Wizard.LoadPackedScene(BootSplash.TscnFilePath);
        StartMenuScene = Wizard.LoadPackedScene(StartMenu.TscnFilePath);
        
        AddChild(new SoundsManager());
        
        await _stateMachine.FireAsync(Trigger.Next);
    }

    public void Quit() => _stateMachine.Fire(Trigger.ToEnd);
    public void StartGame() => _stateMachine.Fire(Trigger.ToGame);

    public void BackToStartMenu()
    {
        if (IsInstanceValid(Global.World)) Global.World.Destroy();
        if (IsInstanceValid(Global.Hud)) Global.Hud.Close();
        _stateMachine.Fire(Trigger.ToStartMenu);
    }

    private void InBootSplash()
    {
        if (Environment.GetCommandLineArgs().Contains("--SkipBootSplash"))
        {
            _logger.ZLogInformation($"Has --SkipBootSplash");
            Global.Flags.Add("SkippedBootSplash");
            _stateMachine.Fire(Trigger.Next);
            return;
        }

        BootSplashScene
            .CreatePanel<BootSplash>()
            .OpenPanel(
                onPanelCloseCallback:
                () =>
                {
                    _stateMachine.Fire(Trigger.Next);
                }
            );
    }
    
    private void InStartMenu()
    {
        if (Environment.GetCommandLineArgs().Contains("--SkipStartMenu") &&
            !Global.Flags.Contains("SkippedStartMenu"))
        {
            _logger.ZLogInformation($"Has --SkipStartMenu");
            Global.Flags.Add("SkippedStartMenu");
            _stateMachine.Fire(Trigger.Next);
            return;
        }
        
        StartMenuScene
            .CreatePanel<StartMenu>()
            .OpenPanel();
    }
}
