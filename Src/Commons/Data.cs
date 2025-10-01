using System.Collections.Generic;
using System.Text.Json.Serialization;
using Core;
using Core.Tables;
using Godot;
using MasterMemory;
using VYaml.Serialization;
using ZeroLog;

namespace Game.Commons;

public static class Data
{
    public static readonly MemoryDatabase Tables;

    static Data()
    {
        var builder = new DatabaseBuilder();

        builder.Append(GetDocumentsInFolder<ItemTemplate>("ItemTemplates"));

        Tables = new MemoryDatabase(builder.Build());
    }

    private static Log Logger { get; } = LogManager.GetLogger("Data");

    private static IEnumerable<T> GetDocuments<T>(string fileName)
    {
        var path = $"res://Assets/Tables/{fileName}";
        Logger.Info($"Loading {path}");
        foreach (var document in YamlSerializer.DeserializeMultipleDocuments<T>(
                     FileAccess.GetFileAsBytes(path)
                 ))
            yield return document;
    }

    private static IEnumerable<T> GetDocumentsInFolder<T>(string folderName)
    {
        Logger.Info($"Loading {folderName}");
        var files = DirAccess.GetFilesAt($"res://Assets/Tables/{folderName}/");
        foreach (var file in files)
        foreach (var document in GetDocuments<T>($"{folderName}/{file}"))
            yield return document;
    }
}

[JsonSerializable(typeof(Dictionary<string, string>))]
[JsonSerializable(typeof(Dictionary<string, string[]>))]
public partial class MyJsonContext : JsonSerializerContext
{
}