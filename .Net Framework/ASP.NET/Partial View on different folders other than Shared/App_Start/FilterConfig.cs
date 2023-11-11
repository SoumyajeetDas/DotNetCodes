using System.Web;
using System.Web.Mvc;

namespace Partial_View_on_different_folders_other_than_Shared
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
