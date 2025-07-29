using System;
using MemoryPack;

namespace Game.Persistent.Models;

[MemoryPackable]
public partial class GameSave : ISavableModel
{
    public event Action TryApplyChanged = delegate { };

    public void Apply()
    {
        TryApplyChanged.Invoke();
    }
}