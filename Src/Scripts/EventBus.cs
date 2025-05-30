using System;

namespace Game.Scripts;

public static class EventBus
{
    public static Action
        RequestBackToStartMenu = delegate { },
        RequestSaveAppSaver = delegate { },
        RequestSaveGameSave = delegate { },
        RequestStartGame = delegate { },
        RequestQuitGame = delegate { };
    public static readonly Action<int> PauseCountChanged = delegate { };
}