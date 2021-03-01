using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class ValoresDemostradosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "ValoresDemostrados";
        [DataMember]
        public int ValoresDemostradosId { get; set; }
        [DataMember]
        public int DatosGeneralesId { get; set; }
        [DataMember]
        public int ValoresMaestraId { get; set; }
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
        public ValoresDemostradosBE() { }

        public ValoresDemostradosBE(
            int m_ValoresDemostradosId,
            int m_DatosGeneralesId,
            int m_ValoresMaestraId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            ValoresDemostradosId = m_ValoresDemostradosId;
            DatosGeneralesId = m_DatosGeneralesId;
            ValoresMaestraId = m_ValoresMaestraId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public ValoresDemostradosBE(IDataReader Registro)
        {
            ValoresDemostradosId = ValidarInt(Registro["ValoresDemostradosId"]);
            DatosGeneralesId = ValidarInt(Registro["DatosGeneralesId"]);
            ValoresMaestraId = ValidarInt(Registro["ValoresMaestraId"]);
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
