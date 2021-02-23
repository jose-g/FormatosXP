using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class UsuariosPerfilesViewModel
    {
        public string ErrorSMS { get; set; } = "";

        #region Propiedades
        public int UsuarioPerfilId { get; set; }
        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }
        public int? EstadoId { get; set; }
        [Display(Name = "Usuario Registro")]
        public string UsuarioRegistro { get; set; }
        [Display(Name = "Fecha Registro")]
        public DateTime? FechaRegistro { get; set; }
        [Display(Name = "Usuario Modificacion Registro")]
        public string UsuarioModificacionRegistro { get; set; }
        [Display(Name = "Fecha Modificacion Registro")]
        public DateTime? FechaModificacionRegistro { get; set; }
        [Display(Name = "Nro IP Registro")]
        public string NroIpRegistro { get; set; }
        [Display(Name = "Estado")]
        public string EstadoNombre { get; set; }
        [Display(Name = "Nombre del Perfil")]
        public String PerfilNombre { get; set; }
        [Display(Name = "Nombre del Usuario")]
        public String UsuarioNombre { get; set; }
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
        #endregion

        #region "Constructores"        
        public UsuariosPerfilesViewModel() { }
        #endregion


        #region "Operaciones"   
        public List<UsuariosPerfilesViewModel> Listar()
        {
            List<UsuariosPerfilesViewModel> LstUsuarioPerfilesVM = new List<UsuariosPerfilesViewModel>();

            List<UsuarioPerfilesBE> LstUsuarioPerfilesBE = (new UsuarioPerfilesBL()).Consultar_Lista();

            foreach (UsuarioPerfilesBE usuarioperfilBE in LstUsuarioPerfilesBE)
            {
                LstUsuarioPerfilesVM.Add(BEToViewModel(usuarioperfilBE));

            }

            return LstUsuarioPerfilesVM;
        }
        public bool Eliminar(int UsuarioPerfilesId)
        {
            bool v = false;
            if (UsuarioPerfilesId < 0) return false;

            v = (new UsuarioPerfilesBL()).Anular(new UsuarioPerfilesBL().Consultar_PK(UsuarioPerfilesId).FirstOrDefault());

            if (v == false) this.ErrorSMS = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return v;
        }
        private UsuariosPerfilesViewModel BEToViewModel(UsuarioPerfilesBE m_usuarioperfilBE)
        {
            UsuariosPerfilesViewModel m_usuarioperfilesVM = new UsuariosPerfilesViewModel();

            m_usuarioperfilesVM.UsuarioPerfilId = m_usuarioperfilBE.UsuarioPerfilId;
            m_usuarioperfilesVM.UsuarioId = m_usuarioperfilBE.UsuarioId;
            m_usuarioperfilesVM.PerfilId = m_usuarioperfilBE.PerfilId;
            m_usuarioperfilesVM.EstadoId = m_usuarioperfilBE.EstadoId;
            m_usuarioperfilesVM.UsuarioRegistro = m_usuarioperfilBE.UsuarioRegistro;
            m_usuarioperfilesVM.FechaRegistro = m_usuarioperfilBE.FechaRegistro;
            m_usuarioperfilesVM.UsuarioModificacionRegistro = m_usuarioperfilBE.UsuarioModificacionRegistro;
            m_usuarioperfilesVM.FechaModificacionRegistro = m_usuarioperfilBE.FechaModificacionRegistro;
            m_usuarioperfilesVM.NroIpRegistro = m_usuarioperfilBE.NroIpRegistro;
            m_usuarioperfilesVM.EstadoNombre = new EstadosBL().Consultar_Lista().Where(x => x.EstadoId == m_usuarioperfilBE.EstadoId).First().Nombre; ;
            m_usuarioperfilesVM.PerfilNombre = new PerfilesBL().Consultar_Lista().Where(x => x.PerfilesId == m_usuarioperfilBE.PerfilId).First().Nombre;
            m_usuarioperfilesVM.UsuarioNombre = new UsuariosBL().Consultar_Lista().Where(x => x.UsuarioId == m_usuarioperfilBE.UsuarioId).First().Login;
            return m_usuarioperfilesVM;
        }
        private UsuarioPerfilesBE ViewModelToBE(UsuariosPerfilesViewModel m_usuarioperfilesVM)
        {
            UsuarioPerfilesBE m_usuarioperfilBE = new UsuarioPerfilesBE();

            m_usuarioperfilBE.UsuarioPerfilId = m_usuarioperfilesVM.UsuarioPerfilId;
            m_usuarioperfilBE.UsuarioId = m_usuarioperfilesVM.UsuarioId;
            m_usuarioperfilBE.PerfilId = m_usuarioperfilesVM.PerfilId;
            m_usuarioperfilBE.EstadoId = m_usuarioperfilesVM.EstadoId;
            m_usuarioperfilBE.UsuarioRegistro = m_usuarioperfilesVM.UsuarioRegistro;
            m_usuarioperfilBE.FechaRegistro = m_usuarioperfilesVM.FechaRegistro;
            m_usuarioperfilBE.UsuarioModificacionRegistro = m_usuarioperfilesVM.UsuarioModificacionRegistro;
            m_usuarioperfilBE.FechaModificacionRegistro = m_usuarioperfilesVM.FechaModificacionRegistro;
            m_usuarioperfilBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            return m_usuarioperfilBE;
        }
        public void BuscarPorId(int UsuarioPerfilId)
        {
            if (UsuarioPerfilId < 0) return;

            UsuarioPerfilesBE UsuarioPerfilBE = new UsuarioPerfilesBL().Consultar_PK(UsuarioPerfilId).FirstOrDefault();

            if (UsuarioPerfilBE != null)
                BEToViewModel(UsuarioPerfilBE);
        }
        public bool Actualizar()
        {
            String out_sms_err = "";
            bool v = false;

            v = (new UsuarioPerfilesBL()).Actualizar(ViewModelToBE(this), ref out_sms_err);

            if (v == false) this.ErrorSMS = out_sms_err;

            return v;
        }
        public bool AsignarPerfil(string login)
        {
            String out_sms_err = "";
            bool v = false;

            if (this.PerfilId < 10)
            {
                if (new UsuarioPerfilesBL().Consultar_Lista().FindAll(x => x.UsuarioId == this.UsuarioId && x.PerfilId < 10 && x.EstadoId != 0).Count > 0)
                {
                    this.ErrorSMS = "No puede asignarse dos perfiles de Administrador";
                    return v;
                }
            }

            if (this.PerfilId > 10 && this.PerfilId < 20)
            {
                if (new UsuarioPerfilesBL().Consultar_Lista().FindAll(x => x.UsuarioId == this.UsuarioId && x.PerfilId > 10 && x.PerfilId < 20 && x.EstadoId != 0).Count > 0)
                {
                    this.ErrorSMS = "No puede asignarse dos perfiles del Sistema";
                    return v;
                }
            }

            UsuarioPerfilesBE usuarioPerfilesBE = new UsuarioPerfilesBL().Consultar_Lista().Find(x => x.UsuarioId == this.UsuarioId && x.PerfilId == this.PerfilId && x.EstadoId == 1);
            if (usuarioPerfilesBE != null)
            {
                this.ErrorSMS = "Perfil ya fue asignado";
                return v;
            }

            this.UsuarioRegistro = login;

            v = (new UsuarioPerfilesBL()).Insertar(ViewModelToBE(this), ref out_sms_err);
            if (v == false) this.ErrorSMS = out_sms_err;

            return v;
        }
        public List<UsuariosPerfilesViewModel> ListarPerfilesAsignados(UsuariosPerfilesViewModel mv)
        {
            List<UsuariosPerfilesViewModel> LstUsuariosPerfilesVM = new List<UsuariosPerfilesViewModel>();
            List<UsuarioPerfilesBE> LstusuarioPerfilesBE = new UsuarioPerfilesBL().ListarPerfilesAsignados(ViewModelToBE(mv));

            foreach (UsuarioPerfilesBE usuarioPerfilesBE in LstusuarioPerfilesBE)
                LstUsuariosPerfilesVM.Add(BEToViewModel(usuarioPerfilesBE));

            return LstUsuariosPerfilesVM.OrderBy(x=>x.PerfilNombre).ToList();
        }
        //public bool Eliminar(int id)
        //{
        //    bool v = false;
        //    if (id < 0) return false;

        //    UsuarioPerfilesBE ent = new UsuarioPerfilesBE();
        //    ent.UsuarioPerfilId = id;

        //    v = (new UsuarioPerfilesBL()).Anular(ent);

        //    if (v == false)
        //        this.ErrorSMS = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

        //    return v;
        //}
        //public void BuscarPorId(int id)
        //{

        //    if (id < 0) return;

        //    UsuarioPerfilDTO dto = new UsuarioPerfilDTO();
        //    UsuarioPerfilesBE usuariosperfilesBE = new UsuarioPerfilesBL().Consultar_Lista().Where(x => x.UsuarioPerfilId == id).First();
        //    this.UsuarioPerfilId = usuariosperfilesBE.UsuarioPerfilId;
        //    this.UsuarioId = usuariosperfilesBE.UsuarioId;
        //    this.PerfilId = usuariosperfilesBE.PerfilId;
        //    this.EstadoId = usuariosperfilesBE.EstadoId;
        //    this.UsuarioRegistro = usuariosperfilesBE.UsuarioRegistro;
        //    this.FechaRegistro = usuariosperfilesBE.FechaRegistro;
        //    this.UsuarioModificacionRegistro = usuariosperfilesBE.UsuarioModificacionRegistro;
        //    this.FechaModificacionRegistro = usuariosperfilesBE.FechaModificacionRegistro;
        //    this.EstadoNombre = new EstadosBL().Consultar_Lista().Where(x => x.EstadoId == usuariosperfilesBE.EstadoId).First().Descripcion;

        //}
        //public bool Actualizar()
        //{
        //    string sms = "";
        //    bool v = false;
        //    UsuarioPerfilesBE ent = new UsuarioPerfilesBE();

        //    ent.UsuarioPerfilId = this.UsuarioPerfilId;
        //    ent.UsuarioId = this.UsuarioId;
        //    ent.PerfilId = this.PerfilId;
        //    ent.EstadoId = this.EstadoId;
        //    ent.UsuarioRegistro = this.UsuarioRegistro;
        //    ent.FechaRegistro = this.FechaRegistro;
        //    ent.UsuarioModificacionRegistro = this.UsuarioModificacionRegistro;
        //    ent.FechaModificacionRegistro = this.FechaModificacionRegistro;
        //    v = (new UsuarioPerfilesBL()).Actualizar(ent, ref sms);

        //    if (v == false)
        //        this.ErrorSMS = sms;

        //    return v;
        //}
        public bool EliminarPerfil(int UsuarioPerfilId)
        {
            bool v = false;

            v = (new UsuarioPerfilesBL()).EliminarPerfil(UsuarioPerfilId);

            return v;
        }
        //public bool Insertar()
        //{
        //    string sms = "";
        //    bool v = false;
        //    UsuarioPerfilesBE ent = new UsuarioPerfilesBE();

        //    ent.UsuarioPerfilId = this.UsuarioPerfilId;
        //    ent.UsuarioId = this.UsuarioId;
        //    ent.PerfilId = this.PerfilId;
        //    ent.EstadoId = this.EstadoId;
        //    ent.UsuarioRegistro = this.UsuarioRegistro;
        //    ent.FechaRegistro = this.FechaRegistro;
        //    ent.UsuarioModificacionRegistro = this.UsuarioModificacionRegistro;
        //    ent.FechaModificacionRegistro = this.FechaModificacionRegistro;
        //    ent.NroIpRegistro = HttpContext.Current.Request.UserHostAddress; ;

        //    v = (new UsuarioPerfilesBL()).Insertar(ent, ref sms);

        //    if (v == false)
        //        this.ErrorSMS = sms;

        //    return v;
        //}


        #endregion

    }
}