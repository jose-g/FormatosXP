using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class Vinculaciones1005BL : BaseBL
    {
        const string Nombre_Clase = "Vinculaciones1005BL";
        private string m_BaseDatos = string.Empty;

        public Vinculaciones1005BL() {  }

        public bool Insertar(Vinculaciones1005BE e_Vinculaciones1005)
        {
            try
            {
                Vinculaciones1005DA o_Vinculaciones1005 = new Vinculaciones1005DA();
                int resp = o_Vinculaciones1005.Insertar(e_Vinculaciones1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(Vinculaciones1005BE e_Vinculaciones1005)
        {
            try
            {
                Vinculaciones1005DA o_Vinculaciones1005 = new Vinculaciones1005DA();
                int resp = o_Vinculaciones1005.Actualizar(e_Vinculaciones1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(Vinculaciones1005BE e_Vinculaciones1005)
        {
            try
            {
                Vinculaciones1005DA o_Vinculaciones1005 = new Vinculaciones1005DA();
                int resp = o_Vinculaciones1005.Anular(e_Vinculaciones1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Vinculaciones1005BE> Consultar_Lista()
        {
            List<Vinculaciones1005BE> lista = new List<Vinculaciones1005BE>();
            try
            {
                Vinculaciones1005DA o_Vinculaciones1005 = new Vinculaciones1005DA();
                return o_Vinculaciones1005.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Vinculaciones1005BE> Consultar_PK(
                              int m_Vinculaciones1005d
                              )
        {
            List<Vinculaciones1005BE> lista = new List<Vinculaciones1005BE>();
            try
            {
                Vinculaciones1005DA o_Vinculaciones1005 = new Vinculaciones1005DA();
                return o_Vinculaciones1005.Consultar_PK(
                                                            m_Vinculaciones1005d
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public int GetMaxId()
        {
            int idMax = -1;
            try
            {
                Vinculaciones1005DA o_Vinculaciones1005 = new Vinculaciones1005DA();
                idMax = o_Vinculaciones1005.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
