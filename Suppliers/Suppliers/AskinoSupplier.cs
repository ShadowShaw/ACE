using Suppliers.Accesors;
using Suppliers.Interfaces;
using Suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suppliers
{
    public class AskinoSupplier : ISupplier
    {
        private IEnumerable<SupplierModel> askinoPriceList;
        private CSVAccessor accessor;

        public AskinoSupplier()
        {
            accessor = new CSVAccessor();
        }

        public void OpenPriceList(string path)
        {
            askinoPriceList = accessor.loadCSV<AskinoModel>(path);
        }

        public List<SupplierModel> GetPriceList()
        {
            return askinoPriceList.ToList();
        }

        //private bool HasReference(string reference)
        //{
        //    var item = askinoPriceList.Where(x => x.Reference == reference);
        //    if (item.ToList().Count > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //private decimal GetPrice(string reference)
        //{
        //    var item = askinoPriceList.Where(x => x.Reference == reference).FirstOrDefault(); //.Select(x => x.PriceWithDph).Distinct();
        //    return System.Convert.ToDecimal(item.PriceWithDph);
        //}

        public void repriceAskino(string operation, int idManufacturer)
        {
            //List<Product> items = products.Where(x => x.IdManufacturer == askinoIdSupplier).ToList();

            //var r = getOperation(operation);
            //operation = operation.Substring(1);

            //foreach (Product p in items)
            //{
            //    if (isReferenceInAskino(p.Reference))
            //    {
            //        if (p.IdManufacturer == idManufacturer)
            //        {
            //            decimal askinoPrice = getNovikoPrice(p.Reference);

            //            if (r == "+")
            //            {
            //                p.Price = askinoPrice + System.Convert.ToDecimal(operation);
            //            }

            //            if (r == "%")
            //            {
            //                p.Price = askinoPrice * System.Convert.ToDecimal(operation);
            //            }
            //        }
            //    }
            //}
        }

        //public List<ProductViewModel> checkConsistencyAskino()
        //{
        //    List<ProductViewModel> result = new List<ProductViewModel>();

        //    List<ProductViewModel> productListAskino = products.Select(x => x).Where(x => x.IdSupplier == GetAskinoId()).ToList();
        //    List<AskinoModel> askinoList = askinoPriceList.Select(x => x).ToList();

        //    foreach (ProductViewModel s in productListAskino)
        //    {
        //        var result1 = askinoList.Where(y => y.Reference == s.id.ToString()).ToList();
        //        if (result1.Count == 0)
        //        {
        //            result.Add(s);
        //        }
        //    }

        //    return result;
        //}

    }
} 