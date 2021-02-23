using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class DeclaranteIdentificacionesBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "DeclaranteIdentificaciones";
        [DataMember]
        public int DeclaranteIdentificacionId { get; set; }
        [DataMember]
        public int? DocumentoIdentidadTipoId { get; set; }
        [DataMember]
        public string DeclaranteNumeroDocumento { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public int? DatosPersonalesId { get; set; }
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
        public DeclaranteIdentificacionesBE() { }

        public DeclaranteIdentificacionesBE(
            int m_DeclaranteIdentificacionId,
            int? m_DocumentoIdentidadTipoId,
            string m_DeclaranteNumeroDocumento,
            int? m_EstadoId,
            int? m_DatosPersonalesId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            DeclaranteIdentificacionId = m_DeclaranteIdentificacionId;
            DocumentoIdentidadTipoId = m_DocumentoIdentidadTipoId;
            DeclaranteNumeroDocumento = m_DeclaranteNumeroDocumento;
            EstadoId = m_EstadoId;
            DatosPersonalesId = m_DatosPersonalesId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public DeclaranteIdentificacionesBE(IDataReader Registro)
        {
            DeclaranteIdentificacionId = ValidarInt(Registro["DeclaranteIdentificacionId"]);
            DocumentoIdentidadTipoId = ValidarIntNulos(Registro["DocumentoIdentidadTipoId"]);
            DeclaranteNumeroDocumento = ValidarString(Registro["DeclaranteNumeroDocumento"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            DatosPersonalesId = ValidarIntNulos(Registro["DatosPersonalesId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
