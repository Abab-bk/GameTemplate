using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Game.Scripts.Classes;
using Godot;
using Linguini.Bundle;
using Linguini.Bundle.Builder;
using Linguini.Shared.Types.Bundle;

namespace Game.Scripts.I18n;

public static class Translator
{
    public static event Action<Language> LanguageChanged;
    
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

    public static void TranslateTree(Node node)
    {
        foreach (var child in node.GetChildren())
        {
            if (child is not Control control) continue;
            // if (control.AutoTranslateMode == Node.AutoTranslateModeEnum.Disabled) continue;
            
            if (control is Button button)
            {
                button.Text = GetMessage(button.Text);
            } else if (control is Label label)
            {
                label.Text = GetMessage(label.Text);
            } else if (control is RichTextLabel richTextLabel)
            {
                richTextLabel.Text = GetMessage(richTextLabel.Text);
            }
            
            TranslateTree(control);
        }
    }

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

        LanguageChanged?.Invoke(language);
    }

    private static IEnumerable<string> GetLanguageResources(Language language)
    {
        var result = new List<string>();
        
        foreach (var file in Directory.GetFiles(
                     Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        GetLanguageFolder(language)
                        )
                     )
                 )
        {
            try
            {
                var content = File.ReadAllText(file);
                result.Add(content);
            }
            catch (Exception e)
            {
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