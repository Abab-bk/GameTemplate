using System;

namespace Game.Scripts;

public static class EventBus
{
    public static Action
        RequestBackToStartMenu,
        RequestSaveAppSaver,
        RequestSaveGameSave,
        RequestStartGame,
        RequestQuitGame;
    public static Action<int> PauseCountChanged;
}