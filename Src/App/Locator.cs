using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ZeroLog;

namespace Game.App;

public static class Locator
{
    private static Log Logger { get; } = LogManager.GetLogger("Locator");
    private static readonly Dictionary<Type, object> Services = new();

    public static void Register<T>(T serviceInstance) where T : class
    {
        Services[typeof(T)] = serviceInstance;
        var text = $"Service registered for type {typeof(T)}";
        Logger.Info(text);
    }

    public static T Get<T>() where T : class
    {
        if (!Services.TryGetValue(typeof(T), out var service))
        {
            var text = $"Service not found for type {typeof(T)}";
            Logger.Error(text);
            return null!;
        }
        return (T)service;
    }
    
    public static bool TryGet<T>([NotNullWhen(true)] out T? service) where T : class
    {
        if (Services.TryGetValue(typeof(T), out var service1))
        {
            service = (T)service1;
            return true;
        }
        
        service = null;
        return false;
    }

    public static void Reset()
    {
        Services.Clear();
    }
}