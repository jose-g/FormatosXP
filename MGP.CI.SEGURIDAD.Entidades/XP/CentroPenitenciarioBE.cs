using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class CentroPenitenciarioBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "CentroPenitenciario";
        [DataMember]
        public int CentroPenitenciarioId { get; set; }
        [DataMember]
        public string RegionId { get; set; }
        [DataMember]
        public string RegionNombre { get; set; }
        [DataMember]
        public int? PenalId { get; set; }
        [DataMember]
        public string PenalNombre { get; set; }
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
        public CentroPenitenciarioBE() { }

        public CentroPenitenciarioBE(
            int m_CentroPenitenciarioId,
            string m_RegionId,
            string m_RegionNombre,
            int? m_PenalId,
            string m_PenalNombre,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            CentroPenitenciarioId = m_CentroPenitenciarioId;
            RegionId = m_RegionId;
            RegionNombre = m_RegionNombre;
            PenalId = m_PenalId;
            PenalNombre = m_PenalNombre;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public CentroPenitenciarioBE(IDataReader Registro)
        {
            CentroPenitenciarioId = ValidarInt(Registro["CentroPenitenciarioId"]);
            RegionId = ValidarString(Registro["RegionId"]);
            RegionNombre = ValidarString(Registro["RegionNombre"]);
            PenalId = ValidarIntNulos(Registro["PenalId"]);
            PenalNombre = ValidarString(Registro["PenalNombre"]);
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
