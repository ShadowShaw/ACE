using Bussiness.Services;
using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public class CategoryService : ServiceBase
    {
        public List<category> Categories;
        public CategoriesAccesor categoriesAccesor;
                
        public CategoryService(string BaseUrl, string Account, string Password)
        {
            categoriesAccesor = new CategoriesAccesor(BaseUrl, Account, "");
            Categories = new List<category>();
            loaded = false;
        }

        public void Setup(string baseUrl, string apiToken)
        {
            Categories.Clear();
            categoriesAccesor.Setup(baseUrl, apiToken, "");
        }

        public async Task<bool> LoadCategoriesAsync()
        {
            Categories.Clear();

            try
            {
                return await Task.Factory.StartNew(() => LoadCategories());
            }
            catch (Exception ex)
            {
                //TODO
                //MessageBox.Show(ex.Message);
            }
            return false;
        }

        private bool LoadCategories()
        {
            List<int> ids = new List<int>();
            ids = categoriesAccesor.GetIds();

            if (ids == null)
            {
                return false;
            }
            
            foreach (int id in ids)
            {
                PrestashopEntity cat = categoriesAccesor.Get(id);
                Categories.Add(cat as category );
            }
            loaded = true;
            return true;
        }

        public string GetCategoryName(int id)
        {
            if (id == 0)
            {
                return "";
            }

            category result = Categories.Where(x => x.id == id).FirstOrDefault();
            return result.name;
        }

        public List<int> GetSubcategories(int idCategory, List<int> categories)
        {
            foreach (category item in Categories)
            {
                if (item.id_parent == idCategory)
                {
                    categories.Add(System.Convert.ToInt32(item.id));
                    categories = GetSubcategories(System.Convert.ToInt32(item.id), categories);
                }
            }
            
            return categories;
        }

        public long? GetCategoryId(string categoryName)
        {
            if (categoryName != "")
            {
                return Categories.Where(x => x.name == categoryName).FirstOrDefault().id;
            }

            return 0;
        }

        public List<string> GetCategoryList()
        { 
            List<string> result = new List<string>();

            foreach (category item in Categories)
            {
                result.Add(item.name);
            }

            return result;
        }

        public category GetById(int id)
        {
            return Categories.Where(x => x.id == id).FirstOrDefault();
        }
    }
}
