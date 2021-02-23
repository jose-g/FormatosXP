using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class PermisoPerfilModulosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "PermisoPerfilModulos";
        [DataMember]
        public int PermisoPerfilModuloId { get; set; }
        [DataMember]
        public int? PerfilModuloId { get; set; }
        [DataMember]
        public int? UsuarioId { get; set; }
        [DataMember]
        public int? PermisoId { get; set; }
        [DataMember]
        public int? EstadoId { get; set; }
        [DataMember]
        public int? UsuarioModuloId { get; set; }
        [DataMember]
        public int? ModuloId { get; set; }
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
        public PermisoPerfilModulosBE() { }

        public PermisoPerfilModulosBE(
            int m_PermisoPerfilModuloId,
            int? m_PerfilModuloId,
            int? m_UsuarioId,
            int? m_PermisoId,
            int? m_EstadoId,
            int? m_UsuarioModuloId,
            int? m_ModuloId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            PermisoPerfilModuloId = m_PermisoPerfilModuloId;
            PerfilModuloId = m_PerfilModuloId;
            UsuarioId = m_UsuarioId;
            PermisoId = m_PermisoId;
            EstadoId = m_EstadoId;
            UsuarioModuloId = m_UsuarioModuloId;
            ModuloId = m_ModuloId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public PermisoPerfilModulosBE(IDataReader Registro)
        {
            PermisoPerfilModuloId = ValidarInt(Registro["PermisoPerfilModuloId"]);
            PerfilModuloId = ValidarIntNulos(Registro["PerfilModuloId"]);
            UsuarioId = ValidarIntNulos(Registro["UsuarioId"]);
            PermisoId = ValidarIntNulos(Registro["PermisoId"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            UsuarioModuloId = ValidarIntNulos(Registro["UsuarioModuloId"]);
            ModuloId = ValidarIntNulos(Registro["ModuloId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
        }
        #endregion

    }
}
