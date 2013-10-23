using Core.ViewModels;
using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using PrestaAccesor.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Bussiness
{
    public class ProductService : ServiceBase, IService
    {
        public List<ProductViewModel> Products;
        public ProductsAccesor productsAccesor;

        public ProductViewModel GetById(int id)
        {
            return Products.Where(x => x.id == id).FirstOrDefault();
        }

        public ProductService(string BaseUrl, string apiToken, string Password)
        {
            productsAccesor = new ProductsAccesor(BaseUrl, apiToken, "");
            Products = new List<ProductViewModel>();
        }

        public void Setup(string baseUrl, string apiToken)
        {
            Products.Clear();
            productsAccesor.Setup(baseUrl, apiToken, "");
        }

        public async Task<bool> LoadProductsAsync()
        {
            Products.Clear();
            try
            {
                return await Task.Factory.StartNew(() => LoadProducts());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private bool LoadProducts()
        {
            int startItem = 0;
            
            List<product> items = new List<product>();
            do
            {
                items = productsAccesor.GetByFilter(null, null, startItem + "," + StepCount);
                startItem = startItem + StepCount;

                if (items == null)
                {
                    return false;
                }
                
                foreach (product item in items)
                {
                    Products.Add(ProductFromPresta(item));
                }
                
            } while (items.Count == 500);

            return true;
        }

        public List<ProductViewModel> GetProductWithEmptyManufacturer()
        {
                List<ProductViewModel> result = new List<ProductViewModel>();
 
            foreach (ProductViewModel item in this.Products)
            {
                if ((item.id_manufacturer.HasValue == false) || (item.id_manufacturer == 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyCategory()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if ((item.id_category_default.HasValue == false) || (item.id_category_default == 1) || (item.id_category_default == 2))
                {
                    result.Add(item);
                }
            }
                        
            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyImage()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if (item.id_image == 0)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyShortDescription()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if (item.description_short == "")
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyLongDescription()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if (item.description == "")
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyPrice()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if ((item.price.HasValue == false) || (item.price == Decimal.Zero))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyWholesalePrice()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if ((item.wholesale_price.HasValue == false) || (item.wholesale_price == Decimal.Zero))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyWeight()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if ((item.weight.HasValue == false) || (item.weight <= 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductForRepricing(int idManufacturer, int idSupplier, List<int> idCategories)
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in this.Products)
            {
                if ((idManufacturer == 0) || (item.id_manufacturer == idManufacturer))
                {
                    if ((idSupplier == 0) || (item.id_supplier == idSupplier))
                    {
                        if (idCategories.Count == 0)
                        {
                            result.Add(item);
                        }
                        else
                        {
                            if (idCategories.Contains(System.Convert.ToInt32(item.id_category_default)))
                            {
                                result.Add(item);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public void Edit(ProductViewModel entity)
        {
            productsAccesor.Update(ProductToPresta(entity));
        }

        public void Add(product entity)
        {
            productsAccesor.Add(entity);
        }

        private ProductViewModel ProductFromPresta(product entity)
        {
            ProductViewModel result = new ProductViewModel();

            int languageIndex = entity.description.FindIndex(language => language.id == activePrestaLanguage);

            result.description = entity.description[languageIndex].Value;
            result.description_short = entity.description_short[languageIndex].Value;
            result.id = entity.id;
            result.id_category_default = entity.id_category_default;
            //result.id_image = 0;
            result.id_manufacturer = entity.id_manufacturer;
            result.id_supplier = entity.id_supplier;
            result.name = entity.name[languageIndex].Value;
            result.price = entity.price;
            result.weight = entity.weight;
            result.wholesale_price = entity.wholesale_price;
            result.link_rewrite = entity.link_rewrite[languageIndex].Value;

            return result;
        }

        private product ProductToPresta(ProductViewModel entity)
        {
            product result = productsAccesor.Get(entity.id) as product;
                        
            PrestaValues.SetValueForLanguage(result.description, activePrestaLanguage, entity.description);
            PrestaValues.SetValueForLanguage(result.description_short, activePrestaLanguage, entity.description_short);
            PrestaValues.SetValueForLanguage(result.link_rewrite, activePrestaLanguage, entity.link_rewrite);
            result.id_category_default = entity.id_category_default;
            //result.id_image = 0;
            result.id_manufacturer = entity.id_manufacturer;
            result.id_supplier = entity.id_supplier;
            PrestaValues.SetValueForLanguage(result.name, activePrestaLanguage, entity.name);
            if (entity.price == null)
            {
                entity.price = 0;
            }
            else
            {
                result.price = entity.price;
            }

            if (entity.wholesale_price == null)
            {
                entity.wholesale_price = 0;
            }
            else
            {
                result.wholesale_price = entity.wholesale_price;
            }

            if (entity.weight == null)
            {
                entity.weight = 0;
            }
            else
            {
                result.weight = entity.weight;
            }

            return result;
        }
    }
}
