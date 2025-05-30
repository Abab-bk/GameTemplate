using Game.Scripts.I18n;

namespace Game.Scripts.Classes;

public static class Utils
{
    public static string GetLanguageLocaleCode(Language language)
    {
        return language switch
        {
            Language.English => "en",
            Language.Chinese => "zh",
            _ => "en"
        };
    }
}