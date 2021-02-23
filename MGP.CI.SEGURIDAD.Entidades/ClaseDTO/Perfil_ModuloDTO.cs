using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Entidades
{
    public class Perfil_ModuloDTO : PerfilModulosBE
    {
        #region Propiedades
        public String NOMBRES_SISTEMA { get; set; } = "";
        public int SISTEMA_ID { get; set; } = -1;

        #endregion

        #region Construcctores
        public Perfil_ModuloDTO() { }

        public Perfil_ModuloDTO(IDataReader Registro)
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
            SISTEMA_ID = ValidarInt(Registro["SistemaId"]);
            NOMBRES_SISTEMA = ValidarString(Registro["SistemaNombre"]);
        }
        #endregion
    }
}

