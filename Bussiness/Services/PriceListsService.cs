using Bussiness.UserSettings;
using Suppliers;
using Suppliers.Interfaces;
using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness.Services
{
    public class PriceListsService
    {
        //TODO zmenit na private, mozna property
        public Dictionary<string, ISupplier> priceLists;

        public PriceListsService()
        {
            priceLists = new Dictionary<string, ISupplier>();
        }

        public ISupplier this[string key]
        {
            get
            {
                return this.priceLists[key];
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
