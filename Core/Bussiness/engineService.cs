using PrestaAccesor.Serializers;
using PrestaSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Bussiness
{
    public class TreeItem
    {
        public string Name;
        public int Level;

        public TreeItem(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }

    public class EngineService
    {
        private LoginService m_loginService;

        private string m_shopUrl;
        private string m_apiToken;
        private CategoriesAccesor m_categoryAccesor;
        private ManufacturerAccesor m_manufacturerAccesor;

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

        public List<ps_manufacturer> manufacturers { get; set; }

        public EngineService()
        {
            m_loginService = new LoginService();
            m_shopUrl = "http://testpresta.mzf.cz/prestashop/";
            m_apiToken = "BYWM7NA5NKVNZ873VJTFLUXGQ4WI9YT8";

            m_categoryAccesor = new CategoriesAccesor(ShopUrl + "api/", ApiToken, "");
            m_manufacturerAccesor = new ManufacturerAccesor(ShopUrl + "api/", ApiToken, "");
        }

        public List<TreeItem> CreateCategoryTreeList()
        {
            List<TreeItem> result = new List<TreeItem>();
            List<int> Ids = m_categoryAccesor.GetIds();

            foreach (int id in Ids)
            {
                var item = m_categoryAccesor.Get(id);
                result.Add(new TreeItem(item.name, item.level_depth));
            }

            return result;
        }
    }
}
