using Bussiness.UserSettings;
using Suppliers.Interfaces;
using System.Collections.Generic;
using Suppliers.Suppliers;

namespace Bussiness.Services
{
    public class PriceListsService
    {
        private readonly Dictionary<string, ISupplier> priceLists;

        public PriceListsService()
        {
            priceLists = new Dictionary<string, ISupplier>();
        }

        public ISupplier this[string key]
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

        public bool HasSupplier(string supplierName)
        {
            return priceLists.ContainsKey(supplierName);
        }
        
        public void AddPriceLists(EshopConfiguration eshop)
        {
            // TODO zjednodusit
            if (eshop.Suppliers[eshop.NovikoIndex()].UseSupplier)
            {
                if (priceLists.ContainsKey("Noviko") == false)
                {
                    NovikoSupplier noviko = new NovikoSupplier(eshop.Suppliers[eshop.NovikoIndex()].SupplierFileName);
                    priceLists.Add("Noviko", noviko);
                }
            }

            if (eshop.Suppliers[eshop.AskinoIndex()].UseSupplier)
            {
                if (priceLists.ContainsKey("Askino") == false)
                {
                    AskinoSupplier askino = new AskinoSupplier(eshop.Suppliers[eshop.AskinoIndex()].SupplierFileName);
                    priceLists.Add("Askino", askino);
                }
            }
        }


    }
}
