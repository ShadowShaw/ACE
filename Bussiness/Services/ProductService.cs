using Bussiness.Base;
using Bussiness.ViewModels;
using PrestaAccesor.Accesors;
using PrestaAccesor.Utils;
using Suppliers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserSettings;
using Product = PrestaAccesor.Entities.Product;

namespace Bussiness.Services
{
    public class ProductService : ServiceBase
    {
        public List<ProductViewModel> Products;
        private readonly ProductsAccesor productsAccesor;

        public ProductViewModel GetById(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }

        public ProductService(string baseUrl, string apiToken, string password)
        {
            productsAccesor = new ProductsAccesor(baseUrl, apiToken, password);
            Products = new List<ProductViewModel>();
        }

        public void Setup(string baseUrl, string apiToken)
        {
            Products.Clear();
            productsAccesor.Setup(baseUrl, apiToken, "");
        }

        public void DeleteProduct(long? productId)
        {
            Products.Remove(Products.FirstOrDefault(x => x.Id == productId));
            productsAccesor.Delete(productId);
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
            
            List<Product> items;
            do
            {
                items = productsAccesor.GetByFilter(null, null, startItem + "," + StepCount);
                startItem = startItem + StepCount;

                if (items == null)
                {
                    return false;
                }
                
                foreach (Product item in items)
                {
                    Products.Add(ProductFromPresta(item));
                }
                
            } while (items.Count == 500);

            return true;
        }

        public List<ProductViewModel> GetProductWithEmptyManufacturer()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
 
            foreach (ProductViewModel item in Products)
            {
                if ((item.IdManufacturer.HasValue == false) || (item.IdManufacturer == 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyCategory()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in Products)
            {
                if ((item.IdCategoryDefault.HasValue == false) || (item.IdCategoryDefault == 1) || (item.IdCategoryDefault == 2))
                {
                    result.Add(item);
                }
            }
                        
            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyImage()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in Products)
            {
                if (item.IdImage == 0)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyShortDescription()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in Products)
            {
                if (item.DescriptionShort == "")
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyLongDescription()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in Products)
            {
                if (item.Description == "")
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyPrice()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in Products)
            {
                if ((item.Price.HasValue == false) || (item.Price == Decimal.Zero))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public List<ProductViewModel> GetProductWithEmptyWholesalePrice()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in Products)
            {
                if ((item.WholesalePrice.HasValue == false) || (item.WholesalePrice == Decimal.Zero))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public IEnumerable<ProductViewModel> GetProductWithoutSupplier()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in Products)
            {
                if ((item.IdSupplier.HasValue == false) || (item.IdSupplier == 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }


        public IEnumerable<ProductViewModel> GetProductWithEmptyWeight()
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in Products)
            {
                if ((item.Weight.HasValue == false) || (item.Weight <= 0))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        private IEnumerable<ProductViewModel> GetProductsOfSupplier(long? supplierId)
        {
            return Products.Select(x => x).Where(x => x.IdSupplier == supplierId).ToList();
        }

        public IEnumerable<ProductViewModel> GetNonAvailableProductOfSuppliers(PriceListsService priceLists, SupplierService suppliers)
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (Enums.Suppliers supplier in Enum.GetValues(typeof(Enums.Suppliers)))
            {
                if (priceLists.HasSupplier(supplier))
                {
                    long? supplierId = suppliers.GetSupplierId(supplier.ToString());
                    IEnumerable<ProductViewModel> productToCheck = GetProductsOfSupplier(supplierId); 
                    ISupplier supplierPriceList = priceLists[supplier];
                    supplierPriceList.OpenPriceList();

                    foreach (ProductViewModel product in productToCheck)
                    {
                        if (supplierPriceList.HasReference(product.Id.ToString()) == false)
                        {
                            result.Add(product);
                        }
                    }
                }
            }
            return result;
        }


        public List<ProductViewModel> GetProductForRepricing(int idManufacturer, int idSupplier, List<int> idCategories)
        {
            List<ProductViewModel> result = new List<ProductViewModel>();

            foreach (ProductViewModel item in Products)
            {
                if ((idManufacturer == 0) || (item.IdManufacturer == idManufacturer))
                {
                    if ((idSupplier == 0) || (item.IdSupplier == idSupplier))
                    {
                        if (idCategories.Count == 0)
                        {
                            result.Add(item);
                        }
                        else
                        {
                            if (idCategories.Contains(Convert.ToInt32(item.IdCategoryDefault)))
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

        public void Add(Product entity)
        {
            productsAccesor.Add(entity);
        }

        private ProductViewModel ProductFromPresta(Product entity)
        {
            ProductViewModel result = new ProductViewModel();

            int languageIndex = entity.description.FindIndex(language => language.id == ServiceActivePrestaLanguage);

            result.Description = entity.description[languageIndex].Value;
            result.DescriptionShort = entity.description_short[languageIndex].Value;
            result.Id = entity.id;
            result.IdCategoryDefault = entity.id_category_default;
            result.Reference = entity.reference;
            //result.id_image = 0;
            result.IdManufacturer = entity.id_manufacturer;
            result.IdSupplier = entity.id_supplier;
            result.Name = entity.name[languageIndex].Value;
            result.Price = entity.price;
            result.Weight = entity.weight;
            result.WholesalePrice = entity.wholesale_price;
            result.LinkRewrite = entity.link_rewrite[languageIndex].Value;

            return result;
        }

        private Product ProductToPresta(ProductViewModel entity)
        {
            Product result = productsAccesor.Get(entity.Id) as Product;

            PrestaValues.SetValueForLanguage(result.description, ServiceActivePrestaLanguage, entity.Description);
            PrestaValues.SetValueForLanguage(result.description_short, ServiceActivePrestaLanguage, entity.DescriptionShort);
            PrestaValues.SetValueForLanguage(result.link_rewrite, ServiceActivePrestaLanguage, entity.LinkRewrite);
            result.id_category_default = entity.IdCategoryDefault;
            result.reference = entity.Reference;
            //result.id_image = 0;
            result.id_manufacturer = entity.IdManufacturer;
            result.id_supplier = entity.IdSupplier;
            PrestaValues.SetValueForLanguage(result.name, ServiceActivePrestaLanguage, entity.Name);
            if (entity.Price == null)
            {
                entity.Price = 0;
            }
            else
            {
                result.price = entity.Price;
            }

            if (entity.WholesalePrice == null)
            {
                entity.WholesalePrice = 0;
            }
            else
            {
                result.wholesale_price = entity.WholesalePrice;
            }

            if (entity.Weight == null)
            {
                entity.Weight = 0;
            }
            else
            {
                result.weight = entity.Weight;
            }

            return result;
        }
    }
}
