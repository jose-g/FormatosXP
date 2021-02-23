using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class FotosDeclarantesBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "FotosDeclarantes";
        [DataMember]
        public int FotoDeclaranteId { get; set; }
        [DataMember]
        public int? DatosPersonalesId { get; set; }
        [DataMember]
        public int FotoTipoId { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
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
        public FotosDeclarantesBE() { }

        public FotosDeclarantesBE(
            int m_FotoDeclaranteId,
            int? m_DatosPersonalesId,
            int m_FotoTipoId,
            int? m_EstadoId,
            byte[] m_Foto,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            FotoDeclaranteId = m_FotoDeclaranteId;
            DatosPersonalesId = m_DatosPersonalesId;
            FotoTipoId = m_FotoTipoId;
            EstadoId = m_EstadoId;
            Foto = m_Foto;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public FotosDeclarantesBE(IDataReader Registro)
        {
            FotoDeclaranteId = ValidarInt(Registro["FotoDeclaranteId"]);
            DatosPersonalesId = ValidarIntNulos(Registro["DatosPersonalesId"]);
            FotoTipoId = ValidarInt(Registro["FotoTipoId"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            Foto = ValidarByte(Registro["Foto"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
