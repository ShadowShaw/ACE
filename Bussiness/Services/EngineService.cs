using Bussiness.ViewModels;
using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public class EngineService : ServiceBase
    {
        private LoginService loginService;
        private ProductService productService;
        private ManufactuerService manufacturerService;
        private CategoryService categoryService;
        private LanguageService languageService;
        private SupplierService supplierService;
        private PriceListsService priceListService;

        public PriceListsService PriceLists
        {
            get
            {
                return priceListService;
            }
        }

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

        public SupplierService Suppliers
        {
            get
            {
                return supplierService;
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
            priceListService = new PriceListsService();
        }

        public void InitPrestaServices(string baseUrl, string apiToken)
        {
            this.baseUrl = baseUrl;
            this.apiToken = apiToken;
            
            //if (productService == null)
            //{
            productService = new ProductService(baseUrl, apiToken, "");
            //}
            //else
            //{
            //    Products.Setup(baseUrl, apiToken);
            //}
            
            //if (manufacturerService == null)
            //{
            manufacturerService = new ManufactuerService(baseUrl, apiToken, "");
            //}
            //else
            //{
            //    Manufacturers.Setup(baseUrl, apiToken);
            //}

            //if (categoryService == null)
            //{
            categoryService = new CategoryService(baseUrl, apiToken, "");
            //}
            //else
            //{
            //    Categories.Setup(baseUrl, apiToken);
            //}

            //if (languageService == null)
            //{
            languageService = new LanguageService(baseUrl, apiToken, "");
            //}
            //else
            //{
            //    Languages.Setup(baseUrl, apiToken);
            //}

            //if (supplierService == null)
            //{
            supplierService = new SupplierService(baseUrl, apiToken, "");
            //}
            //else
            //{
            //    Suppliers.Setup(baseUrl, apiToken);
            //}
        }

        public void SetupPrestaLanguages()
        { 
            Categories.SetupLanguage(Languages.ActivePrestaLanguage);
            Manufacturers.SetupLanguage(Languages.ActivePrestaLanguage);
            Products.SetupLanguage(Languages.ActivePrestaLanguage);
            Suppliers.SetupLanguage(Languages.ActivePrestaLanguage);
        }

        public bool TestPrestaAccess()
        {
            bool result = false;
            if (Languages.Loaded == false)
            {
                Languages.LoadLanguagesSync();
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

        public void OpenProductInBrowser(int productId)
        {
            ProductViewModel product = this.Products.GetById(System.Convert.ToInt32(productId));
            category cat = Categories.GetById(System.Convert.ToInt32(product.id_category_default));
            int languageIndex = cat.link_rewrite.FindIndex(language => language.id == Languages.ActivePrestaLanguage);
            string categoryLink = cat.link_rewrite[languageIndex].Value;
            string eshopUrl = BaseUrl.Substring(0, BaseUrl.Length - 4);
            string productUrl = eshopUrl + categoryLink + "/" + product.id + "-" + product.link_rewrite + ".html";
            ProcessStartInfo sInfo = new ProcessStartInfo(productUrl);
            Process.Start(sInfo);
        }
    }
}
