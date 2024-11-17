using Game.Scripts.Enums;

namespace Game.Scripts.Classes;

public static class Utils
{
    public static string GetLanguageLocaleCode(Language language)
    {
        return language switch
        {
            Language.English => "en",
            Language.Chinese => "zh",
            Language.Japanese => "ja",
            _ => "en"
        };
    }
}