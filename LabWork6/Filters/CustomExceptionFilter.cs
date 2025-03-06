using System;
using System.Web.Mvc;

namespace WebApplication1.Filters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is ArgumentOutOfRangeException)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "ArgumentError",
                    ViewData = new ViewDataDictionary(filterContext.Exception)
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}