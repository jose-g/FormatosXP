using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class OpinionesBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Opiniones";
        [DataMember]
        public int OpinionesId { get; set; }
        [DataMember]
        public int Vinculaciones1005d { get; set; }
        [DataMember]
        public int OpinionMaestraId { get; set; }
        [DataMember]
        public int? NivelesBuenoId { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
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
        public OpinionesBE() { }

        public OpinionesBE(
            int m_OpinionesId,
            int m_Vinculaciones1005d,
            int m_OpinionMaestraId,
            int? m_NivelesBuenoId,
            string m_Descripcion,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            OpinionesId = m_OpinionesId;
            Vinculaciones1005d = m_Vinculaciones1005d;
            OpinionMaestraId = m_OpinionMaestraId;
            NivelesBuenoId = m_NivelesBuenoId;
            Descripcion = m_Descripcion;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public OpinionesBE(IDataReader Registro)
        {
            OpinionesId = ValidarInt(Registro["OpinionesId"]);
            Vinculaciones1005d = ValidarInt(Registro["Vinculaciones1005d"]);
            OpinionMaestraId = ValidarInt(Registro["OpinionMaestraId"]);
            NivelesBuenoId = ValidarIntNulos(Registro["NivelesBuenoId"]);
            Descripcion = ValidarString(Registro["Descripcion"]);
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
