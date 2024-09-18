using Godot;
using ImGuiGodot;
using ImGuiNET;

namespace Game.Scripts;

public partial class Debugger : Node
{
#if IMGUI
    public override void _Ready()
    {
        ImGuiGD.Connect(OnImGuiLayout);
    }
    
    private void OnImGuiLayout()
    {
        ImGui.Begin("Debugger");
        ImGui.End();
    }
#endif
}