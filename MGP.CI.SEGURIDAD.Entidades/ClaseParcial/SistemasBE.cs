using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class SistemasBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Sistemas";
        [DataMember]
        public int SistemaId { get; set; }
        [DataMember]
        public string SistemaKey { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Abreviatura { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Path { get; set; }
        [DataMember]
        public string Icon { get; set; }
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
        public SistemasBE() { }

        public SistemasBE(
            int m_SistemaId,
            string m_SistemaKey,
            string m_Nombre,
            string m_Abreviatura,
            string m_Tipo,
            string m_Descripcion,
            string m_Path,
            string m_Icon,
            int? m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro
        )
        {
            SistemaId = m_SistemaId;
            SistemaKey = m_SistemaKey;
            Nombre = m_Nombre;
            Abreviatura = m_Abreviatura;
            Tipo = m_Tipo;
            Descripcion = m_Descripcion;
            Path = m_Path;
            Icon = m_Icon;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
        }

        public SistemasBE(IDataReader Registro)
        {
            SistemaId = ValidarInt(Registro["SistemaId"]);
            SistemaKey = ValidarString(Registro["SistemaKey"]);
            Nombre = ValidarString(Registro["Nombre"]);
            Abreviatura = ValidarString(Registro["Abreviatura"]);
            Tipo = ValidarString(Registro["Tipo"]);
            Descripcion = ValidarString(Registro["Descripcion"]);
            Path = ValidarString(Registro["Path"]);
            Icon = ValidarString(Registro["Icon"]);
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
