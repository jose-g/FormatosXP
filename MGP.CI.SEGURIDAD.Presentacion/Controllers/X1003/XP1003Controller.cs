using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using MGP.CI.SEGURIDAD.Presentacion.ViewModels.X1003;
using MGP.CI.SEGURIDAD.Presentacion.Views.X1003;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers.X1003
{
    public class XP1003Controller : MGPBaseController
    {
        // GET: XP1003
        public ActionResult Index()
        {
            ViewBag.PERMISOS = this.GetPermisoVista('/' + "Usuario" + '/' + "Index");

            BusquedaDeclaranteViewModel vm = new BusquedaDeclaranteViewModel();
            vm.CargarTablasMaestras();

            return View(vm);
        }

 
        public ActionResult Consultar_listaToDatatableXP1003(BusquedaDeclaranteViewModel obj)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            BusquedaDeclaranteViewModel vm = new BusquedaDeclaranteViewModel();
            var query = vm.ListarUsuariosFiltrados(obj).Select(x => new { x.DatosPersonalesId, x.ApePaterno, x.ApeMaterno, x.Nombres, x.FechaRegistroStr }).DistinctBy(x => x.DatosPersonalesId).ToList();
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Consultar_listaFichasToDatatableXP1003(BusquedaFichaViewModel obj)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            BusquedaFichaViewModel vm = new BusquedaFichaViewModel();
            var query = vm.ListarFichasFiltrados(obj).Select(x => new { x.Ficha1003Id, x.FechaRegistroStr }).DistinctBy(x => x.Ficha1003Id).ToList();
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]

        public ActionResult VerFrmConfirmacion()
        {
            return PartialView("../X1003/FrmCrearFicha");
        }

        [HttpGet]
        public ActionResult FichaVerDetalles(string m_FichaId)
        {
            X1003ViewModel vm = new X1003ViewModel();
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            if (m_FichaId != null)
                vm = new X1003ViewModel().BuscarxId(Convert.ToInt32(m_FichaId));
            else
                vm.CrearNuevaFichaXP1003(sesionVM.Login);

            vm.CargarTablasMaestras();

            return PartialView("../X1003/FrmFichaDetalles", vm);

        }

        //**************************************
        //SECCION FRM DECLARANTE
        //**************************************


        [HttpPost]
        public ActionResult VerFrmAgregarNuevoDocumento()
        {
            AgregarDocumentoViewModel vm = new AgregarDocumentoViewModel();
            return PartialView("../X1003/FrmAgregarDocumento", vm);
        }


        [HttpPost]
        public JsonResult GrabarDatosPersonales(X1003DatosPersonalesViewModel vm, List<AgregarDocumentoViewModel> LstIdentificaciones, List<FotosViewModel> LstFotos)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, mensajeError = "Modelo Invalido"}, JsonRequestBehavior.AllowGet);
            }


            bool ret = true; ;

            vm.LstAgregarDocumentoVM = LstIdentificaciones;
            vm.LstFotos = LstFotos;
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            ret = vm.Insertar(sesionVM.Login);

            return Json(new { success = ret, mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInstitucionesPorPais(string PaisId)
        {
            return Json(new X1003DatosPersonalesViewModel().GetInstitucionesPorPais(PaisId).Select(x => new { x.InstitucionMilitarExtranjeraId, x.Descripcion, }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGradosExtranjerosPorInstitucion(String InstitucioneMilitarExtranjeraId)
        {
            return Json(new X1003DatosPersonalesViewModel().GetGradosExtranjerosPorInstitucionMilitar(InstitucioneMilitarExtranjeraId.ToString()).Select(x => new { x.GradoExtranjeroId, x.Descripcion, }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEspecialidadExtranjerosPorInstitucion(String GradoExtranjeroId)
        {
            return Json(new X1003DatosPersonalesViewModel().GetEspecialidadExtranjerosPorInstitucion(GradoExtranjeroId.ToString()).Select(x => new { x.EspecialidadesExtranjerasId, x.Descripcion, }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEnfermedadxTipo(String EnfermedadesId)
        {
            return Json(new X1003DatosPersonalesViewModel().GetEnfermedadxTipo(EnfermedadesId).Select(x => new { x.EnfermedadesId, x.Enfermedad, }).ToList(), JsonRequestBehavior.AllowGet);
        }




        //**************************************
        //SECCION FRM DATOS FAMILIARES
        //**************************************

        [HttpPost]
        public JsonResult GrabarDatosFamiliares(x1003DatosFamiliaresVM vm, int FichaId, List<AgregarDocumentoViewModel> LstIdentificaciones, List<AgregarHijoViewModel> LstHijos, List<AgregarFamiliarViewModel> LstFamiliares, List<AgregarFamiliarResidentesEnPeru> LstFamResidentes, List<string> LstIdiomas)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Json(new { success = false, mensajeError = "Modelo Invalido" }, JsonRequestBehavior.AllowGet);
            //}

            //Hacer una distinticion entre una nueva grabacion y una actualizacion

            vm.LstIdentificaciones = LstIdentificaciones;
            vm.LstHijos = LstHijos;
            vm.LstFamiliares = LstFamiliares;
            vm.LstFamResidentes = LstFamResidentes;
            vm.LstStrIdiomas = LstIdiomas;
            vm.FichaId = FichaId;
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            bool ret = true; ;
            ret = vm.Insertar(sesionVM.Login);

            return Json(new { success = ret, mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult VerFrmAgregarNuevoDocumentoEsposa()
        {
            AgregarDocumentoViewModel vm = new AgregarDocumentoViewModel();
            return PartialView("../X1003/FrmAgregarDocumentoEsposa", vm);
        }

        [HttpPost]
        public ActionResult VerFrmAgregarNuevoHijo()
        {
            AgregarHijoViewModel vm = new AgregarHijoViewModel();
            return PartialView("../X1003/FrmAgregarHijo", vm);
        }

        [HttpPost]
        public ActionResult VerFrmAgregarNuevoFamiliar()
        {
            AgregarFamiliarViewModel vm = new AgregarFamiliarViewModel();
            return PartialView("../X1003/FrmAgregarFamiliar", vm);
        }

        [HttpPost]
        public ActionResult VerFrmAgregarNuevoResidente()
        {
            AgregarFamiliarResidentesEnPeru vm = new AgregarFamiliarResidentesEnPeru();
            return PartialView("../X1003/FrmAgregarFamiliarResidente", vm);
        }

        //**************************************
        //SECCION FRM CARGOS Y FUNCIONES
        //**************************************
        [HttpPost]
        public JsonResult GrabarDatosCargosFunciones(X1003CargosFuncionesViewModel vm,  List<AgregarDomiciliosEnPeruVewModel> LstDomicilios, List<AgregarVehiculoViewModel> LstVehiculos, List<AgregarIngresosAlPaisViewModel> LstIngresos, List<AgregarIngresosAnterioresAlPaisViewModel> LstIngresosAnteriores)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Json(new { success = false, mensajeError = "Modelo Invalido" }, JsonRequestBehavior.AllowGet);
            //}
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            bool ret = true;
            vm.LstDomicilios = LstDomicilios;
            vm.LstVehiculos = LstVehiculos;
            vm.LstIngresos = LstIngresos;
            vm.LstIngresosAnteriores = LstIngresosAnteriores;

            if (vm.CargosFuncionesX1003Id == 0)
            {
                ret = vm.Insertar(sesionVM.Login);
            }

            return Json(new { success = ret, mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult VerFrmCargosFunciones(int CargoId)
        //{
        //    CargosFuncionesBE BE = new CargosFuncionesBE();
            
        //    AgregarDomiciliosEnPeruVewModel vm = new AgregarDomiciliosEnPeruVewModel();
        //    return PartialView("../X1003/FrmAgregarDomicilioEnPeru", vm);
        //}



        [HttpPost]
        public ActionResult VerFrmAgregarDomicilioEnPeru()
        {
            AgregarDomiciliosEnPeruVewModel vm = new AgregarDomiciliosEnPeruVewModel();
            return PartialView("../X1003/FrmAgregarDomicilioEnPeru", vm);
        }

        [HttpPost]
        public ActionResult VerFrmAgregarVehiculo()
        {
            AgregarVehiculoViewModel vm = new AgregarVehiculoViewModel();
            return PartialView("../X1003/FrmAgregarVehiculoCargo", vm);
        }

        [HttpPost]
        public ActionResult VerFrmAgregarIngresosAlPais()
        {
            AgregarIngresosAlPaisViewModel vm = new AgregarIngresosAlPaisViewModel();
            return PartialView("../X1003/FrmAgregarIngresosAlPais", vm);
        }

        [HttpPost]
        public ActionResult VerFrmAgregarIngresosAnterioresAlPais()
        {
            AgregarIngresosAnterioresAlPaisViewModel vm = new AgregarIngresosAnterioresAlPaisViewModel();
            return PartialView("../X1003/FrmAgregarIngresosAnterioresAlPais", vm);
        }

        public JsonResult GetPronviciaPorDepartamento(string DepartamentoId)
        {
            return Json(new UbigeoViewModel().GetPronviciaPorDepartamento(DepartamentoId).Select(x => new { x.UbigeoCodigo, x.Provincia, }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistritoPorProvincia(String ProvinciaId)
        {
            return Json(new UbigeoViewModel().GetDistritoPorProvincia(ProvinciaId.ToString()).Select(x => new { x.UbigeoCodigo, x.Distrito, }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModelosxMarca(string AutoMarcaId)
        {
            return Json(new AgregarVehiculoViewModel().GetModelosxMarca(AutoMarcaId).Select(x => new { x.AutoModeloId, x.Nombre, }).ToList(), JsonRequestBehavior.AllowGet);
        }

        //**************************************
        //SECCION FRM INFORMACION CASTRENSE
        //**************************************
        [HttpPost]
        public ActionResult VerFrmAscensoObtenido()
        {
            AgregarAscensosObtenidosViewModel vm = new AgregarAscensosObtenidosViewModel();
            return PartialView("../X1003/FrmAgregarAscensoObtenido", vm);
        }
        public ActionResult VerFrmCargoComision()
        {
            AgregarCargosFuncionesRealizadasViewModel vm = new AgregarCargosFuncionesRealizadasViewModel();
            return PartialView("../X1003/FrmAgregarCargoComision", vm);
        }

        public ActionResult VerFrmCondecoraciones()
        {
            AgregarCondecoracionesViewModel vm = new AgregarCondecoracionesViewModel();
            return PartialView("../X1003/FrmAgregarCondecoracion", vm);
        }

        public ActionResult VerFrmAgregarIdioma()
        {
            AgregarIdiomaDominadoViewModel vm = new AgregarIdiomaDominadoViewModel();
            return PartialView("../X1003/FrmAgregarIdioma", vm);
        }

        public ActionResult VerFrmAgregarEscuelaCursada()
        {
            AgregarCursoRealizadoViewModel vm = new AgregarCursoRealizadoViewModel();
            return PartialView("../X1003/FrmAgregarEscuelaCursada", vm);
        }


        public JsonResult GetCondecoracionesPorInstitucion(string InstitucioneMilitarExtranjeraId)
        {
            return Json(new X1003InformacionCastrenseViewModel().GetCondecoracionesPorInstitucion(InstitucioneMilitarExtranjeraId).Select(x => new { x.CondecoracionesExtranjerasId, x.Nombre, }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGradosPorInstitucion(string InstitucioneMilitarExtranjeraId)
        {
            return Json(new X1003InformacionCastrenseViewModel().GetGradosPorInstitucion(InstitucioneMilitarExtranjeraId).Select(x => new { x.GradoExtranjeroId, x.Descripcion, }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEscuelasPorInstitucion(string InstitucioneMilitarExtranjeraId)
        {
            return Json(new X1003InformacionCastrenseViewModel().GetEscuelasPorInstitucion(InstitucioneMilitarExtranjeraId).Select(x => new { x.EscuelaExtranjeraId, x.Nombre, }).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCursosPorEscuelas(string EscuelaExtranjeraId)
        {
            return Json(new X1003InformacionCastrenseViewModel().GetCursosPorEscuelas(EscuelaExtranjeraId).Select(x => new { x.CursoEscuelaExtranjeraId, x.Nombre, }).ToList(), JsonRequestBehavior.AllowGet);
        }



        //**************************************
        //SECCION FRM OTROS
        //**************************************
        public ActionResult VerFrmAgregarObservacion()
        {
            AgregarObservacionViewModel vm = new AgregarObservacionViewModel();
            return PartialView("../X1003/FrmAgregarObservacion", vm);
        }

        public ActionResult VerFrmAgregarDeporte()
        {
            AgregarDeporteViewModel vm = new AgregarDeporteViewModel();
            return PartialView("../X1003/FrmAgregarDeporte", vm);
        }

    }
}