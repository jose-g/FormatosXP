using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class Observaciones1005DetallesBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Observaciones1005Detalles";
        [DataMember]
        public int Observaciones1005DetallesId { get; set; }
        [DataMember]
        public int Observaciones1005Id { get; set; }
        [DataMember]
        public int Observaciones1005TipoId { get; set; }
        [DataMember]
        public string Hechos { get; set; }
        [DataMember]
        public string Observaciones { get; set; }
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
        public Observaciones1005DetallesBE() { }

        public Observaciones1005DetallesBE(
            int m_Observaciones1005DetallesId,
            int m_Observaciones1005Id,
            int m_Observaciones1005TipoId,
            string m_Hechos,
            string m_Observaciones,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            Observaciones1005DetallesId = m_Observaciones1005DetallesId;
            Observaciones1005Id = m_Observaciones1005Id;
            Observaciones1005TipoId = m_Observaciones1005TipoId;
            Hechos = m_Hechos;
            Observaciones = m_Observaciones;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public Observaciones1005DetallesBE(IDataReader Registro)
        {
            Observaciones1005DetallesId = ValidarInt(Registro["Observaciones1005DetallesId"]);
            Observaciones1005Id = ValidarInt(Registro["Observaciones1005Id"]);
            Observaciones1005TipoId = ValidarInt(Registro["Observaciones1005TipoId"]);
            Hechos = ValidarString(Registro["Hechos"]);
            Observaciones = ValidarString(Registro["Observaciones"]);
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
