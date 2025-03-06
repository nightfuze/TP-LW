using System.Web.Mvc;

namespace WebApplication1.Filters
{
    public class CustomIdFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionParameters.TryGetValue("id", out object idValue)
                && (idValue is int id)
                && id < 0)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "NegativeIdError",
                    ViewData = new ViewDataDictionary(filterContext.ActionParameters)
                };
            }
        }
    }
}