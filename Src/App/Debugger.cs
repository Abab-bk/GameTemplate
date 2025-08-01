﻿using Godot;
using ImGuiGodot;
using ImGuiNET;

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
        ImGui.Text($"Paused: {Global.IsPaused}");
        ImGui.End();
    }
#endif
}