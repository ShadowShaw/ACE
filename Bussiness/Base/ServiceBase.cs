using Bussiness.Interfaces;

namespace Bussiness.Base
{
    public abstract class ServiceBase : IService
    {
        public const int StepCount = 500;

        protected ServiceBase()
        {
            ServiceLoaded = false;
        }

        protected bool ServiceLoaded;
        public bool Loaded
        {
            get
            {
                return ServiceLoaded;
            }
        }

        protected long? ServiceActivePrestaLanguage;
        
        public long? ActivePrestaLanguage
        {
            get
            {
                return ServiceActivePrestaLanguage;
            }
        }

        protected string ServiceBaseUrl;
        public string BaseUrl
        {
            get
            {
                return ServiceBaseUrl;
            }
        }

        protected string ServiceApiToken;
        public string ApiToken
        {
            get
            {
                return ServiceApiToken;
            }
        }

        public void SetupLanguage(long? activeLanguage)
        {
            ServiceActivePrestaLanguage = activeLanguage;
        }
    }
}
