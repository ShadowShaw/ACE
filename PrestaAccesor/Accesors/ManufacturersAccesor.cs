using PrestaAccesor.Accesors;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaAccesor.Serializers
{
    public class ManufacturerList
    {
        public List<Manufacturer> Manufacturers { get; set; }
    }

    public class Manufacturer
    {
        public string id { get; set; }
    }

    public class ManufacturersAccesor : RestSharpAccesor, IRestAccesor
    {
        public ManufacturersAccesor(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.prestashopentity Get(int EntityId)
        {
            RestRequest request = this.RequestForGet("manufacturers", EntityId, "manufacturer");
            return this.Execute<Entities.manufacturer>(request);
        }

        public void Add(Entities.manufacturer Manufacturer)
        {
            Manufacturer.id = null;
            RestRequest request = this.RequestForAdd("manufacturers", Manufacturer);
            this.Execute<Entities.manufacturer>(request);
        }

        public void AddImage(int ManufacturerId, string ManufacturerImagePath)
        {
            RestRequest request = this.RequestForAddImage("manufacturers", ManufacturerId, ManufacturerImagePath);
            this.Execute<Entities.manufacturer>(request);
        }

        public void Update(Entities.manufacturer Manufacturer)
        {
            RestRequest request = this.RequestForUpdate("manufacturers", Manufacturer.id, Manufacturer);
            try
            {
                this.Execute<Entities.manufacturer>(request);
            }
            catch (ApplicationException ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Entities.manufacturer Manufacturer)
        {
            RestRequest request = this.RequestForDelete("manufacturers", Manufacturer.id);
            this.Execute<Entities.manufacturer>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = this.RequestForGet("manufacturers", null, "prestashop");
            return this.ExecuteForGetIds<List<int>>(request, "manufacturer");
        }

        public List<int> GetIdsPartial()
        {
            int startItem = 0;
            
            List<int> result = new List<int>();
            ManufacturerList IdList = new ManufacturerList();
            do
            {
                string requestString = String.Format("manufacturers/?display=[id]&limit={0},{1}", startItem, StepCount);
                IRestRequest request = new RestRequest(requestString, Method.GET);

                IdList = client.Execute<ManufacturerList>(request).Data;
                startItem = startItem + StepCount;

                foreach (var item in IdList.Manufacturers)
                {
                    result.Add(System.Convert.ToInt32(item.id));
                }
            } while (IdList.Manufacturers.Count == 500);

            return result;
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.prestashopentity> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("manufacturers", "full", Filter, Sort, Limit, "manufacturers");
            return this.Execute<List<Entities.prestashopentity>>(request);
        }

        /// <summary>
        /// Get all manufacturers.
        /// </summary>
        /// <returns>A list of manufacturers</returns>
        public List<Entities.prestashopentity> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}
