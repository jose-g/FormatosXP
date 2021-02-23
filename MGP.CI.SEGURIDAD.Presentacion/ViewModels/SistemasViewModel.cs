using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class SistemasViewModel
    {

        public String ErrorSms { get; set; } = "";

        #region "Propiedades"   

        public int SistemaId { get; set; }

        [Display(Name = "Nombre del Sistema")]
        public string Nombre { get; set; }
        [Display(Name = "Abreviatura")]
        public string Abreviatura { get; set; }
        //[Display(Name = "Tipo de Sistema")]
        //public string Tipo { get; set; }
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        //[Display(Name = "Ruta Servidor")]
        //public string Path { get; set; }
        [Display(Name = "Icono")]
        public string Icon { get; set; }
        [Display(Name = "Estado Id")]
        public int? EstadoId { get; set; }
        [Display(Name = "Estado")]
        public string EstadoNombre{ get; set; }

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

        public List<ModulosBE> LstModulosBE;
        #endregion

        #region "Constructores" 
        public SistemasViewModel() { }
        #endregion

        #region "Operaciones" 

        public List<SistemasViewModel> Listar()
        {
            List<SistemasViewModel> LstSistemasVM = new List<SistemasViewModel>();
            List<SistemasBE> LstSistemasBE = (new SistemasBL()).Consultar_Lista();

            foreach (SistemasBE sistemaBE in LstSistemasBE)
                LstSistemasVM.Add(BEToViewModel(sistemaBE));

            return LstSistemasVM;
        }
        public bool Eliminar(int SistemaId)
        {
            bool v = false;
            if (SistemaId < 0) return false;

            v = (new SistemasBL()).Anular(new SistemasBL().Consultar_PK(SistemaId).FirstOrDefault());

            if (v == false) this.ErrorSms = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return v;
        }
        private SistemasViewModel BEToViewModel(SistemasBE m_sistemaBE)
        {
            SistemasViewModel sistemasVM = new SistemasViewModel();

            sistemasVM.SistemaId = m_sistemaBE.SistemaId;
            sistemasVM.Nombre = m_sistemaBE.Nombre;
            sistemasVM.Abreviatura = m_sistemaBE.Abreviatura;
            sistemasVM.Descripcion = m_sistemaBE.Descripcion;
            sistemasVM.Icon = m_sistemaBE.Icon;
            sistemasVM.EstadoId = m_sistemaBE.EstadoId;
            sistemasVM.EstadoNombre = new EstadosBL().Consultar_Lista().Where(x => x.EstadoId == m_sistemaBE.EstadoId).FirstOrDefault().Nombre;
            sistemasVM.UsuarioRegistro = m_sistemaBE.UsuarioRegistro;
            sistemasVM.FechaRegistro = m_sistemaBE.FechaRegistro;
            sistemasVM.UsuarioModificacionRegistro = m_sistemaBE.UsuarioModificacionRegistro;
            sistemasVM.FechaModificacionRegistro = m_sistemaBE.FechaModificacionRegistro;
            sistemasVM.NroIpRegistro = m_sistemaBE.NroIpRegistro;
            sistemasVM.LstModulosBE = new ModulosBL().Consultar_Lista().Where(x => x.SistemaId == m_sistemaBE.SistemaId).ToList();
            return sistemasVM;
        }
        private SistemasBE ViewModelToBE(SistemasViewModel m_sistemasVM)
        {
            SistemasBE sistemasBE = new SistemasBE();

            sistemasBE.SistemaId = m_sistemasVM.SistemaId;
            sistemasBE.Nombre = m_sistemasVM.Nombre;
            sistemasBE.Abreviatura = m_sistemasVM.Abreviatura;
            sistemasBE.Descripcion = m_sistemasVM.Descripcion;
            sistemasBE.Icon = m_sistemasVM.Icon;
            sistemasBE.EstadoId = m_sistemasVM.EstadoId;
            sistemasBE.UsuarioRegistro = m_sistemasVM.UsuarioRegistro;
            sistemasBE.FechaRegistro = m_sistemasVM.FechaRegistro;
            sistemasBE.UsuarioModificacionRegistro = m_sistemasVM.UsuarioModificacionRegistro;
            sistemasBE.FechaModificacionRegistro = m_sistemasVM.FechaModificacionRegistro;
            sistemasBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            return sistemasBE;
        }
        public void BuscarPorId(int id)
        {
            if (id < 0) return;

            SistemasBE sistemasBE = new SistemasBL().Consultar_PK(id).FirstOrDefault();

            if (sistemasBE != null)
                BEToViewModel(sistemasBE);
        }
        public bool Actualizar()
        {
            String out_sms_err = "";
            bool v = false;
            SistemasBE sistemasBE = new SistemasBE();
            sistemasBE  = ViewModelToBE(this);
            v = (new SistemasBL()).Actualizar(sistemasBE, ref out_sms_err);

            if (v == false) this.ErrorSms = out_sms_err;

            return v;
        }
        public bool Insertar()
        {
            String out_sms_err = "";
            bool v = false;
            SistemasBE sistemasBE = new SistemasBE();
            sistemasBE = ViewModelToBE(this);
            v = (new SistemasBL()).Insertar(sistemasBE, ref out_sms_err);

            if (v == false) this.ErrorSms = out_sms_err;

            return v;
        }
        #endregion
    }
}