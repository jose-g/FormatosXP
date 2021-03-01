using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class ReligionProfesadaBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "ReligionProfesada";
        [DataMember]
        public int ReligionProfesadaId { get; set; }
        [DataMember]
        public int DatosGeneralesId { get; set; }
        [DataMember]
        public int? ReligionMaestraId { get; set; }
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
        public ReligionProfesadaBE() { }

        public ReligionProfesadaBE(
            int m_ReligionProfesadaId,
            int m_DatosGeneralesId,
            int? m_ReligionMaestraId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            ReligionProfesadaId = m_ReligionProfesadaId;
            DatosGeneralesId = m_DatosGeneralesId;
            ReligionMaestraId = m_ReligionMaestraId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public ReligionProfesadaBE(IDataReader Registro)
        {
            ReligionProfesadaId = ValidarInt(Registro["ReligionProfesadaId"]);
            DatosGeneralesId = ValidarInt(Registro["DatosGeneralesId"]);
            ReligionMaestraId = ValidarIntNulos(Registro["ReligionMaestraId"]);
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
