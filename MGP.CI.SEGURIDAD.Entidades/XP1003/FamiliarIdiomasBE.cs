using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class FamiliarIdiomasBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "FamiliarIdiomas";
        [DataMember]
        public int FamiliarIdiomasId { get; set; }
        [DataMember]
        public int? IdiomaId { get; set; }
        [DataMember]
        public int? FamiliarId { get; set; }
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
        public FamiliarIdiomasBE() { }

        public FamiliarIdiomasBE(
            int m_FamiliarIdiomasId,
            int? m_IdiomaId,
            int? m_EstadoId,
            int? m_FamiliarId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            FamiliarIdiomasId = m_FamiliarIdiomasId;
            IdiomaId = m_IdiomaId;
            EstadoId = m_EstadoId;
            FamiliarId = m_FamiliarId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public FamiliarIdiomasBE(IDataReader Registro)
        {
            FamiliarIdiomasId = ValidarInt(Registro["FamiliarIdiomasId"]);
            IdiomaId = ValidarIntNulos(Registro["IdiomaId"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            FamiliarId = ValidarIntNulos(Registro["FamiliarId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
