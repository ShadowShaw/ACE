using PrestaAccesor.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace PrestaAccesor.Accesors
{
    public abstract class RestSharpAccesor
    {
        public const int StepCount = 500;

        protected RestClient Client;
        protected string BaseUrl { get; set; }
        protected string Account { get; set; }
        protected string Password { get; set; }

        protected RestSharpAccesor(string baseUrl, string account, string password)
        {
            BaseUrl = baseUrl;
            Account = account;
            Password = password;

            Client = new RestClient();
            if (Uri.IsWellFormedUriString(baseUrl, UriKind.RelativeOrAbsolute))
            {
                Client.BaseUrl = new Uri(BaseUrl);    
            }
            
            Client.Authenticator = new HttpBasicAuthenticator(Account, Password);
        }

        public void Setup(string baseUrl, string account, string password)
        {
            BaseUrl = baseUrl;
            Account = account;
            Password = password;

            Client.BaseUrl = new Uri(BaseUrl);
            Client.Authenticator = new HttpBasicAuthenticator(Account, Password);
        }

        protected T Execute<T>(RestRequest request) where T : new()
        {
            request.AddParameter("Account", Account, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            var response = Client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var exception = new ApplicationException(message, response.ErrorException);
                throw exception;
            }
            return response.Data;
        }

        //protected T Execute<T>(RestRequest request) where T : new()
        //{
        //    Client.BaseUrl = BaseUrl;
        //    Client.Authenticator = new HttpBasicAuthenticator(this.Account, this.Password);
        //    request.AddParameter("Account", Account, ParameterType.UrlSegment); // used on every request
        //    if (request.Method == Method.GET)
        //    {
        //        Client.ClearHandlers();
        //        Client.AddHandler("text/xml", new Bukimedia.PrestaSharp.Deserializers.PrestaSharpDeserializer());
        //    }
        //    var response = Client.Execute<T>(request);
        //    if (response.StatusCode == HttpStatusCode.InternalServerError
        //        || response.StatusCode == HttpStatusCode.ServiceUnavailable
        //        || response.StatusCode == HttpStatusCode.BadRequest
        //        || response.StatusCode == HttpStatusCode.Unauthorized
        //        || response.StatusCode == HttpStatusCode.MethodNotAllowed
        //        || response.StatusCode == HttpStatusCode.Forbidden
        //        || response.StatusCode == HttpStatusCode.NotFound
        //        || response.StatusCode == 0)
        //    {
        //        string requestParameters = Environment.NewLine;
        //        foreach (Parameter parameter in request.Parameters)
        //        {
        //            requestParameters += parameter.Value + Environment.NewLine + Environment.NewLine;
        //        }
        //        PrestaSharpException exception = new PrestaSharpException(requestParameters + response.Content, response.ErrorMessage, response.StatusCode, response.ErrorException);
        //        throw exception;
        //    }
        //    return response.Data;
        //}

        protected void ExecuteAsync(RestRequest request)
        {
            try
            {
                Client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine(response.ToString());
                    }
                    else
                    {
                        Console.WriteLine(response.ToString());
                    }
                });
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }

        protected RestRequest RequestForGet(string resource, long? id, string rootElement)
        {
            var request = new RestRequest();
            request.Resource = resource + "/" + id;
            request.RootElement = rootElement;
            return request;
        }

        protected List<int> ExecuteForGetIds<T>(RestRequest request, string rootElement) where T : new()
        {
            request.AddParameter("Account", Account, ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            var response = Client.Execute<T>(request);
            if (string.IsNullOrEmpty(response.Content))
            {
                return null;
            }
                XDocument xDcoument = XDocument.Parse(response.Content);
            var ids = (from doc in xDcoument.Descendants(rootElement)
                       select int.Parse(doc.Attribute("id").Value)).ToList();
            return ids;
        }
        
        protected RestRequest RequestForAdd(string resource, PrestashopEntity entity)
        {
            var request = new RestRequest();
            request.Resource = resource;
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
            string serialized = request.XmlSerializer.Serialize(entity);
            serialized = serialized.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<prestashop>");
            serialized += "\n</prestashop>";
            request.AddParameter("xml", serialized);
            return request;
        }

        /// <summary>
        /// More information about image management: http://doc.prestashop.com/display/PS15/Chapter+9+-+Image+management
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="id"></param>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        protected RestRequest RequestForAddImage(string resource, int id, string imagePath)
        {
            var request = new RestRequest();
            request.Resource = "/images/" + resource + "/" + id;
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
            byte[] imgBytes = ImageToBinary(imagePath);
            request.AddParameter("images", imgBytes);
            return request;
        }

        protected RestRequest RequestForUpdate(string resource, long? id, PrestashopEntity prestashopEntity)
        {
            if (id == null)
            {
                throw new ApplicationException("Id is required to update something.");
            }
            var request = new RestRequest();
            request.RootElement = "prestashop";
            request.Resource = resource;
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.Method = Method.PUT;
            request.RequestFormat = DataFormat.Xml;
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
            request.AddBody(prestashopEntity);
            request.Parameters[1].Value = request.Parameters[1].Value.ToString().Replace("<" + prestashopEntity.GetType().Name+">", "<prestashop>\n<" + prestashopEntity.GetType().Name + ">");
            request.Parameters[1].Value = request.Parameters[1].Value.ToString().Replace("</" + prestashopEntity.GetType().Name + ">", "</" + prestashopEntity.GetType().Name + "></prestashop>");
            return request;
        }

        //protected RestRequest RequestForUpdate(string Resource, long? Id, PrestashopEntity PrestashopEntity)
        //{
        //    if (Id == null)
        //    {
        //        throw new ApplicationException("Id is required to update something.");
        //    }
        //    var request = new RestRequest();
        //    request.RootElement = "prestashop";
        //    request.Resource = Resource;
        //    request.AddParameter("id", Id, ParameterType.UrlSegment);
        //    request.Method = Method.PUT;
        //    request.RequestFormat = DataFormat.Xml;
        //    request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
        //    request.AddBody(PrestashopEntity);
        //    //issue #81, #54 fixed
        //    request.Parameters[1].Value = Functions.ReplaceFirstOccurrence(request.Parameters[1].Value.ToString(), "<" + PrestashopEntity.GetType().Name + ">", "<prestashop>\n<" + PrestashopEntity.GetType().Name + ">");
        //    request.Parameters[1].Value = Functions.ReplaceLastOccurrence(request.Parameters[1].Value.ToString(), "</" + PrestashopEntity.GetType().Name + ">", "</" + PrestashopEntity.GetType().Name + ">\n</prestashop>");
        //    //issue #36 fixed
        //    request.Parameters[1].Value = request.Parameters[1].Value.ToString().Replace("xmlns=\"Bukimedia/PrestaSharp/Entities\"", "xmlns=\"\"");
        //    request.Parameters[1].Value = request.Parameters[1].Value.ToString().Replace("xmlns=\"Bukimedia/PrestaSharp/Entities/AuxEntities\"", "xmlns=\"\"");
        //    return request;
        //}

        protected RestRequest RequestForDelete(string resource, long? id)
        {
            if (id == null)
            {
                throw new ApplicationException("Id is required to delete something.");
            }
            var request = new RestRequest();
            request.RootElement = "prestashop";
            request.Resource = resource + "/" + id;
            request.Method = Method.DELETE;
            request.RequestFormat = DataFormat.Xml;
            return request;
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="display"></param>
        /// <param name="filter"></param>
        /// <param name="sort"></param>
        /// <param name="limit"></param>
        /// <param name="rootElement"></param>
        /// <returns></returns>
        protected RestRequest RequestForFilter(string resource, string display, Dictionary<string,string> filter, string sort, string limit, string rootElement)
        {
            var request = new RestRequest();
            request.Resource = resource;
            request.RootElement = rootElement;
            if (display != null)
            {
                request.AddParameter("display", display);
            }
            if (filter != null)
            {
                foreach (string key in filter.Keys)
                {
                    request.AddParameter("filter[" + key + "]", filter[key]);
                }
            }
            if (sort != null)
            {
                request.AddParameter("sort", sort);
            }
            if (limit != null)
            {
                request.AddParameter("limit", limit);
            }
            return request;
        }

        public static byte[] ImageToBinary(string imagePath)
        {
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);
            fileStream.Close();
            return buffer;
        }

    }
}
