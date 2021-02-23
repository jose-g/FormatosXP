using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class PerfilModulosViewModel
    {
        public String ErrorSms { get; set; } = "";

        #region Propiedades
        public int PerfilModuloId { get; set; }
        [Display(Name = "Nombre del Modulo")]
        public int ModuloId { get; set; }
        public string ModuloNombre { get; set; }
        public int PerfilId { get; set; }
        [Display(Name = "Nombre del Perfil")]
        public string  PerfilNombre  { get; set; }
        [Display(Name = "Estado Id")]
        public int EstadoId { get; set; }
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
        [Display(Name = "IP de Registro")]
        public string NroIpRegistro { get; set; }
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
        List<ModulosBE> LstModulosBE { get; set; }
        List<PermisoPerfilModulosBE> LstPermisoPerfilModulosBE { get; set; }
        #endregion
        #region "Constructores"        
        public PerfilModulosViewModel()
        {
            LstPermisoPerfilModulosBE = new List<PermisoPerfilModulosBE>();
            LstModulosBE = new List<ModulosBE>();

        }
        #endregion

        #region "Operaciones"        

        public void ListarModulosxSistema()
        {
        }

        public List<PerfilModulosViewModel> ListarxPerfil(int m_perfilId)
        {
            List<PerfilModulosViewModel> LstPerfilModulosViewModel = new List<PerfilModulosViewModel>();
            List<PerfilModulosBE> LstPerfilesModulosBE = (new PerfilModulosBL()).Consultar_Lista().Where(x => x.PerfilId == m_perfilId).ToList();
            foreach (PerfilModulosBE perfilmoduloBE in LstPerfilesModulosBE)
            {
                LstPerfilModulosViewModel.Add(BEToViewModel(perfilmoduloBE));

            }
            return LstPerfilModulosViewModel;
        }
        public List<PerfilModulosViewModel> ListarxModulos(int m_moduloId)
        {
            List<PerfilModulosViewModel> LstPerfilModulosViewModel = new List<PerfilModulosViewModel>();
            List<PerfilModulosBE> LstPerfilesModulosBE = (new PerfilModulosBL()).Consultar_Lista().Where(x => x.ModuloId == m_moduloId).ToList();
            foreach (PerfilModulosBE perfilmoduloBE in LstPerfilesModulosBE)
            {
                LstPerfilModulosViewModel.Add(BEToViewModel(perfilmoduloBE));

            }
            return LstPerfilModulosViewModel;
        }
        public List<PerfilModulosViewModel> Listar()
        {
            List<PerfilModulosViewModel> LstPerfilModulosViewModel = new List<PerfilModulosViewModel>();
            List<PerfilModulosBE> LstPerfilesModulosBE = (new PerfilModulosBL()).Consultar_Lista();

            foreach (PerfilModulosBE perfilmoduloBE in LstPerfilesModulosBE)
            {
                LstPerfilModulosViewModel.Add(BEToViewModel(perfilmoduloBE));

            }
            return LstPerfilModulosViewModel;
        }
        public bool Eliminar(int m_moduloId, int m_perfil)
        {
            bool v = false;
            if (m_moduloId < 0) return false;

            v = new PerfilModulosBL().Anular(new PerfilModulosBL().Consultar_Lista().Where(x => x.ModuloId == m_moduloId && x.PerfilId == m_perfil).FirstOrDefault());

            if (v == false) this.ErrorSms = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return v;

        }
        public void BuscarPorId(int m_perfilmoduloId)
        {
            if (m_perfilmoduloId < 0) return;

            PerfilModulosBE perfilmoduloBE = new PerfilModulosBL().Consultar_PK(m_perfilmoduloId).FirstOrDefault();

            if (perfilmoduloBE != null)
                BEToViewModel(perfilmoduloBE);
        }
        public bool Actualizar()
        {
            String out_sms_err = "";
            bool v = false;
            PerfilModulosBE perfilmoduloBE = new PerfilModulosBE();
            perfilmoduloBE = ViewModelToBE(this);
            v = (new PerfilModulosBL()).Actualizar(perfilmoduloBE);

            if (v == false) this.ErrorSms = out_sms_err;

            return v;
        }
        public bool Insertar()
        {
            String out_sms_err = "";
            bool v = false;
            PerfilModulosBE perfilmoduloBE = new PerfilModulosBE();
            perfilmoduloBE = ViewModelToBE(this);
            v = (new PerfilModulosBL()).Insertar(perfilmoduloBE);

            if (v == false) this.ErrorSms = out_sms_err;

            return v;
        }
        private PerfilModulosViewModel BEToViewModel(PerfilModulosBE m_PerfilModulosBE)
        {
            PerfilModulosViewModel perfilmodulosVM = new PerfilModulosViewModel();

            perfilmodulosVM.PerfilModuloId = m_PerfilModulosBE.PerfilModuloId;
            perfilmodulosVM.ModuloId = m_PerfilModulosBE.ModuloId.Value;
            perfilmodulosVM.ModuloNombre = new ModulosBL().Consultar_PK(m_PerfilModulosBE.ModuloId.Value).FirstOrDefault().Nombre;
            perfilmodulosVM.PerfilId = m_PerfilModulosBE.PerfilId.Value;
            perfilmodulosVM.PerfilNombre = new PerfilesBL().Consultar_PK(m_PerfilModulosBE.ModuloId.Value).FirstOrDefault().Nombre;
            perfilmodulosVM.EstadoId = m_PerfilModulosBE.EstadoId.Value;
            perfilmodulosVM.EstadoNombre = new EstadosBL().Consultar_Lista().Where(x => x.EstadoId == m_PerfilModulosBE.EstadoId).FirstOrDefault().Nombre;
            perfilmodulosVM.UsuarioRegistro = m_PerfilModulosBE.UsuarioRegistro;
            perfilmodulosVM.FechaRegistro = m_PerfilModulosBE.FechaRegistro;
            perfilmodulosVM.UsuarioModificacionRegistro = m_PerfilModulosBE.UsuarioModificacionRegistro;
            perfilmodulosVM.FechaModificacionRegistro = m_PerfilModulosBE.FechaModificacionRegistro;
            perfilmodulosVM.NroIpRegistro = m_PerfilModulosBE.NroIpRegistro;
            perfilmodulosVM.LstModulosBE = new ModulosBL().Consultar_Lista().Where(x => x.ModuloId == m_PerfilModulosBE.ModuloId).ToList();
            return perfilmodulosVM;
        }
        private PerfilModulosBE ViewModelToBE(PerfilModulosViewModel m_perfilmodulosVM)
        {
            PerfilModulosBE perfilModulosBE = new PerfilModulosBE();

            perfilModulosBE.PerfilModuloId = m_perfilmodulosVM.PerfilModuloId;
            perfilModulosBE.ModuloId = m_perfilmodulosVM.ModuloId;
            perfilModulosBE.PerfilId = m_perfilmodulosVM.PerfilId;
            perfilModulosBE.EstadoId = m_perfilmodulosVM.EstadoId;
            perfilModulosBE.UsuarioRegistro = m_perfilmodulosVM.UsuarioRegistro;
            perfilModulosBE.FechaRegistro = m_perfilmodulosVM.FechaRegistro;
            perfilModulosBE.UsuarioModificacionRegistro = m_perfilmodulosVM.UsuarioModificacionRegistro;
            perfilModulosBE.FechaModificacionRegistro = m_perfilmodulosVM.FechaModificacionRegistro;
            perfilModulosBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            return perfilModulosBE;
        }


        #endregion

    }
}