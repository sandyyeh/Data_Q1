using System.Web;
using System.Web.Mvc;

namespace Sandy_JSON_20190415_Q1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
