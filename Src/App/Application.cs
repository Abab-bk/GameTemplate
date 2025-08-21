using System;
using System.IO;
using Game.Extensions;
using Game.Persistent;
using Game.Ui;
using GDPanelFramework;
using GDPanelFramework.Panels.Tweener;
using Godot;
using GodotTask;
using Stateless;
using ZeroLog;
using ZeroLog.Appenders;
using ZeroLog.Configuration;
using ZeroLog.Formatting;
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
    private static Log _logger = default!;

    private PackedScene BootSplashScene { get; set; } = default!;
    private PackedScene StartMenuScene { get; set; } = default!;

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
                    new ConsoleAppender()
                    {
                        Formatter = formatter
                    }
                }
            }
        };

        var launchConfig = LaunchConfig.Parse(Environment.GetCommandLineArgs());

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

        _stateMachine = new StateMachine<State, Trigger>(State.Unknown);

        _stateMachine.Configure(State.Unknown)
            .Permit(Trigger.Next, State.Booting);

        _stateMachine.Configure(State.Booting)
            .Permit(Trigger.Next, State.InBootSplash)
            .OnEntry(() => { Booting().Forget(); });

        _stateMachine.Configure(State.InBootSplash)
            .Permit(Trigger.Next, State.InStartMenu)
            .OnEntry(() => InBootSplash(launchConfig));

        _stateMachine.Configure(State.InStartMenu)
            .Permit(Trigger.Next, State.InGame)
            .Permit(Trigger.ToEnd, State.End)
            .Permit(Trigger.ToGame, State.InGame)
            .OnEntry(() => InStartMenu(launchConfig));

        _stateMachine.Configure(State.InGame)
            .Permit(Trigger.ToEnd, State.End)
            .Permit(Trigger.ToStartMenu, State.InStartMenu)
            .OnEntry(InGame);

        _stateMachine.Configure(State.End)
            .OnEntry(() =>
            {
                LogManager.Shutdown();
                GetTree().Quit();
            });

        _stateMachine.OnTransitionCompleted(transition =>
        {
            _logger.Info(
                $"Transitioned from {transition.Source.ToString()} to {transition.Destination.ToString()}"
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
        AddChild(
            new SaveManager(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves"),
                new FileSaveSystem()
                )
            );

        await Global.SaveManager.LoadUserPreferencesAsync();
        Global.SaveManager.ApplyUserPreferences();

        PanelManager.DefaultPanelTweener = new FadePanelTweener();

        BootSplashScene = Wizard.LoadPackedScene(BootSplash.TscnFilePath);
        StartMenuScene = Wizard.LoadPackedScene(StartMenu.TscnFilePath);

        AddChild(new SoundsManager());

        await _stateMachine.FireAsync(Trigger.Next);
    }

    public void Quit()
    {
        _stateMachine.Fire(Trigger.ToEnd);
    }

    public void StartGame()
    {
        _stateMachine.Fire(Trigger.ToGame);
    }

    public void BackToStartMenu()
    {
        if (IsInstanceValid(Global.World)) Global.World.Destroy();
        if (IsInstanceValid(Global.Hud)) Global.Hud.Close();
        _stateMachine.Fire(Trigger.ToStartMenu);
    }

    private void InBootSplash(LaunchConfig launchConfig)
    {
        if (launchConfig.SkipBootSplash)
        {
            _logger.Info("Has --SkipBootSplash");
            Global.Flags.Add("SkippedBootSplash");
            _stateMachine.Fire(Trigger.Next);
            return;
        }

        BootSplashScene
            .CreatePanel<BootSplash>()
            .OpenPanel(
                () => { _stateMachine.Fire(Trigger.Next); }
            );
    }

    private void InStartMenu(LaunchConfig launchConfig)
    {
        if (launchConfig.SkipStartMenu &&
            !Global.Flags.Contains("SkippedStartMenu"))
        {
            _logger.Info("Has --SkipStartMenu");
            Global.Flags.Add("SkippedStartMenu");
            _stateMachine.Fire(Trigger.Next);
            return;
        }

        StartMenuScene
            .CreatePanel<StartMenu>()
            .OpenPanel();
    }
}