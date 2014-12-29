using System.ComponentModel;
using Suppliers.Interfaces;
using System.Collections.Generic;
using Suppliers.Models;
using Suppliers.Suppliers;
using UserSettings;

namespace Bussiness.Services
{
    public class PriceListsService
    {
        private readonly Dictionary<Enums.Suppliers, ISupplier> _priceLists;

        public PriceListsService()
        {
            _priceLists = new Dictionary<Enums.Suppliers, ISupplier>();
        }

        public ISupplier this[Enums.Suppliers key]
        {
            get
            {
                ISupplier result = null;
                if (_priceLists.ContainsKey(key))
                {
                    result = _priceLists[key];    
                }
                
                return result;
            }
        }

        public bool HasSupplier(Enums.Suppliers supplier)
        {
            return _priceLists.ContainsKey(supplier);
        }
        
        public void LoadPriceLists(BindingList<SupplierConfiguration> suppliers)
        {
            _priceLists.Clear();

            foreach (SupplierConfiguration supplierConfiguration in suppliers)
            {
                ISupplier supplier = null;
                if (supplierConfiguration.Supplier == Enums.Suppliers.Askino)
                {
                    supplier = new GenericSupplier<AskinoModel>(supplierConfiguration.PathToFile);
                }
                if (supplierConfiguration.Supplier == Enums.Suppliers.AskinoTrixie)
                {
                    supplier = new GenericSupplier<AskinoTrixieModel>(supplierConfiguration.PathToFile);
                }
                if (supplierConfiguration.Supplier == Enums.Suppliers.HenrySchein)
                {
                    supplier = new GenericSupplier<HenryScheinModel>(supplierConfiguration.PathToFile);
                }
                if (supplier != null)
                {
                    _priceLists.Add(supplierConfiguration.Supplier, supplier);
                }
            }
        }
    }
}
