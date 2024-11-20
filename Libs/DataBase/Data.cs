using System.Text.Json;
using cfg;

namespace DataBase;

public static class Data
{
    public static Tables Tables;
    public static readonly TbConstants Constants;

    static Data()
    {
        Tables = new Tables(file => JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText($"res://Assets/Data/{file}.json")));
        Constants = Tables.TbConstants;
    }
}