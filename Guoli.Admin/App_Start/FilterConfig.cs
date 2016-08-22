using System.Web;
using System.Web.Mvc;
using Guoli.Admin.Filters;

namespace Guoli.Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionFilter());
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorityFilter());
        }
    }
}