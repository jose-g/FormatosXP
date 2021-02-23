using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Entidades
{
    public class Usuario_ModuloDTO : BaseBE
    {
        public int UsuarioModuloId { get; set; }
        public int? UsuarioId{ get; set; }
        public int? ModuloId { get; set; }
        public int? SISTEMA_ID { get; set; }
        public string NOMBRES_SISTEMA { get; set; }
        public Usuario_ModuloDTO() { }

        public Usuario_ModuloDTO(IDataReader Registro)
        {
            UsuarioModuloId = ValidarInt(Registro["USUARIO_MODULO_ID"]);
            UsuarioId = ValidarIntNulos(Registro["USUARIO_ID"]);
            ModuloId  = ValidarIntNulos(Registro["MODULO_ID"]);
            SISTEMA_ID = ValidarIntNulos(Registro["SISTEMA_ID"]);
            NOMBRES_SISTEMA = ValidarString(Registro["NOMBRES_SISTEMA"]); 
        }
    }
}
