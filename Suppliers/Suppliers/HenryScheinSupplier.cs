using Suppliers.Accesors;
using Suppliers.Interfaces;
using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Suppliers.Suppliers
{
    public class HenryScheinSupplier : ISupplier
    {
        private IEnumerable<HenryScheinModel> novikoPriceList;
        private IAccessor accessor;
        public string Path { get; private set; }
        public int SupplierId { get; set; }

        public HenryScheinSupplier(string pathToFile)
        {
            Path = pathToFile;
        }

        public void OpenPriceList()
        {
            if (Path.EndsWith("csv"))
            {
                accessor = new CSVAccessor();
            }
            if (Path.EndsWith("xls"))
            {
                accessor = new XLSAccessor();
            }
            novikoPriceList = accessor.Load<HenryScheinModel>(Path);
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

