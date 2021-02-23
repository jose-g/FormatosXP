using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class FichasBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Fichas";
        [DataMember]
        public int FichaId { get; set; }
        [DataMember]
        public int? FichaTipoId { get; set; }
        [DataMember]
        public int? DeclaranteId { get; set; }
        [DataMember]
        public int EstadoFichaId { get; set; }
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
        public FichasBE() { }

        public FichasBE(
            int m_FichaId,
            int? m_FichaTipoId,
            int? m_DeclaranteId,
            int m_EstadoFichaId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            FichaId = m_FichaId;
            FichaTipoId = m_FichaTipoId;
            DeclaranteId = m_DeclaranteId;
            EstadoFichaId = m_EstadoFichaId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public FichasBE(IDataReader Registro)
        {
            FichaId = ValidarInt(Registro["FichaId"]);
            FichaTipoId = ValidarIntNulos(Registro["FichaTipoId"]);
            DeclaranteId = ValidarIntNulos(Registro["DeclaranteId"]);
            EstadoFichaId = ValidarInt(Registro["EstadoFichaId"]);
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
