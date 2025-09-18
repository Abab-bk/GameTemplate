using System;
using Godot;

namespace Game.Extensions;

public static class NodeExtension
{
    public static void ForeachChild<T>(this T node, Action<T> action) where T : Node
    {
        foreach (var child in node.GetChildren())
        {
            if (child is not T t) continue;
            action(t);
        }
    }

    public static void ForeachChild(this Node node, Action<Node> action)
        => ForeachChild<Node>(node, action);

    public static bool FindNode<T>(this Node node, out T? result) where T : Node
    {
        foreach (var child in node.GetChildren())
        {
            if (child is not T t) continue;
            result = t;
            return true;
        }

        result = null;
        return false;
    }

    public static T FindNode<T>(this Node node) where T : Node
    {
        foreach (var child in node.GetChildren())
        {
            if (child is not T t) continue;
            return t;
        }

        return null!;
    }

    public static void RemoveAllChildren(this Node node)
    {
        foreach (var child in node.GetChildren()) child.QueueFree();
    }

    public static void RemoveAllChildren<T>(this Node node, Action<T> action) where T : Node
    {
        foreach (var child in node.GetChildren())
        {
            if (child is not T t) continue;
            action(t);
            child.QueueFree();
        }
    }
}