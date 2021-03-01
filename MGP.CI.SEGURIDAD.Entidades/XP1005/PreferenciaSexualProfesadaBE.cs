using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.X1005
{
    [DataContract]
    [Serializable]
    public partial class PreferenciaSexualProfesadaBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "PreferenciaSexualProfesada";
        [DataMember]
        public int PreferenciaSexualProfesadaID { get; set; }
        [DataMember]
        public int DatosGeneralesId { get; set; }
        [DataMember]
        public int? PreferenciaSexualMaestraId { get; set; }
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
        public PreferenciaSexualProfesadaBE() { }

        public PreferenciaSexualProfesadaBE(
            int m_PreferenciaSexualProfesadaID,
            int m_DatosGeneralesId,
            int? m_PreferenciaSexualMaestraId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            PreferenciaSexualProfesadaID = m_PreferenciaSexualProfesadaID;
            DatosGeneralesId = m_DatosGeneralesId;
            PreferenciaSexualMaestraId = m_PreferenciaSexualMaestraId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public PreferenciaSexualProfesadaBE(IDataReader Registro)
        {
            PreferenciaSexualProfesadaID = ValidarInt(Registro["PreferenciaSexualProfesadaID"]);
            DatosGeneralesId = ValidarInt(Registro["DatosGeneralesId"]);
            PreferenciaSexualMaestraId = ValidarIntNulos(Registro["PreferenciaSexualMaestraId"]);
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
