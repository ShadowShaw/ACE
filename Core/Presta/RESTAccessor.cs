using PrestaSharp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Core.Presta
{
    public class RESTAccessor<T> where T : class 
    {
        //http://testpresta.mzf.cz/prestashop/api/manufacturers

        private RestClient restClient;
        public RESTAccessor(string Url, string Token)
        {
            Url = "http://testpresta.mzf.cz/prestashop/";
            Token = "BYWM7NA5NKVNZ873VJTFLUXGQ4WI9YT8";
            restClient = new RestClient(Url);
            restClient.Authenticator = new HttpBasicAuthenticator(Token, "");
        }

        public ps_manufacturer GetManufacturer(string id)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "api/manufacturers/{CallSid}";

            request.AddParameter("CallSid", id, ParameterType.UrlSegment);

            return restClient.Execute<ps_manufacturer>(request).Data;
        }

        public class Manufacturers
        {
            public List<ps_manufacturer> manufacturers { get; set; }
        }

        public List<ps_manufacturer> Receive(string requestString)
        {
            List<ps_manufacturer> result = new List<ps_manufacturer>();
            requestString = "api/manufacturers/?display=full";
            IRestRequest request = new RestRequest(requestString, Method.GET);
            Manufacturers man = new Manufacturers();
            
            var xids = restClient.Execute<Manufacturers>(request).Data;

            IRestResponse response = restClient.Execute(request);
            var content = response.Content; // raw content as string
            
            return result;
        }

        public void DeleteManufacturer(string id)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "api/manufacturers/{CallSid}";

            request.AddParameter("CallSid", id, ParameterType.UrlSegment);

            restClient.Execute<ps_manufacturer>(request);
        }

        public void CreateManufacturer(ps_manufacturer item)
        {
            //var request = new RestRequest(Method.POST);
            //request.Resource = "api/manufacturers/{CallSid}";

            //request.AddParameter("CallSid", id, ParameterType.UrlSegment);

            //restClient.Execute<ps_manufacturer>(request);
        }


        public void UpdateManufacturer(ps_manufacturer item)
        {
            var request = new RestRequest(Method.PATCH );
            request.Resource = "api/manufacturers/{CallSid}";

            request.AddParameter("id_manufacturer", item.id_manufacturer);
            request.AddParameter("name", item.name);
            request.AddParameter("date_add", item.date_add);
            request.AddParameter("date_upd", item.date_upd);
            request.AddParameter("active", item.active);
            
            restClient.Execute<ps_manufacturer>(request);
        }
    }
}
