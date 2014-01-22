using System;
using System.Collections.Generic;
using RestSharp;

namespace PrestaAccesor.Accesors
{
    public class LanguageList
    {
        public List<Language> Languages { get; set; }
    }

    public class Language
    {
        public string Id { get; set; }
    }


    public class LanguageAccesor: RestSharpAccesor, IRestAccesor
    {
        public LanguageAccesor(string baseUrl, string account, string secretKey) : base(baseUrl, account, secretKey)
        {

        }

        public Entities.PrestashopEntity Get(long? entityId)
        {
            RestRequest request = RequestForGet("languages", entityId, "language");
            return Execute<Entities.LanguageEntity>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = RequestForGet("languages", null, "prestashop");
            return ExecuteForGetIds<List<int>>(request, "language");
        }

        public List<int> GetIdsPartial()
        {
            return GetIds();
        }

        public void Update(Entities.PrestashopEntity product)
        {
            RestRequest request = RequestForUpdate("languages", product.id, product);
            try
            {
                Execute<Entities.LanguageEntity>(request);
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Delete(Entities.PrestashopEntity product)
        {
            RestRequest request = RequestForDelete("languages", product.id);
            Execute<Entities.language>(request);
        }

        public void Add(Entities.PrestashopEntity category)
        {
            category.id = null;
            RestRequest request = RequestForAdd("languages", category);
            Execute<Entities.LanguageEntity>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="filter">Example: key:name value:Apple</param>
        /// <param name="sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.LanguageEntity> GetByFilter(Dictionary<string, string> filter, string sort, string limit)
        {
            RestRequest request = RequestForFilter("languages", "full", filter, sort, limit, "language");
            return Execute<List<Entities.LanguageEntity>>(request);
        }

        /// <summary>
        /// Get all manufacturers.
        /// </summary>
        /// <returns>A list of manufacturers</returns>
        public List<Entities.LanguageEntity> GetAll()
        {
            return GetByFilter(null, null, null);
        }
    }
}
