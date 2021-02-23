using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class CargosFuncionesRealizadasBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "CargosFuncionesRealizadas";
        [DataMember]
        public int CargosFuncionesRealizadas { get; set; }
        [DataMember]
        public int? CargosFuncionesId { get; set; }
        [DataMember]
        public int? InformacionCastrenseId { get; set; }
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
        public CargosFuncionesRealizadasBE() { }

        public CargosFuncionesRealizadasBE(
            int m_CargosFuncionesRealizadas,
            int? m_CargosFuncionesId,
            int? m_InformacionCastrenseId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            CargosFuncionesRealizadas = m_CargosFuncionesRealizadas;
            CargosFuncionesId = m_CargosFuncionesId;
            InformacionCastrenseId = m_InformacionCastrenseId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public CargosFuncionesRealizadasBE(IDataReader Registro)
        {
            CargosFuncionesRealizadas = ValidarInt(Registro["CargosFuncionesRealizadas"]);
            CargosFuncionesId = ValidarIntNulos(Registro["CargosFuncionesId"]);
            InformacionCastrenseId = ValidarIntNulos(Registro["InformacionCastrenseId"]);
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
