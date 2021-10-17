using IdentityTask.MyFilters;
using System.Web;
using System.Web.Mvc;

namespace IdentityTask
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyHandleError());
        }
    }
}
