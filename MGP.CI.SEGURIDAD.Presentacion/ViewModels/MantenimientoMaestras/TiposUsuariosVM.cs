using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;


namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class TiposUsuariosVM : TablaBaseVM
    {

        #region PropiedadesBE
        public string DescCorta { get; set; }

        public string DescLarga { get; set; }

        public List<TiposUsuariosVM> LstTipoUsuarios{ get; set; }
        #endregion

        public TiposUsuariosVM()
        {
            LstTipoUsuarios = new List<TiposUsuariosVM>();
        }

        #region "TipoDocumentos"        
        public List<TiposUsuariosVM> CargarTiposUsuarios()
        {
            List<TiposUsuariosBE> LstTipoUsuariosBE = (new TiposUsuariosBL()).Consultar_Lista();

            foreach (TiposUsuariosBE tipousuarioBE in LstTipoUsuariosBE)
                LstTipoUsuarios.Add(BEToViewModel(tipousuarioBE));

            return LstTipoUsuarios;
        }
        private TiposUsuariosVM BEToViewModel(TiposUsuariosBE m_tipousuarioBE)
        {
            TiposUsuariosVM tipoUsuarioVM = new TiposUsuariosVM();

            tipoUsuarioVM.Id = m_tipousuarioBE.TipoUsuarioId;
            tipoUsuarioVM.DescCorta = m_tipousuarioBE.DescCorta;
            tipoUsuarioVM.DescLarga = m_tipousuarioBE.DescLarga;
            tipoUsuarioVM.EstadoId = m_tipousuarioBE.EstadoId;
            tipoUsuarioVM.UsuarioRegistro = m_tipousuarioBE.UsuarioRegistro;
            tipoUsuarioVM.FechaRegistro = m_tipousuarioBE.FechaRegistro;
            tipoUsuarioVM.UsuarioModificacionRegistro = m_tipousuarioBE.UsuarioModificacionRegistro;
            tipoUsuarioVM.FechaModificacionRegistro = m_tipousuarioBE.FechaModificacionRegistro;
            tipoUsuarioVM.NroIpRegistro = m_tipousuarioBE.NroIpRegistro;
            tipoUsuarioVM.EstadoNombre = new EstadosBL().Consultar_PK(m_tipousuarioBE.EstadoId.Value).FirstOrDefault().Nombre;

            return tipoUsuarioVM;
        }
        private TiposUsuariosBE ViewModelToBE(TiposUsuariosVM tipoUsuarioVM)
        {
            TiposUsuariosBE tipoUsuarioBE = new TiposUsuariosBE();

            tipoUsuarioBE.TipoUsuarioId = tipoUsuarioVM.Codigo.Value;
            tipoUsuarioBE.DescCorta = tipoUsuarioVM.DescCorta;
            tipoUsuarioBE.DescLarga = tipoUsuarioVM.DescLarga;
            tipoUsuarioBE.EstadoId = tipoUsuarioVM.EstadoId;
            tipoUsuarioBE.UsuarioRegistro = tipoUsuarioVM.UsuarioRegistro;
            tipoUsuarioBE.FechaRegistro = tipoUsuarioVM.FechaRegistro;
            tipoUsuarioBE.UsuarioModificacionRegistro = tipoUsuarioVM.UsuarioModificacionRegistro;
            tipoUsuarioBE.FechaModificacionRegistro = tipoUsuarioVM.FechaModificacionRegistro;
            tipoUsuarioBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            return tipoUsuarioBE;
        }
        public List<TiposUsuariosVM> ListarRegistrosFiltrados(TiposUsuariosVM m_tipousuarioVM)
        {
            List<TiposUsuariosVM> LstTipoUsuarioVM = new List<TiposUsuariosVM>();

            List<TiposUsuariosBE> LstDocumentoIdentidadTiposBE = (new TiposUsuariosBL()).ListarRegistrosFiltrados(ViewModelToBE(m_tipousuarioVM));
            foreach (TiposUsuariosBE tipoUsuarioBE in LstDocumentoIdentidadTiposBE)
                LstTipoUsuarioVM.Add(BEToViewModel(tipoUsuarioBE));

            return LstTipoUsuarioVM;
        }
        public bool Anular(int tipoUsuarioId, string m_login)
        {
            bool ret = false;
            if (tipoUsuarioId < 0) return false;

            TiposUsuariosBE TipoUsuarioBE = new TiposUsuariosBL().Consultar_PK(tipoUsuarioId).FirstOrDefault();
            TipoUsuarioBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            TipoUsuarioBE.UsuarioModificacionRegistro = m_login;

            if (TipoUsuarioBE != null)
                ret = (new TiposUsuariosBL()).Anular(TipoUsuarioBE);

            if (ret == false)
                this.ErrorSMS = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return ret;
        }
        public bool CambiarEstado(int tipoUsuarioId, int estadoId, string m_login)
        {
            bool v = false;

            v = (new TiposUsuariosBL()).CambiarEstado(tipoUsuarioId, estadoId, m_login);
            return v;
        }
        public bool Actualizar(string login)
        {
            string sms = "";
            bool v = false;
            TiposUsuariosBE tipousuarioBE = new TiposUsuariosBE();
            this.UsuarioModificacionRegistro = login;
            this.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            tipousuarioBE = ViewModelToBE(this);
            v = (new TiposUsuariosBL()).Actualizar(tipousuarioBE);

            if (v == false)
                this.ErrorSMS = sms;

            return v;
        }
        public bool Insertar(string login)
        {
            string out_sms_err = "";
            bool v = false;

            TiposUsuariosBE tipousuarioBE = new TiposUsuariosBE();
            this.UsuarioRegistro = login;
            this.Codigo = GetMaxId() + 1;
            tipousuarioBE = ViewModelToBE(this);
            v = (new TiposUsuariosBL()).Insertar(tipousuarioBE);

            if (v == false)
                this.ErrorSMS = out_sms_err;

            return v; ;
        }
        public int GetMaxId()
        {
            return (new TiposUsuariosBL()).GetMaxId();
        }
        public TiposUsuariosVM BuscarxId(int documentoIdentidadId)
        {
            TiposUsuariosBE tipoUsuarioBE = new TiposUsuariosBL().Consultar_PK(documentoIdentidadId).FirstOrDefault();

            if (tipoUsuarioBE != null)
                return BEToViewModel(tipoUsuarioBE);

            return null;
        }


        #endregion

    }
}