using System;
using MessagePack;

namespace Game.Persistent.Models;

[MessagePackObject(true)]
public partial class GameSave : ISavableModel
{
    public event Action? OnTryApplyChanged;

    public void Apply()
    {
        OnTryApplyChanged?.Invoke();
    }
}