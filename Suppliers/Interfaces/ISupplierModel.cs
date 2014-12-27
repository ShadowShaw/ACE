using System.Collections.Generic;

namespace Suppliers.Interfaces
{
    public interface ISupplierModel
    {
        Dictionary<int, string> GetMapping();
        int GetFileTableIndex();
        int GetReferenceColumnIndex();
        string GetReference();
        decimal GetPrice();
        decimal GetWholeSalePrice();

    }
}
