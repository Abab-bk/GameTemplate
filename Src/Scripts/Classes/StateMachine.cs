using System;
using Godot;

namespace Game.Scripts.Classes;

public class StateMachine
{
    public event Action<string, string> OnTransition;
    // public event Action<string, float> OnUpdate;

    public string CurrentState => (string)_node.Get("current");
    
    private readonly Node _node;

    public StateMachine(Node node, string stateMachineName = "")
    {
        _node = node;
        
        _node.Connect("transited", Callable.From(
            (string from, string to) =>
            {
                Logger.Log($"[{stateMachineName}] state transitioned from {from} to {to}");
                OnTransition?.Invoke(from, to);
            }));
        // _node.Connect("updated", Callable.From(
        //     (string state, double delta) =>
        //     {
        //         OnUpdate?.Invoke(state, (float)delta);
        //     })
        // );
    }
    
    public void Start() => _node.Call("start");

    public void SetTrigger(string trigger)
    {
        _node.Call("set_trigger", trigger);
    }
}