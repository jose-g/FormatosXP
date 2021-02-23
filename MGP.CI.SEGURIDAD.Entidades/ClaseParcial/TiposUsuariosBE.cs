using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class TiposUsuariosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "TiposUsuarios";
        [DataMember]
        public int TipoUsuarioId { get; set; }
        [DataMember]
        public string DescCorta { get; set; }
        [DataMember]
        public string DescLarga { get; set; }
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
        public TiposUsuariosBE() { }

        public TiposUsuariosBE(
            int m_TipoUsuarioId,
            string m_DescCorta,
            string m_DescLarga,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            TipoUsuarioId = m_TipoUsuarioId;
            DescCorta = m_DescCorta;
            DescLarga = m_DescLarga;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public TiposUsuariosBE(IDataReader Registro)
        {
            TipoUsuarioId = ValidarInt(Registro["TipoUsuarioId"]);
            DescCorta = ValidarString(Registro["DescCorta"]);
            DescLarga = ValidarString(Registro["DescLarga"]);
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
