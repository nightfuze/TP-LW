using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.Controllers
{
    public class StartController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string controller = (string)requestContext.RouteData.Values["controller"];
            string action = (string)requestContext.RouteData.Values["action"];

            if (controller.Equals("start") && action.Equals("0"))
            {
                requestContext.HttpContext.Response.RedirectToRoute(new { action = "Index", controller = "DatabaseCourse" });
            }

            requestContext.HttpContext.Response.Write(
              string.Format("Ошибка! Неверный адрес: {0}", requestContext.HttpContext.Request.Url.ToString()));

        }
    }

}