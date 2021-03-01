using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class DependenciasDeVisitaBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "DependenciasDeVisita";
        [DataMember]
        public int DependenciasDeVisitaId { get; set; }
        [DataMember]
        public int DatosGeneralesId { get; set; }
        [DataMember]
        public int UbigeoNavalId { get; set; }
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
        public DependenciasDeVisitaBE() { }

        public DependenciasDeVisitaBE(
            int m_DependenciasDeVisitaId,
            int m_DatosGeneralesId,
            int m_UbigeoNavalId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            DependenciasDeVisitaId = m_DependenciasDeVisitaId;
            DatosGeneralesId = m_DatosGeneralesId;
            UbigeoNavalId = m_UbigeoNavalId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public DependenciasDeVisitaBE(IDataReader Registro)
        {
            DependenciasDeVisitaId = ValidarInt(Registro["DependenciasDeVisitaId"]);
            DatosGeneralesId = ValidarInt(Registro["DatosGeneralesId"]);
            UbigeoNavalId = ValidarInt(Registro["UbigeoNavalId"]);
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
