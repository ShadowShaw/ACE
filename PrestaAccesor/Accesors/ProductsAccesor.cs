using PrestaAccesor.Entities;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PrestaAccesor.Accesors
{
    public class ProductList
    {
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public string Id { get; set; }
    }

    public class ProductsAccesor : RestSharpAccesor, IRestAccesor
    {
        public ProductsAccesor(string baseUrl, string account, string secretKey) : base(baseUrl, account, secretKey)
        {

        }

        public PrestashopEntity Get(long? entityId)
        {
            RestRequest request = RequestForGet("products", entityId, "product");
            return Execute<Entities.Product>(request);
        }

        public void Add(PrestashopEntity category)
        {
            category.id = null;
            RestRequest request = RequestForAdd("products", category);
            Execute<Entities.Product>(request);
        }

        public void AddImage(int productId, string productImagePath)
        {
            RestRequest request = RequestForAddImage("products", productId, productImagePath);
            Execute<Entities.Product>(request);
        }

        public void Update(PrestashopEntity product)
        {
            RestRequest request = RequestForUpdate("products", product.id, product);
            try
            {
                Execute<Entities.Product>(request);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Delete(PrestashopEntity product)
        {
            RestRequest request = RequestForDelete("products", product.id);
            Execute<Entities.Product>(request);
        }

        public void Delete(long? productId)
        {
            RestRequest request = RequestForDelete("products", productId);
            Execute<Entities.Product>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = RequestForGet("products", null, "prestashop");
            return ExecuteForGetIds<List<int>>(request, "product");
        }

        public List<int> GetIdsPartial()
        {
            int startItem = 0;
            
            List<int> result = new List<int>();
            ProductList idList;
            do
            {
                string requestString = String.Format("products/?display=[id]&limit={0},{1}", startItem, StepCount);
                IRestRequest request = new RestRequest(requestString, Method.GET);

                idList = Client.Execute<ProductList>(request).Data;
                startItem = startItem + StepCount;

                if (idList == null)
                {
                    return null;
                }
                    foreach (var item in idList.Products)
                    {
                        result.Add(Convert.ToInt32(item.Id));
                    }
            } while (idList.Products.Count == 500);

            return result;
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="filter">Example: key:name value:Apple</param>
        /// <param name="sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.Product> GetByFilter(Dictionary<string, string> filter, string sort, string limit)
        {
            RestRequest request = RequestForFilter("products", "full", filter, sort, limit, "products");
            return Execute<List<Entities.Product>>(request);
        }

        public List<Entities.Product> GetAll()
        {
            return GetByFilter(null, null, null);
        }
    }
}
