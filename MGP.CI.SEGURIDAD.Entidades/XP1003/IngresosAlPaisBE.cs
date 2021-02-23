using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class IngresosAlPaisBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "IngresosAlPais";
        [DataMember]
        public int IngresoPaisId { get; set; }
        [DataMember]
        public DateTime? FechaIngreso { get; set; }
        [DataMember]
        public DateTime? FechaInicioMision { get; set; }
        [DataMember]
        public DateTime? FechaTerminoMision { get; set; }
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
        public IngresosAlPaisBE() { }

        public IngresosAlPaisBE(
            int m_IngresoPaisId,
            DateTime? m_FechaIngreso,
            DateTime? m_FechaInicioMision,
            DateTime? m_FechaTerminoMision,
            int m_CargosFuncionesX1003Id,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            IngresoPaisId = m_IngresoPaisId;
            FechaIngreso = m_FechaIngreso;
            FechaInicioMision = m_FechaInicioMision;
            FechaTerminoMision = m_FechaTerminoMision;
            CargosFuncionesX1003Id = m_CargosFuncionesX1003Id;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public IngresosAlPaisBE(IDataReader Registro)
        {
            IngresoPaisId = ValidarInt(Registro["IngresoPaisId"]);
            FechaIngreso = ValidarDatetime(Registro["FechaIngreso"]);
            FechaInicioMision = ValidarDatetime(Registro["FechaInicioMision"]);
            FechaTerminoMision = ValidarDatetime(Registro["FechaTerminoMision"]);
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
