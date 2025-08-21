using System;
using MemoryPack;

namespace Game.Persistent.Models;

[MemoryPackable]
public partial class GameSave : ISavableModel
{
    public event Action? OnTryApplyChanged;

    public void Apply()
    {
        OnTryApplyChanged?.Invoke();
    }
}