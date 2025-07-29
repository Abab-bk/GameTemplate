using System;
using AcidWallStudio;
using Godot;

namespace AcidUtilities;

public class ScreenHelper
{
    public static float GetScreenCenterX()
    {
        return (float)ProjectSettings.GetSetting("display/window/size/viewport_width") / 2;
    }

    public static float GetScreenCenterY()
    {
        return (float)ProjectSettings.GetSetting("display/window/size/viewport_height") / 2;
    }

    public static Vector2 GetScreenCenter()
    {
        return new Vector2(
            (float)ProjectSettings.GetSetting("display/window/size/viewport_width") / 2,
            (float)ProjectSettings.GetSetting("display/window/size/viewport_height") / 2
        );
    }

    public static Vector2 GetRandomScreenPosition()
    {
        return new Vector2(
            Random.Shared.FloatRange(0f, (float)ProjectSettings.GetSetting("display/window/size/viewport_width")),
            Random.Shared.FloatRange(0f, (float)ProjectSettings.GetSetting("display/window/size/viewport_height"))
        );
    }

    public static float GetRandomScreenX()
    {
        return Random.Shared.FloatRange(0f, (float)ProjectSettings.GetSetting("display/window/size/viewport_width"));
    }

    public static float GetRandomScreenY()
    {
        return Random.Shared.FloatRange(0f, (float)ProjectSettings.GetSetting("display/window/size/viewport_height"));
    }

    public static float GetMaxScreenX()
    {
        return (float)ProjectSettings.GetSetting("display/window/size/viewport_width");
    }

    public static float GetMaxScreenY()
    {
        return (float)ProjectSettings.GetSetting("display/window/size/viewport_height");
    }
}