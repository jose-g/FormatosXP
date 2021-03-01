using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class LugaresFrecuentadosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "LugaresFrecuentados";
        [DataMember]
        public int LugaresFrecuentadosId { get; set; }
        [DataMember]
        public int DatosGeneralesId { get; set; }
        [DataMember]
        public int UbigeoId { get; set; }
        [DataMember]
        public int MotivoLugaresFrecuentadosId { get; set; }
        [DataMember]
        public string Observacion { get; set; }
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
        public LugaresFrecuentadosBE() { }

        public LugaresFrecuentadosBE(
            int m_LugaresFrecuentadosId,
            int m_DatosGeneralesId,
            int m_UbigeoId,
            int m_MotivoLugaresFrecuentadosId,
            string m_Observacion,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            LugaresFrecuentadosId = m_LugaresFrecuentadosId;
            DatosGeneralesId = m_DatosGeneralesId;
            UbigeoId = m_UbigeoId;
            MotivoLugaresFrecuentadosId = m_MotivoLugaresFrecuentadosId;
            Observacion = m_Observacion;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public LugaresFrecuentadosBE(IDataReader Registro)
        {
            LugaresFrecuentadosId = ValidarInt(Registro["LugaresFrecuentadosId"]);
            DatosGeneralesId = ValidarInt(Registro["DatosGeneralesId"]);
            UbigeoId = ValidarInt(Registro["UbigeoId"]);
            MotivoLugaresFrecuentadosId = ValidarInt(Registro["MotivoLugaresFrecuentadosId"]);
            Observacion = ValidarString(Registro["Observacion"]);
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
