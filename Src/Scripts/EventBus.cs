using System;

namespace Game.Scripts;

public static class EventBus
{
    public static Action
        RequestSaveAppSaver,
        RequestStartGame,
        RequestQuitGame;
}