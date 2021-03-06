﻿using Bussiness.Base;
using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bussiness.Services
{
    public class LanguageService : ServiceBase
    {
        public List<LanguageEntity> Languages;
        private readonly LanguageAccesor languageAccesor;

        public long? GetActiveLanguage()
        {
            if (ServiceLoaded == false)
            {
                LoadLanguages();
            }

            foreach (LanguageEntity entity in Languages)
            {
                if (entity.active)
                {
                    ServiceActivePrestaLanguage = entity.id;
                }
            }

            return ServiceActivePrestaLanguage;
        }

        public LanguageEntity GetById(int id)
        {
            return languageAccesor.Get(id) as LanguageEntity;
        }

        public LanguageService(string baseUrl, string account, string password)
        {
            languageAccesor = new LanguageAccesor(baseUrl, account, password);
            Languages = new List<LanguageEntity>();
            ServiceLoaded = false;
        }

        public void Setup(string baseUrl, string apiToken)
        {
            Languages.Clear();
            languageAccesor.Setup(baseUrl, apiToken, "");
        }

        public async Task<bool> LoadLanguagesAsync()
        {
            Languages.Clear();
            try
            {
                return await Task.Factory.StartNew(() => LoadLanguages());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public void LoadLanguagesSync()
        {
            Languages.Clear();
            try
            {
                LoadLanguages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool LoadLanguages()
        {
            List<int> ids = languageAccesor.GetIds();

            if (ids == null)
            {
                return false;
            }

            foreach (int id in ids)
            {
                PrestashopEntity lang = languageAccesor.Get(id);
                Languages.Add(lang as LanguageEntity);
            }
            ServiceLoaded = true;
            return true;
        }
    }
}
