using System.Web;
using System.Web.Mvc;

namespace Login_Logout_and_SignUp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
