using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class Observaciones1005BL : BaseBL
    {
        const string Nombre_Clase = "Observaciones1005BL";
        private string m_BaseDatos = string.Empty;

        public Observaciones1005BL() {  }

        public bool Insertar(Observaciones1005BE e_Observaciones1005)
        {
            try
            {
                Observaciones1005DA o_Observaciones1005 = new Observaciones1005DA();
                int resp = o_Observaciones1005.Insertar(e_Observaciones1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(Observaciones1005BE e_Observaciones1005)
        {
            try
            {
                Observaciones1005DA o_Observaciones1005 = new Observaciones1005DA();
                int resp = o_Observaciones1005.Actualizar(e_Observaciones1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(Observaciones1005BE e_Observaciones1005)
        {
            try
            {
                Observaciones1005DA o_Observaciones1005 = new Observaciones1005DA();
                int resp = o_Observaciones1005.Anular(e_Observaciones1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Observaciones1005BE> Consultar_Lista()
        {
            List<Observaciones1005BE> lista = new List<Observaciones1005BE>();
            try
            {
                Observaciones1005DA o_Observaciones1005 = new Observaciones1005DA();
                return o_Observaciones1005.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Observaciones1005BE> Consultar_PK(
                              int m_Observaciones1005Id
                              )
        {
            List<Observaciones1005BE> lista = new List<Observaciones1005BE>();
            try
            {
                Observaciones1005DA o_Observaciones1005 = new Observaciones1005DA();
                return o_Observaciones1005.Consultar_PK(
                                                            m_Observaciones1005Id
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
                Observaciones1005DA o_Observaciones1005 = new Observaciones1005DA();
                idMax = o_Observaciones1005.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
