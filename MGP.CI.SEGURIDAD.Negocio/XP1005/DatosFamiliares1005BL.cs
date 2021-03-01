using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class DatosFamiliares1005BL : BaseBL
    {
        const string Nombre_Clase = "DatosFamiliares1005BL";
        private string m_BaseDatos = string.Empty;

        public DatosFamiliares1005BL() {  }

        public bool Insertar(DatosFamiliares1005BE e_DatosFamiliares1005)
        {
            try
            {
                DatosFamiliares1005DA o_DatosFamiliares1005 = new DatosFamiliares1005DA();
                int resp = o_DatosFamiliares1005.Insertar(e_DatosFamiliares1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(DatosFamiliares1005BE e_DatosFamiliares1005)
        {
            try
            {
                DatosFamiliares1005DA o_DatosFamiliares1005 = new DatosFamiliares1005DA();
                int resp = o_DatosFamiliares1005.Actualizar(e_DatosFamiliares1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DatosFamiliares1005BE e_DatosFamiliares1005)
        {
            try
            {
                DatosFamiliares1005DA o_DatosFamiliares1005 = new DatosFamiliares1005DA();
                int resp = o_DatosFamiliares1005.Anular(e_DatosFamiliares1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DatosFamiliares1005BE> Consultar_Lista()
        {
            List<DatosFamiliares1005BE> lista = new List<DatosFamiliares1005BE>();
            try
            {
                DatosFamiliares1005DA o_DatosFamiliares1005 = new DatosFamiliares1005DA();
                return o_DatosFamiliares1005.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DatosFamiliares1005BE> Consultar_PK(
                              int m_DatosFamiliares1005Id
                              )
        {
            List<DatosFamiliares1005BE> lista = new List<DatosFamiliares1005BE>();
            try
            {
                DatosFamiliares1005DA o_DatosFamiliares1005 = new DatosFamiliares1005DA();
                return o_DatosFamiliares1005.Consultar_PK(
                                                            m_DatosFamiliares1005Id
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
                DatosFamiliares1005DA o_DatosFamiliares1005 = new DatosFamiliares1005DA();
                idMax = o_DatosFamiliares1005.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
