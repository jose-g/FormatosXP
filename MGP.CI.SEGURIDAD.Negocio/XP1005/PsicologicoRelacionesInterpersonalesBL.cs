using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class PsicologicoRelacionesInterpersonalesBL : BaseBL
    {
        const string Nombre_Clase = "PsicologicoRelacionesInterpersonalesBL";
        private string m_BaseDatos = string.Empty;

        public PsicologicoRelacionesInterpersonalesBL() {  }

        public bool Insertar(PsicologicoRelacionesInterpersonalesBE e_PsicologicoRelacionesInterpersonales)
        {
            try
            {
                PsicologicoRelacionesInterpersonalesDA o_PsicologicoRelacionesInterpersonales = new PsicologicoRelacionesInterpersonalesDA();
                int resp = o_PsicologicoRelacionesInterpersonales.Insertar(e_PsicologicoRelacionesInterpersonales);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(PsicologicoRelacionesInterpersonalesBE e_PsicologicoRelacionesInterpersonales)
        {
            try
            {
                PsicologicoRelacionesInterpersonalesDA o_PsicologicoRelacionesInterpersonales = new PsicologicoRelacionesInterpersonalesDA();
                int resp = o_PsicologicoRelacionesInterpersonales.Actualizar(e_PsicologicoRelacionesInterpersonales);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(PsicologicoRelacionesInterpersonalesBE e_PsicologicoRelacionesInterpersonales)
        {
            try
            {
                PsicologicoRelacionesInterpersonalesDA o_PsicologicoRelacionesInterpersonales = new PsicologicoRelacionesInterpersonalesDA();
                int resp = o_PsicologicoRelacionesInterpersonales.Anular(e_PsicologicoRelacionesInterpersonales);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PsicologicoRelacionesInterpersonalesBE> Consultar_Lista()
        {
            List<PsicologicoRelacionesInterpersonalesBE> lista = new List<PsicologicoRelacionesInterpersonalesBE>();
            try
            {
                PsicologicoRelacionesInterpersonalesDA o_PsicologicoRelacionesInterpersonales = new PsicologicoRelacionesInterpersonalesDA();
                return o_PsicologicoRelacionesInterpersonales.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PsicologicoRelacionesInterpersonalesBE> Consultar_PK(
                              int m_PsicologicoRelacionesInterpersonales
                              )
        {
            List<PsicologicoRelacionesInterpersonalesBE> lista = new List<PsicologicoRelacionesInterpersonalesBE>();
            try
            {
                PsicologicoRelacionesInterpersonalesDA o_PsicologicoRelacionesInterpersonales = new PsicologicoRelacionesInterpersonalesDA();
                return o_PsicologicoRelacionesInterpersonales.Consultar_PK(
                                                            m_PsicologicoRelacionesInterpersonales
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
                PsicologicoRelacionesInterpersonalesDA o_PsicologicoRelacionesInterpersonales = new PsicologicoRelacionesInterpersonalesDA();
                idMax = o_PsicologicoRelacionesInterpersonales.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
