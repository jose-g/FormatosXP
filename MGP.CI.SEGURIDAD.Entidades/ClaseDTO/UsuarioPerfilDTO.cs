using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Entidades
{
    public class UsuarioPerfilDTO : UsuarioPerfilesBE
    {
        #region Propiedades
        public String PerfilNombre { get; set; }
        public String EstadoNombre { get; set; } = "";
        #endregion

        #region Constructores
        public UsuarioPerfilDTO() { }

        public UsuarioPerfilDTO(IDataReader Registro)
        {
            UsuarioPerfilId = ValidarInt(Registro["UsuarioPerfilId"]);
            UsuarioId = ValidarInt(Registro["UsuarioId"]);
            PerfilId = ValidarInt(Registro["PerfilId"]);
            EstadoId = ValidarIntNulos(Registro["EstadoId"]);
            UsuarioRegistro = ValidarString(Registro["UsuarioRegistro"]);
            FechaRegistro = ValidarDatetime(Registro["FechaRegistro"]);
            UsuarioModificacionRegistro = ValidarString(Registro["UsuarioModificacionRegistro"]);
            FechaModificacionRegistro = ValidarDatetime(Registro["FechaModificacionRegistro"]);
            NroIpRegistro = ValidarString(Registro["NroIpRegistro"]);
            PerfilNombre = ValidarString(Registro["PERFIL_NOMBRE"]);
            EstadoNombre = ValidarString(Registro["ESTADO_NOMBRE"]);            
        }
        #endregion
    }
}
