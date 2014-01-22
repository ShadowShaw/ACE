using Bussiness.ViewModels;
using Suppliers.Interfaces;
using System.Collections.Generic;

namespace Bussiness.Services
{
    public class RepriceLimits
    {
        public int Limit;
        public int Value;
    }
    public class PricingService
    {
        private List<ProductViewModel> productToReprice;
        private SupplierService supplierService;
        private PriceListsService priceListsService;

        public delegate int BinaryOp(int x, int y);
        
        public PricingService()
        {
            productToReprice = new List<ProductViewModel>();
        }

        public void Setup(SupplierService suppliers, PriceListsService priceLists)
        {
            supplierService = suppliers;
            priceListsService = priceLists;
        }

        public List<ProductViewModel> GetProducts()
        {
            return productToReprice;
        }

        public void SetProducts(List<ProductViewModel> products)
        {
            productToReprice = products;
        }

        public void UpdatePrices()
        {
            foreach (ProductViewModel product in productToReprice)
            {
                string supplierName = supplierService.GetSupplierName(product.IdSupplier);
                ISupplier priceList = priceListsService[supplierName];
                if (priceList.HasReference(product.Reference))
                {
                    product.Price = priceListsService[supplierName].GetPrice(product.Reference);
                    product.WholesalePrice = priceListsService[supplierName].GetWholeSalePrice(product.Reference);
                }
            }
        }

        public void ProcentReprice(decimal procent)
        {
            foreach (ProductViewModel product in productToReprice)
            {
                product.Price = product.Price * procent;
                product.WholesalePrice = product.WholesalePrice * procent;
            }
        }

        public void LimitReprice(List<RepriceLimits> limits)
        {
            
        }

        public void LimitReprice(decimal limit, decimal below, decimal above)
        {
            foreach (ProductViewModel product in productToReprice)
            {
                if (product.Price > limit)
                {
                    product.Price = product.Price + above;
                }
                else
                {
                    product.Price = product.Price + below;
                }

                if (product.WholesalePrice > limit)
                {
                    product.WholesalePrice = product.WholesalePrice + above;
                }
                else
                {
                    product.WholesalePrice = product.WholesalePrice + below;
                }
            }
        }
//        //Delegate can point to any method which takes 2 int and returns single int


////Delegate can point to any method in this class
//public class SimpleMath
//{
//   public static int Add(int x, int y)
//   {
//      return x + y;
//   }

//   public static int Subtract(int x, int y)
//   {
//      return x - y;
//   }
//}

////Create instance of delegate type and call
//BinaryOp b = new BinaryOp(SimpleMath.Add);
//Console.WriteLine("10 + 10 is {0}", b(10, 10));

        
    }
}
