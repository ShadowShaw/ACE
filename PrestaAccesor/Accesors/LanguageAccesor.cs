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

        public Entities.PrestashopEntity Get(long? EntityId)
        {
            RestRequest request = this.RequestForGet("languages", EntityId, "language");
            return this.Execute<Entities.LanguageEntity>(request);
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

        public void Update(Entities.PrestashopEntity Language)
        {
            RestRequest request = this.RequestForUpdate("languages", Language.id, Language);
            try
            {
                this.Execute<Entities.LanguageEntity>(request);
            }
            catch (ApplicationException ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Entities.PrestashopEntity Language)
        {
            RestRequest request = this.RequestForDelete("languages", Language.id);
            this.Execute<Entities.language>(request);
        }

        public void Add(Entities.PrestashopEntity Language)
        {
            Language.id = null;
            RestRequest request = this.RequestForAdd("languages", Language);
            this.Execute<Entities.LanguageEntity>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.LanguageEntity> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("languages", "full", Filter, Sort, Limit, "language");
            return this.Execute<List<Entities.LanguageEntity>>(request);
        }

        /// <summary>
        /// Get all manufacturers.
        /// </summary>
        /// <returns>A list of manufacturers</returns>
        public List<Entities.LanguageEntity> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}
