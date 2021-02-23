using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class CondecoracionesExtranjerasBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "CondecoracionesExtranjeras";
        [DataMember]
        public int CondecoracionesExtranjerasId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int InstitucionMilitarExtranjeraId { get; set; }
        [DataMember]
        public int? CategoriaMilitarId { get; set; }
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
        public CondecoracionesExtranjerasBE() { }

        public CondecoracionesExtranjerasBE(
            int m_CondecoracionesExtranjerasId,
            string m_Nombre,
            string m_Descripcion,
            int m_InstitucionMilitarExtranjeraId,
            int? m_CategoriaMilitarId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            CondecoracionesExtranjerasId = m_CondecoracionesExtranjerasId;
            Nombre = m_Nombre;
            Descripcion = m_Descripcion;
            InstitucionMilitarExtranjeraId = m_InstitucionMilitarExtranjeraId;
            CategoriaMilitarId = m_CategoriaMilitarId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public CondecoracionesExtranjerasBE(IDataReader Registro)
        {
            CondecoracionesExtranjerasId = ValidarInt(Registro["CondecoracionesExtranjerasId"]);
            Nombre = ValidarString(Registro["Nombre"]);
            Descripcion = ValidarString(Registro["Descripcion"]);
            InstitucionMilitarExtranjeraId = ValidarInt(Registro["InstitucionMilitarExtranjeraId"]);
            CategoriaMilitarId = ValidarIntNulos(Registro["CategoriaMilitarId"]);
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
