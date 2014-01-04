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
        
        public void AddPriceLists(EshopConfiguration eshop)
        {
            if (eshop.UseNoviko)
            {
                if (priceLists.ContainsKey("Noviko") == false)
                {
                    NovikoSupplier noviko = new NovikoSupplier(eshop.NovikoFilePath);
                    priceLists.Add("Noviko", noviko);
                }
            }

            if (eshop.UseAskino)
            {
                if (priceLists.ContainsKey("Askino") == false)
                {
                    AskinoSupplier askino = new AskinoSupplier(eshop.AskinoFilePath);
                    priceLists.Add("Askino", askino);
                }
            }
        }


    }
}
