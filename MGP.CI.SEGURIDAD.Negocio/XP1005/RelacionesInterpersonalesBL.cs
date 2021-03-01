using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class RelacionesInterpersonalesBL : BaseBL
    {
        const string Nombre_Clase = "RelacionesInterpersonalesBL";
        private string m_BaseDatos = string.Empty;

        public RelacionesInterpersonalesBL() {  }

        public bool Insertar(RelacionesInterpersonalesBE e_RelacionesInterpersonales)
        {
            try
            {
                RelacionesInterpersonalesDA o_RelacionesInterpersonales = new RelacionesInterpersonalesDA();
                int resp = o_RelacionesInterpersonales.Insertar(e_RelacionesInterpersonales);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(RelacionesInterpersonalesBE e_RelacionesInterpersonales)
        {
            try
            {
                RelacionesInterpersonalesDA o_RelacionesInterpersonales = new RelacionesInterpersonalesDA();
                int resp = o_RelacionesInterpersonales.Actualizar(e_RelacionesInterpersonales);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(RelacionesInterpersonalesBE e_RelacionesInterpersonales)
        {
            try
            {
                RelacionesInterpersonalesDA o_RelacionesInterpersonales = new RelacionesInterpersonalesDA();
                int resp = o_RelacionesInterpersonales.Anular(e_RelacionesInterpersonales);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<RelacionesInterpersonalesBE> Consultar_Lista()
        {
            List<RelacionesInterpersonalesBE> lista = new List<RelacionesInterpersonalesBE>();
            try
            {
                RelacionesInterpersonalesDA o_RelacionesInterpersonales = new RelacionesInterpersonalesDA();
                return o_RelacionesInterpersonales.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<RelacionesInterpersonalesBE> Consultar_PK(
                              int m_RelacionesInterpersonalesId
                              )
        {
            List<RelacionesInterpersonalesBE> lista = new List<RelacionesInterpersonalesBE>();
            try
            {
                RelacionesInterpersonalesDA o_RelacionesInterpersonales = new RelacionesInterpersonalesDA();
                return o_RelacionesInterpersonales.Consultar_PK(
                                                            m_RelacionesInterpersonalesId
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
                RelacionesInterpersonalesDA o_RelacionesInterpersonales = new RelacionesInterpersonalesDA();
                idMax = o_RelacionesInterpersonales.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
