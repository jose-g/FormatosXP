using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MGP.CI.SEGURIDAD.Presentacion.ViewModels;

namespace MGP.CI.SEGURIDAD.Presentacion.Helpers
{
    public class SessionExpireFilter : ActionFilterAttribute
    {
        public bool Disable { get; set; } = false;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Disable) return;
            HttpContext ctx = HttpContext.Current;
            SesionViewModel sessionUsuario = SessionManager.Obtener<SesionViewModel>(ConstantStatic.nameSession);
            if (sessionUsuario == null)
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}




