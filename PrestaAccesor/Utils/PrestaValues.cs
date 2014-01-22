using PrestaAccesor.Entities;
using System.Collections.Generic;

namespace PrestaAccesor.Utils
{
    public class PrestaValues
    {
        //public static string GetValueForLanguage(List<language> languageList, int id)
        //{
        //    int index = languageList.FindIndex(language => language.id == id);
        //    return languageList[index].Value;
        //}

        public static void SetValueForLanguage(List<language> languageList, long? id, string value)
        {
            int index = languageList.FindIndex(language => language.id == id);
            languageList[index].Value = value;
        }

        //public static void AddValueForLanguage(List<language> languageList, int id, string value)
        //{
        //    language lang = new language();
        //    lang.id = id;
        //    lang.Value = value;
        //    languageList.Add(lang);
        //}

    
    }
}
