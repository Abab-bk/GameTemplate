using Microsoft.Extensions.Logging;

namespace Game.Scripts;

public static class Logger
{
    public static void Log(string message)
    {
        Global.Logger.Log(LogLevel.Information, message);
    }
    
    public static void LogError(string message)
    {
        Global.Logger.Log(LogLevel.Error, message);
    }
}