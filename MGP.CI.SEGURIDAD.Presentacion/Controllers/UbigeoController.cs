using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers
{
    public class UbigeoController : Controller
    {
        // GET: Ubigeo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDependenciasxZonasNavales(int ZonaNavalId)
        {
            return Json(new UbigeoNavalVM().ListarxZonasNavales(ZonaNavalId).Select(x => new { x.DependenciaId, x.DependenciaDescCorta }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}