using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interfaces
{
    public interface ISupplier
    {
        void OpenPriceListCSV(string path);
        //public List<AskinoModel> GetPriceList();
        bool HasReference(string reference);
        decimal GetPrice(string reference);
    }
}
