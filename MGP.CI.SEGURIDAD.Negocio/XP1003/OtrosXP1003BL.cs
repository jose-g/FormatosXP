using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class OtrosXP1003BL : BaseBL
    {
        const string Nombre_Clase = "OtrosXP1003BL";
        private string m_BaseDatos = string.Empty;

        public OtrosXP1003BL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public OtrosXP1003BL() {  }

        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new OtrosXP1003DA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        public bool Insertar(OtrosXP1003BE e_OtrosXP1003)
        {
            try
            {
                OtrosXP1003DA o_OtrosXP1003 = new OtrosXP1003DA(m_BaseDatos);
                int resp = o_OtrosXP1003.Insertar(e_OtrosXP1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(OtrosXP1003BE e_OtrosXP1003)
        {
            try
            {
                OtrosXP1003DA o_OtrosXP1003 = new OtrosXP1003DA(m_BaseDatos);
                int resp = o_OtrosXP1003.Actualizar(e_OtrosXP1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(OtrosXP1003BE e_OtrosXP1003)
        {
            try
            {
                OtrosXP1003DA o_OtrosXP1003 = new OtrosXP1003DA(m_BaseDatos);
                int resp = o_OtrosXP1003.Anular(e_OtrosXP1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<OtrosXP1003BE> Consultar_Lista()
        {
            List<OtrosXP1003BE> lista = new List<OtrosXP1003BE>();
            try
            {
                OtrosXP1003DA o_OtrosXP1003 = new OtrosXP1003DA(m_BaseDatos);
                return o_OtrosXP1003.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<OtrosXP1003BE> Consultar_PK(
                              int m_OtrosId
                              )
        {
            List<OtrosXP1003BE> lista = new List<OtrosXP1003BE>();
            try
            {
                OtrosXP1003DA o_OtrosXP1003 = new OtrosXP1003DA(m_BaseDatos);
                return o_OtrosXP1003.Consultar_PK(
                                                            m_OtrosId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
