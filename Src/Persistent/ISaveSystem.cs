using System.Collections.Generic;
using GodotTask;

namespace Game.Persistent;

public interface ISaveSystem
{
    IReadOnlyList<SaveSlot> ListSlots();

    GDTask<T?> LoadAsync<T>(string filePath) where T : ISavableModel;

    GDTask SaveAsync<T>(string filePath, T data) where T : ISavableModel;

    GDTask DeleteAsync(string filePath);

    bool Exists(string filePath);
}