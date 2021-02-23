using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class UsuarioAutenticacionesBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "UsuarioAutenticaciones";
        [DataMember]
        public int AutenticacionId { get; set; }
        [DataMember]
        public int? UsuarioId { get; set; }
        [DataMember]
        public string CodigoAcceso { get; set; }
        [DataMember]
        public DateTime? FechaHoraCodigo { get; set; }
        [DataMember]
        public bool FlagLogueo { get; set; }
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
        public UsuarioAutenticacionesBE() { }

        public UsuarioAutenticacionesBE(
            int m_AutenticacionId,
            int? m_UsuarioId,
            string m_CodigoAcceso,
            DateTime? m_FechaHoraCodigo,
            bool m_FlagLogueo,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            AutenticacionId = m_AutenticacionId;
            UsuarioId = m_UsuarioId;
            CodigoAcceso = m_CodigoAcceso;
            FechaHoraCodigo = m_FechaHoraCodigo;
            FlagLogueo = m_FlagLogueo;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public UsuarioAutenticacionesBE(IDataReader Registro)
        {
            AutenticacionId = ValidarInt(Registro["AutenticacionId"]);
            UsuarioId = ValidarIntNulos(Registro["UsuarioId"]);
            CodigoAcceso = ValidarString(Registro["CodigoAcceso"]);
            FechaHoraCodigo = ValidarDatetime(Registro["FechaHoraCodigo"]);
            FlagLogueo = ValidarBool(Registro["FlagLogueo"]);
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
