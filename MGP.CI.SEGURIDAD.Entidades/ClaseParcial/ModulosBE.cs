using System;
using System.Data;
using System.Runtime.Serialization;

namespace MGP.CI.SEGURIDAD.Entidades
{
    [DataContract]
    [Serializable]
    public partial class ModulosBE : BaseBE
    {
        #region Propiedades
        public readonly string Table_Name = "Modulos";
        [DataMember]
        public int ModuloId { get; set; }
        [DataMember]
        public string ModuloKey { get; set; }
        [DataMember]
        public int? SistemaId { get; set; }
        [DataMember]
        public int? ModuloPadreId { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public bool MenuDisplay { get; set; }
        [DataMember]
        public string MenuIcono { get; set; }
        [DataMember]
        public string MenuNombre { get; set; }
        [DataMember]
        public string MenuPath { get; set; }
        [DataMember]
        public int MenuPrioridad { get; set; }
        [DataMember]
        public int EstadoId { get; set; }
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

        [DataMember]
        public string SistemaKey { get; set; }
        #endregion

        #region Constructores
        public ModulosBE() { }

        public ModulosBE(
            int m_ModuloId,
            string m_ModuloKey,
            int? m_SistemaId,
            int? m_ModuloPadreId,
            string m_Nombre,
            string m_Descripcion,
            bool m_MenuDisplay,
            string m_MenuIcono,
            string m_MenuNombre,
            string m_MenuPath,
            int m_MenuPrioridad,
            int m_EstadoId,
            string m_UsuarioRegistro,
            DateTime? m_FechaRegistro,
            string m_UsuarioModificacionRegistro,
            DateTime? m_FechaModificacionRegistro,
            string m_NroIpRegistro,
            string m_SistemaKey
        )
        {
            ModuloId = m_ModuloId;
            ModuloKey = m_ModuloKey;
            SistemaId = m_SistemaId;
            ModuloPadreId = m_ModuloPadreId;
            Nombre = m_Nombre;
            Descripcion = m_Descripcion;
            MenuDisplay = m_MenuDisplay;
            MenuIcono = m_MenuIcono;
            MenuNombre = m_MenuNombre;
            MenuPath = m_MenuPath;
            MenuPrioridad = m_MenuPrioridad;
            EstadoId = m_EstadoId;
            UsuarioRegistro = m_UsuarioRegistro;
            FechaRegistro = m_FechaRegistro;
            UsuarioModificacionRegistro = m_UsuarioModificacionRegistro;
            FechaModificacionRegistro = m_FechaModificacionRegistro;
            NroIpRegistro = m_NroIpRegistro;
            SistemaKey = m_SistemaKey;
        }

        public ModulosBE(IDataReader Registro)
        {
            ModuloId = ValidarInt(Registro["ModuloId"]);
            ModuloKey = ValidarString(Registro["ModuloKey"]);
            SistemaId = ValidarIntNulos(Registro["SistemaId"]);
            ModuloPadreId = ValidarIntNulos(Registro["ModuloPadreId"]);
            Nombre = ValidarString(Registro["Nombre"]);
            Descripcion = ValidarString(Registro["Descripcion"]);
            MenuDisplay = ValidarBool(Registro["MenuDisplay"]);
            MenuIcono = ValidarString(Registro["MenuIcono"]);
            MenuNombre = ValidarString(Registro["MenuNombre"]);
            MenuPath = ValidarString(Registro["MenuPath"]);
            MenuPrioridad = ValidarInt(Registro["MenuPrioridad"]);
            EstadoId = ValidarInt(Registro["EstadoId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
            SistemaKey = ValidarString(Registro["SistemaKey"]);
        }
        #endregion

    }
}
