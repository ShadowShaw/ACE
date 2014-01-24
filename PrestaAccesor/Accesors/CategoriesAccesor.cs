using RestSharp;
using System;
using System.Collections.Generic;

namespace PrestaAccesor.Accesors
{
    public class CategoryList
    {
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
    }


    public class CategoriesAccesor : RestSharpAccesor, IRestAccesor
    {
        public CategoriesAccesor(string baseUrl, string account, string secretKey)
            : base(baseUrl, account, secretKey)
        {

        }

        public Entities.PrestashopEntity Get(long? entityId)
        {
            RestRequest request = RequestForGet("categories", entityId, "category");
            return Execute<Entities.category>(request);
        }

        public void Add(Entities.PrestashopEntity category)
        {
            category.id = null;
            RestRequest request = RequestForAdd("categories", category);
            Execute<Entities.category>(request);
        }

        public void AddImage(int categoryId, string categoryImagePath)
        {
            RestRequest request = RequestForAddImage("categories", categoryId, categoryImagePath);
            Execute<Entities.manufacturer>(request);
        }

        public void Update(Entities.PrestashopEntity product)
        {
            RestRequest request = RequestForUpdate("categories", product.id, product);
            try
            {
                Execute<Entities.category>(request);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Entities.PrestashopEntity product)
        {
            RestRequest request = RequestForDelete("categories", product.id);
            Execute<Entities.category>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = RequestForGet("categories", null, "prestashop");
            return ExecuteForGetIds<List<int>>(request, "category");
        }

        public List<int> GetIdsPartial()
        {
            int startItem = 0;

            List<int> result = new List<int>();
            CategoryList idList;
            do
            {
                string requestString = String.Format("categories/?display=[id]&limit={0},{1}", startItem, StepCount);
                IRestRequest request = new RestRequest(requestString, Method.GET);

                idList = Client.Execute<CategoryList>(request).Data;
                startItem = startItem + StepCount;

                foreach (var item in idList.Categories)
                {
                    result.Add(Convert.ToInt32(item.Id));
                }

            } while (idList.Categories.Count == 500);

            return result;
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="filter">Example: key:name value:Apple</param>
        /// <param name="sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.category> GetByFilter(Dictionary<string, string> filter, string sort, string limit)
        {
            RestRequest request = RequestForFilter("categories", "full", filter, sort, limit, "categories");
            return Execute<List<Entities.category>>(request);
        }

        /// <summary>
        /// Get all manufacturers.
        /// </summary>
        /// <returns>A list of manufacturers</returns>
        public List<Entities.category> GetAll()
        {
            return GetByFilter(null, null, null);
        }
    }
}
