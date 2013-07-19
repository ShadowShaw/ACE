using PrestaAccesor.Entities;
using PrestaAccesor.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Bussiness
{
    public class EngineService
    {
        private LoginService m_loginService;

        private string m_shopUrl;
        private string m_apiToken;
        private CategoriesAccesor m_categoryAccesor;
        private ManufacturersAccesor m_manufacturerAccesor;
        private ProductsAccesor m_productsAccesor;

        public string ShopUrl
        {
            get
            {
                return m_shopUrl;
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

        public EngineService()
        {
            m_loginService = new LoginService();
           // m_shopUrl = "http://testpresta.mzf.cz/prestashop/";
           // m_apiToken = "BYWM7NA5NKVNZ873VJTFLUXGQ4WI9YT8";

            m_categoryAccesor = new CategoriesAccesor(m_shopUrl, m_apiToken, "");
            m_manufacturerAccesor = new ManufacturersAccesor(m_shopUrl, m_apiToken, "");
            m_productsAccesor = new ProductsAccesor(m_shopUrl, m_apiToken, "");
        }

        public void LoadConfiguration()
        { 
        
        }

        public void PrestaSetup(string url, string apiToken)
        {
            m_apiToken = apiToken;
            m_shopUrl = url;

            m_categoryAccesor.Setup(m_shopUrl, m_apiToken, "");
            m_manufacturerAccesor.Setup(m_shopUrl, m_apiToken, "");
            m_productsAccesor.Setup(m_shopUrl, m_apiToken, "");
        }

        public List<TreeItem> CreateCategoryTreeList()
        {
            List<TreeItem> result = new List<TreeItem>();
            List<int> Ids = m_categoryAccesor.GetIds();

            foreach (int id in Ids)
            {
                category item = m_categoryAccesor.Get(id);
                result.Add(new TreeItem(item.name, item.level_depth, item.id.Value));
            }

            return result;
        }

        public List<product> GetProductWithEmptyManufacturer()
        {
            List<product> result = new List<product>();

            var ids = m_productsAccesor.GetIds();

            foreach (int id in ids)
            {
                product item = m_productsAccesor.Get(id);
                if (item.id_manufacturer.HasValue == false)
                {
                    result.Add(item);
                }
            }
            
            return result;
        }

        public List<product> GetProductWithEmptyCategory()
        {
            List<product> result = new List<product>();

            var i = m_productsAccesor.GetAll();
            var ids = m_productsAccesor.GetIdsPartial();

            //foreach (int id in ids)
            //{
            //    product item = m_productsAccesor.Get(id);
            //    if (item.id_category_default == 0)
            //    {
            //        result.Add(item);
            //    }
            //}

            return result;
            return null;
        }
    }
}
