using System;
using Godot;

namespace AcidUtilities;

public static class NodeExtension
{
    /// <summary>
    /// 查找有没有相同类型子节点，返回第一个，不深入查询（只查直接的子节点）
    /// </summary>
    /// <param name="node"></param>
    /// <param name="result"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool FindNode<T>(this Node node, out T result) where T : Node
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

        return null;
    }

    public static void RemoveAllChildren(this Node node)
    {
        foreach (var child in node.GetChildren())
        {
            child.QueueFree();
        }
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