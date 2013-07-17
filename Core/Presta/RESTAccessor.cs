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
    public class RESTAccessor//<T> where T : class 
    {
        //IRestResponse response = restClient.Execute(request);
        //var content = response.Content; // raw content as string
        //http://testpresta.mzf.cz/prestashop/api/manufacturers

        protected RestClient restClient;
        public RESTAccessor(string Url, string Token)
        {
            restClient = new RestClient(Url);
            restClient.Authenticator = new HttpBasicAuthenticator(Token, "");
        }

        protected ps_manufacturer Get(string segment, string id)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "api/{CallParam}/{CallSid}";
            
            request.AddParameter("CallParam", segment, ParameterType.UrlSegment);
            request.AddParameter("CallSid", id, ParameterType.UrlSegment);

            return restClient.Execute<ps_manufacturer>(request).Data;
        }

        protected void Delete(string segment, string id)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "api/{CallParam}/{CallSid}";

            request.AddParameter("CallParam", segment, ParameterType.UrlSegment);
            request.AddParameter("CallSid", id, ParameterType.UrlSegment);

            restClient.Execute<ps_manufacturer>(request);
        }

        public void Update(string segment, string id, List<KeyValuePair<string,string>> parameters)
        {
            //var request = new RestRequest(Method.PATCH);
            //request.Resource = "api/manufacturers/{CallSid}";

            //request.AddParameter("name", item.name);
            //request.AddParameter("date_add", item.date_add);
            //request.AddParameter("date_upd", item.date_upd);
            //request.AddParameter("active", item.active);

            //restClient.Execute<ps_manufacturer>(request);
        }
    }
}
