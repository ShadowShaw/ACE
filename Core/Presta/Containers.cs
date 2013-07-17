using PrestaSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Presta
{
    public class Manufacturers
    {
        public List<ps_manufacturer> manufacturers { get; set; }
    }

    public class Products
    {
        public List<ps_product> products { get; set; }
    }

    public class Categories
    {
        public List<ps_category_group> categories { get; set; }
    }
}
