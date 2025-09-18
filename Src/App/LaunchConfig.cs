using System;
using System.Linq;

namespace Game.App;

public record LaunchConfig(
    bool SkipStartMenu,
    bool SkipBootSplash,
    bool LogToFile
)
{
    public static LaunchConfig Parse(string[] args)
    {
        return new LaunchConfig(
            HasArg("--SkipStartMenu"),
            HasArg("--SkipBootSplash"),
            HasArg("--LogToFile")
        );

        bool HasArg(string arg)
        {
            return args.Any(a => a.Equals(arg, StringComparison.OrdinalIgnoreCase));
        }
    }
}