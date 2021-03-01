using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class InteresesHabitosViciosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "InteresesHabitosVicios";
        [DataMember]
        public int InteresHabitosId { get; set; }
        [DataMember]
        public string InteresHabitosTipo { get; set; }
        [DataMember]
        public string InteresHabitosNombre { get; set; }
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
        public InteresesHabitosViciosBE() { }

        public InteresesHabitosViciosBE(
            int m_InteresHabitosId,
            string m_InteresHabitosTipo,
            string m_InteresHabitosNombre,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            InteresHabitosId = m_InteresHabitosId;
            InteresHabitosTipo = m_InteresHabitosTipo;
            InteresHabitosNombre = m_InteresHabitosNombre;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public InteresesHabitosViciosBE(IDataReader Registro)
        {
            InteresHabitosId = ValidarInt(Registro["InteresHabitosId"]);
            InteresHabitosTipo = ValidarString(Registro["InteresHabitosTipo"]);
            InteresHabitosNombre = ValidarString(Registro["InteresHabitosNombre"]);
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
