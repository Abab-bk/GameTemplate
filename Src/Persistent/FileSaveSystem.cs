using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using GodotTask;
using MemoryPack;
using ZeroLog;

namespace Game.Persistent;

public class FileSaveSystem : ISaveSystem
{
    private static Log Logger { get; } = LogManager.GetLogger<FileSaveSystem>();

    public IReadOnlyList<SaveSlot> ListSlots()
    {
        throw new System.NotImplementedException();
    }

    public async GDTask<T?> LoadAsync<
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
        T>(string filePath) where T : ISavableModel
    {
        await using var stream = new FileStream(filePath, FileMode.Open);
        Logger.Info($"Loading {filePath}");
        return await MemoryPackSerializer.DeserializeAsync<T>(stream);
    }

    public async GDTask SaveAsync<T>(string filePath, T data) where T : ISavableModel
    {
        var writer = new ArrayBufferWriter<byte>();
        MemoryPackSerializer.Serialize(in writer, in data);
        Logger.Info($"Saving {filePath}");
        await File.WriteAllBytesAsync(filePath, writer.WrittenMemory.ToArray());
    }

    public GDTask DeleteAsync(string filePath)
    {
        throw new System.NotImplementedException();
    }

    public bool Exists(string filePath)
    {
        return File.Exists(filePath);
    }
}