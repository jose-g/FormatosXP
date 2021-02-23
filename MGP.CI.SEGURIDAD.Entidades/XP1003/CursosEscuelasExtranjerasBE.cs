using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class CursosEscuelasExtranjerasBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "CursosEscuelasExtranjeras";
        [DataMember]
        public int CursoEscuelaExtranjeraId { get; set; }
        [DataMember]
        public int EscuelaExtranjeraId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
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
        public CursosEscuelasExtranjerasBE() { }

        public CursosEscuelasExtranjerasBE(
            int m_CursoEscuelaExtranjeraId,
            int m_EscuelaExtranjeraId,
            string m_Nombre,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            CursoEscuelaExtranjeraId = m_CursoEscuelaExtranjeraId;
            EscuelaExtranjeraId = m_EscuelaExtranjeraId;
            Nombre = m_Nombre;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public CursosEscuelasExtranjerasBE(IDataReader Registro)
        {
            CursoEscuelaExtranjeraId = ValidarInt(Registro["CursoEscuelaExtranjeraId"]);
            EscuelaExtranjeraId = ValidarInt(Registro["EscuelaExtranjeraId"]);
            Nombre = ValidarString(Registro["Nombre"]);
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
