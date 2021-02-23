using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class DocumentoIdentidadTiposBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "DocumentoIdentidadTipos";
        [DataMember]
        public int DocumentoIdentidadTipoId { get; set; }
        [DataMember]
        public int? CodigoDocumento { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int EstadoId { get; set; }
        [DataMember]
        public string UsuarioRegistro { get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        [DataMember]
        public string UsuarioModificacionRegistro { get; set; }
        [DataMember]
        public DateTime? FechaModificacionRegistro { get; set; }
        [DataMember]
        public string NroIpRegistro { get; set; }

        #endregion

        #region Constructores
        public DocumentoIdentidadTiposBE() { }

        public DocumentoIdentidadTiposBE(
            int m_DocumentoIdentidadId,
            int? m_CodigoDocumento,
            string m_Descripcion,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_IdFuncionRegistro,
            string m_NroIpRegistro,
            string m_NroMacRegistro,
            string m_NroDniRegistro,
            int m_EstadoId
        )
        {
            DocumentoIdentidadTipoId = m_DocumentoIdentidadId;
            CodigoDocumento = m_CodigoDocumento;
            Descripcion = m_Descripcion;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
            EstadoId=m_EstadoId;
    }

        public DocumentoIdentidadTiposBE(IDataReader Registro)
        {
            DocumentoIdentidadTipoId = ValidarInt(Registro["DocumentoIdentidadTipoId"]);
            CodigoDocumento = ValidarIntNulos(Registro["CodigoDocumento"]);
            Descripcion = ValidarString(Registro["Descripcion"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
            EstadoId = ValidarInt(Registro["EstadoId"]);
        }
        #endregion

    }
}
