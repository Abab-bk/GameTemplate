using Game.Scripts.Classes;
using Godot;

namespace Game.Scripts;

public partial class World : Node2D
{
    private StateMachine _stateMachine;
    
    public override void _Ready()
    {
        _stateMachine = new StateMachine(GetNode("StateMachinePlayer"), "WorldState");

        _stateMachine.OnTransition += OnStateMachineTransition;
        _stateMachine.OnUpdate += OnStateMachineUpdate;
        
        _stateMachine.SetTrigger("ToPreBoot");
    }
    
    private void OnStateMachineUpdate(string state, float delta)
    {
    }

    private void OnStateMachineTransition(string from, string to)
    {
        switch (to)
        {
            case "PreBoot":
                Global.World = this;
                _stateMachine.SetTrigger("ToBooting");
                break;
            case "Booting":
                _stateMachine.SetTrigger("ToInitGame");
                break;
            case "InitGame":
#if IMGUI
                AddChild(new Debugger());
#endif
                _stateMachine.SetTrigger("ToInGame");
                break;
            case "InGame":
                break;
            case "End":
                break;
        }
    }
}
