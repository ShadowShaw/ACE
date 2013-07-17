using PrestaSharp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Presta
{
    public class ManufacturersAccesor : RESTAccessor 
    {
        public ManufacturersAccesor(string Url, string Token) : base( Url, Token) 
        {
        }

        public ps_manufacturer GetManufacturer(string id)
        {
            return this.Get("manufacturers", id);
        }

        public void DeleteManufacturer(string id)
        {
            this.Delete("manufacturers", id);
        }

        public Manufacturers ReceiveManufacturers()
        {
            Manufacturers result = new Manufacturers();
            string requestString = "api/manufacturers/?display=full";
            IRestRequest request = new RestRequest(requestString, Method.GET);

            result = restClient.Execute<Manufacturers>(request).Data;

            return result;
        }

        protected RestRequest RequestForAdd(string Resource, ps_manufacturer item)
        {
            var request = new RestRequest();
            request.Resource = Resource;
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
            string serialized = request.XmlSerializer.Serialize(item);
            serialized = serialized.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<prestashop>");
            serialized += "\n</prestashop>";
            request.AddParameter("xml", serialized);
            return request;
        }

        public void Add(ps_manufacturer Manufacturer)
        {
            //Manufacturer.id = null;
            RestRequest request = this.RequestForAdd("manufacturers", Manufacturer);
            restClient.Execute<ps_manufacturer>(request);
        }

        public void CreateManufacturer(ps_manufacturer item)
        {
            //var request = new RestRequest("api/manufacturers/", Method.POST);
            //request.RequestFormat = DataFormat.Json;
            //request.AddBody(item);
            //restClient.Execute(request);

            //var request = new RestRequest("/api/tickets.json", Method.POST); 
            //request.AddHeader("Accept", "application/json"); 
            //request.Parameters.Clear(); 
            //request.RequestFormat = RestSharp.DataFormat.Json; 
            //request.AddBody(item); 
            //IRestResponse response = restClient.Execute(request);
            //var content = response.Content; 


            Add(item);


            //var request = new RestRequest(Method.POST);
            //request.Resource = "api/manufacturers/";

            ////            request.AddParameter("CallSid", item.id, ParameterType.UrlSegment);
            //request.AddParameter("name", item.name);
            //request.AddParameter("date_add", item.date_add);
            //request.AddParameter("date_upd", item.date_upd);
            //request.AddParameter("active", item.active);

            //var r = restClient.Execute(request);
            //var content = r.Content; // raw content as string
        }

        public void UpdateManufacturer(ps_manufacturer item)
        {
            var request = new RestRequest(Method.PATCH);
            request.Resource = "api/manufacturers/{CallSid}";

            request.AddParameter("CallSid", item.id, ParameterType.UrlSegment);
            request.AddParameter("name", item.name);
            request.AddParameter("date_add", item.date_add);
            request.AddParameter("date_upd", item.date_upd);
            request.AddParameter("active", item.active);

            var r = restClient.Execute(request);
            var content = r.Content; // raw content as string
        
        }

    }
}
