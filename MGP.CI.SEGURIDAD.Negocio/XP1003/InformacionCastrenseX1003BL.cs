using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class InformacionCastrenseX1003BL : BaseBL
    {
        const string Nombre_Clase = "InformacionCastrenseX1003BL";
        private string m_BaseDatos = string.Empty;

        public InformacionCastrenseX1003BL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public InformacionCastrenseX1003BL() { }

        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new InformacionCastrenseX1003DA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        bool Insertar(InformacionCastrenseX1003BE e_InformacionCastrenseX1003)
        {
            try
            {
                InformacionCastrenseX1003DA o_InformacionCastrenseX1003 = new InformacionCastrenseX1003DA(m_BaseDatos);
                int resp = o_InformacionCastrenseX1003.Insertar(e_InformacionCastrenseX1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        bool Actualizar(InformacionCastrenseX1003BE e_InformacionCastrenseX1003)
        {
            try
            {
                InformacionCastrenseX1003DA o_InformacionCastrenseX1003 = new InformacionCastrenseX1003DA(m_BaseDatos);
                int resp = o_InformacionCastrenseX1003.Actualizar(e_InformacionCastrenseX1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        bool Anular(InformacionCastrenseX1003BE e_InformacionCastrenseX1003)
        {
            try
            {
                InformacionCastrenseX1003DA o_InformacionCastrenseX1003 = new InformacionCastrenseX1003DA(m_BaseDatos);
                int resp = o_InformacionCastrenseX1003.Anular(e_InformacionCastrenseX1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<InformacionCastrenseX1003BE> Consultar_Lista()
        {
            List<InformacionCastrenseX1003BE> lista = new List<InformacionCastrenseX1003BE>();
            try
            {
                InformacionCastrenseX1003DA o_InformacionCastrenseX1003 = new InformacionCastrenseX1003DA(m_BaseDatos);
                return o_InformacionCastrenseX1003.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<InformacionCastrenseX1003BE> Consultar_PK(
                              int m_InformacionCastrenseId
                              )
        {
            List<InformacionCastrenseX1003BE> lista = new List<InformacionCastrenseX1003BE>();
            try
            {
                InformacionCastrenseX1003DA o_InformacionCastrenseX1003 = new InformacionCastrenseX1003DA(m_BaseDatos);
                return o_InformacionCastrenseX1003.Consultar_PK(
                                                            m_InformacionCastrenseId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
