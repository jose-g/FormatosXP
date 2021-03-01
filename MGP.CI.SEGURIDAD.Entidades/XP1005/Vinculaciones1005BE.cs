using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class Vinculaciones1005BE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Vinculaciones1005";
        [DataMember]
        public int Vinculaciones1005d { get; set; }
        [DataMember]
        public int FichaId { get; set; }
        [DataMember]
        public string TendenciaIdelogica { get; set; }
        [DataMember]
        public string LineaPolitica { get; set; }
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
        public Vinculaciones1005BE() { }

        public Vinculaciones1005BE(
            int m_Vinculaciones1005d,
            int m_FichaId,
            string m_TendenciaIdelogica,
            string m_LineaPolitica,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            Vinculaciones1005d = m_Vinculaciones1005d;
            FichaId = m_FichaId;
            TendenciaIdelogica = m_TendenciaIdelogica;
            LineaPolitica = m_LineaPolitica;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public Vinculaciones1005BE(IDataReader Registro)
        {
            Vinculaciones1005d = ValidarInt(Registro["Vinculaciones1005d"]);
            FichaId = ValidarInt(Registro["FichaId"]);
            TendenciaIdelogica = ValidarString(Registro["TendenciaIdelogica"]);
            LineaPolitica = ValidarString(Registro["LineaPolitica"]);
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
