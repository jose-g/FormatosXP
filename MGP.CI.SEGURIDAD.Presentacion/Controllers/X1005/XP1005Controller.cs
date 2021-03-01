using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1005;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers.X1005
{
    public class XP1005Controller : Controller
    {
        // GET: XP1005
        public ActionResult Index()
        {
            BusquedaDeclaranteXP1005ViewModel vm = new BusquedaDeclaranteXP1005ViewModel();
            vm.CargarTablasMaestras();
            return View(vm);
        }

        public ActionResult Consultar_listaToDatatableXP1005(BusquedaDeclaranteXP1005ViewModel obj)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            var query = obj.ListarUsuariosFiltrados(obj).Select(x => new { x.DeclaranteXP1005Id, x.ApePaterno, x.ApeMaterno, x.Nombres }).DistinctBy(x => x.DeclaranteXP1005Id).ToList();
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ConsultarFichasFromDeclarante(string DeclaranteId)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            var query = new BusquedaFichasXP1005ViewModel().ListarFichasFromDeclarante(Int32.Parse(DeclaranteId)). Select(x => new { x.FichaId, x.TipoFichaStr, x.FechaRegistroStr, x.NroFamiliares, x.NroIdentificaciones}).DistinctBy(x => x.FichaId).ToList();
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult FichaVerDetalles(string FichaId, string DeclaranteId)
        {
            X1005ViewModel vm = new X1005ViewModel();
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            if (FichaId == null)
                vm = new X1005ViewModel().BuscarxId(Int32.Parse(FichaId));
            else
                vm.CrearNuevaFichaXP1005(sesionVM.Login, Int32.Parse(DeclaranteId));
            vm.DeclaranteId = Int32.Parse(DeclaranteId);
            vm.CargarTablasMaestras();

            return PartialView("../X1005/FrmFichaDetalles", vm);

        }



    }
}