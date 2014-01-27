using System;
using Bussiness.Interfaces;

namespace Bussiness.ViewModels
{
    [Serializable]
    public class ProductViewModel : IViewModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionShort { get; set; }
        public long? IdSupplier { get; set; }
        public long? IdManufacturer { get; set; }
        public long? IdCategoryDefault { get; set; }
        public decimal? Price { get; set; }
        public decimal? WholesalePrice { get; set; }
        public decimal? Weight { get; set; }
        public string Reference { get; set; }
        public int IdImage { get; set; }
        public string LinkRewrite { get; set; }
    }
}