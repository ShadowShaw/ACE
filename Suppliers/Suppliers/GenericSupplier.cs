using Suppliers.Accesors;
using Suppliers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Suppliers.Suppliers
{
    public class GenericSupplier<T> : ISupplier where T : class, ISupplierModel, new()
    {
        private IEnumerable<T> _priceList;
        private IAccessor _accessor;
        public string Path { get; private set; }
        public int SupplierId { get; set; }

        public GenericSupplier(string pathToFile)
        {
            Path = pathToFile;
        }

        public void OpenPriceList()
        {
            if (Path.EndsWith("csv"))
            {
                _accessor = new CsvAccessor();
            }
            if (Path.EndsWith("xls") || Path.EndsWith("xlsx"))
            {
                _accessor = new XlsAccessor();
            }
            _priceList = _accessor.Load<T>(Path);
        }

        public IEnumerable<Object> GetPriceList()
        {
            return _priceList.ToList();
        }

        public bool HasReference(string reference)
        {
            bool result = false;
            IEnumerable<T> item = _priceList.Where(x => x.GetReference() == reference);
            if (item.Any())
            {
                result = true;
            }
            return result;
        }

        public decimal GetPrice(string reference)
        {
            T item = _priceList.Single(x => x.GetReference() == reference);
            return Convert.ToDecimal(item.GetPrice());
        }

        public decimal GetWholeSalePrice(string reference)
        {
            T item = _priceList.Single(x => x.GetReference() == reference);
            return Convert.ToDecimal(item.GetWholeSalePrice());
        }
    }
}