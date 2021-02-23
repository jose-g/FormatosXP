using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class EspecialidadesExtranjerasBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "EspecialidadesExtranjeras";
        [DataMember]
        public int EspecialidadesExtranjerasId { get; set; }
        [DataMember]
        public int InstitucionMilitarExtranjeraId { get; set; }
        [DataMember]
        public string Escalafon { get; set; }
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
        public EspecialidadesExtranjerasBE() { }

        public EspecialidadesExtranjerasBE(
            int m_EspecialidadesExtranjerasId,
            int m_InstitucionMilitarExtranjeraId,
            string m_Escalafon,
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
            EspecialidadesExtranjerasId = m_EspecialidadesExtranjerasId;
            InstitucionMilitarExtranjeraId = m_InstitucionMilitarExtranjeraId;
            Escalafon = m_Escalafon;
            CategoriaMilitarId = m_CategoriaMilitarId;
            Descripcion = m_Descripcion;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public EspecialidadesExtranjerasBE(IDataReader Registro)
        {
            EspecialidadesExtranjerasId = ValidarInt(Registro["EspecialidadesExtranjerasId"]);
            InstitucionMilitarExtranjeraId = ValidarInt(Registro["InstitucionMilitarExtranjeraId"]);
            Escalafon = ValidarString(Registro["Escalafon"]);
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
