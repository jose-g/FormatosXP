using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades.XP1003
{
    [DataContract]
    [Serializable]
    public partial class NacionalidadBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Nacionalidad";
        [DataMember]
        public int NacionalidadId { get; set; }
        [DataMember]
        public int? PaisId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Abreviatura { get; set; }
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
        public NacionalidadBE() { }

        public NacionalidadBE(
            int m_NacionalidadId,
            int? m_PaisId,
            string m_Nombre,
            string m_Abreviatura,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            NacionalidadId = m_NacionalidadId;
            PaisId = m_PaisId;
            Nombre = m_Nombre;
            Abreviatura = m_Abreviatura;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public NacionalidadBE(IDataReader Registro)
        {
            NacionalidadId = ValidarInt(Registro["NacionalidadId"]);
            PaisId = ValidarIntNulos(Registro["PaisId"]);
            Nombre = ValidarString(Registro["Nombre"]);
            Abreviatura = ValidarString(Registro["Abreviatura"]);
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
