using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class DatosPersonales1003BL : BaseBL
    {
        const string Nombre_Clase = "DatosPersonales1003BL";
        private string m_BaseDatos = string.Empty;

        public DatosPersonales1003BL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public DatosPersonales1003BL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(DatosPersonales1003BE e_DatosPersonales1003)
        {
            try
            {
                DatosPersonales1003DA o_DatosPersonales1003 = new DatosPersonales1003DA(m_BaseDatos);
                int resp = o_DatosPersonales1003.Insertar(e_DatosPersonales1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(DatosPersonales1003BE e_DatosPersonales1003)
        {
            try
            {
                DatosPersonales1003DA o_DatosPersonales1003 = new DatosPersonales1003DA(m_BaseDatos);
                int resp = o_DatosPersonales1003.Actualizar(e_DatosPersonales1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DatosPersonales1003BE e_DatosPersonales1003)
        {
            try
            {
                DatosPersonales1003DA o_DatosPersonales1003 = new DatosPersonales1003DA(m_BaseDatos);
                int resp = o_DatosPersonales1003.Anular(e_DatosPersonales1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new DatosPersonales1003DA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        public List<DatosPersonales1003BE> Consultar_Lista()
        {
            List<DatosPersonales1003BE> lista = new List<DatosPersonales1003BE>();
            try
            {
                DatosPersonales1003DA o_DatosPersonales1003 = new DatosPersonales1003DA(m_BaseDatos);
                return o_DatosPersonales1003.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DatosPersonales1003BE> Consultar_PK(
                              int m_DatosPersonalesId
                              )
        {
            List<DatosPersonales1003BE> lista = new List<DatosPersonales1003BE>();
            try
            {
                DatosPersonales1003DA o_DatosPersonales1003 = new DatosPersonales1003DA(m_BaseDatos);
                return o_DatosPersonales1003.Consultar_PK(
                                                            m_DatosPersonalesId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
