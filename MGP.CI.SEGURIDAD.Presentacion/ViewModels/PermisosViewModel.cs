using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using MGP.CI.SEGURIDAD.Presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class PermisosViewModel
    {
        public string ErrorSMS { get; set; }
        #region "propiedades"

        public int PermisoId { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public int? EstadoId { get; set; }
        [Display(Name = "Estado Nombre")]
        public string EstadoNombre { get; set; }
        [Display(Name = "Usuario Registro")]
        public string UsuarioRegistro { get; set; }
        [Display(Name = "Fecha Registro")]
        public DateTime? FechaRegistro { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public string UsuarioModificacionRegistro { get; set; }
        [Display(Name = "Fecha de Modificacion")]
        public DateTime? FechaModificacionRegistro { get; set; }
        public String FechaRegistroStr
        {
            get
            {
                return (this.FechaRegistro == null) ? "" : this.FechaRegistro.ToString();
            }
        }
        public String FechaModificacionRegistroStr
        {
            get
            {
                return (this.FechaModificacionRegistro == null) ? "" : this.FechaModificacionRegistro.ToString();
            }
        }
        [Display(Name = "IP de Registro")]
        public string NroIpRegistro { get; set; }
        #endregion

        public bool NUEVO { get; set; } = false;
        public bool ELIMINAR { get; set; } = false;
        public bool MODIFICAR { get; set; } = false;
        public bool CONSULTAR { get; set; } = false;
        public bool REPORTE { get; set; } = false;

        public int MODULO_ID { get; set; } = -1;
        public int SISTEMA_ID { get; set; } = -1;
        public int SESION_USUARIO_ID { get; set; } = -1;

        #region "Constructores"   

        public PermisosViewModel()
        {
        }
        #endregion
        #region "Operaciones"        

        private PermisosBE ViewModelToBE(PermisosViewModel m_PermisoVM)
        {
            PermisosBE m_permisosBE = new PermisosBE();

            m_permisosBE.PermisoId = m_PermisoVM.PermisoId;
            m_permisosBE.Nombre = m_PermisoVM.Nombre;
            m_permisosBE.EstadoId = m_PermisoVM.EstadoId;
            m_permisosBE.UsuarioRegistro = m_PermisoVM.UsuarioRegistro;
            m_permisosBE.FechaRegistro = m_PermisoVM.FechaRegistro;
            m_permisosBE.UsuarioModificacionRegistro = m_PermisoVM.UsuarioModificacionRegistro;
            m_permisosBE.FechaModificacionRegistro = m_PermisoVM.FechaModificacionRegistro;
            m_permisosBE.NroIpRegistro = m_PermisoVM.NroIpRegistro;
            return m_permisosBE;
        }
        private PermisosViewModel BEToViewModel(PermisosBE m_PermisoBE)
        {
            PermisosViewModel permisoVM = new PermisosViewModel();

            permisoVM.PermisoId = m_PermisoBE.PermisoId;
            permisoVM.Nombre = m_PermisoBE.Nombre;
            permisoVM.EstadoId = m_PermisoBE.EstadoId;
            permisoVM.EstadoNombre = new EstadosBL().Consultar_Lista().Where(x => x.EstadoId == m_PermisoBE.EstadoId).FirstOrDefault().Nombre;
            permisoVM.UsuarioRegistro = m_PermisoBE.UsuarioRegistro;
            permisoVM.FechaRegistro = m_PermisoBE.FechaRegistro;
            permisoVM.UsuarioModificacionRegistro = m_PermisoBE.UsuarioModificacionRegistro;
            permisoVM.FechaModificacionRegistro = m_PermisoBE.FechaModificacionRegistro;
            permisoVM.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            return permisoVM;
        }
        public List<PermisosViewModel> Listar()
        {
            List<PermisosViewModel> LstPermisosVM= new List<PermisosViewModel>();
            List<PermisosBE> LstPermisosBE = (new PermisosBL()).Consultar_Lista();

            foreach (PermisosBE permisoBE in LstPermisosBE)
            {
                LstPermisosVM.Add(BEToViewModel(permisoBE));

            }
            return LstPermisosVM;
        }
        public bool Insertar()
        {
            String out_sms_err = "";
            bool v = false;
            PermisosBE permisosBE = new PermisosBE();
            permisosBE = ViewModelToBE(this);
            v = (new PermisosBL()).Insertar(permisosBE);

            if (v == false) this.ErrorSMS = out_sms_err;

            return v;
        }
        public bool Actualizar()
        {
            String out_sms_err = "";
            bool v = false;
            PermisosBE permisosBE = new PermisosBE();
            permisosBE = ViewModelToBE(this);
            v = (new PermisosBL()).Actualizar(permisosBE);

            if (v == false) this.ErrorSMS = out_sms_err;

            return v;
        }
        public void BuscarPorId(int m_permisoId)
        {
            if (m_permisoId < 0) return;

            PermisosBE permisoBE = new PermisosBL().Consultar_PK(m_permisoId).FirstOrDefault();

            if (permisoBE != null)
                BEToViewModel(permisoBE);
        }
        public bool Eliminar(int m_permisoId)
        {
            bool v = false;
            if (m_permisoId < 0) return false;

            v = new PermisosBL().Anular(new PermisosBL().Consultar_Lista().Where(x => x.PermisoId == m_permisoId).FirstOrDefault());

            if (v == false) this.ErrorSMS = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return v;

        }







        //public void CargarPermisos(string KEY_MODULO, int usuarioId, List<PermisoPerfilModuloViewModel> lstModPerm)
        //{
        //    //// Tengo que sacar el perfil : si es 1 es decir admin entonces tiene todos los permisos

        //    //if (usuarioId == 2)
        //    //{//si es admin
        //    //    this.NUEVO = true;
        //    //    this.ELIMINAR = true;
        //    //    this.MODIFICAR = true;
        //    //    this.CONSULTAR = true;
        //    //    this.REPORTE = true;
        //    //    this.SESION_USUARIO_ID = 1;
        //    //    return;
        //    //}

        //    //var lst = from fila in lstModPerm
        //    //          where fila.ModuloKey == KEY_MODULO// && fila.USUARIO_ID == usuarioId
        //    //          select fila;

        //    //foreach (var f in lst)
        //    //{
        //    //    if (f.PermisoId == ConstantHelpers.enum_PERMISOS.NUEVO) this.NUEVO = true;
        //    //    if (f.PermisoId == ConstantHelpers.enum_PERMISOS.ELIMINAR) this.ELIMINAR = true;
        //    //    if (f.PermisoId == ConstantHelpers.enum_PERMISOS.MODIFICAR) this.MODIFICAR = true;
        //    //    if (f.PermisoId == ConstantHelpers.enum_PERMISOS.CONSULTAR) this.CONSULTAR = true;
        //    //    if (f.PermisoId == ConstantHelpers.enum_PERMISOS.REPORTE) this.REPORTE = true;
        //    //}
        //    //this.SESION_USUARIO_ID = usuarioId;
        //}

        #endregion

    }
}