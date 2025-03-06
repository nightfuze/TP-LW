using System;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Filters
{
    public class CustomAuthFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var query = httpContext.Request.QueryString;

            if (query.Count < 2)
                throw new ArgumentOutOfRangeException("Необходимо два параметра в запросе. DatabaseName и IsActive.");


            var databaseName = query["DatabaseName"];
            var isActiveStr = query["IsActive"];

            if (databaseName == null && isActiveStr == null)
                throw new ArgumentOutOfRangeException("Отсутствуют параметры в запросе: DatabaseName и IsActive.");

            if (databaseName == null)
                throw new ArgumentOutOfRangeException("Отсутствует параметр в запросе: DatabaseName.");

            if (isActiveStr == null)
                throw new ArgumentOutOfRangeException("Отсутствует параметр в запросе: IsActive.");

            try
            {
                bool isActive = Convert.ToBoolean(isActiveStr);
            }
            catch (FormatException)
            {
                throw new FormatException($"Некорректное значение параметра в запросе: IsActive={isActiveStr}.");
            }

            return true;
        }
    }
}