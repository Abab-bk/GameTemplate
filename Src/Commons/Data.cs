using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using cfg;
using Luban;

namespace Game.Commons;

public static class Data
{
    public static readonly Tables Tables;
    public static readonly TbConstants Constants;

    static Data()
    {
        Tables = new Tables(file =>
            new ByteBuf(File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Assets/{file}.bytes")))
        );
        Constants = Tables.TbConstants;
    }
}

[JsonSerializable(typeof(Dictionary<string, string>))]
[JsonSerializable(typeof(Dictionary<string, string[]>))]
public partial class MyJsonContext : JsonSerializerContext
{
}