using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MGP.CI.SEGURIDAD.Presentacion.ViewModels
{
    public class DocumentoIdentidadTiposViewModel : TablaBaseVM
    {
        #region PropiedadesBE
        public List<DocumentoIdentidadTiposViewModel> LstTipoDocumentos { get; set; }
        #endregion

        public DocumentoIdentidadTiposViewModel()
        {
            LstTipoDocumentos = new List<DocumentoIdentidadTiposViewModel>();
        }

        #region "TipoDocumentos"        
        public void CargarTiposDocumentos()
        {
            List<DocumentoIdentidadTiposBE> LstDocumentoIdentidadTiposBE = (new DocumentoIdentidadTiposBL()).Consultar_Lista();

            foreach (DocumentoIdentidadTiposBE DocumentoIdentidadTiposBE in LstDocumentoIdentidadTiposBE)
                LstTipoDocumentos.Add(BEToViewModel(DocumentoIdentidadTiposBE));
        }
        private DocumentoIdentidadTiposViewModel BEToViewModel(DocumentoIdentidadTiposBE m_tipodocumentoBE)
        {
            DocumentoIdentidadTiposViewModel documentoVM  = new DocumentoIdentidadTiposViewModel();

            documentoVM.Id = m_tipodocumentoBE.DocumentoIdentidadTipoId;
            documentoVM.Codigo = m_tipodocumentoBE.CodigoDocumento;
            documentoVM.Descripcion = m_tipodocumentoBE.Descripcion;
            documentoVM.EstadoId= m_tipodocumentoBE.EstadoId;
            documentoVM.UsuarioRegistro = m_tipodocumentoBE.UsuarioRegistro;
            documentoVM.FechaRegistro = m_tipodocumentoBE.FechaRegistro;
            documentoVM.UsuarioModificacionRegistro = m_tipodocumentoBE.UsuarioModificacionRegistro;
            documentoVM.FechaModificacionRegistro = m_tipodocumentoBE.FechaModificacionRegistro;
            documentoVM.NroIpRegistro = m_tipodocumentoBE.NroIpRegistro;
            documentoVM.EstadoNombre = new EstadosBL().Consultar_PK(m_tipodocumentoBE.EstadoId).FirstOrDefault().Nombre;

            return documentoVM;
        }
        private DocumentoIdentidadTiposBE ViewModelToBE(DocumentoIdentidadTiposViewModel documentoVM)
        {
            DocumentoIdentidadTiposBE m_tipodocumentoBE = new DocumentoIdentidadTiposBE();

            m_tipodocumentoBE.DocumentoIdentidadTipoId = documentoVM.Id.Value;
            m_tipodocumentoBE.CodigoDocumento = documentoVM.Codigo;
            m_tipodocumentoBE.Descripcion = documentoVM.Descripcion;
            m_tipodocumentoBE.EstadoId = documentoVM.EstadoId.Value;
            m_tipodocumentoBE.UsuarioRegistro = documentoVM.UsuarioRegistro;
            m_tipodocumentoBE.FechaRegistro = documentoVM.FechaRegistro;
            m_tipodocumentoBE.UsuarioModificacionRegistro = documentoVM.UsuarioModificacionRegistro;
            m_tipodocumentoBE.FechaModificacionRegistro = documentoVM.FechaModificacionRegistro;
            m_tipodocumentoBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;

            return m_tipodocumentoBE;
        }
        public List<DocumentoIdentidadTiposViewModel> ListarRegistrosFiltrados(DocumentoIdentidadTiposViewModel m_tipodocumentoVM)
        {
            List<DocumentoIdentidadTiposViewModel> LstTipodocumentoVM = new List<DocumentoIdentidadTiposViewModel>();

            List<DocumentoIdentidadTiposBE> LstDocumentoIdentidadTiposBE = (new DocumentoIdentidadTiposBL()).ListarRegistrosFiltrados(ViewModelToBE(m_tipodocumentoVM));
            foreach (DocumentoIdentidadTiposBE documentoIdentidadTiposBE in LstDocumentoIdentidadTiposBE)
            {
                LstTipodocumentoVM.Add(BEToViewModel(documentoIdentidadTiposBE));
            }

            return LstTipodocumentoVM;
        }
        public bool Anular(int documentoIdentidadId, string m_login)
        {
            bool ret = false;
            if (documentoIdentidadId < 0) return false;

            DocumentoIdentidadTiposBE TipoDocumentoBE = new DocumentoIdentidadTiposBL().Consultar_PK(documentoIdentidadId).FirstOrDefault();
            TipoDocumentoBE.NroIpRegistro = HttpContext.Current.Request.UserHostAddress;
            TipoDocumentoBE.UsuarioModificacionRegistro = m_login;

            if (TipoDocumentoBE != null)
                ret = (new DocumentoIdentidadTiposBL()).Anular(TipoDocumentoBE);

            if (ret == false)
                this.ErrorSMS = "No se pudo eliminar el registro, posiblemente ya ha sido referenciado.";

            return ret;
        }
        public bool CambiarEstado(int documentoIdentidadId, int estadoId, string m_login)
        {
            bool v = false;

            v = (new DocumentoIdentidadTiposBL()).CambiarEstado(documentoIdentidadId, estadoId, m_login);
            return v;
        }
        public bool Actualizar(string login)
        {
            string sms = "";
            bool v = false;
            DocumentoIdentidadTiposBE tipodocumentoBE = new DocumentoIdentidadTiposBE();
            this.UsuarioModificacionRegistro = login;
            tipodocumentoBE = ViewModelToBE(this);
            v = (new DocumentoIdentidadTiposBL()).Actualizar(tipodocumentoBE);

            if (v == false)
                this.ErrorSMS = sms;

            return v;
        }
        public bool Insertar(string login)
        {
            string out_sms_err = "";
            bool v = false ;

            DocumentoIdentidadTiposBE tipodocumentoBE = new DocumentoIdentidadTiposBE();
            this.UsuarioRegistro = login;
            this.Codigo = GetMaxId() + 1;
            tipodocumentoBE = ViewModelToBE(this);
            v = (new DocumentoIdentidadTiposBL()).Insertar(tipodocumentoBE);

            if (v == false)
                this.ErrorSMS = out_sms_err;

            return v; ;
        }
        public int GetMaxId()
        {
            return (new DocumentoIdentidadTiposBL()).GetMaxId();
        }
        public DocumentoIdentidadTiposViewModel BuscarxId(int documentoIdentidadId)
        {
            DocumentoIdentidadTiposBE documentoIdentidadTiposBE = new DocumentoIdentidadTiposBL().Consultar_PK(documentoIdentidadId).FirstOrDefault();

            if (documentoIdentidadTiposBE != null)
                return BEToViewModel(documentoIdentidadTiposBE);

            return null;
        }
        #endregion


    }
}