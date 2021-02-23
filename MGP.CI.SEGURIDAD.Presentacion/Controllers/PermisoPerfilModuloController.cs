using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers
{
    public class PermisoPerfilModuloController : MGPBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GrabarPermisos(int perfilModuloId, int permisoId, bool estado)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            string controllerName = "Usuario";
            if (this.GetPermisoVista('/' + controllerName + '/' + "Index").MODIFICAR == false)
                return Json(new { success = false, mensajeError = "Usuario no autorizado" }, JsonRequestBehavior.AllowGet);

            PermisoPerfilModuloViewModel permisoPerfilModuloVM = new PermisoPerfilModuloViewModel();

            if (estado == true)
            {
                permisoPerfilModuloVM.Insertar(perfilModuloId, permisoId, sesionVM.Login);

            }
            else
            {
                permisoPerfilModuloVM.Eliminar(perfilModuloId, permisoId, sesionVM.Login);
            }

            var grabarpermisos = "oll";


            return Json(new { success = true, mensajeError = ""}, JsonRequestBehavior.AllowGet);

        }
    }
}