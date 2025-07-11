using System.Buffers;
using System.Collections.Generic;
using System.IO;
using Game.App;
using Game.Commons;
using Game.Persistent.Models;
using Game.Scripts;
using GodotTask;
using MemoryPack;
using Microsoft.Extensions.Logging;
using ZLogger;

namespace Game.Persistent;

public class FileSaveSystem : ISaveSystem
{
    private ILogger<FileSaveSystem> Logger { get; } = LogManager.GetLogger<FileSaveSystem>();
    
    public IReadOnlyList<SaveSlot> ListSlots()
    {
        throw new System.NotImplementedException();
    }

    public async GDTask<T?> LoadAsync<T>(string filePath) where T : ISavableModel
    {
        await using var stream = new FileStream(filePath, FileMode.Open);
        Logger.ZLogInformation($"Loading {filePath}");
        return await MemoryPackSerializer.DeserializeAsync<T>(stream);
    }

    public async GDTask SaveAsync<T>(string filePath, T data) where T : ISavableModel
    {
        var writer = new ArrayBufferWriter<byte>();
        MemoryPackSerializer.Serialize(in writer, in data);
        Logger.ZLogInformation($"Saving {filePath}");
        await File.WriteAllBytesAsync(filePath, writer.WrittenMemory.ToArray());
    }

    public GDTask DeleteAsync(string filePath)
    {
        throw new System.NotImplementedException();
    }

    public bool Exists(string filePath) => File.Exists(filePath);
}