using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class FotosFamiliaresBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "FotosFamiliares";
        [DataMember]
        public int FotoFamiliaresId { get; set; }
        [DataMember]
        public int? FamiliarId { get; set; }
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
        public FotosFamiliaresBE() { }

        public FotosFamiliaresBE(
            int m_FotoFamiliaresId,
            int? m_FamiliarId,
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
            FotoFamiliaresId = m_FotoFamiliaresId;
            FamiliarId = m_FamiliarId;
            FotoTipoId = m_FotoTipoId;
            EstadoId = m_EstadoId;
            Foto = m_Foto;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public FotosFamiliaresBE(IDataReader Registro)
        {
            FotoFamiliaresId = ValidarInt(Registro["FotoFamiliaresId"]);
            FamiliarId = ValidarIntNulos(Registro["FamiliarId"]);
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
