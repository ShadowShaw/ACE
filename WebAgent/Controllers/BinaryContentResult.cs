using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ACEAgent.Controllers
{
    public class BinaryContentResult : ActionResult
    {
        private readonly string _contentType;
        private readonly byte[] _contentBytes;

        public BinaryContentResult(byte[] contentBytes, string contentType)
        {
            _contentBytes = contentBytes;
            _contentType = contentType;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.Clear();
            response.Cache.SetCacheability(HttpCacheability.Public);
            response.ContentType = _contentType;

            using (MemoryStream stream = new MemoryStream(_contentBytes))
            {
                stream.WriteTo(response.OutputStream);
                stream.Flush();
            }
        }
    }
}