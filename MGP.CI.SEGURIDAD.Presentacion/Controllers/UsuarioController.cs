using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Presentacion.Helpers;
using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers
{
    [FiltroSesion]
    public class UsuarioController : MGPBaseController
    {
        public UsuarioController()
        {
        }
        public ActionResult Index()
        {
            if (Session["objsesion"] == null) return RedirectToAction("index", "Login");

            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            ViewBag.PERMISOS = this.GetPermisoVista('/' + controllerName + '/' + actionName);

            return View();
        }
        public ActionResult Consultar_listaToDatatable()
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            UsuarioViewModel usuarioVM= new UsuarioViewModel();

            var usuariosVista = usuarioVM.Consultar_listaToDatatable(sesionVM.UsuarioId).Select(x => new { x.UsuarioId, x.Login, x.NombresCompletos, x.ZonaNaval, x.Dependencia, x.EstadoNombre, x.TipoUsuario, x.FechaRegistroStr, x.EstadoId }).ToList();
            return Json(new { data = usuariosVista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Consultar_lista()
        {
            UsuarioViewModel vm = new UsuarioViewModel();

            return Json(new { data = vm.Consultar_lista() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult VerFormCambioClave(int UsuarioId)
        {
            LoginViewModel loginVM = new LoginViewModel();
            UsuariosBE usuarioBE = new UsuariosBE();

            usuarioBE = new UsuariosBL().Consultar_PK(UsuarioId).FirstOrDefault();

            loginVM.Login = usuarioBE.Login;
            loginVM.UsuarioNombre = usuarioBE.Nombres + ' ' + usuarioBE.ApePaterno + ' ' + usuarioBE.ApeMaterno;
            loginVM.UsuarioId = usuarioBE.UsuarioId;

            return PartialView("FrmCambiarClave", loginVM);
        }

        [HttpPost]
        public ActionResult CambiarClave(LoginViewModel m_loginVM)
        {
            return Json(new { success = m_loginVM.CambiarClave(), mensajeError = m_loginVM.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ListarUsuariosFiltrados(UsuarioViewModel obj)
        {
            UsuarioViewModel vm = new UsuarioViewModel();
            var query = vm.ListarUsuariosFiltrados(obj).Select(x => new { x.UsuarioId, x.Login, x.NombresCompletos, x.ZonaNaval, x.Dependencia, x.EstadoNombre, x.TipoUsuario, x.FechaRegistroStr, x.EstadoId }).ToList();

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UsuarioCambiarEstado(int m_usuarioId, int m_estadoId)
        {
            UsuarioViewModel vm = new UsuarioViewModel();
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
            return Json(new { success = vm.CambiarEstado(m_usuarioId, m_estadoId, sesionVM.UsuarioId), mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Anular(int UsuarioId)
        {
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            if (this.GetPermisoVista('/' + controllerName + '/' + "Index").ELIMINAR == false)
                return Json(new { success = false, mensajeError = "Usuario no autorizado" }, JsonRequestBehavior.AllowGet);

            UsuarioViewModel vm = new UsuarioViewModel();
            return Json(new { success = vm.Anular(UsuarioId, sesionVM.Login), mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UsuarioVerDetalles(String m_usuarioId)
        {
            if (Session["objsesion"] == null)
                return RedirectToAction("index", "Login");

            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            ViewBag.PERMISOS = this.GetPermisoVista('/' + controllerName + '/' + "Index");

            UsuarioViewModel m_usuarioVM = new UsuarioViewModel();

            if (m_usuarioId != null)
            {
                m_usuarioVM = new UsuarioViewModel().BuscarxId(Convert.ToInt32(m_usuarioId));
                try
                {
                    byte[] FotoByte = System.IO.File.ReadAllBytes(Server.MapPath("~" + m_usuarioVM.AvatarPath));
                    m_usuarioVM.ImagenBase64 = Convert.ToBase64String(FotoByte);
                }
                catch (Exception e)
                {
                    m_usuarioVM.ImagenBase64 = "";
                }
            }
            else
            {
                m_usuarioVM.DependenciaId = 80443;
                m_usuarioVM.ZonaNavalId = 0;
            }

            m_usuarioVM.CargarDependenciasxZona(m_usuarioVM.ZonaNavalId);
            m_usuarioVM.CargarTablasMaestras();
            return View("FrmUsuarioDetalles", m_usuarioVM);
        }
        
        //public ActionResult GrabarDetalles(UsuarioViewModel m_usuarioVM, HttpPostedFileBase ImagenAdjunto, string fotoDelete)
        public ActionResult GrabarDetalles(UsuarioViewModel m_usuarioVM)
        {
            int id = -1;
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            if (!ModelState.IsValid)
                return Json(new { success = false, mensajeError = GetErrorFromModel() }, JsonRequestBehavior.AllowGet);

            if (m_usuarioVM.ZonaNavalId == 0 && m_usuarioVM.DependenciaId == 0)
            {
                m_usuarioVM.ZonaNavalId = 0;
                m_usuarioVM.DependenciaId = 80443;
            }

            try
            {
                if (m_usuarioVM.UsuarioId == 0) // nuevo
                   id = m_usuarioVM.Insertar(sesionVM.Login);
                else
                    id = m_usuarioVM.Actualizar(sesionVM.Login);
            }
            catch (Exception e)
            {
                return Json(new { success = false, mensajeError = "Ocurrió una excepción interna" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = (id > 0), mensajeError = m_usuarioVM.ErrorSMS, id = id }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VerFormBuscarUsuario()
        {
            ConsultaUsuarioViewModel consultausuario = new ConsultaUsuarioViewModel();
            return PartialView("../MantenimientoMaestras/FrmBuscarUsuario", consultausuario);
        }

        //[HttpPost]
        //public ActionResult BuscarUsuarioReniec(string DNI)
        //{
        //    //ReniecViewModel vm = new ReniecViewModel();
        //    //if (vm.BuscarPorDni(DNI))
        //    //    return Json(new { data = vm, mensajeError = vm.ERROR_SMS, NUM_TOT_REG = vm.TOTAL_COINCIDENCIA }, JsonRequestBehavior.AllowGet);

        //    //return Json(new { data = vm, mensajeError = vm.ERROR_SMS, NUM_TOT_REG = 0 }, JsonRequestBehavior.AllowGet);
        //}


















        //[HttpPost]
        //public ActionResult ListarGrillaInicial(UsuarioViewModel obj)
        //{
        //    UsuarioViewModel vm = new UsuarioViewModel();

        //    //ViewBag.objPERMISO = getPermiso();

        //    //return Json(new { data = vm.Listar_grilla_inicial(obj) }, JsonRequestBehavior.AllowGet);
        //    return Json(new { data = vm.Consultar_lista() }, JsonRequestBehavior.AllowGet);
        //}





        //[HttpPost]
        //public ActionResult ListarGrilla(UsuarioViewModel obj)
        //{
        //    UsuarioViewModel vm = new UsuarioViewModel();

        //    ViewBag.objPERMISO = getPermiso();

        //    return Json(new { data = vm.Listar_grilla(obj) }, JsonRequestBehavior.AllowGet);
        //}



        //[HttpPost]
        //public ActionResult GrabarCambioClave(LoginViewModel ent)
        //{
        //    bool b = false;

        //    b = ent.GrabarCambioClave();

        //    if (b == true) Session["objsesion"] = null;

        //    return Json(new { success = b, mensajeError = ent.ErrorSMS }, JsonRequestBehavior.AllowGet);
        //}






        //[HttpPost]
        //public ActionResult MostrarFrmResetClave(int id_usuario)
        //{
        //    LoginViewModel loginVM = new LoginViewModel();
        //    UsuarioViewModel u = new UsuarioViewModel();

        //    u.UsuarioId = id_usuario;
        //    u.EstadoId = -1;

        //    List<UsuariosBE> usuarioBE = new List<UsuariosBE>();
        //    usuarioBE = new UsuariosBL().Consultar_PK(id_usuario);

        //    loginVM.Login = usuarioBE[0].Login;
        //    loginVM.UsuarioNombre = usuarioBE[0].Nombres + ' ' + usuarioBE[0].ApePaterno + ' ' + usuarioBE[0].ApeMaterno;
        //    loginVM.UsuarioId = usuarioBE[0].UsuarioId;

        //    return PartialView("ResetPasswordPopup", loginVM);
        //}


        //[HttpPost]
        //public ActionResult UsuarioResetClave(LoginViewModel ent)
        //{
        //    return Json(new { success = ent.CambioClave(), mensajeError = ent.ErrorSMS }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult UsuarioEliminar(int id)
        //{
        //    if (getPermiso().ELIMINAR == false) return Json(new { success = false, mensajeError = "Ud. no esta autorizado para eliminar Usuarios" }, JsonRequestBehavior.AllowGet);

        //    UsuarioViewModel vm = new UsuarioViewModel();
        //    return Json(new { success = vm.Eliminar(id), mensajeError = vm.ErrorSMS }, JsonRequestBehavior.AllowGet);
        //}







    }
}