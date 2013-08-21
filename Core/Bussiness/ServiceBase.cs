using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Bussiness
{
    public abstract class ServiceBase
    {
        protected int activePrestaLanguage;
        public const int StepCount = 500;

        protected bool loaded;
        public bool Loaded
        {
            get
            {
                return loaded;
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


        //list
        //accesor

    }
}
