using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestaAccesor.Accesors;
using RestSharp;

namespace PrestaAccesor.Accesors
{
    public class LanguageList
    {
        public List<Language> Languages { get; set; }
    }

    public class Language
    {
        public string id { get; set; }
    }


    public class LanguageAccesor: RestSharpAccesor, IRestAccesor
    {
        public LanguageAccesor(string BaseUrl, string Account, string SecretKey) : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.prestashopentity Get(int EntityId)
        {
            RestRequest request = this.RequestForGet("languages", EntityId, "language");
            return this.Execute<Entities.languageEntity>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = this.RequestForGet("languages", null, "prestashop");
            return this.ExecuteForGetIds<List<int>>(request, "language");
        }

        public List<int> GetIdsPartial()
        {
            return GetIds();
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.languageEntity> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("languages", "full", Filter, Sort, Limit, "language");
            return this.Execute<List<Entities.languageEntity>>(request);
        }

        /// <summary>
        /// Get all manufacturers.
        /// </summary>
        /// <returns>A list of manufacturers</returns>
        public List<Entities.languageEntity> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}
