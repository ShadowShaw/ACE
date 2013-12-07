using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suppliers.Models
{
    public abstract class SupplierModel
    {
        public string PriceWithDph { get; set; }
        public string Reference { get; set; }
    }
}
