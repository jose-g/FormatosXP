using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class CursosRealizadosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "CursosRealizados";
        [DataMember]
        public int CursosRealizadosId { get; set; }
        [DataMember]
        public int CursoEscuelaExtranjeraId { get; set; }
        [DataMember]
        public int InformacionCastrenseId { get; set; }
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
        public CursosRealizadosBE() { }

        public CursosRealizadosBE(
            int m_CursosRealizadosId,
            int m_CursoEscuelaExtranjeraId,
            int m_InformacionCastrenseId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            CursosRealizadosId = m_CursosRealizadosId;
            CursoEscuelaExtranjeraId = m_CursoEscuelaExtranjeraId;
            InformacionCastrenseId = m_InformacionCastrenseId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public CursosRealizadosBE(IDataReader Registro)
        {
            CursosRealizadosId = ValidarInt(Registro["CursosRealizadosId"]);
            CursoEscuelaExtranjeraId = ValidarInt(Registro["CursoEscuelaExtranjeraId"]);
            InformacionCastrenseId = ValidarInt(Registro["InformacionCastrenseId"]);
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
