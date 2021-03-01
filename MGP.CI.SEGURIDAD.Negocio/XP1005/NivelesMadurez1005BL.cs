using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class NivelesMadurez1005BL : BaseBL
    {
        const string Nombre_Clase = "NivelesMadurez1005BL";
        private string m_BaseDatos = string.Empty;

        public NivelesMadurez1005BL() {  }

        public bool Insertar(NivelesMadurez1005BE e_NivelesMadurez1005)
        {
            try
            {
                NivelesMadurez1005DA o_NivelesMadurez1005 = new NivelesMadurez1005DA();
                int resp = o_NivelesMadurez1005.Insertar(e_NivelesMadurez1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(NivelesMadurez1005BE e_NivelesMadurez1005)
        {
            try
            {
                NivelesMadurez1005DA o_NivelesMadurez1005 = new NivelesMadurez1005DA();
                int resp = o_NivelesMadurez1005.Actualizar(e_NivelesMadurez1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(NivelesMadurez1005BE e_NivelesMadurez1005)
        {
            try
            {
                NivelesMadurez1005DA o_NivelesMadurez1005 = new NivelesMadurez1005DA();
                int resp = o_NivelesMadurez1005.Anular(e_NivelesMadurez1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<NivelesMadurez1005BE> Consultar_Lista()
        {
            List<NivelesMadurez1005BE> lista = new List<NivelesMadurez1005BE>();
            try
            {
                NivelesMadurez1005DA o_NivelesMadurez1005 = new NivelesMadurez1005DA();
                return o_NivelesMadurez1005.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<NivelesMadurez1005BE> Consultar_PK(
                              int m_NivelesMadurez1005Id
                              )
        {
            List<NivelesMadurez1005BE> lista = new List<NivelesMadurez1005BE>();
            try
            {
                NivelesMadurez1005DA o_NivelesMadurez1005 = new NivelesMadurez1005DA();
                return o_NivelesMadurez1005.Consultar_PK(
                                                            m_NivelesMadurez1005Id
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
                NivelesMadurez1005DA o_NivelesMadurez1005 = new NivelesMadurez1005DA();
                idMax = o_NivelesMadurez1005.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
