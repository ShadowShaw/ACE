using Core.Utils;
using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core.Bussiness
{
    public class EngineService : ServiceBase
    {
        private LoginService loginService;
        private ProductService productService;
        private ManufactuerService manufacturerService;
        private CategoryService categoryService;
        private LanguageService languageService;

        public LoginService Login 
        {
            get
            {
                return loginService;
            }
        }

        public ProductService Products
        {
            get
            {
                return productService;
            }
        }

        public ManufactuerService Manufacturers
        {
            get
            {
                return manufacturerService;
            }
        }

        public CategoryService Categories
        {
            get
            {
                return categoryService;
            }
        }

        public LanguageService Languages
        {
            get
            {
                return languageService;
            }
        }

        public EngineService()
        {
            loginService = new LoginService();

           // BaseUrl = "http://testpresta.mzf.cz/prestashop/";
           // apiToken = "BYWM7NA5NKVNZ873VJTFLUXGQ4WI9YT8";
        }

        public void InitPrestaServices(string baseUrl, string apiToken)
        {
            this.baseUrl = baseUrl;
            this.apiToken = apiToken;
            productService = new ProductService(baseUrl, apiToken, "");
            manufacturerService = new ManufactuerService(baseUrl, apiToken, "");
            categoryService = new CategoryService(baseUrl, apiToken, "");
            languageService = new LanguageService(baseUrl, apiToken, "");
        }

        public void SetupPrestaServices(string baseUrl, string apiToken)
        {
            this.apiToken = apiToken;
            this.baseUrl = baseUrl;

            Categories.Setup();
            Manufacturers.Setup();
            Products.Setup();
            Languages.Setup();
        }

        public void SetupPrestaLanguages()
        { 
            Categories.SetupLanguage(Languages.ActivePrestaLanguage);
            Manufacturers.SetupLanguage(Languages.ActivePrestaLanguage);
            Products.SetupLanguage(Languages.ActivePrestaLanguage);
        }

        public bool TestPrestaAccess()
        {
            bool result = false;
            if (Languages.Loaded == false)
            {
                Languages.LoadLanguages();
                if (Languages.Loaded == false)
                {
                    return result;
                }
            }
            
            Languages.GetActiveLanguage();

            if (Languages.ActivePrestaLanguage != -1)
            {
                result = true;
            }
            
            return result;
        }

        public List<TreeItem> CreateCategoryTreeList()
        {
            List<TreeItem> result = new List<TreeItem>();
            //List<int> Ids = categoryAccesor.GetIds();

            //foreach (int id in Ids)
            //{
            //    category item = categoryAccesor.Get(id) as category;
            //    result.Add(new TreeItem(item.name, item.level_depth, item.id.Value));
            //}

            return result;
        }
    }
}
