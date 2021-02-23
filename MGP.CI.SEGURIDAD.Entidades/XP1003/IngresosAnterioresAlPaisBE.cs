using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class IngresosAnterioresAlPaisBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "IngresosAnterioresAlPais";
        [DataMember]
        public int IngresosAnterioresAlPaisID { get; set; }
        [DataMember]
        public int CargosFuncionesX1003Id { get; set; }
        [DataMember]
        public DateTime? FechaIngreso { get; set; }
        [DataMember]
        public DateTime? FechaSalid { get; set; }
        [DataMember]
        public int? UbigeoId { get; set; }
        [DataMember]
        public string Motivo { get; set; }
        [DataMember]
        public string DondeResidio { get; set; }
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
        public IngresosAnterioresAlPaisBE() { }

        public IngresosAnterioresAlPaisBE(
            int m_IngresosAnterioresAlPaisID,
            int m_CargosFuncionesX1003Id,
            DateTime? m_FechaIngreso,
            DateTime? m_FechaSalid,
            int? m_UbigeoId,
            string m_Motivo,
            string m_DondeResidio,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            IngresosAnterioresAlPaisID = m_IngresosAnterioresAlPaisID;
            CargosFuncionesX1003Id = m_CargosFuncionesX1003Id;
            FechaIngreso = m_FechaIngreso;
            FechaSalid = m_FechaSalid;
            UbigeoId = m_UbigeoId;
            Motivo = m_Motivo;
            DondeResidio = m_DondeResidio;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public IngresosAnterioresAlPaisBE(IDataReader Registro)
        {
            IngresosAnterioresAlPaisID = ValidarInt(Registro["IngresosAnterioresAlPaisID"]);
            CargosFuncionesX1003Id = ValidarInt(Registro["CargosFuncionesX1003Id"]);
            FechaIngreso = ValidarDatetime(Registro["FechaIngreso"]);
            FechaSalid = ValidarDatetime(Registro["FechaSalid"]);
            UbigeoId = ValidarIntNulos(Registro["UbigeoId"]);
            Motivo = ValidarString(Registro["Motivo"]);
            DondeResidio = ValidarString(Registro["DondeResidio"]);
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
