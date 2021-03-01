using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class DatosGenerales1005BL : BaseBL
    {
        const string Nombre_Clase = "DatosGenerales1005BL";
        private string m_BaseDatos = string.Empty;

        public DatosGenerales1005BL() {  }

        public bool Insertar(DatosGenerales1005BE e_DatosGenerales1005)
        {
            try
            {
                DatosGenerales1005DA o_DatosGenerales1005 = new DatosGenerales1005DA();
                int resp = o_DatosGenerales1005.Insertar(e_DatosGenerales1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(DatosGenerales1005BE e_DatosGenerales1005)
        {
            try
            {
                DatosGenerales1005DA o_DatosGenerales1005 = new DatosGenerales1005DA();
                int resp = o_DatosGenerales1005.Actualizar(e_DatosGenerales1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DatosGenerales1005BE e_DatosGenerales1005)
        {
            try
            {
                DatosGenerales1005DA o_DatosGenerales1005 = new DatosGenerales1005DA();
                int resp = o_DatosGenerales1005.Anular(e_DatosGenerales1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DatosGenerales1005BE> Consultar_Lista()
        {
            List<DatosGenerales1005BE> lista = new List<DatosGenerales1005BE>();
            try
            {
                DatosGenerales1005DA o_DatosGenerales1005 = new DatosGenerales1005DA();
                return o_DatosGenerales1005.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DatosGenerales1005BE> Consultar_PK(
                              int m_DatosGeneralesId
                              )
        {
            List<DatosGenerales1005BE> lista = new List<DatosGenerales1005BE>();
            try
            {
                DatosGenerales1005DA o_DatosGenerales1005 = new DatosGenerales1005DA();
                return o_DatosGenerales1005.Consultar_PK(
                                                            m_DatosGeneralesId
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
                DatosGenerales1005DA o_DatosGenerales1005 = new DatosGenerales1005DA();
                idMax = o_DatosGenerales1005.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
