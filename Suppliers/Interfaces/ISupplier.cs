using System;
using System.Collections.Generic;

namespace Suppliers.Interfaces
{
    public interface ISupplier
    {
        void OpenPriceList();
        IEnumerable<Object> GetPriceList();
        bool HasReference(string reference);
        decimal GetPrice(string reference);
        decimal GetWholeSalePrice(string reference);
    }
}
