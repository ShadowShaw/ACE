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
            productService = new ProductService(baseUrl, apiToken, "");
            manufacturerService = new ManufactuerService(baseUrl, apiToken, "");
            categoryService = new CategoryService(baseUrl, apiToken, "");
            languageService = new LanguageService(baseUrl, apiToken, "");

           // BaseUrl = "http://testpresta.mzf.cz/prestashop/";
           // apiToken = "BYWM7NA5NKVNZ873VJTFLUXGQ4WI9YT8";
        }

        public void GetActiveLanguage()
        {
            activeLanguage = Languages.GetActiveLanguage();
        }

        public void PrestaSetup(string url, string apiToken)
        {
            this.apiToken = apiToken;
            this.baseUrl = url;

            Categories.Setup();
            Manufacturers.Setup();
            Products.Setup();
            Languages.Setup();
        }

        public bool TestPrestaAccess()
        {
            bool result = false;
            if (Languages.Loaded == false)
            {
                Languages.LoadLanguages();
            }
            
            activeLanguage = -1;

            GetActiveLanguage();
            
            if (activeLanguage != -1)
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
