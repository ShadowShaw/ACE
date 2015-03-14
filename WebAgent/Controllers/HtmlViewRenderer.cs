using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ACEAgent.Controllers
{
    public class FakeView : IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            throw new NotImplementedException();
        }
     }

    public class HtmlViewRenderer
    {
        public string RenderViewToString(Controller controller, string viewName, object viewData)
        {
            StringBuilder renderedView = new StringBuilder();
            using (StringWriter responseWriter = new StringWriter(renderedView))
            {
                HttpResponse fakeResponse = new HttpResponse(responseWriter);
                HttpContext fakeContext = new HttpContext(HttpContext.Current.Request, fakeResponse);
                ControllerContext fakeControllerContext = new ControllerContext(new HttpContextWrapper(fakeContext), controller.ControllerContext.RouteData, controller.ControllerContext.Controller);

                HttpContext oldContext = HttpContext.Current;
                HttpContext.Current = fakeContext;

                using (ViewPage viewPage = new ViewPage())
                {
                    HtmlHelper html = new HtmlHelper(CreateViewContext(responseWriter, fakeControllerContext), viewPage);
                    html.RenderPartial(viewName, viewData);
                    HttpContext.Current = oldContext;
                }
            }

            return renderedView.ToString();
        }

        private static ViewContext CreateViewContext(TextWriter responseWriter, ControllerContext fakeControllerContext)
        {
            return new ViewContext(fakeControllerContext, new FakeView(), new ViewDataDictionary(), new TempDataDictionary(), responseWriter);
        }
    }
}