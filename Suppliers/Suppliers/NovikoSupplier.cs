using Suppliers.Accesors;
using Suppliers.Interfaces;
using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suppliers
{
    public class NovikoSupplier : ISupplier
    {
        private IEnumerable<NovikoModel> novikoPriceList;
        private CSVAccessor accessor;
        public string Path { get; private set; } 

        public NovikoSupplier(string pathToFile)
        {
            accessor = new CSVAccessor();
            Path = pathToFile;
        }

        public void OpenPriceList()
        {
            novikoPriceList = accessor.loadCSV<NovikoModel>(Path);
        }

        public IEnumerable<Object> GetPriceList()
        {
            return novikoPriceList.ToList() as IEnumerable<NovikoModel>;
        }

        public bool HasReference(string reference)
        {
            var item = novikoPriceList.Where(x => x.Reference == reference);
            if (item.ToList().Count > 0)
            {
                return true;
            }
            return false;
        }

        //private decimal GetPrice(string reference) 
        //{
        //    var item = novikoPriceList.Where(x => x.Reference == reference).FirstOrDefault(); //.Select(x => x.PriceWithDph).Distinct();
        //    return System.Convert.ToDecimal(item.PriceWithDph);
        //}

        //public List<ProductViewModel> checkConsistenceNoviko()
        //{
        //    List<ProductViewModel> result = new List<ProductViewModel>();

        //    List<ProductViewModel> productListNoviko = products.Select(x => x).Where(x => x.IdSupplier == GetNovikoId()).ToList();
        //    List<NovikoModel> novikoList = noviko.Select(x => x).ToList();

        //    foreach (ProductViewModel s in productListNoviko)
        //    {
        //        var result1 = novikoList.Where(y => y.Reference == s.Id.ToString()).ToList();
        //        if (result1.Count == 0)
        //        {
        //            result.Add(s);
        //        }
        //    }

        //    return result;
        //}


        //public void repriceNoviko(string operation, int idManufacturer)
        //{
        //    List<Product> productList = products.ToList();
        //    List<Product> items = products.Where(x => x.IdManufacturer == novikoIdSupplier).ToList();

        //    var r = getOperation(operation);
        //    operation = operation.Substring(1);

        //    for (int i = 0; i < productList.Count; i++)
        //    {
        //        if (productList[i].IdManufacturer == novikoIdSupplier)
        //        {
        //            if (isReferenceInNoviko(productList[i].Reference))
        //            {
        //                if (productList[i].IdManufacturer == idManufacturer)
        //                {
        //                    decimal novikoPrice = getNovikoPrice(productList[i].Reference);

        //                    if (r == "+")
        //                    {
        //                        productList[i].Price = novikoPrice + System.Convert.ToDecimal(operation);
        //                    }

        //                    if (r == "%")
        //                    {
        //                        productList[i].Price = novikoPrice * System.Convert.ToDecimal(operation);
        //                    }
        //                }
        //            }    
        //        }
        //    }
        //    products = productList;
        //}
    }
}

