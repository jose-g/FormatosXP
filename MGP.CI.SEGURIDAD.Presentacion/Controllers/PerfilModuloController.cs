using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers
{
    public class PerfilModuloController : MGPBaseController
    {
        // GET: PerfilModulo
        public ActionResult Index()
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            if (Session["objsesion"] == null)
                return RedirectToAction("index", "Login");

            string controllerName = "Usuario";
            ViewBag.PERMISOS = this.GetPermisoVista('/' + controllerName + '/' + "Index");

            return View();
        }

        [HttpPost]
        public ActionResult VerPermisosxModulos(int PerfilId)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            ModulosxPerfilViewModel modulosxperfil = new ModulosxPerfilViewModel();
            modulosxperfil.CargarxPerfil(PerfilId);

            //Perfil_ModuloViewModel sis = new Perfil_ModuloViewModel();
            //PermisoViewModel perm = new PermisoViewModel();

            //sis.PERFIL_ID = PERFIL_ID;
            //Permiso_Perfil_ModuloViewModel Vppm = new Permiso_Perfil_ModuloViewModel();
            //Vppm.PERFIL_ID = PERFIL_ID;

            //ViewBag.listDetalle = Vppm.Listar_grilla_x_perfil();
            //ViewBag.listSisMod = sis.Listar_grilla(sis);
            //ViewBag.lstTipPerm = perm.Listar_grilla(perm);
            //ViewBag.listSisMod = sesionVM.LstModulosAsociados;
            //ViewBag.lstTipPerm = sesionVM.LstPermisosAsociados;

            string controllerName = "Usuario";
            ViewBag.PERMISOS = this.GetPermisoVista('/' + controllerName + '/' + "Index");

            return PartialView("VerPermisosxModulos", modulosxperfil);
        }



    }
}