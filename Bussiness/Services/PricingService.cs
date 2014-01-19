using Bussiness.ViewModels;
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
        public delegate int BinaryOp(int x, int y);
        
        public PricingService()
        {
            productToReprice = new List<ProductViewModel>();
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
            //foreach (ProductViewModel product in productToReprice)
            {
                //product.id_supplier
                //product.price = product.price * procent;
                //product.wholesale_price = product.wholesale_price * procent;
            }
        }

        public void ProcentReprice(decimal procent)
        {
            foreach (ProductViewModel product in productToReprice)
            {
                product.price = product.price * procent;
                product.wholesale_price = product.wholesale_price * procent;
            }
        }

        public void LimitReprice(List<RepriceLimits> limits)
        {
            
        }

        public void LimitReprice(decimal limit, decimal below, decimal above)
        {
            foreach (ProductViewModel product in productToReprice)
            {
                if (product.price > limit)
                {
                    product.price = product.price + above;
                }
                else
                {
                    product.price = product.price + below;
                }

                if (product.wholesale_price > limit)
                {
                    product.wholesale_price = product.wholesale_price + above;
                }
                else
                {
                    product.wholesale_price = product.wholesale_price + below;
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
