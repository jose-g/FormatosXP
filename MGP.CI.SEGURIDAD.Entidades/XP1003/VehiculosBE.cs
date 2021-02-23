using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class VehiculosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Vehiculos";
        [DataMember]
        public int VehiculoId { get; set; }
        [DataMember]
        public int VehiculoTipoId { get; set; }
        [DataMember]
        public int AutoModeloId { get; set; }
        [DataMember]
        public int CargosFuncionesX1003Id { get; set; }
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
        public VehiculosBE() { }

        public VehiculosBE(
            int m_VehiculoId,
            int m_VehiculoTipoId,
            int m_AutoModeloId,
            int m_CargosFuncionesX1003Id,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            VehiculoId = m_VehiculoId;
            VehiculoTipoId = m_VehiculoTipoId;
            AutoModeloId = m_AutoModeloId;
            CargosFuncionesX1003Id = m_CargosFuncionesX1003Id;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public VehiculosBE(IDataReader Registro)
        {
            VehiculoId = ValidarInt(Registro["VehiculoId"]);
            VehiculoTipoId = ValidarInt(Registro["VehiculoTipoId"]);
            AutoModeloId = ValidarInt(Registro["AutoModeloId"]);
            CargosFuncionesX1003Id = ValidarInt(Registro["CargosFuncionesX1003Id"]);
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
