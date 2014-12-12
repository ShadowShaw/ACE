using Suppliers.Interfaces;
using System.Collections.Generic;
using Suppliers.Suppliers;
using UserSettings;

namespace Bussiness.Services
{
    public class PriceListsService
    {
        private readonly Dictionary<Enums.Suppliers, ISupplier> priceLists;

        public PriceListsService()
        {
            priceLists = new Dictionary<Enums.Suppliers, ISupplier>();
        }

        public ISupplier this[Enums.Suppliers key]
        {
            get
            {
                ISupplier result = null;
                if (priceLists.ContainsKey(key))
                {
                    result = priceLists[key];    
                }
                
                return result;
            }
        }

        public bool HasSupplier(Enums.Suppliers supplier)
        {
            return priceLists.ContainsKey(supplier);
        }
        
        public void LoadPriceLists(EshopConfiguration eshop)
        {
            foreach (SupplierConfiguration supplierConfiguration in eshop.Suppliers)
            {
                ISupplier supplier = null;
                if (supplierConfiguration.Supplier == Enums.Suppliers.Askino)
                {
                    supplier = new AskinoSupplier(supplierConfiguration.PathToFile);
                }
                if (supplierConfiguration.Supplier == Enums.Suppliers.HenrySchein)
                {
                    supplier = new HenryScheinSupplier(supplierConfiguration.PathToFile);
                }
                if (supplier != null)
                {
                    if (priceLists.ContainsValue(supplier) == false)
                    {
                        priceLists.Add(supplierConfiguration.Supplier, supplier);
                    }    
                }
            }
        }
    }
}
