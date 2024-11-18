using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Game.Scripts.Classes;
using Game.Scripts.Enums;
using Linguini.Bundle;
using Linguini.Bundle.Builder;
using Linguini.Shared.Types.Bundle;

namespace Game.Scripts;

public static class Translator
{
    private static FluentBundle _currentBundle;
    
    public static Language GetLanguage() => Global.AppSaver.UserPreferences.Language;
    
    public static string GetMessage(
        string id,
        string attribute = null,
        IDictionary<string, IFluentType> args = null
        ) => _currentBundle.GetMessage(id, attribute, args);

    public static string GetAttrMessage(
        string msgWithAttr, 
        params (string, IFluentType)[] args
        ) => _currentBundle.GetAttrMessage(msgWithAttr, args);

    public static void Setup()
    {
        ChangeLanguage(GetLanguage());
    }

    public static void ChangeLanguage(Language language)
    {
        _currentBundle = LinguiniBuilder.Builder()
            .CultureInfo(new CultureInfo(Utils.GetLanguageLocaleCode(language)))
            .AddResources(GetLanguageResources(language))
            .UncheckedBuild();
    }

    private static IEnumerable<string> GetLanguageResources(Language language)
    {
        var result = new List<string>();
        
        foreach (var file in Directory.GetFiles(GetLanguageFolder(language)))
        {
            try
            {
                var content = File.ReadAllText(file);
                result.Add(content);
            }
            catch (Exception e)
            {
                Logger.LogError($"[Translator Error]: {e}");
                throw;
            }
        }
        
        return result;
    }

    private static string GetLanguageFolder(Language language) =>
        language switch
        {
            Language.English => "Assets/Locale/English",
            Language.Chinese => "Assets/Locale/Chinese",
            Language.Japanese => "Assets/Locale/English",
            _ => "Assets/Locale/English"
        };
}