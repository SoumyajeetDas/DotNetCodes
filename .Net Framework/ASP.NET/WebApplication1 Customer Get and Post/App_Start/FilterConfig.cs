using System.Web;
using System.Web.Mvc;

namespace WebApplication1_Customer_Get_and_Post
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
