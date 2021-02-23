using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class UbigeoNavalVM
    {
        #region Propiedades

        public string ErrorSMS { get; set; }
        public string InfoSMS { get; set; }

        public int UbigeoNavalId{ get; set; }
        public string EstadoNombre { get; set; }

        [Display(Name = "Zona Naval")]

        public int ZonaNavalId { get; set; }

        public string ZonaNavalDescCorta { get; set; }

        public string ZonaNavalDescLarga { get; set; }

        public int? DependenciaId { get; set; }

        [Display(Name = "Dependencia - Nombre Corto")]
        public string DependenciaDescCorta { get; set; }

        [Display(Name = "Dependencia - Nombre Largo")]
        public string DependenciaDescLarga { get; set; }
        public string UsuarioRegistro { get; set; }
        public string UsuarioModificacionRegistro { get; set; }
        public DateTime? FechaModificacionRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string NroIpRegistro { get; set; }
        public int EstadoId { get; set; }
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

        public List<UbigeoNavalBE> LstUbigeoNavalBE;
        public List<UbigeoNavalVM> LstUbigeoNavalVM;

        #endregion

        public UbigeoNavalVM() {
            LstUbigeoNavalBE = new List<UbigeoNavalBE>();
            LstUbigeoNavalVM = new List<UbigeoNavalVM>();
        }
        public List<UbigeoNavalVM> Listar()
        {
            LstUbigeoNavalBE = new UbigeoNavalBL().Consultar_Lista().ToList();

            foreach (var item in LstUbigeoNavalBE)
                LstUbigeoNavalVM.Add(BEToViewModel(item));

            return LstUbigeoNavalVM.OrderBy(x => x.ZonaNavalDescCorta).ToList();
        }

        public void CargarZonasNavalesxGrupo()
        {
            LstUbigeoNavalBE = ListarxGrupo();
        }

        public UbigeoNavalVM BuscarxIdReturnVM(int documentoIdentidadId)
        {
            UbigeoNavalBE ubigeoBE = new UbigeoNavalBL().Consultar_PK(documentoIdentidadId).FirstOrDefault();
            if (ubigeoBE != null)
                return BEToViewModel(ubigeoBE);

            return null;
        }

        public void BuscarxId(int IdUbigeoNaval)
        {
            if (IdUbigeoNaval < 0) return;

            UbigeoNavalBE ubigeoNavalBE = new UbigeoNavalBL().Consultar_PK(IdUbigeoNaval).FirstOrDefault();

            if (ubigeoNavalBE != null)
                BEToViewModel(ubigeoNavalBE);
        }
        public bool Insertar()
        {
            String out_sms_err = "";
            bool v = false;
            UbigeoNavalBE ubigeoNavalBE = new UbigeoNavalBE();
            ubigeoNavalBE = ViewModelToBE(this);
            v = (new UbigeoNavalBL()).Insertar(ubigeoNavalBE);

            if (v == false) this.ErrorSMS = out_sms_err;

            return v;
        }
        public bool Insertar(string login)
        {
            string out_sms_err = "";
            bool v = false;

            UbigeoNavalBE ubigeoNavalBE = new UbigeoNavalBE();
            this.UsuarioRegistro = login;
            ubigeoNavalBE = ViewModelToBE(this);
            v = (new UbigeoNavalBL()).Insertar(ubigeoNavalBE);

            if (v == false)
                this.ErrorSMS = out_sms_err;

            return v; ;
        }
        public bool Actualizar(string login)
        {
            string sms = "";
            bool v = false;
            UbigeoNavalBE ubigeoNavalBE = new UbigeoNavalBE();
            this.UsuarioModificacionRegistro = login;
            if (this.UbigeoNavalId > 0)
            {
                this.ZonaNavalId = new UbigeoNavalBL().Consultar_Lista().Find(x => x.UbigeoNavalId == this.UbigeoNavalId).ZonaNavalId.Value;
                this.ZonaNavalDescCorta = new UbigeoNavalBL().Consultar_Lista().Find(x => x.UbigeoNavalId == this.UbigeoNavalId).ZonaNavalDescCorta;
                this.ZonaNavalDescLarga = new UbigeoNavalBL().Consultar_Lista().Find(x => x.UbigeoNavalId == this.UbigeoNavalId).ZonaNavalDescLarga;
                this.DependenciaId= new UbigeoNavalBL().Consultar_Lista().Find(x => x.UbigeoNavalId == this.UbigeoNavalId).DependenciaId;
            }

            ubigeoNavalBE = ViewModelToBE(this);

            v = (new UbigeoNavalBL()).Actualizar(ubigeoNavalBE);

            if (v == false)
                this.ErrorSMS = sms;

            return v;
        }
        public bool Actualizar()
        {
            String out_sms_err = "";
            bool v = false;
            UbigeoNavalBE ubigeoNavalBE  = new UbigeoNavalBE();
            ubigeoNavalBE = ViewModelToBE(this);
            v = (new UbigeoNavalBL()).Actualizar(ubigeoNavalBE);

            if (v == false) this.ErrorSMS = out_sms_err;

            return v;
        }
        public bool Eliminar(int documentoIdentidadId, string m_login)
        {
            bool ret = false;
            if (documentoIdentidadId < 0) return false;

            UbigeoNavalBE ubigeoNavalBE = new UbigeoNavalBL().Consultar_PK(documentoIdentidadId).FirstOrDefault();
            ubigeoNavalBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            ubigeoNavalBE.UsuarioModificacionRegistro = m_login;

            if (ubigeoNavalBE != null)
                ret = (new UbigeoNavalBL()).Anular(ubigeoNavalBE);

            if (ret == false)
                this.ErrorSMS = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return ret;
        }
        public bool Eliminar(int UbigeoNavalId)
        {
            bool ret = false;
            if (UbigeoNavalId < 0) return false;
            if (UbigeoNavalId == 1)
            {
                this.ErrorSMS = "No es posible eliminar el registro, es un usuario del sistema, como alternativa inhabilite al usuario.";
                return false;
            }

            UbigeoNavalBE ubigeonavalBE = new UbigeoNavalBL().Consultar_PK(UbigeoNavalId).FirstOrDefault();
            if (ubigeonavalBE != null)
                ret = (new UbigeoNavalBL()).Anular(ubigeonavalBE);

            if (ret == false)
                this.ErrorSMS = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return ret;
        }
        private UbigeoNavalVM BEToViewModel(UbigeoNavalBE m_ubigeoNavalBE)
        {
            UbigeoNavalVM objUbigeoNavalVM = new UbigeoNavalVM();

            objUbigeoNavalVM.UbigeoNavalId = m_ubigeoNavalBE.UbigeoNavalId;
            objUbigeoNavalVM.ZonaNavalId = m_ubigeoNavalBE.ZonaNavalId.Value;
            objUbigeoNavalVM.ZonaNavalDescCorta= m_ubigeoNavalBE.ZonaNavalDescCorta;
            objUbigeoNavalVM.ZonaNavalDescLarga= m_ubigeoNavalBE.ZonaNavalDescLarga;
            objUbigeoNavalVM.DependenciaId = m_ubigeoNavalBE.DependenciaId;
            objUbigeoNavalVM.DependenciaDescCorta = m_ubigeoNavalBE.DependenciaDescCorta;
            objUbigeoNavalVM.DependenciaDescLarga= m_ubigeoNavalBE.DependenciaDescLarga;
            objUbigeoNavalVM.UsuarioRegistro = m_ubigeoNavalBE.UsuarioRegistro;
            objUbigeoNavalVM.UsuarioModificacionRegistro= m_ubigeoNavalBE.UsuarioModificacionRegistro;
            objUbigeoNavalVM.FechaRegistro = m_ubigeoNavalBE.FechaRegistro;
            objUbigeoNavalVM.UsuarioModificacionRegistro = m_ubigeoNavalBE.UsuarioModificacionRegistro;
            objUbigeoNavalVM.FechaModificacionRegistro = m_ubigeoNavalBE.FechaModificacionRegistro;
            objUbigeoNavalVM.NroIpRegistro = m_ubigeoNavalBE.NroIpRegistro;
            objUbigeoNavalVM.EstadoId = m_ubigeoNavalBE.EstadoId.Value;
            objUbigeoNavalVM.EstadoNombre = new EstadosBL().Consultar_PK(m_ubigeoNavalBE.EstadoId.Value).FirstOrDefault().Nombre;




            return objUbigeoNavalVM;
        }
        private UbigeoNavalBE ViewModelToBE(UbigeoNavalVM m_ubigeoNavalVM)
        {
            UbigeoNavalBE objUbigeoNavalBE = new UbigeoNavalBE();
            objUbigeoNavalBE.UbigeoNavalId = m_ubigeoNavalVM.UbigeoNavalId;
            objUbigeoNavalBE.ZonaNavalId = m_ubigeoNavalVM.ZonaNavalId;
            objUbigeoNavalBE.ZonaNavalDescCorta = m_ubigeoNavalVM.ZonaNavalDescCorta;
            objUbigeoNavalBE.ZonaNavalDescLarga = m_ubigeoNavalVM.ZonaNavalDescLarga;
            objUbigeoNavalBE.DependenciaId = m_ubigeoNavalVM.DependenciaId;
            objUbigeoNavalBE.DependenciaDescCorta = m_ubigeoNavalVM.DependenciaDescCorta;
            objUbigeoNavalBE.DependenciaDescLarga = m_ubigeoNavalVM.DependenciaDescLarga;
            objUbigeoNavalBE.UsuarioRegistro = m_ubigeoNavalVM.UsuarioRegistro;
            objUbigeoNavalBE.UsuarioModificacionRegistro = m_ubigeoNavalVM.UsuarioModificacionRegistro;
            objUbigeoNavalBE.FechaRegistro = m_ubigeoNavalVM.FechaRegistro;
            objUbigeoNavalBE.UsuarioModificacionRegistro = m_ubigeoNavalVM.UsuarioModificacionRegistro;
            objUbigeoNavalBE.FechaModificacionRegistro = m_ubigeoNavalVM.FechaModificacionRegistro;
            objUbigeoNavalBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            objUbigeoNavalBE.EstadoId = m_ubigeoNavalVM.EstadoId;



            return objUbigeoNavalBE;
        }
        public List<UbigeoNavalBE> ListarxZonasNavales(Int32 ZonaNavalId)
        {
            return new UbigeoNavalBL().Consultar_Lista().ToList().Where(x => x.ZonaNavalId == ZonaNavalId).OrderBy(x => x.DependenciaDescCorta).ToList();
        }
        public List<UbigeoNavalBE> ListarxGrupo()
        {
            return new UbigeoNavalBL().Consultar_Lista().ToList().DistinctBy(x => x.ZonaNavalId).OrderBy(x => x.ZonaNavalDescCorta).ToList();
        }
        public bool CambiarEstado(int ZonaNavalId, int estadoId, string m_login)
        {
            bool v = false;

            v = (new UbigeoNavalBL()).CambiarEstado(ZonaNavalId, estadoId, m_login);
            return v;
        }

    }
}