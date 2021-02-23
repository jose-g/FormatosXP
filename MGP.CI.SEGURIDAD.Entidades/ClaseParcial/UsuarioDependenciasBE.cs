using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class UsuarioDependenciasBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "UsuarioDependencias";
        [DataMember]
        public int UsuarioDependenciaId { get; set; }
        [DataMember]
        public int? UsuarioId { get; set; }
        [DataMember]
        public short? DependenciaTipo { get; set; }
        [DataMember]
        public int? ZonaNavalId { get; set; }
        [DataMember]
        public int? DependenciaId { get; set; }
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
        public UsuarioDependenciasBE() { }

        public UsuarioDependenciasBE(
            int m_UsuarioDependenciaId,
            int? m_UsuarioId,
            short? m_DependenciaTipo,
            int? m_ZonaNavalId,
            int? m_DependenciaId,
            int m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            UsuarioDependenciaId = m_UsuarioDependenciaId;
            UsuarioId = m_UsuarioId;
            DependenciaTipo = m_DependenciaTipo;
            ZonaNavalId = m_ZonaNavalId;
            DependenciaId = m_DependenciaId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public UsuarioDependenciasBE(IDataReader Registro)
        {
            UsuarioDependenciaId = ValidarInt(Registro["UsuarioDependenciaId"]);
            UsuarioId = ValidarIntNulos(Registro["UsuarioId"]);
            DependenciaTipo = ValidarShortNulos(Registro["DependenciaTipo"]);
            ZonaNavalId = ValidarIntNulos(Registro["ZonaNavalId"]);
            DependenciaId = ValidarIntNulos(Registro["DependenciaId"]);
            EstadoId = ValidarInt(Registro["EstadoId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
