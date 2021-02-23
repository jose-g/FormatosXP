using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class GradosExtranjerosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "GradosExtranjeros";
        [DataMember]
        public int GradoExtranjeroId { get; set; }
        [DataMember]
        public int? InstitucionMilitarExtranjeraId { get; set; }
        [DataMember]
        public int? CategoriaMilitarId { get; set; }
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
        public GradosExtranjerosBE() { }

        public GradosExtranjerosBE(
            int m_GradoExtranjeroId,
            int? m_InstitucionMilitarExtranjeraId,
            int? m_CategoriaMilitarId,
            string m_Descripcion,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            GradoExtranjeroId = m_GradoExtranjeroId;
            InstitucionMilitarExtranjeraId = m_InstitucionMilitarExtranjeraId;
            CategoriaMilitarId = m_CategoriaMilitarId;
            Descripcion = m_Descripcion;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public GradosExtranjerosBE(IDataReader Registro)
        {
            GradoExtranjeroId = ValidarInt(Registro["GradoExtranjeroId"]);
            InstitucionMilitarExtranjeraId = ValidarIntNulos(Registro["InstitucionMilitarExtranjeraId"]);
            CategoriaMilitarId = ValidarIntNulos(Registro["CategoriaMilitarId"]);
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
