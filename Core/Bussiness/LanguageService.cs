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
    public class LanguageService : ServiceBase, IService
    {
        public List<LanguageEntity> Languages;
        public LanguageAccesor languageAccesor;

        public long? GetActiveLanguage()
        {
            if (loaded == false)
            {
                this.LoadLanguages();
            }

            foreach (LanguageEntity entity in Languages)
            {
                if (entity.active)
                {
                    activePrestaLanguage = entity.id;
                }
            }

            return activePrestaLanguage;
        }

        public LanguageEntity GetById(int id)
        {
            return languageAccesor.Get(id) as LanguageEntity;
        }

        public LanguageService(string BaseUrl, string Account, string Password)
        {
            languageAccesor = new LanguageAccesor(BaseUrl, Account, "");
            Languages = new List<LanguageEntity>();
            loaded = false;
        }

        public void Setup(string baseUrl, string apiToken)
        {
            Languages.Clear();
            languageAccesor.Setup(baseUrl, apiToken, "");
        }

        public void LoadLanguages()
        {
            Languages.Clear();
            List<int> ids = new List<int>();
            ids = languageAccesor.GetIds();

            if (ids == null)
            {
                return;
            }

            foreach (int id in ids)
            {
                PrestashopEntity lang = languageAccesor.Get(id);
                Languages.Add(lang as LanguageEntity);
            }
            loaded = true;
        }
    }
}
