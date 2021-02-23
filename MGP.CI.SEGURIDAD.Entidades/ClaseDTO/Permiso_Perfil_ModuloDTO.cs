using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Entidades
{
    public class Permiso_Perfil_ModuloDTO : PermisoPerfilModulosBE
    {
        #region Propiedades

        public int SISTEMA_ID { get; set; }
        public string NOMBRES_SISTEMA { get; set; }
        public string NOMBRE_MODULO { get; set; }
        public string NOMBRE_PERMISO { get; set; }
        public int? USUARIO_ID { get; set; }
        public int? PERFIL_ID { get; set; }
        public string KEY_SISTEMA { get; set; }
        public string KEY_MODULO { get; set; }
        public string PERFIL_NOMBRE { get; set; }
        
        #endregion

        public Permiso_Perfil_ModuloDTO() { }

        public Permiso_Perfil_ModuloDTO(IDataReader Registro)
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
            SISTEMA_ID = ValidarInt(Registro["SISTEMA_ID"]);
            NOMBRES_SISTEMA = ValidarString(Registro["NOMBRES_SISTEMA"]);
            USUARIO_ID = ValidarInt(Registro["USUARIO_ID"]);
            NOMBRE_MODULO = ValidarString(Registro["NOMBRE_MODULO"]);
            NOMBRE_PERMISO = ValidarString(Registro["NOMBRE_PERMISO"]);
            KEY_SISTEMA = ValidarString(Registro["KEY_SISTEMA"]);
            KEY_MODULO = ValidarString(Registro["KEY_MODULO"]);
            PERFIL_NOMBRE = ValidarString(Registro["PERFIL_NOMBRE"]);
        }
    }
}
