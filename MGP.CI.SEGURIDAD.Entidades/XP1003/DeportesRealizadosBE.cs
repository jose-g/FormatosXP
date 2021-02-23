using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class DeportesRealizadosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "DeportesRealizados";
        [DataMember]
        public int DeporteRealizadoId { get; set; }
        [DataMember]
        public int OtrosId { get; set; }
        [DataMember]
        public int DeportesId { get; set; }
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
        public DeportesRealizadosBE() { }

        public DeportesRealizadosBE(
            int m_DeportRealizadoId,
            int m_OtrosId,
            int m_DeporteId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            DeporteRealizadoId = m_DeportRealizadoId;
            OtrosId = m_OtrosId;
            DeportesId = m_DeporteId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public DeportesRealizadosBE(IDataReader Registro)
        {
            DeporteRealizadoId = ValidarInt(Registro["DeporteRealizadoId"]);
            OtrosId = ValidarInt(Registro["OtrosId"]);
            DeportesId = ValidarInt(Registro["DeporteId"]);
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
