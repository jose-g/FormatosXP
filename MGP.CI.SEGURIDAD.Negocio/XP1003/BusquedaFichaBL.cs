using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGP.CI.SEGURIDAD.Entidades.ClaseDTO;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class BusquedaFichaBL : BaseBL
    {
        const string Nombre_Clase = "BusquedaFichaBL";
        private string m_BaseDatos = string.Empty;

        public BusquedaFichaBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public BusquedaFichaBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }


        public List<BusquedaFichaXP1003DTO> ListarFichasFiltrados(BusquedaFichaXP1003DTO ent)
        {
            List<BusquedaFichaXP1003DTO> l = new List<BusquedaFichaXP1003DTO>();
            try
            {
                l = (new BusquedaFichaDA()).ListarFichasFiltrados(ent);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

    }
}
