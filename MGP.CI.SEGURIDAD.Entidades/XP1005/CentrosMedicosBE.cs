using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class CentrosMedicosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "CentrosMedicos";
        [DataMember]
        public int CentrosMedicosId { get; set; }
        [DataMember]
        public string SectorCentroMedico { get; set; }
        [DataMember]
        public string NombreCentroMedico { get; set; }
        [DataMember]
        public string Direccion { get; set; }
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
        public CentrosMedicosBE() { }

        public CentrosMedicosBE(
            int m_CentrosMedicosId,
            string m_SectorCentroMedico,
            string m_NombreCentroMedico,
            string m_Direccion,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            CentrosMedicosId = m_CentrosMedicosId;
            SectorCentroMedico = m_SectorCentroMedico;
            NombreCentroMedico = m_NombreCentroMedico;
            Direccion = m_Direccion;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public CentrosMedicosBE(IDataReader Registro)
        {
            CentrosMedicosId = ValidarInt(Registro["CentrosMedicosId"]);
            SectorCentroMedico = ValidarString(Registro["SectorCentroMedico"]);
            NombreCentroMedico = ValidarString(Registro["NombreCentroMedico"]);
            Direccion = ValidarString(Registro["Direccion"]);
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
