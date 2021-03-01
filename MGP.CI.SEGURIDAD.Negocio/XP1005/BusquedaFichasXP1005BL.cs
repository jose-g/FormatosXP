using MGP.CI.SEGURIDAD.AccesoDatos.XP1005;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.Entidades.XP1005;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.Negocio.XP1005
{
    public class BusquedaFichasXP1005BL : BaseBL
    {
        const string Nombre_Clase = "BusquedaFichasXP1005BL";

        private string m_BaseDatos = string.Empty;

        public BusquedaFichasXP1005BL() { }


        public List<BusquedaFichasXP1005BE> ListarFichasFromDeclarante(int DeclaranteId)
        {
            List<BusquedaFichasXP1005BE> l = new List<BusquedaFichasXP1005BE>();
            try
            {
                l = (new BusquedaFichasXP1005DA()).ListarFichasFromDeclarante(DeclaranteId);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
    }
}
