using Bussiness.Base;
using Bussiness.ViewModels;
using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bussiness.Services
{
    public class CategoryService : ServiceBase
    {
        public List<CategoryViewModel> Categories;
        private readonly CategoriesAccesor categoriesAccesor;
                
        public CategoryService(string baseUrl, string account, string password)
        {
            categoriesAccesor = new CategoriesAccesor(baseUrl, account, password);
            Categories = new List<CategoryViewModel>();
            ServiceLoaded = false;
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
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private bool LoadCategories()
        {
            List<int> ids = categoriesAccesor.GetIds();

            if (ids == null)
            {
                return false;
            }
            
            foreach (int id in ids)
            {
                PrestashopEntity cat = categoriesAccesor.Get(id);
                Categories.Add(CategoryFromPresta(cat as category));
            }
            ServiceLoaded = true;
            return true;
        }

        public string GetCategoryName(int id)
        {
            if (id == 0)
            {
                return "";
            }

            CategoryViewModel result = Categories.FirstOrDefault(x => x.Id == id);
            return result.Name;
        }

        public List<int> GetSubcategories(int idCategory, List<int> categories)
        {
            foreach (CategoryViewModel item in Categories)
            {
                if (item.IdParent == idCategory)
                {
                    categories.Add(Convert.ToInt32(item.Id));
                    categories = GetSubcategories(Convert.ToInt32(item.Id), categories);
                }
            }
            
            return categories;
        }

        public long? GetCategoryId(string categoryName)
        {
            if (categoryName != "")
            {
                return Categories.FirstOrDefault(x => x.Name == categoryName).Id;
            }

            return 0;
        }

        public List<string> GetCategoryList()
        {
            return Categories.Select(item => item.Name).ToList();
        }

        public CategoryViewModel GetById(int id)
        {
            return Categories.FirstOrDefault(x => x.Id == id);
        }

        private CategoryViewModel CategoryFromPresta(category entity)
        {
            CategoryViewModel result = new CategoryViewModel();

            int languageIndex = entity.description.FindIndex(language => language.id == ServiceActivePrestaLanguage);

            result.Id = entity.id;
            result.LinkRewrite = entity.link_rewrite[languageIndex].Value;

            result.Name = entity.name;
            //result.name = entity.name[languageIndex].Value;

            result.IdParent = entity.id_parent;
            result.IdShopDefault = entity.id_shop_default;
            result.LevelDepth = entity.level_depth;
            result.IsRootCategory = entity.is_root_category;

            return result;
        }

        //private category CategoryToPresta(CategoryViewModel entity)
        //{
            //product result = productsAccesor.Get(entity.id) as product;

            //PrestaValues.SetValueForLanguage(result.description, activePrestaLanguage, entity.description);
            //PrestaValues.SetValueForLanguage(result.description_short, activePrestaLanguage, entity.description_short);
            //PrestaValues.SetValueForLanguage(result.link_rewrite, activePrestaLanguage, entity.link_rewrite);
            //result.id_category_default = entity.id_category_default;
            ////result.id_image = 0;
            //result.id_manufacturer = entity.id_manufacturer;
            //result.id_supplier = entity.id_supplier;
            //PrestaValues.SetValueForLanguage(result.name, activePrestaLanguage, entity.name);
            //if (entity.price == null)
            //{
            //    entity.price = 0;
            //}
            //else
            //{
            //    result.price = entity.price;
            //}

            //if (entity.wholesale_price == null)
            //{
            //    entity.wholesale_price = 0;
            //}
            //else
            //{
            //    result.wholesale_price = entity.wholesale_price;
            //}

            //if (entity.weight == null)
            //{
            //    entity.weight = 0;
            //}
            //else
            //{
            //    result.weight = entity.weight;
            //}

            //return result;

        //    return null;
        //}
    }
}
