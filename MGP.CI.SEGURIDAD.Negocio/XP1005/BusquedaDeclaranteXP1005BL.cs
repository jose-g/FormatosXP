using MGP.CI.SEGURIDAD.AccesoDatos.XP1005;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Negocio.XP1005
{
    public class BusquedaDeclaranteXP1005BL
    {
        const string Nombre_Clase = "BusquedaDeclaranteXP1005BL";
        private string m_BaseDatos = string.Empty;

        public BusquedaDeclaranteXP1005BL() { }


        public List<BusquedaDeclaranteXP1005DTO> ListarUsuariosFiltrados(BusquedaDeclaranteXP1005DTO ent)
        {
            List<BusquedaDeclaranteXP1005DTO> l = new List<BusquedaDeclaranteXP1005DTO>();
            try
            {
                l = (new BusquedaDeclaranteXP1005DA()).ListarUsuariosFiltrados(ent);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
    }
}
