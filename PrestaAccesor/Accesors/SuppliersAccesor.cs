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
    public class SupplierList
    {
        public List<Supplier> Suppliers { get; set; }
    }

    public class Supplier
    {
        public string id { get; set; }
    }

    public class SupplierAccesor : RestSharpAccesor, IRestAccesor
    {
        public SupplierAccesor(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.PrestashopEntity Get(long? EntityId)
        {
            RestRequest request = this.RequestForGet("suppliers", EntityId, "supplier");
            return this.Execute<Entities.supplier>(request);
        }

        public void Add(Entities.PrestashopEntity Supplier)
        {
            Supplier.id = null;
            RestRequest request = this.RequestForAdd("suppliers", Supplier);
            this.Execute<Entities.supplier>(request);
        }

        public void AddImage(int SupplierId, string SupplierImagePath)
        {
            RestRequest request = this.RequestForAddImage("suppliers", SupplierId, SupplierImagePath);
            this.Execute<Entities.supplier>(request);
        }

        public void Update(Entities.PrestashopEntity Supplier)
        {
            RestRequest request = this.RequestForUpdate("suppliers", Supplier.id, Supplier);
            try
            {
                this.Execute<Entities.supplier>(request);
            }
            catch (ApplicationException ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Entities.PrestashopEntity Supplier)
        {
            RestRequest request = this.RequestForDelete("suppliers", Supplier.id);
            this.Execute<Entities.supplier>(request);
        }

        public List<int> GetIds()
        {
            RestRequest request = this.RequestForGet("suppliers", null, "prestashop");
            return this.ExecuteForGetIds<List<int>>(request, "supplier");
        }

        public List<int> GetIdsPartial()
        {
            int startItem = 0;

            List<int> result = new List<int>();
            SupplierList IdList = new SupplierList();
            do
            {
                string requestString = String.Format("suppliers/?display=[id]&limit={0},{1}", startItem, StepCount);
                IRestRequest request = new RestRequest(requestString, Method.GET);

                IdList = client.Execute<SupplierList>(request).Data;
                startItem = startItem + StepCount;

                foreach (var item in IdList.Suppliers)
                {
                    result.Add(System.Convert.ToInt32(item.id));
                }
            } while (IdList.Suppliers.Count == 500);

            return result;
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.supplier> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("suppliers", "full", Filter, Sort, Limit, "suppliers");
            return this.Execute<List<Entities.supplier>>(request);
        }

        /// <summary>
        /// Get all suppliers.
        /// </summary>
        /// <returns>A list of supplier</returns>
        public List<Entities.supplier> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}
