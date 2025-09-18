using System;
using System.IO;
using Appccelerate.StateMachine;
using Appccelerate.StateMachine.Machine;
using Game.Extensions;
using Game.Persistent;
using Game.Ui;
using GDPanelFramework;
using GDPanelFramework.Panels.Tweener;
using Godot;
using GodotTask;
using ZeroLog;
using ZeroLog.Appenders;
using ZeroLog.Configuration;
using ZeroLog.Formatting;
using Environment = System.Environment;

namespace Game.App;

public partial class Application : Node2D
{
    private bool _isSkippingBootSplash;
    private bool _isSkippingStartMenu;
    
    private enum State
    {
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

    private PassiveStateMachine<State, Trigger> StateMachine { get; set; } = null!;

    private static Log _logger = null!;

    private PackedScene BootSplashScene { get; set; } = null!;
    private PackedScene StartMenuScene { get; set; } = null!;

    public override void _Ready()
    {
        var formatter = new DefaultFormatter
        {
            PrefixPattern = "[%level] [%logger] "
        };

        var logConfig = new ZeroLogConfiguration
        {
            RootLogger =
            {
                Appenders =
                {
                    new ConsoleAppender
                    {
                        Formatter = formatter
                    }
                }
            }
        };

        var launchConfig = LaunchConfig.Parse(Environment.GetCommandLineArgs());
        Locator.Register(launchConfig);

        if (launchConfig.LogToFile)
        {
            var dir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                ".Logs"
            );
            logConfig.RootLogger.Appenders.Add(new DateAndSizeRollingFileAppender(dir)
            {
                Formatter = formatter
            });
        }
        
        LogManager.Initialize(logConfig);

        _logger = LogManager.GetLogger<Application>();

        var builder = new StateMachineDefinitionBuilder<State, Trigger>();

        builder.In(State.Booting)
            .ExecuteOnEntry(() => Booting().Forget())
            .On(Trigger.Next)
            .Goto(State.InBootSplash);

        builder.In(State.InBootSplash)
            .ExecuteOnEntry(() => InBootSplash(Locator.Get<LaunchConfig>()))
            .On(Trigger.Next)
            .Goto(State.InStartMenu);

        builder.In(State.InStartMenu)
            .ExecuteOnEntry(() => InStartMenu(Locator.Get<LaunchConfig>()))
            .On(Trigger.Next)
            .Goto(State.InGame)
            .On(Trigger.ToEnd)
            .Goto(State.End)
            .On(Trigger.ToGame)
            .Goto(State.InGame);

        builder.In(State.InGame)
            .ExecuteOnEntry(InGame)
            .On(Trigger.ToEnd)
            .Goto(State.End)
            .On(Trigger.ToStartMenu)
            .Goto(State.InStartMenu);

        builder.In(State.End).ExecuteOnEntry(InEnd);

        builder.WithInitialState(State.Booting);

        StateMachine = builder.Build().CreatePassiveStateMachine();

        StateMachine.TransitionCompleted += (_, transition) =>
        {
            _logger.Info(
                $"Transitioned from {transition.StateId.ToString()} to {transition.NewStateId.ToString()}"
            );
        };

        StateMachine.Start();
    }

    private void InEnd()
    {
        GetTree().Root.PropagateNotification((int)NotificationWMCloseRequest);
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what != NotificationWMCloseRequest) return;

        LogManager.Shutdown();
        Locator.Get<World>().Destroy();

        GetTree().Quit();
    }

    private void InGame()
    {
        var world = Wizard.Instantiate<World>(World.TscnFilePath);
        Locator.Register(world);
        AddChild(world);
    }

    private async GDTask Booting()
    {
        Locator.Register(this);
        var saveManager = new SaveManager(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves"),
            new FileSaveSystem()
        );
        AddChild(saveManager);

        await saveManager.LoadUserPreferencesAsync();
        saveManager.ApplyUserPreferences();

        PanelManager.DefaultPanelTweener = new FadePanelTweener();

        BootSplashScene = Wizard.LoadPackedScene(BootSplash.TscnFilePath);
        StartMenuScene = Wizard.LoadPackedScene(StartMenu.TscnFilePath);

        var soundsManager = new SoundsManager();
        AddChild(soundsManager);

        StateMachine.Fire(Trigger.Next);
    }

    public void Quit()
    {
        StateMachine.Fire(Trigger.ToEnd);
    }

    public void StartGame()
    {
        StateMachine.Fire(Trigger.ToGame);
    }

    public void BackToStartMenu()
    {
        var world = Locator.Get<World>();
        if (IsInstanceValid(world)) world.Destroy();
        if (IsInstanceValid(Locator.Get<Hud>())) Locator.Get<Hud>().Close();
        StateMachine.Fire(Trigger.ToStartMenu);
    }

    private void InBootSplash(LaunchConfig launchConfig)
    {
        if (launchConfig.SkipBootSplash)
        {
            _logger.Info("Has --SkipBootSplash");
            _isSkippingBootSplash = true;
            StateMachine.Fire(Trigger.Next);
            return;
        }

        BootSplashScene
            .CreatePanel<BootSplash>()
            .OpenPanel(() => { StateMachine.Fire(Trigger.Next); }
            );
    }

    private void InStartMenu(LaunchConfig launchConfig)
    {
        if (launchConfig.SkipStartMenu &&
            !_isSkippingStartMenu)
        {
            _logger.Info("Has --SkipStartMenu");
            _isSkippingStartMenu = true;
            StateMachine.Fire(Trigger.Next);
            return;
        }

        StartMenuScene
            .CreatePanel<StartMenu>()
            .OpenPanel();
    }
    
    
    private int _pauseCount;
    public bool IsPaused => _pauseCount > 0;

    public void TryPause()
    {
        _pauseCount++;
        GetTree().Paused = _pauseCount > 0;
    }

    public void TryResume()
    {
        _pauseCount--;
        GetTree().Paused = _pauseCount > 0;
    }
}