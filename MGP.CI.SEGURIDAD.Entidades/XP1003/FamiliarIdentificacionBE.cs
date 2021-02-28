using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class FamiliarIdentificacionBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "FamiliarIdentificacion";
        [DataMember]
        public int FamiliarIdentificacionId { get; set; }
        [DataMember]
        public int? DocumentoIdentidadTipoId { get; set; }
        [DataMember]
        public string FamiliarNumeroDocumento { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public int? FamiliarId { get; set; }
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
        public FamiliarIdentificacionBE() { }

        public FamiliarIdentificacionBE(
            int m_FamiliarIdentificacionId,
            int? m_DocumentoIdentidadTipoId,
            string m_FamiliarNumeroDocumento,
            int? m_EstadoId,
            int? m_FamiliarId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            FamiliarIdentificacionId = m_FamiliarIdentificacionId;
            DocumentoIdentidadTipoId = m_DocumentoIdentidadTipoId;
            FamiliarNumeroDocumento = m_FamiliarNumeroDocumento;
            EstadoId = m_EstadoId;
            FamiliarId = m_FamiliarId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public FamiliarIdentificacionBE(IDataReader Registro)
        {
            FamiliarIdentificacionId = ValidarInt(Registro["FamiliarIdentificacionId"]);
            DocumentoIdentidadTipoId = ValidarIntNulos(Registro["DocumentoIdentidadTipoId"]);
            FamiliarNumeroDocumento = ValidarString(Registro["FamiliarNumeroDocumento"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            FamiliarId = ValidarIntNulos(Registro["FamiliarId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
