using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class PsicologicoInteresesHabitosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "PsicologicoInteresesHabitos";
        [DataMember]
        public int PsicologicoInteresesHabitosId { get; set; }
        [DataMember]
        public int PerfilPsicologicoDetallesId { get; set; }
        [DataMember]
        public int NivelesMadurez1005Id { get; set; }
        [DataMember]
        public int InteresHabitosId { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
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
        public PsicologicoInteresesHabitosBE() { }

        public PsicologicoInteresesHabitosBE(
            int m_PsicologicoInteresesHabitosId,
            int m_PerfilPsicologicoDetallesId,
            int m_NivelesMadurez1005Id,
            int m_InteresHabitosId,
            string m_Descripcion,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            PsicologicoInteresesHabitosId = m_PsicologicoInteresesHabitosId;
            PerfilPsicologicoDetallesId = m_PerfilPsicologicoDetallesId;
            NivelesMadurez1005Id = m_NivelesMadurez1005Id;
            InteresHabitosId = m_InteresHabitosId;
            Descripcion = m_Descripcion;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public PsicologicoInteresesHabitosBE(IDataReader Registro)
        {
            PsicologicoInteresesHabitosId = ValidarInt(Registro["PsicologicoInteresesHabitosId"]);
            PerfilPsicologicoDetallesId = ValidarInt(Registro["PerfilPsicologicoDetallesId"]);
            NivelesMadurez1005Id = ValidarInt(Registro["NivelesMadurez1005Id"]);
            InteresHabitosId = ValidarInt(Registro["InteresHabitosId"]);
            Descripcion = ValidarString(Registro["Descripcion"]);
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
