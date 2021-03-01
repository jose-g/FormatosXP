using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class BienesEconomicosPoseedorBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "BienesEconomicosPoseedor";
        [DataMember]
        public int BienesEconomicosPoseedorId { get; set; }
        [DataMember]
        public int DatosGeneralesId { get; set; }
        [DataMember]
        public int BienesEconomicosMaestraId { get; set; }
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
        public BienesEconomicosPoseedorBE() { }

        public BienesEconomicosPoseedorBE(
            int m_BienesEconomicosPoseedorId,
            int m_DatosGeneralesId,
            int m_BienesEconomicosMaestraId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            BienesEconomicosPoseedorId = m_BienesEconomicosPoseedorId;
            DatosGeneralesId = m_DatosGeneralesId;
            BienesEconomicosMaestraId = m_BienesEconomicosMaestraId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public BienesEconomicosPoseedorBE(IDataReader Registro)
        {
            BienesEconomicosPoseedorId = ValidarInt(Registro["BienesEconomicosPoseedorId"]);
            DatosGeneralesId = ValidarInt(Registro["DatosGeneralesId"]);
            BienesEconomicosMaestraId = ValidarInt(Registro["BienesEconomicosMaestraId"]);
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
