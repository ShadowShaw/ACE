using PrestaAccesor.Accesors;
using PrestaAccesor.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PrestaAccesor.Serializers
{
    public class ProductList
    {
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public string id { get; set; }
    }

    public class ProductsAccesor : RestSharpAccesor, IRestAccesor
    {
        public ProductsAccesor(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.prestashopentity Get(int EntityId)
        {
            RestRequest request = this.RequestForGet("products", EntityId, "product");
            return this.Execute<Entities.product>(request);
        }

        public void Add(Entities.product Product)
        {
            Product.id=null;
            RestRequest request = this.RequestForAdd("products", Product);
            this.Execute<Entities.product>(request);
        }

        public void AddImage(int ProductId, string ProductImagePath)
        {
            RestRequest request = this.RequestForAddImage("products", ProductId, ProductImagePath);
            this.Execute<Entities.product>(request);
        }

        public void Update(Entities.product Product)
        {
            RestRequest request = this.RequestForUpdate("products", Product.id, Product);
            try
            {
                this.Execute<Entities.product>(request);
            }
            catch (ApplicationException ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Entities.product Product)
        {
            RestRequest request = this.RequestForDelete("products", Product.id);
            this.Execute<Entities.product>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = this.RequestForGet("products", null, "prestashop");
            return this.ExecuteForGetIds<List<int>>(request, "product");
        }

        public List<int> GetIdsPartial()
        {
            int startItem = 0;
            
            List<int> result = new List<int>();
            ProductList IdList = new ProductList();
            do
            {
                string requestString = String.Format("products/?display=[id]&limit={0},{1}", startItem, StepCount);
                IRestRequest request = new RestRequest(requestString, Method.GET);

                IdList = client.Execute<ProductList>(request).Data;
                startItem = startItem + StepCount;

                if (IdList == null)
                {
                    return null;
                }
                    foreach (var item in IdList.Products)
                    {
                        result.Add(System.Convert.ToInt32(item.id));
                    }
            } while (IdList.Products.Count == 500);

            return result;
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.product> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("products", "full", Filter, Sort, Limit, "products");
            return this.Execute<List<Entities.product>>(request);
        }

        public List<Entities.product> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}
