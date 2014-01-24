using RestSharp;
using System;
using System.Collections.Generic;

namespace PrestaAccesor.Accesors
{
    public class ManufacturerList
    {
        public List<Manufacturer> Manufacturers { get; set; }
    }

    public class Manufacturer
    {
        public string Id { get; set; }
    }

    public class ManufacturersAccesor : RestSharpAccesor, IRestAccesor
    {
        public ManufacturersAccesor(string baseUrl, string account, string secretKey)
            : base(baseUrl, account, secretKey)
        {

        }

        public Entities.PrestashopEntity Get(long? entityId)
        {
            RestRequest request = RequestForGet("manufacturers", entityId, "manufacturer");
            return Execute<Entities.manufacturer>(request);
        }

        public void Add(Entities.PrestashopEntity category)
        {
            category.id = null;
            RestRequest request = RequestForAdd("manufacturers", category);
            Execute<Entities.manufacturer>(request);
        }

        public void AddImage(int manufacturerId, string manufacturerImagePath)
        {
            RestRequest request = RequestForAddImage("manufacturers", manufacturerId, manufacturerImagePath);
            Execute<Entities.manufacturer>(request);
        }

        public void Update(Entities.PrestashopEntity product)
        {
            RestRequest request = RequestForUpdate("manufacturers", product.id, product);
            try
            {
                Execute<Entities.manufacturer>(request);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Delete(Entities.PrestashopEntity product)
        {
            RestRequest request = RequestForDelete("manufacturers", product.id);
            Execute<Entities.manufacturer>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = RequestForGet("manufacturers", null, "prestashop");
            return ExecuteForGetIds<List<int>>(request, "manufacturer");
        }

        public List<int> GetIdsPartial()
        {
            int startItem = 0;
            
            List<int> result = new List<int>();
            ManufacturerList idList;
            do
            {
                string requestString = String.Format("manufacturers/?display=[id]&limit={0},{1}", startItem, StepCount);
                IRestRequest request = new RestRequest(requestString, Method.GET);

                idList = Client.Execute<ManufacturerList>(request).Data;
                startItem = startItem + StepCount;

                foreach (var item in idList.Manufacturers)
                {
                    result.Add(Convert.ToInt32(item.Id));
                }
            } while (idList.Manufacturers.Count == 500);

            return result;
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="filter">Example: key:name value:Apple</param>
        /// <param name="sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.manufacturer> GetByFilter(Dictionary<string, string> filter, string sort, string limit)
        {
            RestRequest request = RequestForFilter("manufacturers", "full", filter, sort, limit, "manufacturers");
            return Execute<List<Entities.manufacturer>>(request);
        }

        /// <summary>
        /// Get all manufacturers.
        /// </summary>
        /// <returns>A list of manufacturers</returns>
        public List<Entities.manufacturer> GetAll()
        {
            return GetByFilter(null, null, null);
        }
    }
}
