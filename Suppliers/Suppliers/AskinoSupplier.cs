using Suppliers.Accesors;
using Suppliers.Interfaces;
using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Suppliers.Suppliers
{
    public class AskinoSupplier : ISupplier
    {
        private IEnumerable<AskinoModel> askinoPriceList;
        private readonly CSVAccessor accessor;
        public string Path { get; private set;}
        public int SupplierId { get; set;}

        public AskinoSupplier(string pathToFile)
        {
            accessor = new CSVAccessor();
            Path = pathToFile;
        }

        public void OpenPriceList()
        {
            askinoPriceList = accessor.LoadCSV<AskinoModel>(Path);
        }

        public IEnumerable<Object> GetPriceList()
        {
            return askinoPriceList.ToList();
        }

        public bool HasReference(string reference)
        {
            bool result = false;
            var item = askinoPriceList.Where(x => x.Reference == reference);
            if (item.Any())
            {
                result = true;
            }
            return result;
        }

        public decimal GetPrice(string reference)
        {
            var item = askinoPriceList.Single(x => x.Reference == reference);
            return Convert.ToDecimal(item.PriceWithDph);
        }

        public decimal GetWholeSalePrice(string reference)
        {
            var item = askinoPriceList.Single(x => x.Reference == reference);
            return Convert.ToDecimal(item.UnitPrice);
        }
    }
} 