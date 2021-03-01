using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class ActividadesIntoPais1005BL : BaseBL
    {
        const string Nombre_Clase = "ActividadesIntoPais1005BL";
        private string m_BaseDatos = string.Empty;

        public ActividadesIntoPais1005BL() {  }

        public bool Insertar(ActividadesIntoPais1005BE e_ActividadesIntoPais1005)
        {
            try
            {
                ActividadesIntoPais1005DA o_ActividadesIntoPais1005 = new ActividadesIntoPais1005DA();
                int resp = o_ActividadesIntoPais1005.Insertar(e_ActividadesIntoPais1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(ActividadesIntoPais1005BE e_ActividadesIntoPais1005)
        {
            try
            {
                ActividadesIntoPais1005DA o_ActividadesIntoPais1005 = new ActividadesIntoPais1005DA();
                int resp = o_ActividadesIntoPais1005.Actualizar(e_ActividadesIntoPais1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(ActividadesIntoPais1005BE e_ActividadesIntoPais1005)
        {
            try
            {
                ActividadesIntoPais1005DA o_ActividadesIntoPais1005 = new ActividadesIntoPais1005DA();
                int resp = o_ActividadesIntoPais1005.Anular(e_ActividadesIntoPais1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ActividadesIntoPais1005BE> Consultar_Lista()
        {
            List<ActividadesIntoPais1005BE> lista = new List<ActividadesIntoPais1005BE>();
            try
            {
                ActividadesIntoPais1005DA o_ActividadesIntoPais1005 = new ActividadesIntoPais1005DA();
                return o_ActividadesIntoPais1005.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ActividadesIntoPais1005BE> Consultar_PK(
                              int m_ActividadesIntoPais1005Id
                              )
        {
            List<ActividadesIntoPais1005BE> lista = new List<ActividadesIntoPais1005BE>();
            try
            {
                ActividadesIntoPais1005DA o_ActividadesIntoPais1005 = new ActividadesIntoPais1005DA();
                return o_ActividadesIntoPais1005.Consultar_PK(
                                                            m_ActividadesIntoPais1005Id
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
                ActividadesIntoPais1005DA o_ActividadesIntoPais1005 = new ActividadesIntoPais1005DA();
                idMax = o_ActividadesIntoPais1005.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
