using Godot;

namespace Game.Commons;

[LayerNames]
public static partial class Layers
{
    public static int GetLayer(int layer) => layer + 1;
}