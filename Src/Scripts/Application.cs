using System.Linq;
using DsUi;
using Game.Scripts.Classes;
using Godot;
using Environment = System.Environment;

namespace Game.Scripts;

public partial class Application : Node2D
{
    private StateMachine _stateMachine;
    
    public override void _Ready()
    {
        _stateMachine = new StateMachine(GetNode("StateMachinePlayer"), "ApplicationState");

        _stateMachine.OnTransition += OnStateMachineTransition;
        _stateMachine.OnUpdate += OnStateMachineUpdate;
        
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
    
    private void OnStateMachineUpdate(string state, float delta)
    {
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
                _stateMachine.SetTrigger("ToInitGame");
                break;
            case "InitGame":
#if IMGUI
                AddChild(new Debugger());
#endif
                _stateMachine.SetTrigger("ToStartMenu");
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
                AddChild(new World());
                break;
            case "End":
                GetTree().Quit();
                break;
        }
    }
}
