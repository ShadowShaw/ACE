using Bussiness.Services;
using Bussiness.ViewModels;
using Suppliers.Interfaces;
using System.Collections.Generic;

namespace Bussiness.RePricing
{
    public class RepriceLimits
    {
        public int Limit;
        public int Value;
    }
    public class PricingService
    {
        private List<ProductViewModel> productToReprice;
        private SupplierService supplierService;
        private PriceListsService priceListsService;
        public List<ChangeRecord> ConsistencyChanges { get; private set; }

        public PricingService()
        {
            productToReprice = new List<ProductViewModel>();
            ConsistencyChanges = new List<ChangeRecord>();
        }

        public void Setup(SupplierService suppliers, PriceListsService priceLists)
        {
            supplierService = suppliers;
            priceListsService = priceLists;
        }

        public List<ProductViewModel> GetProducts()
        {
            return productToReprice;
        }

        public void SetProducts(List<ProductViewModel> products)
        {
            productToReprice = products;
        }

        public void UndoChanges()
        {
            if (ConsistencyChanges.Count > 0)
            {
                foreach (ChangeRecord change in ConsistencyChanges)
                {
                    if (change.Type == RecordType.Product)
                    {
                        if (change.Field == FieldType.Price)
                        {
                         //   Product.
                        }

                        if (change.Field == FieldType.WholesalePrice)
                        {
                            
                        }
                    }
                }
            }
        }

        private void AddDecimalChange(decimal? oldValue, decimal? newValue, long? id, FieldType field)
        {
            if (oldValue != newValue)
            {
                ChangeRecord change = new ChangeRecord();

                change.Value = newValue.ToString();
                change.OldValue = oldValue.ToString();
                change.Type = RecordType.Product;
                change.Field = field;
                if (id != null)
                {
                    change.Id = (int)id;
                    ConsistencyChanges.Add(change);    
                }
            }
        }
        
        public void ProcentReprice(decimal procent, bool usePriceLists)
        {
            foreach (ProductViewModel product in productToReprice)
            {
                decimal? productPrice = product.Price;
                decimal? productWholesalePrice = product.WholesalePrice;
                
                if (usePriceLists)
                {
                    string supplierName = supplierService.GetSupplierName(product.IdSupplier);
                    ISupplier priceList = priceListsService[supplierName];

                    if ((priceList != null) && (priceList.HasReference(product.Reference)))
                    {
                        productWholesalePrice = priceListsService[supplierName].GetWholeSalePrice(product.Reference);
                        
                        AddDecimalChange(product.WholesalePrice, productWholesalePrice, product.Id, FieldType.WholesalePrice);
                        product.WholesalePrice = productWholesalePrice;

                        decimal? newPrice = productWholesalePrice * procent;
                        AddDecimalChange(product.Price, newPrice, product.Id, FieldType.Price);
                        product.Price = newPrice;
                    }
                }
                else
                {
                    decimal? newPrice = productPrice * procent;
                    AddDecimalChange(product.Price, newPrice, product.Id, FieldType.Price);
                    product.Price = newPrice;

                    decimal? newWholeSalePrice = productWholesalePrice * procent;
                    AddDecimalChange(product.WholesalePrice, newWholeSalePrice, product.Id, FieldType.WholesalePrice);
                    product.WholesalePrice = newWholeSalePrice;
                }
            }
        }

        public void LimitReprice(List<RepriceLimits> limits)
        {
            
        }

        public void LimitReprice(decimal limit, decimal below, decimal above, bool usePriceLists)
        {
            foreach (ProductViewModel product in productToReprice)
            {
                decimal? productPrice = product.Price;
                decimal? productWholesalePrice = product.WholesalePrice;

                if (usePriceLists)
                {
                    string supplierName = supplierService.GetSupplierName(product.IdSupplier);
                    ISupplier priceList = priceListsService[supplierName];

                    if ((priceList != null) && (priceList.HasReference(product.Reference)))
                    {
                        productWholesalePrice = priceListsService[supplierName].GetWholeSalePrice(product.Reference);

                        AddDecimalChange(product.WholesalePrice, productWholesalePrice, product.Id, FieldType.Price);
                        product.WholesalePrice = productWholesalePrice;
                
                        decimal? newPrice;

                        if (productWholesalePrice > limit)
                        {
                            newPrice = productWholesalePrice + above; 
                        }
                        else
                        {
                            newPrice = productWholesalePrice + below; 
                        }

                        AddDecimalChange(product.Price, newPrice, product.Id, FieldType.Price);
                        product.Price = newPrice;
                    }
                }
                else
                {
                    decimal? newPrice;
                    decimal? newWholeSalePrice;
                    if (productPrice > limit)
                    {
                        newPrice = productPrice + above; 
                    }
                    else
                    {
                        newPrice = productPrice + below; 
                    }
                    AddDecimalChange(product.Price, newPrice, product.Id, FieldType.Price);
                    product.Price = newPrice;
                    
                    if (productWholesalePrice > limit)
                    {
                        newWholeSalePrice = productWholesalePrice + above;
                    }
                    else
                    {
                        newWholeSalePrice = productWholesalePrice + below;
                    }
                    AddDecimalChange(product.WholesalePrice, newWholeSalePrice, product.Id, FieldType.Price);
                    product.WholesalePrice = newWholeSalePrice;
                }
            }
        }
    }
}
