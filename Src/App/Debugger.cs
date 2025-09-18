using Godot;

#if IMGUI
using ImGuiGodot;
using ImGuiNET;
#endif

namespace Game.App;

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
        ImGui.Text($"Paused: {Locator.Get<Application>().IsPaused}");
        ImGui.End();
    }
#endif
}