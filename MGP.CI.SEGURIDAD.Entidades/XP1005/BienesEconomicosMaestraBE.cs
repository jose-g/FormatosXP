using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class BienesEconomicosMaestraBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "BienesEconomicosMaestra";
        [DataMember]
        public int BienesEconomicosMaestraId { get; set; }
        [DataMember]
        public string NombreRegistro { get; set; }
        [DataMember]
        public string NombreTipo { get; set; }
        [DataMember]
        public string NombreBien { get; set; }
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
        public BienesEconomicosMaestraBE() { }

        public BienesEconomicosMaestraBE(
            int m_BienesEconomicosMaestraId,
            string m_NombreRegistro,
            string m_NombreTipo,
            string m_NombreBien,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            BienesEconomicosMaestraId = m_BienesEconomicosMaestraId;
            NombreRegistro = m_NombreRegistro;
            NombreTipo = m_NombreTipo;
            NombreBien = m_NombreBien;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public BienesEconomicosMaestraBE(IDataReader Registro)
        {
            BienesEconomicosMaestraId = ValidarInt(Registro["BienesEconomicosMaestraId"]);
            NombreRegistro = ValidarString(Registro["NombreRegistro"]);
            NombreTipo = ValidarString(Registro["NombreTipo"]);
            NombreBien = ValidarString(Registro["NombreBien"]);
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
