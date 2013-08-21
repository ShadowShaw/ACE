using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.ViewModels
{
    public class ProductViewModel
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string description_short { get; set; }
        public long? id_supplier { get; set; }
        public long? id_manufacturer { get; set; }
        public long? id_category_default { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> wholesale_price { get; set; }
        public Nullable<decimal> weight { get; set; }
        public int id_image { get; set; }
    }
}