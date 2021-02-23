//using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Helpers
{
    public class FiltroSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //LoginSesionViewModel sessionUsuario = (LoginSesionViewModel)HttpContext.Current.Session["objsesion"];
            //if (sessionUsuario == null)
            //{
            //    filterContext.Result = new RedirectResult("~/Login/Index");
            //    return;
            //}
            //base.OnActionExecuting(filterContext);
        }
    }
}