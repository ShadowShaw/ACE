using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suppliers.Interfaces
{
    public interface ISupplier
    {
        void OpenPriceList(string path);
        List<SupplierModel> GetPriceList();
        //bool HasReference(string reference);
        //decimal GetPrice(string reference);
    }
}
