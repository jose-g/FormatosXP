using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class EstadosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Estados";
        [DataMember]
        public int EstadoId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int FlagEliminado { get; set; }
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
        public EstadosBE() { }

        public EstadosBE(
            int m_EstadoId,
            string m_Nombre,
            string m_Descripcion,
            int m_FlagEliminado,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            EstadoId = m_EstadoId;
            Nombre = m_Nombre;
            Descripcion = m_Descripcion;
            FlagEliminado = m_FlagEliminado;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public EstadosBE(IDataReader Registro)
        {
            EstadoId = ValidarInt(Registro["EstadoId"]);
            Nombre = ValidarString(Registro["Nombre"]);
            Descripcion = ValidarString(Registro["Descripcion"]);
            FlagEliminado = ValidarInt(Registro["FlagEliminado"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
