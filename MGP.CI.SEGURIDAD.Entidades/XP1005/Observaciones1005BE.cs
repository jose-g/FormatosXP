using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class Observaciones1005BE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Observaciones1005";
        [DataMember]
        public int Observaciones1005Id { get; set; }
        [DataMember]
        public int FichaId { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public int? InformanteId { get; set; }
        [DataMember]
        public byte[] InformanteIdFirma { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
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
        public Observaciones1005BE() { }

        public Observaciones1005BE(
            int m_Observaciones1005Id,
            int m_FichaId,
            byte[] m_Foto,
            int? m_InformanteId,
            byte[] m_InformanteIdFirma,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            Observaciones1005Id = m_Observaciones1005Id;
            FichaId = m_FichaId;
            Foto = m_Foto;
            InformanteId = m_InformanteId;
            InformanteIdFirma = m_InformanteIdFirma;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public Observaciones1005BE(IDataReader Registro)
        {
            Observaciones1005Id = ValidarInt(Registro["Observaciones1005Id"]);
            FichaId = ValidarInt(Registro["FichaId"]);
            Foto = ValidarByte(Registro["Foto"]);
            InformanteId = ValidarIntNulos(Registro["InformanteId"]);
            InformanteIdFirma = ValidarByte(Registro["InformanteIdFirma"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
