using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class SalidasDelPaisBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "SalidasDelPais";
        [DataMember]
        public int SalidasDelPaisId { get; set; }
        [DataMember]
        public int DatosGeneralesId { get; set; }
        [DataMember]
        public DateTime? FechaSalida { get; set; }
        [DataMember]
        public DateTime? FechaIngreso { get; set; }
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
        public SalidasDelPaisBE() { }

        public SalidasDelPaisBE(
            int m_SalidasDelPaisId,
            int m_DatosGeneralesId,
            DateTime? m_FechaSalida,
            DateTime? m_FechaIngreso,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            SalidasDelPaisId = m_SalidasDelPaisId;
            DatosGeneralesId = m_DatosGeneralesId;
            FechaSalida = m_FechaSalida;
            FechaIngreso = m_FechaIngreso;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public SalidasDelPaisBE(IDataReader Registro)
        {
            SalidasDelPaisId = ValidarInt(Registro["SalidasDelPaisId"]);
            DatosGeneralesId = ValidarInt(Registro["DatosGeneralesId"]);
            FechaSalida = ValidarDatetime(Registro["FechaSalida"]);
            FechaIngreso = ValidarDatetime(Registro["FechaIngreso"]);
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
