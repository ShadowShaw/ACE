using System.Collections.Generic;

namespace Suppliers.Interfaces
{
    interface IAccessor
    {
        IEnumerable<T> Load<T>(string filename) where T : class, new();
    }
}
