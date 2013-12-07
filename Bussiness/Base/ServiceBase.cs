using Bussiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness.Services
{
    public abstract class ServiceBase : IService
    {
        public const int StepCount = 500;

        public ServiceBase()
        {
            loaded = false;
        }

        protected bool loaded;
        public bool Loaded
        {
            get
            {
                return loaded;
            }
        }

        protected long? activePrestaLanguage;
        
        public long? ActivePrestaLanguage
        {
            get
            {
                return activePrestaLanguage;
            }
        }

        protected string baseUrl;
        protected string apiToken;

        public string BaseUrl
        {
            get
            {
                return baseUrl;
            }
        }

        public string ApiToken
        {
            get
            {
                return apiToken;
            }
        }

        public void SetupLanguage(long? activeLanguage)
        {
            this.activePrestaLanguage = activeLanguage;
        }

        //list
        //accesor

    }
}
