using System.Text.Json;
using AcidWallStudio;
using cfg;

namespace Game.Scripts;

public static class Data
{
    public static Tables Tables;
    public static readonly TbConstants Constants;

    static Data()
    {
        Tables = new Tables(file => JsonSerializer.Deserialize<JsonElement>(
            Wizard.ReadAllText($"res://Assets/Data/{file}.json")));
        Constants = Tables.TbConstants;
    }
}