using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class DatosFamiliares1003BL : BaseBL
    {
        const string Nombre_Clase = "DatosFamiliares1003BL";
        private string m_BaseDatos = string.Empty;

        public DatosFamiliares1003BL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public DatosFamiliares1003BL() { }

        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new DatosFamiliares1003DA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(DatosFamiliares1003BE e_DatosFamiliares1003)
        {
            try
            {
                DatosFamiliares1003DA o_DatosFamiliares1003 = new DatosFamiliares1003DA(m_BaseDatos);
                int resp = o_DatosFamiliares1003.Insertar(e_DatosFamiliares1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(DatosFamiliares1003BE e_DatosFamiliares1003)
        {
            try
            {
                DatosFamiliares1003DA o_DatosFamiliares1003 = new DatosFamiliares1003DA(m_BaseDatos);
                int resp = o_DatosFamiliares1003.Actualizar(e_DatosFamiliares1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DatosFamiliares1003BE e_DatosFamiliares1003)
        {
            try
            {
                DatosFamiliares1003DA o_DatosFamiliares1003 = new DatosFamiliares1003DA(m_BaseDatos);
                int resp = o_DatosFamiliares1003.Anular(e_DatosFamiliares1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DatosFamiliares1003BE> Consultar_Lista()
        {
            List<DatosFamiliares1003BE> lista = new List<DatosFamiliares1003BE>();
            try
            {
                DatosFamiliares1003DA o_DatosFamiliares1003 = new DatosFamiliares1003DA(m_BaseDatos);
                return o_DatosFamiliares1003.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DatosFamiliares1003BE> Consultar_PK(
                              int m_FamiliarId
                              )
        {
            List<DatosFamiliares1003BE> lista = new List<DatosFamiliares1003BE>();
            try
            {
                DatosFamiliares1003DA o_DatosFamiliares1003 = new DatosFamiliares1003DA(m_BaseDatos);
                return o_DatosFamiliares1003.Consultar_PK(
                                                            m_FamiliarId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
