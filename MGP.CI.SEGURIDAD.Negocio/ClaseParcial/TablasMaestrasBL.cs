using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public class TablasMaestrasBL : BaseBL
    {
        const string Nombre_Clase = "TablasMaestrasBL";
        private string m_BaseDatos = string.Empty;

        public TablasMaestrasBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }
        public TablasMaestrasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public bool Insertar(TablasMaestrasBE e_TablasMaestras)
        {
            try
            {
                TablasMaestrasDA o_TablasMaestras = new TablasMaestrasDA(m_BaseDatos);
                int resp = o_TablasMaestras.Insertar(e_TablasMaestras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Anular(TablasMaestrasBE e_TablasMaestras)
        {
            try
            {
                TablasMaestrasDA o_TablasMaestras = new TablasMaestrasDA(m_BaseDatos);
                int resp = o_TablasMaestras.Anular(e_TablasMaestras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<TablasMaestrasBE> Consultar_Lista()
        {
            List<TablasMaestrasBE> lista = new List<TablasMaestrasBE>();
            try
            {
                TablasMaestrasDA o_TablasMaestras = new TablasMaestrasDA(m_BaseDatos);
                return o_TablasMaestras.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<TablasMaestrasBE> Consultar_PK()
        {
            List<TablasMaestrasBE> lista = new List<TablasMaestrasBE>();
            try
            {
                TablasMaestrasDA o_TablasMaestras = new TablasMaestrasDA(m_BaseDatos);
                return o_TablasMaestras.Consultar_PK(
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }


        public List<TablasMaestrasBE> ListarUsuariosFiltrados(TablasMaestrasBE ent)
        {
            List<TablasMaestrasBE> l = new List<TablasMaestrasBE>();
            try
            {
                l = new TablasMaestrasDA().ListarTablasFiltradas(ent);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }


    }
}
