using PrestaAccesor.Entities;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PrestaAccesor.Accesors
{
    public class SupplierList
    {
        public List<Supplier> Suppliers { get; set; }
    }

    public class Supplier
    {
        public string Id { get; set; }
    }

    public class SupplierAccesor : RestSharpAccesor, IRestAccesor
    {
        public SupplierAccesor(string baseUrl, string account, string secretKey)
            : base(baseUrl, account, secretKey)
        {

        }

        public PrestashopEntity Get(long? entityId)
        {
            RestRequest request = RequestForGet("suppliers", entityId, "supplier");
            return Execute<supplier>(request);
        }

        public void Add(PrestashopEntity category)
        {
            category.id = null;
            RestRequest request = RequestForAdd("suppliers", category);
            Execute<supplier>(request);
        }

        public void AddImage(int supplierId, string supplierImagePath)
        {
            RestRequest request = RequestForAddImage("suppliers", supplierId, supplierImagePath);
            Execute<supplier>(request);
        }

        public void Update(PrestashopEntity product)
        {
            RestRequest request = RequestForUpdate("suppliers", product.id, product);
            try
            {
                Execute<supplier>(request);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Delete(PrestashopEntity product)
        {
            RestRequest request = RequestForDelete("suppliers", product.id);
            Execute<supplier>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = RequestForGet("suppliers", null, "prestashop");
            return ExecuteForGetIds<List<int>>(request, "supplier");
        }

        public List<int> GetIdsPartial()
        {
            int startItem = 0;

            List<int> result = new List<int>();
            SupplierList idList;
            do
            {
                string requestString = String.Format("suppliers/?display=[id]&limit={0},{1}", startItem, StepCount);
                IRestRequest request = new RestRequest(requestString, Method.GET);

                idList = Client.Execute<SupplierList>(request).Data;
                startItem = startItem + StepCount;

                foreach (var item in idList.Suppliers)
                {
                    result.Add(Convert.ToInt32(item.Id));
                }
            } while (idList.Suppliers.Count == 500);

            return result;
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="filter">Example: key:name value:Apple</param>
        /// <param name="sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<supplier> GetByFilter(Dictionary<string, string> filter, string sort, string limit)
        {
            RestRequest request = RequestForFilter("suppliers", "full", filter, sort, limit, "suppliers");
            return Execute<List<supplier>>(request);
        }

        /// <summary>
        /// Get all suppliers.
        /// </summary>
        /// <returns>A list of supplier</returns>
        public List<supplier> GetAll()
        {
            return GetByFilter(null, null, null);
        }
    }
}
