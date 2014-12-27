using System.Collections.Generic;
using Suppliers.Suppliers;

namespace Suppliers.Interfaces
{
    interface IAccessor
    {
        IEnumerable<T> Load<T>(string filename) where T : class, ISupplierModel, new();
    }
}
