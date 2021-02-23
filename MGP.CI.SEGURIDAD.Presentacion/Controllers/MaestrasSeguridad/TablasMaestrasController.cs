using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers
{
    public class TablasMaestrasController : MGPBaseController
    {
        #region "Tablas Maestras"        
        public ActionResult Index()
        {
            if (Session["objsesion"] == null) return RedirectToAction("index", "Login");

            string controllerName = "Usuario";
            ViewBag.PERMISOS = this.GetPermisoVista('/' + controllerName + '/' + "Index");

            return View();
        }
        public ActionResult VerTablasXP()
        {
            if (Session["objsesion"] == null) return RedirectToAction("index", "Login");

            string controllerName = "Usuario";
            ViewBag.PERMISOS = this.GetPermisoVista('/' + controllerName + '/' + "Index");

            return View();
        }
        public ActionResult Consultar_listaToDatatableXp()
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            TablasMaestrasViewModel usuarioVM = new TablasMaestrasViewModel();

            return Json(new { data = new TablasMaestrasViewModel().Consultar_listaToDatatableXp().Select(x => new { x.TablaNombre, x.TablaDescripcion, x.SistemaNombre, x.EstadoNombre, x.FechaModificacionRegistroStr }), JsonRequestBehavior.AllowGet });
        }
        public ActionResult Consultar_listaToDatatableSeg()
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            TablasMaestrasViewModel usuarioVM = new TablasMaestrasViewModel();

            return Json(new { data = new TablasMaestrasViewModel().Consultar_listaToDatatableSeg().Select(x => new { x.TablaNombre, x.TablaDescripcion, x.SistemaNombre, x.EstadoNombre, x.FechaModificacionRegistroStr }), JsonRequestBehavior.AllowGet });
        }
        public ActionResult ListarTablasFiltradas(TablasMaestrasViewModel obj)
        {
            TablasMaestrasViewModel vm = new TablasMaestrasViewModel();
            var query = vm.ListarTablasFiltradas(obj).Select(x => new { x.TablaNombre, x.TablaDescripcion, x.SistemaNombre, x.EstadoNombre, x.FechaModificacionRegistroStr }).ToList();

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TablaVerDetalles(string m_TablaNombre)
        {
            string actionName = "Index";
            string controllerName = "Usuario";
            ViewBag.PERMISOS = this.GetPermisoVista('/' + controllerName + '/' + actionName);

            if (m_TablaNombre.Equals("DocumentoIdentidadTipos"))
            {
                DocumentoIdentidadTiposViewModel DocTipoVM = new DocumentoIdentidadTiposViewModel();
                DocTipoVM.TablaNombre = m_TablaNombre;

                return View("../MantenimientoMaestras/FrmDocumentoMostrarLista", DocTipoVM);
            }

            if (m_TablaNombre.Equals("TiposUsuarios"))
            {
                TiposUsuariosVM tipoUsuarioVM = new TiposUsuariosVM();
                tipoUsuarioVM.TablaNombre = m_TablaNombre;

                return View("../MantenimientoMaestras/FrmTipoUsuarioMostrarLista", tipoUsuarioVM);
            }

            if (m_TablaNombre.Equals("UbigeoNaval"))
            {
                UbigeoNavalVM UbigelNavalVM = new UbigeoNavalVM();
                //UbigelNavalVM.TablaNombre = m_TablaNombre;

                return View("../MantenimientoMaestras/FrmUbigeoMostrarLista", UbigelNavalVM);
            }

            return View();
        }
        #endregion


        #region "Tipos de Documentos"        
        public ActionResult ConsultarTipoDocumentos()
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            DocumentoIdentidadTiposViewModel DocTipoVM = new DocumentoIdentidadTiposViewModel();
            DocTipoVM.CargarTiposDocumentos();
            var DocTipoVista = DocTipoVM.LstTipoDocumentos.OrderBy(x=>x.Codigo).Select(x => new { x.Codigo, x.EstadoId, x.Id, x.Descripcion, x.EstadoNombre, x.FechaModificacionRegistroStr }).ToList();
            return Json(new { data = DocTipoVista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GrabarTipoDocumento(DocumentoIdentidadTiposViewModel m_tipodocumentoVM)
        {
            bool ret = false;
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            if (!ModelState.IsValid)
                return Json(new { success = false, mensajeError = GetErrorFromModel() }, JsonRequestBehavior.AllowGet);

            try
            {
                if (m_tipodocumentoVM.Id == 0)
                    ret = m_tipodocumentoVM.Insertar(sesionVM.Login);
                else
                    ret = m_tipodocumentoVM.Actualizar(sesionVM.Login);
            }
            catch (Exception e)
            {
                return Json(new { success = false, mensajeError = "Ocurrió una excepción interna" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = ret , mensajeError = m_tipodocumentoVM.ErrorSMS}, JsonRequestBehavior.AllowGet);

        }
        public ActionResult VerFormEditarDocumento(int m_tipodocumentoId)
        {
            DocumentoIdentidadTiposViewModel documentoIdentidadTiposVM;

            if (m_tipodocumentoId == 0)
            {
                documentoIdentidadTiposVM = new DocumentoIdentidadTiposViewModel();
                documentoIdentidadTiposVM.Codigo = documentoIdentidadTiposVM.GetMaxId()+1;
            }
            else
                documentoIdentidadTiposVM = new DocumentoIdentidadTiposViewModel().BuscarxId(m_tipodocumentoId);

            return PartialView("../MantenimientoMaestras/FrmDocumentoEditar", documentoIdentidadTiposVM);
        }
        [HttpPost]
        public ActionResult ListarRegistrosFiltradosDocumentos(DocumentoIdentidadTiposViewModel obj)
        {
            DocumentoIdentidadTiposViewModel vm = new DocumentoIdentidadTiposViewModel();
            var query = vm.ListarRegistrosFiltrados(obj).Select(x => new { x.EstadoId, x.Codigo, x.Descripcion, x.EstadoNombre, x.FechaModificacionRegistroStr }).ToList();

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EliminarRegistro(int m_tipodocumentoId)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            string controllerName = "Usuario";
            if (this.GetPermisoVista('/' + controllerName + '/' + "Index").ELIMINAR == false)
                return Json(new { success = false, mensajeError = "Usuario no autorizado" }, JsonRequestBehavior.AllowGet);

            DocumentoIdentidadTiposViewModel vm = new DocumentoIdentidadTiposViewModel();
            return Json(new { success = vm.Anular(m_tipodocumentoId, sesionVM.Login), mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult cambioEstadoRegistro(int m_tipodocumentoId, int m_estadoId)
        {
            DocumentoIdentidadTiposViewModel vm = new DocumentoIdentidadTiposViewModel();
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            return Json(new { success = vm.CambiarEstado(m_tipodocumentoId, m_estadoId, sesionVM.Login), mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region "Ubigeo Naval"        
        public ActionResult ConsultarUbigelNaval()
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            UbigeoNavalVM ubigeoVM = new UbigeoNavalVM();
            var UbigeoVista = ubigeoVM.Listar().OrderBy(x => x.ZonaNavalDescCorta).Select(x => new {  x.UbigeoNavalId, x.EstadoId, x.EstadoNombre, x.ZonaNavalId, x.ZonaNavalDescCorta, x.ZonaNavalDescLarga, x.DependenciaId, x.DependenciaDescCorta, x.DependenciaDescLarga, x.FechaRegistroStr }).ToList();
            return Json(new { data = UbigeoVista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GrabarUbigeo(UbigeoNavalVM ubigeoVM)
        {
            bool ret = false;
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            if (!ModelState.IsValid)
                return Json(new { success = false, mensajeError = GetErrorFromModel() }, JsonRequestBehavior.AllowGet);

            try
            {
                if (ubigeoVM.UbigeoNavalId == 0)
                    ret = ubigeoVM.Insertar(sesionVM.Login);
                else
                {
                    ret = ubigeoVM.Actualizar(sesionVM.Login);
                }
            }
            catch (Exception e)
            {
                return Json(new { success = false, mensajeError = "Ocurrió una excepción interna" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = ret, mensajeError = ubigeoVM.ErrorSMS }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult VerFormEditarUbigeo (int m_UbigeoId)
        {
            UbigeoNavalVM ubigeoVM;

            if (m_UbigeoId == 0)
                ubigeoVM = new UbigeoNavalVM();
            else
                ubigeoVM = new UbigeoNavalVM().BuscarxIdReturnVM(m_UbigeoId);

            ubigeoVM.CargarZonasNavalesxGrupo();

            return PartialView("../MantenimientoMaestras/FrmUbigeoEditar", ubigeoVM);
        }
         [HttpPost]
        public ActionResult EliminarUbigeo(int m_ubigeoNavalId)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            string controllerName = "Usuario";
            if (this.GetPermisoVista('/' + controllerName + '/' + "Index").ELIMINAR == false)
                return Json(new { success = false, mensajeError = "Usuario no autorizado" }, JsonRequestBehavior.AllowGet);

            UbigeoNavalVM vm = new UbigeoNavalVM();
            return Json(new { success = vm.Eliminar(m_ubigeoNavalId, sesionVM.Login), mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult cambioEstadoRegistroUbigeo(int m_ubigeoNavalId, int m_estadoId)
        {
            UbigeoNavalVM vm = new UbigeoNavalVM();
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            return Json(new { success = vm.CambiarEstado(m_ubigeoNavalId, m_estadoId, sesionVM.Login), mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region "Tipo Usuarios"        
        public ActionResult ConsultarTipoUsuarios()
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            TiposUsuariosVM tipoUsuarioVM = new TiposUsuariosVM();
            var UbigeoVista = tipoUsuarioVM.CargarTiposUsuarios().OrderBy(x => x.DescCorta).Select(x => new { x.Id, x.DescCorta, x.DescLarga, x.EstadoId, x.EstadoNombre, x.FechaRegistroStr }).ToList();
            return Json(new { data = UbigeoVista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GrabarTipoUsuarios(TiposUsuariosVM ubigeoVM)
        {
            bool ret = false;
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            if (!ModelState.IsValid)
                return Json(new { success = false, mensajeError = GetErrorFromModel() }, JsonRequestBehavior.AllowGet);

            try
            {
                if (ubigeoVM.Id == 0)
                    ret = ubigeoVM.Insertar(sesionVM.Login);
                else
                    ret = ubigeoVM.Actualizar(sesionVM.Login);
            }
            catch (Exception e)
            {
                return Json(new { success = false, mensajeError = "Ocurrió una excepción interna" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = ret, mensajeError = ubigeoVM.ErrorSMS }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult VerFormEditarTipoUsuario(int m_TipoUsuarioId)
        {
            TiposUsuariosVM TipoUsuarioVM;

            if (m_TipoUsuarioId == 0)
                TipoUsuarioVM = new TiposUsuariosVM();
            else
                TipoUsuarioVM = new TiposUsuariosVM().BuscarxId(m_TipoUsuarioId);

            return PartialView("../MantenimientoMaestras/FrmTipoUsuarioEditar", TipoUsuarioVM);
        }
        [HttpPost]
        public ActionResult EliminarTipoUsuario(int m_tipoUsuarioId)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            string controllerName = "Usuario";
            if (this.GetPermisoVista('/' + controllerName + '/' + "Index").ELIMINAR == false)
                return Json(new { success = false, mensajeError = "Usuario no autorizado" }, JsonRequestBehavior.AllowGet);

            TiposUsuariosVM vm = new TiposUsuariosVM();
            return Json(new { success = vm.Anular(m_tipoUsuarioId, sesionVM.Login), mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult cambioEstadoRegistroTipoUsuario(int m_TipoUsuarioId, int m_estadoId)
        {
            TiposUsuariosVM vm = new TiposUsuariosVM();
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            return Json(new { success = vm.CambiarEstado(m_TipoUsuarioId, m_estadoId, sesionVM.Login), mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }
        #endregion

       

    }


}