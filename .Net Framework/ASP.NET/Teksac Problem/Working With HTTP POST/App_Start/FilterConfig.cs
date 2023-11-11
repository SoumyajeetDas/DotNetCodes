using System.Web;
using System.Web.Mvc;

namespace Working_With_HTTP_POST
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
