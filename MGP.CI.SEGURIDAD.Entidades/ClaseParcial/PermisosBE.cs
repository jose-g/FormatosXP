using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class PermisosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Permisos";
        [DataMember]
        public int PermisoId { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
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
        public PermisosBE() { }

        public PermisosBE(
            int m_PermisoId,
            int? m_EstadoId,
            string m_Nombre,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            PermisoId = m_PermisoId;
            EstadoId = m_EstadoId;
            Nombre = m_Nombre;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public PermisosBE(IDataReader Registro)
        {
            PermisoId = ValidarInt(Registro["PermisoId"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            Nombre = ValidarString(Registro["Nombre"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
