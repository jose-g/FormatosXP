using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class CargosFuncionesX1003BE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "CargosFuncionesX1003";
        [DataMember]
        public int CargosFuncionesX1003Id { get; set; }
        [DataMember]
        public int FichaId { get; set; }
        [DataMember]
        public int UbigeoId { get; set; }
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
        public CargosFuncionesX1003BE() { }

        public CargosFuncionesX1003BE(
            int m_CargosFuncionesX1003Id,
            int m_FichaId,
            int m_UbigeoId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            CargosFuncionesX1003Id = m_CargosFuncionesX1003Id;
            FichaId = m_FichaId;
            UbigeoId = m_UbigeoId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public CargosFuncionesX1003BE(IDataReader Registro)
        {
            CargosFuncionesX1003Id = ValidarInt(Registro["CargosFuncionesX1003Id"]);
            FichaId = ValidarInt(Registro["FichaId"]);
            UbigeoId = ValidarInt(Registro["UbigeoId"]);
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
