using PrestaAccesor.Accesors;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaAccesor.Accesors
{
    public class CategoryList
    {
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
    }


    public class CategoriesAccesor : RestSharpAccesor, IRestAccesor
    {
        public CategoriesAccesor(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.PrestashopEntity Get(long? EntityId)
        {
            RestRequest request = this.RequestForGet("categories", EntityId, "category");
            return this.Execute<Entities.category>(request);
        }

        public void Add(Entities.category Category)
        {
            Category.id = null;
            RestRequest request = this.RequestForAdd("categories", Category);
            this.Execute<Entities.category>(request);
        }

        public void AddImage(int CategoryId, string CategoryImagePath)
        {
            RestRequest request = this.RequestForAddImage("categories", CategoryId, CategoryImagePath);
            this.Execute<Entities.manufacturer>(request);
        }

        public void Update(Entities.PrestashopEntity Category)
        {
            RestRequest request = this.RequestForUpdate("categories", Category.id, Category);
            try
            {
                this.Execute<Entities.category>(request);
            }
            catch (ApplicationException ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Entities.PrestashopEntity Category)
        {
            RestRequest request = this.RequestForDelete("categories", Category.id);
            this.Execute<Entities.category>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = this.RequestForGet("categories", null, "prestashop");
            return this.ExecuteForGetIds<List<int>>(request, "category");
        }

        public List<int> GetIdsPartial()
        {
            int startItem = 0;

            List<int> result = new List<int>();
            CategoryList IdList = new CategoryList();
            do
            {
                string requestString = String.Format("categories/?display=[id]&limit={0},{1}", startItem, StepCount);
                IRestRequest request = new RestRequest(requestString, Method.GET);

                IdList = client.Execute<CategoryList>(request).Data;
                startItem = startItem + StepCount;

                foreach (var item in IdList.Categories)
                {
                    result.Add(System.Convert.ToInt32(item.id));
                }
            } while (IdList.Categories.Count == 500);

            return result;
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.category> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("categories", "full", Filter, Sort, Limit, "categories");
            return this.Execute<List<Entities.category>>(request);
        }

        /// <summary>
        /// Get all manufacturers.
        /// </summary>
        /// <returns>A list of manufacturers</returns>
        public List<Entities.category> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}
