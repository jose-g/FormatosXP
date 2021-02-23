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
    public partial class BusquedaDeclaranteBL : BaseBL
    {
        const string Nombre_Clase = "BusquedaDeclaranteBL";
        private string m_BaseDatos = string.Empty;

        public BusquedaDeclaranteBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public BusquedaDeclaranteBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }


        public List<BusquedaDeclaranteXP1003DTO> ListarUsuariosFiltrados(BusquedaDeclaranteXP1003DTO ent)
        {
            List<BusquedaDeclaranteXP1003DTO> l = new List<BusquedaDeclaranteXP1003DTO>();
            try
            {
                l = (new BusquedaDeclaranteDA()).ListarUsuariosFiltrados(ent);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

    }
}
