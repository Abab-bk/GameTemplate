using System;

namespace Game.App;

public static class EventBus
{
    public static Action
        RequestBackToStartMenu = delegate { },
        RequestStartGame = delegate { },
        RequestQuitGame = delegate { };
    public static readonly Action<int> PauseCountChanged = delegate { };
}