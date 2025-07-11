using Microsoft.Extensions.Logging;

namespace Game.Commons;

public static class LogManager
{
    private static ILoggerFactory _loggerFactory = default!;
    private static ILogger _globalLogger = default!;
    public static ILogger Logger => _globalLogger;
    
    public static void SetLoggerFactory(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
        _globalLogger = loggerFactory.CreateLogger("Global");
    }
    
    public static ILogger<T> GetLogger<T>() where T : class => _loggerFactory.CreateLogger<T>();
    public static ILogger GetLogger(string categoryName) => _loggerFactory.CreateLogger(categoryName);
}