using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Presentacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.Controllers
{
    public class MGPBaseController : Controller
    {
        //public string CONST_KEY_SISTEMA = "AAFB7F64FD3E4707";
        //public string CONST_KEY_MODULO = "";

        public MGPBaseController()
        {
        }
        protected String GetErrorFromModel()
        {
            String sms = "";
            var err = ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage);

            foreach (var y in err)
            {
                sms = sms + "<li>" + y.ToString() + "</li>";
            }

            return "<ul type='circle'>" + sms + "</ul>";
        }

        protected PermisoVistaVM GetPermisoVista(string path)
        {

            PermisoVistaVM permisovistaVM = new PermisoVistaVM();
            SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];

            if (sesionVM == null)
                return permisovistaVM;

            int PerfilModuloId = 0;

            if (sesionVM.UsuarioPerfilAdmId > 0)
            {
                PerfilModuloId = sesionVM.LstModulosAsociados.Join(new ModulosBL().Consultar_Lista().Where(x => x.MenuPath != null).ToList(), PM => PM.ModuloId, M => M.ModuloId, (PM, M) => new { m = M, pm = PM }).ToList()
                                .Find(x => x.m.MenuPath.ToLower().Equals(path.ToLower()) && x.pm.PerfilId == sesionVM.UsuarioPerfilAdmId).pm.PerfilModuloId;
            }
            else
                PerfilModuloId = sesionVM.LstModulosAsociados.Join(new ModulosBL().Consultar_Lista(), PM => PM.ModuloId, M => M.ModuloId, (PM, M) => new { m = M, pm = PM }).ToList()
                                .Find(x => x.m.MenuPath.ToLower().Equals(path.ToLower()) && x.pm.PerfilId > 10).pm.PerfilModuloId;

            if (PerfilModuloId == 0)
                return permisovistaVM;

            return permisovistaVM.CargarPermisos(sesionVM.LstPermisosAsociados, PerfilModuloId);
        }


        //protected void getPermiso()
        //{

        //    //PermisosViewModel o = new PermisosViewModel();
        //    //if (Session["objsesion"] == null) return o;

        //    SesionViewModel sesionVM = (SesionViewModel)Session["objsesion"];
        //    UsuarioViewModel usuarioVM = new UsuarioViewModel();
        //    usuarioVM.BuscarPorId(sesionVM.UsuarioId);
        //    //   usuarioVM.ObtenerPermisosFromPerfil(sesionVM.UsuarioPerfilId);
        //    // return usuarioVM.Lstpermisos;


        //    //o.CargarPermisos(CONST_KEY_MODULO, v.UsuarioId, v.LstModulosAutorizados);

        //    //return o;
        //}

    }
}