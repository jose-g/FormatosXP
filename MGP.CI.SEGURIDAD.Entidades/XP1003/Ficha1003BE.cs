using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class Ficha1003BE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Ficha1003";
        [DataMember]
        public int Ficha1003Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int DeclaranteFichaId { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public int EstadoFicha { get; set; }
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
        public Ficha1003BE() { }

        public Ficha1003BE(
            int m_Ficha1003Id,
            string m_Nombre,
            int m_DeclaranteFichaId,
            int? m_EstadoId,
            int m_EstadoFicha,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            Ficha1003Id = m_Ficha1003Id;
            Nombre = m_Nombre;
            DeclaranteFichaId = m_DeclaranteFichaId;
            EstadoId = m_EstadoId;
            EstadoFicha = m_EstadoFicha;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public Ficha1003BE(IDataReader Registro)
        {
            Ficha1003Id = ValidarInt(Registro["Ficha1003Id"]);
            Nombre = ValidarString(Registro["Nombre"]);
            DeclaranteFichaId = ValidarInt(Registro["DeclaranteFichaId"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            EstadoFicha = ValidarInt(Registro["EstadoFicha"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
