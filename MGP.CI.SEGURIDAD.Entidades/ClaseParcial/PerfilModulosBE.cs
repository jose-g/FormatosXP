using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class PerfilModulosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "PerfilModulos";
        [DataMember]
        public int PerfilModuloId { get; set; }
        [DataMember]
        public int? ModuloId { get; set; }
        [DataMember]
        public int? PerfilId { get; set; }
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
        public PerfilModulosBE() { }

        public PerfilModulosBE(
            int m_PerfilModuloId,
            int? m_ModuloId,
            int? m_PerfilId,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            PerfilModuloId = m_PerfilModuloId;
            ModuloId = m_ModuloId;
            PerfilId = m_PerfilId;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public PerfilModulosBE(IDataReader Registro)
        {
            PerfilModuloId = ValidarInt(Registro["PerfilModuloId"]);
            ModuloId = ValidarIntNulos(Registro["ModuloId"]);
            PerfilId = ValidarIntNulos(Registro["PerfilId"]);
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
