using Suppliers.Accesors;
using Suppliers.Interfaces;
using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Suppliers.Suppliers
{
    public class NovikoSupplier : ISupplier
    {
        private IEnumerable<NovikoModel> novikoPriceList;
        private readonly CSVAccessor accessor;
        public string Path { get; private set; }
        public int SupplierId { get; set; }

        public NovikoSupplier(string pathToFile)
        {
            accessor = new CSVAccessor();
            Path = pathToFile;
        }

        public void OpenPriceList()
        {
            novikoPriceList = accessor.LoadCSV<NovikoModel>(Path);
        }

        public IEnumerable<Object> GetPriceList()
        {
            return novikoPriceList.ToList();
        }

        public bool HasReference(string reference)
        {
            var item = novikoPriceList.Where(x => x.Reference == reference);
            if (item.Any())
            {
                return true;
            }
            return false;
        }
        
        public decimal GetPrice(string reference)
        {
            var item = novikoPriceList.Single(x => x.Reference == reference);
            return Convert.ToDecimal(item.PriceWithDph);
        }

        public decimal GetWholeSalePrice(string reference)
        {
            var item = novikoPriceList.Single(x => x.Reference == reference);
            return Convert.ToDecimal(item.SalePriceWithDph);
        }
    }
}

