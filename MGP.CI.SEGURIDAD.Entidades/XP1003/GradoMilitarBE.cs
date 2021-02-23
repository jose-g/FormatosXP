using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class GradoMilitarBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "GradoMilitar";
        [DataMember]
        public int GradoMilitarId { get; set; }
        [DataMember]
        public int? InstitucionMilitarId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public int? CategoriaMilitarId { get; set; }
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
        public GradoMilitarBE() { }

        public GradoMilitarBE(
            int m_GradoMilitarId,
            int? m_InstitucionMilitarId,
            string m_Nombre,
            string m_Descripcion,
            int? m_EstadoId,
            int? m_CategoriaMilitarId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            GradoMilitarId = m_GradoMilitarId;
            InstitucionMilitarId = m_InstitucionMilitarId;
            Nombre = m_Nombre;
            Descripcion = m_Descripcion;
            EstadoId = m_EstadoId;
            CategoriaMilitarId = m_CategoriaMilitarId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public GradoMilitarBE(IDataReader Registro)
        {
            GradoMilitarId = ValidarInt(Registro["GradoMilitarId"]);
            InstitucionMilitarId = ValidarIntNulos(Registro["InstitucionMilitarId"]);
            Nombre = ValidarString(Registro["Nombre"]);
            Descripcion = ValidarString(Registro["Descripcion"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            CategoriaMilitarId = ValidarIntNulos(Registro["CategoriaMilitarId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
