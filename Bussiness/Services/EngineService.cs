using Bussiness.Base;
using Bussiness.RePricing;
using Bussiness.ViewModels;
using System.Diagnostics;

namespace Bussiness.Services
{
    public class EngineService : ServiceBase
    {
        private readonly LoginService loginService;
        private ProductService productService;
        private ManufactuerService manufacturerService;
        private CategoryService categoryService;
        private LanguageService languageService;
        private SupplierService supplierService;
        private readonly PricingService pricingService;
        private PriceListsService priceListsService;

        public LoginService Login { get { return loginService; } }
        public ProductService Products { get { return productService; } }
        public SupplierService Suppliers { get { return supplierService; } }
        public ManufactuerService Manufacturers { get { return manufacturerService; } }
        public CategoryService Categories { get { return categoryService; } }
        public LanguageService Languages { get { return languageService; } }
        public PricingService Pricing { get { return pricingService; } }
        public PriceListsService PriceLists { get { return priceListsService; } }

        public EngineService()
        {
            loginService = new LoginService();
            priceListsService = new PriceListsService();
            pricingService = new PricingService();
        }

        public void InitPrestaServices(string url, string token)
        {
            ServiceBaseUrl = url;
            ServiceApiToken = token;
                       
            productService = new ProductService(url, token, "");
            manufacturerService = new ManufactuerService(url, token, "");
            categoryService = new CategoryService(url, token, "");
            languageService = new LanguageService(url, token, "");
            supplierService = new SupplierService(url, token, "");
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
                    return false;
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
            ProductViewModel product = Products.GetById(System.Convert.ToInt32(productId));
            CategoryViewModel cat = Categories.GetById(System.Convert.ToInt32(product.IdCategoryDefault));
            string categoryLink = cat.LinkRewrite;
            string eshopUrl = BaseUrl.Substring(0, BaseUrl.Length - 4);
            string productUrl = eshopUrl + "/" + categoryLink + "/" + product.Id + "-" + product.LinkRewrite + ".html";
            ProcessStartInfo sInfo = new ProcessStartInfo(productUrl);
            Process.Start(sInfo);
        }
    }
}
