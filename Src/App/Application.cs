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

        Global.LaunchConfig = LaunchConfig.Parse(Environment.GetCommandLineArgs());

        if (Global.LaunchConfig.LogToFile)
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
            .ExecuteOnEntry(() => InBootSplash(Global.LaunchConfig))
            .On(Trigger.Next)
            .Goto(State.InStartMenu);

        builder.In(State.InStartMenu)
            .ExecuteOnEntry(() => InStartMenu(Global.LaunchConfig))
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
        Global.World.Destroy();

        GetTree().Quit();
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
        if (IsInstanceValid(Global.World)) Global.World.Destroy();
        if (IsInstanceValid(Global.Hud)) Global.Hud.Close();
        StateMachine.Fire(Trigger.ToStartMenu);
    }

    private void InBootSplash(LaunchConfig launchConfig)
    {
        if (launchConfig.SkipBootSplash)
        {
            _logger.Info("Has --SkipBootSplash");
            Global.Flags.Add("SkippedBootSplash");
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
            !Global.Flags.Contains("SkippedStartMenu"))
        {
            _logger.Info("Has --SkipStartMenu");
            Global.Flags.Add("SkippedStartMenu");
            StateMachine.Fire(Trigger.Next);
            return;
        }

        StartMenuScene
            .CreatePanel<StartMenu>()
            .OpenPanel();
    }
}