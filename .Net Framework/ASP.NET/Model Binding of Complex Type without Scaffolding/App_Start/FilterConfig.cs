using System.Web;
using System.Web.Mvc;

namespace WebApplication1_Manual_Binding
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
