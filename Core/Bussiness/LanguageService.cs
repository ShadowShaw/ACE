using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core.Bussiness
{
    public class LanguageService : ServiceBase
    {
        public List<languageEntity> Languages;
        public LanguageAccesor languageAccesor;
        
        public languageEntity GetById(int id)
        {
            return languageAccesor.Get(id) as languageEntity;
        }

        public LanguageService(string BaseUrl, string Account, string Password)
        {
            languageAccesor = new LanguageAccesor(BaseUrl, Account, "");
            Languages = new List<languageEntity>();
            loaded = false;
        }

        public void Setup()
        {
            languageAccesor.Setup(baseUrl, apiToken, "");
        }

        public void LoadLanguages()
        {
            List<int> ids = new List<int>();
            ids = languageAccesor.GetIds();

            foreach (int id in ids)
            {
                prestashopentity lang = languageAccesor.Get(id);
                Languages.Add(lang as languageEntity);
            }
            loaded = true;
        }

        public int GetActiveLanguage()
        {
            int result = -1;
            
            if (loaded)
            {
                foreach (languageEntity item in Languages)
                {
                    if (item.active)
                    {
                        result = System.Convert.ToInt32(item.id);
                    }
                }
            }

            this.activePrestaLanguage = result;

            return result;
        }

    }
}
