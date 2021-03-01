using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class DetalleCursos1005BL : BaseBL
    {
        const string Nombre_Clase = "DetalleCursos1005BL";
        private string m_BaseDatos = string.Empty;

        public DetalleCursos1005BL() {  }

        public bool Insertar(DetalleCursos1005BE e_DetalleCursos1005)
        {
            try
            {
                DetalleCursos1005DA o_DetalleCursos1005 = new DetalleCursos1005DA();
                int resp = o_DetalleCursos1005.Insertar(e_DetalleCursos1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(DetalleCursos1005BE e_DetalleCursos1005)
        {
            try
            {
                DetalleCursos1005DA o_DetalleCursos1005 = new DetalleCursos1005DA();
                int resp = o_DetalleCursos1005.Actualizar(e_DetalleCursos1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DetalleCursos1005BE e_DetalleCursos1005)
        {
            try
            {
                DetalleCursos1005DA o_DetalleCursos1005 = new DetalleCursos1005DA();
                int resp = o_DetalleCursos1005.Anular(e_DetalleCursos1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DetalleCursos1005BE> Consultar_Lista()
        {
            List<DetalleCursos1005BE> lista = new List<DetalleCursos1005BE>();
            try
            {
                DetalleCursos1005DA o_DetalleCursos1005 = new DetalleCursos1005DA();
                return o_DetalleCursos1005.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DetalleCursos1005BE> Consultar_PK(
                              int m_DetalleCursos1005Id
                              )
        {
            List<DetalleCursos1005BE> lista = new List<DetalleCursos1005BE>();
            try
            {
                DetalleCursos1005DA o_DetalleCursos1005 = new DetalleCursos1005DA();
                return o_DetalleCursos1005.Consultar_PK(
                                                            m_DetalleCursos1005Id
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
                DetalleCursos1005DA o_DetalleCursos1005 = new DetalleCursos1005DA();
                idMax = o_DetalleCursos1005.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
