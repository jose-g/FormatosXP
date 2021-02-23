using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers
{
    public class UsuarioPerfilesController : MGPBaseController
    {
        // GET: UsuarioPerfiles
        public ActionResult Index(int? UsuarioId)
        {

            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            if (Session["objsesion"] == null)
                return RedirectToAction("index", "Login");

            string controllerName = "Usuario";
            ViewBag.PERMISOS = this.GetPermisoVista('/' + controllerName + '/' + "Index");

            UsuarioViewModel usuarioVM = null;

            if (UsuarioId > 0)
                usuarioVM = new UsuarioViewModel().BuscarxId(UsuarioId.Value);

            if (usuarioVM == null)
                usuarioVM = new UsuarioViewModel();


            return View(usuarioVM);
        }

        public ActionResult ListarPerfilesAsignados(UsuariosPerfilesViewModel usuarioperfilVM)
        {
            return Json(new { data = (new UsuariosPerfilesViewModel()).ListarPerfilesAsignados(usuarioperfilVM) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AsignarPerfil(UsuariosPerfilesViewModel usuarioperfil)
        {
            //string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            //string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            PermisoVistaVM permisovistaVM = this.GetPermisoVista('/' + "Usuario" + '/' + "Index");
            if (permisovistaVM.NUEVO == false && permisovistaVM.MODIFICAR == false)
                return Json(new { success = false, mensajeError = "Usuario no autorizado" }, JsonRequestBehavior.AllowGet);

            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            bool b = false;
            if (!ModelState.IsValid)
                return Json(new { success = false, mensajeError = GetErrorFromModel() }, JsonRequestBehavior.AllowGet);



            //SesionViewModel v = (SesionViewModel)Session["objsesion"];
            //usuarioperfil.UsuarioRegistro = v.Login;
            //b = (usuarioperfil.EstadoId > 0 ? usuarioperfil.Actualizar() : usuarioperfil.Insertar());


            return Json(new { success = usuarioperfil.AsignarPerfil(sesionVM.Login), mensajeError = usuarioperfil.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }




        //public ActionResult Detalle(String id)
        //{
        //    UsuariosPerfilesViewModel vm = new UsuariosPerfilesViewModel();
        //    if (id != "" && id != null)
        //        vm.BuscarPorId(Convert.ToInt32(id));

        //    return PartialView("VerEstado", vm);
        //}



        [HttpPost]
        public ActionResult EliminarPerfil(int UsuarioPerfilId)
        {
            UsuariosPerfilesViewModel vm = new UsuariosPerfilesViewModel();
            bool b = false;

            if (UsuarioPerfilId <= 0)
                return Json(new { success = false, mensajeError = "Valor de parámetro no válido" }, JsonRequestBehavior.AllowGet);

            b = vm.EliminarPerfil(UsuarioPerfilId);

            return Json(new { success = b, mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }
    }
}