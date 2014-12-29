using System;
using System.ComponentModel;
using Bussiness.Services;
using Bussiness.ViewModels;
using Core.Utils;
using Suppliers.Interfaces;
using System.Collections.Generic;
using UserSettings;

namespace Bussiness.RePricing
{
    public class PricingService
    {
        private List<ProductViewModel> _productToReprice;
        private SupplierService _suppliers;
        private PriceListsService _priceLists;
        public List<ChangeRecord> ConsistencyChanges { get; private set; }
        public EshopConfiguration _activeEshop;

        public PricingService()
        {
            _productToReprice = new List<ProductViewModel>();
            ConsistencyChanges = new List<ChangeRecord>();
        }

        public void Setup(SupplierService suppliers, PriceListsService priceLists)
        {
            _priceLists = priceLists;
            _suppliers = suppliers;
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productToReprice;
        }

        public void SetProducts(List<ProductViewModel> products)
        {
            _productToReprice = products;
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
        
        public void ProcentReprice(decimal procent, bool usePriceLists, BindingList<SupplierConfiguration> suppliers)
        {
            if (usePriceLists)
            {
                _priceLists.LoadPriceLists(suppliers);
                foreach (SupplierConfiguration supplierConfiguration in suppliers)
                {
                    _priceLists[supplierConfiguration.Supplier].OpenPriceList();
                }
            }

            foreach (ProductViewModel product in _productToReprice)
            {
                decimal? productPrice = product.Price;
                decimal? productWholesalePrice = product.WholesalePrice;
                
                if (usePriceLists)
                {
                    string supplierName = _suppliers.GetSupplierName(product.IdSupplier);
                    if (supplierName == "Henry Schein")
                    {
                        supplierName = "HenrySchein";
                    }
                    Enums.Suppliers supplier;
                    Enum.TryParse(supplierName, true, out supplier);
                    ISupplier priceList = _priceLists[supplier];
                    
                    if ((priceList != null) && (priceList.HasReference(product.Reference)))
                    {
                        productWholesalePrice = _priceLists[supplier].GetWholeSalePrice(product.Reference);

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

        private decimal? UpdatePriceAccordingTheLimits(decimal? price, IEnumerable<RepriceLimit> limits)
        {
            foreach (RepriceLimit limit in limits)
            {
                if ((price > limit.LowLimit) && (price < limit.HiLimit))
                {
                    price = price + limit.Value;
                }
            }

            return price;
        }

        public void LimitReprice(IList<RepriceLimit> limits, bool usePriceLists, BindingList<SupplierConfiguration> suppliers)
        {
            if (usePriceLists)
            {
                _priceLists.LoadPriceLists(suppliers);
                foreach (SupplierConfiguration supplierConfiguration in suppliers)
                {
                    _priceLists[supplierConfiguration.Supplier].OpenPriceList();
                }
            }

            foreach (ProductViewModel product in _productToReprice)
            {
                decimal? productPrice = product.Price;
                decimal? productWholesalePrice = product.WholesalePrice;

                if (usePriceLists)
                {
                    string supplierName = _suppliers.GetSupplierName(product.IdSupplier);
                    if (supplierName == "Henry Schein")
                    {
                        supplierName = "HenrySchein";
                    }
                    Enums.Suppliers supplier;
                    Enum.TryParse(supplierName, true, out supplier);

                    ISupplier priceList = _priceLists[supplier];

                    if ((priceList != null) && (priceList.HasReference(product.Reference)))
                    {
                        productWholesalePrice = _priceLists[supplier].GetWholeSalePrice(product.Reference);

                        AddDecimalChange(product.WholesalePrice, productWholesalePrice, product.Id, FieldType.Price);
                        product.WholesalePrice = productWholesalePrice;

                        decimal? newPrice = UpdatePriceAccordingTheLimits(productWholesalePrice, limits);

                        AddDecimalChange(product.Price, newPrice, product.Id, FieldType.Price);
                        product.Price = newPrice;
                    }
                }
                else
                {
                    decimal? newPrice = UpdatePriceAccordingTheLimits(productPrice, limits);
                    decimal? newWholeSalePrice = UpdatePriceAccordingTheLimits(productWholesalePrice, limits);
                    
                    AddDecimalChange(product.Price, newPrice, product.Id, FieldType.Price);
                    product.Price = newPrice;
                    
                    AddDecimalChange(product.WholesalePrice, newWholeSalePrice, product.Id, FieldType.Price);
                    product.WholesalePrice = newWholeSalePrice;
                }
            }
        }
    }   
}
