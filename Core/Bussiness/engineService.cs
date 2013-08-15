using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using PrestaAccesor.Serializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core.Bussiness
{
    public class EngineService
    {
        private LoginService m_loginService;
        private ProductService m_productService;
        private ManufactuerService m_manufacturerService;
        private CategoryService m_CategoryService;

        private string m_BaseUrl;
        private string m_apiToken;
        //private CategoriesAccesor m_categoryAccesor;
        //private ManufacturersAccesor m_manufacturerAccesor;
        
        public string BaseUrl
        {
            get
            {
                return m_BaseUrl;
            }
        }

        public string ApiToken
        {
            get
            {
                return m_apiToken;
            }
        } 

        public LoginService Login 
        {
            get
            {
                return m_loginService;
            }
        }

        public ProductService Products
        {
            get
            {
                return m_productService;
            }
        }

        public ManufactuerService Manufacturers
        {
            get
            {
                return m_manufacturerService;
            }
        }

        public CategoryService Categories
        {
            get
            {
                return m_CategoryService;
            }
        }

        public EngineService()
        {
            m_loginService = new LoginService();
            m_productService = new ProductService(m_BaseUrl, m_apiToken, "");
            m_manufacturerService = new ManufactuerService(m_BaseUrl, m_apiToken, "");
            m_CategoryService = new CategoryService(m_BaseUrl, m_apiToken, "");

           // m_BaseUrl = "http://testpresta.mzf.cz/prestashop/";
           // m_apiToken = "BYWM7NA5NKVNZ873VJTFLUXGQ4WI9YT8";

            //m_categoryAccesor = new CategoriesAccesor(m_BaseUrl, m_apiToken, "");
            //m_manufacturerAccesor = new ManufacturersAccesor(m_BaseUrl, m_apiToken, "");
        }
        
        public void PrestaSetup(string url, string apiToken)
        {
            m_apiToken = apiToken;
            m_BaseUrl = url;

            Categories.Setup(m_BaseUrl, m_apiToken, "");
            Manufacturers.Setup(m_BaseUrl, m_apiToken, "");
            Products.Setup(m_BaseUrl, m_apiToken, "");
        }

        public bool TestPrestaAccess()
        {
            bool result = false;
            result = m_CategoryService.GetFirstCategory();
            return result;
        }

        public List<TreeItem> CreateCategoryTreeList()
        {
            List<TreeItem> result = new List<TreeItem>();
            //List<int> Ids = m_categoryAccesor.GetIds();

            //foreach (int id in Ids)
            //{
            //    category item = m_categoryAccesor.Get(id) as category;
            //    result.Add(new TreeItem(item.name, item.level_depth, item.id.Value));
            //}

            return result;
        }
    }
}
