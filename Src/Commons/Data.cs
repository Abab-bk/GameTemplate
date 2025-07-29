using System;
using System.IO;
using System.Text.Json;
using cfg;

namespace Game.Commons;

public static class Data
{
    public static readonly Tables Tables;
    public static readonly TbConstants Constants;

    static Data()
    {
        Tables = new Tables(file => JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Assets/{file}.json"))));
        Constants = Tables.TbConstants;
    }
}