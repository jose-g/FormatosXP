using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class DefectosDemostradoBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "DefectosDemostrado";
        [DataMember]
        public int DefectosDemostradoId { get; set; }
        [DataMember]
        public int DatosGeneralesId { get; set; }
        [DataMember]
        public int DefectosMaestraId { get; set; }
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
        public DefectosDemostradoBE() { }

        public DefectosDemostradoBE(
            int m_DefectosDemostradoId,
            int m_DatosGeneralesId,
            int m_DefectosMaestraId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            DefectosDemostradoId = m_DefectosDemostradoId;
            DatosGeneralesId = m_DatosGeneralesId;
            DefectosMaestraId = m_DefectosMaestraId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public DefectosDemostradoBE(IDataReader Registro)
        {
            DefectosDemostradoId = ValidarInt(Registro["DefectosDemostradoId"]);
            DatosGeneralesId = ValidarInt(Registro["DatosGeneralesId"]);
            DefectosMaestraId = ValidarInt(Registro["DefectosMaestraId"]);
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
