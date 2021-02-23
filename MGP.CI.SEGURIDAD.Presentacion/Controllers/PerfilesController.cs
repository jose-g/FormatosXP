using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers
{
    public class PerfilesController :  MGPBaseController
    {
        // GET: Perfiles
        public ActionResult Index()
        {
            //ViewBag.objPERMISO = getPermiso();
            return View();
        }





        public ActionResult Consultar_listaToDatatable(PerfilesViewModel obj)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            PerfilesViewModel perfilesVM = new PerfilesViewModel();

            return Json(new { data = perfilesVM.Listar().Select(x => new { x.PerfilesId, x.EstadoNombre, x.Nombre }).ToList()}, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ListarPerfilesDisponibles(int UsuarioId)
        {
            PerfilesViewModel vm = new PerfilesViewModel();

            return Json(new { data = vm.ListarPerfilesDisponibles(UsuarioId) }, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult Eliminar(int id)
        //{
        //    bool b;
        //    if (getPermiso().ELIMINAR == false) return Json(new { success = false, mensajeError = "Usuario no autorizado" }, JsonRequestBehavior.AllowGet);

        //    PerfilesViewModel vm = new PerfilesViewModel();
        //    b = vm.Eliminar(id);

        //    return Json(new { success = b, mensajeError = vm.ErrorSms }, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult PerfilesVerDetalles(String id)
        //{
        //    PerfilesViewModel vm = new PerfilesViewModel();

        //    if (id != "" && id != null)
        //        vm.BuscarPorId(Convert.ToInt32(id));
        //    else
        //        vm.EstadoId = 1;

        //    ViewBag.objPERMISO = getPermiso();

        //    return PartialView("VerPerfil", vm);
        //}


        //[HttpPost]
        //public ActionResult Grabar(PerfilesViewModel ent)
        //{
        //    if (getPermiso().NUEVO == false && getPermiso().MODIFICAR == false) return Json(new { success = false, mensajeError = "Usuario no autorizado" }, JsonRequestBehavior.AllowGet);

        //    bool b = false;
        //    if (!ModelState.IsValid)
        //        return Json(new { success = false, mensajeError = GetErrorFromModel() }, JsonRequestBehavior.AllowGet);
        //    else
        //        b = (ent.PerfilesId > 0 ? ent.Actualizar() : ent.Insertar());

        //    return Json(new { success = b, mensajeError = ent.ErrorSms }, JsonRequestBehavior.AllowGet);
        //}

    }
}