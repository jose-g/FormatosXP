using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers.Valoracion
{
    public class ValoracionController : Controller
    {
        // GET: Valoracion
        public ActionResult Index()
        {
            ValoracionFichaViewModel vm = new ValoracionFichaViewModel();
            vm.CargarTablasMaestras();

            return View(vm);
        }

        public ActionResult Consultar_listaToDatatableXP1003(ValoracionFichaViewModel obj)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            ValoracionFichaViewModel vm = new ValoracionFichaViewModel();
            var query = vm.ListarUsuariosFiltrados(obj).Select(x => new { x.Ficha1003Id, x.ApePaterno, x.ApeMaterno, x.Nombres, x.FechaRegistroStr }).DistinctBy(x => x.Ficha1003Id).ToList();
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

    }
}