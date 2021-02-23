using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class EnfermedadesBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Enfermedades";
        [DataMember]
        public int EnfermedadesId { get; set; }
        [DataMember]
        public string EnfermedadTipo { get; set; }
        [DataMember]
        public string Enfermedad { get; set; }
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
        public EnfermedadesBE() { }

        public EnfermedadesBE(
            int m_EnfermedadesId,
            string m_EnfermedadTipo,
            string m_Enfermedad,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            EnfermedadesId = m_EnfermedadesId;
            EnfermedadTipo = m_EnfermedadTipo;
            Enfermedad = m_Enfermedad;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public EnfermedadesBE(IDataReader Registro)
        {
            EnfermedadesId = ValidarInt(Registro["EnfermedadesId"]);
            EnfermedadTipo = ValidarString(Registro["EnfermedadTipo"]);
            Enfermedad = ValidarString(Registro["Enfermedad"]);
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
