using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
