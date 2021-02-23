using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Entidades.DTO
{
    public class LoginDTO
    {
        public string ERROR_SMS { get; set; } = "";
        public int USUARIO_ID { get; set; }        
        public String NOMBRES_USUARIO { get; set; } = "";        
        public String LOGIN { get; set; } = "";        
        public String PASSWORD { get; set; }
        
    }
}
