using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class Ficha1003BL : BaseBL
    {
        const string Nombre_Clase = "Ficha1003BL";
        private string m_BaseDatos = string.Empty;

        public Ficha1003BL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public Ficha1003BL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(Ficha1003BE e_Ficha1003)
        {
            try
            {
                Ficha1003DA o_Ficha1003 = new Ficha1003DA(m_BaseDatos);
                int resp = o_Ficha1003.Insertar(e_Ficha1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(Ficha1003BE e_Ficha1003)
        {
            try
            {
                Ficha1003DA o_Ficha1003 = new Ficha1003DA(m_BaseDatos);
                int resp = o_Ficha1003.Actualizar(e_Ficha1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(Ficha1003BE e_Ficha1003)
        {
            try
            {
                Ficha1003DA o_Ficha1003 = new Ficha1003DA(m_BaseDatos);
                int resp = o_Ficha1003.Anular(e_Ficha1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Ficha1003BE> Consultar_Lista()
        {
            List<Ficha1003BE> lista = new List<Ficha1003BE>();
            try
            {
                Ficha1003DA o_Ficha1003 = new Ficha1003DA(m_BaseDatos);
                return o_Ficha1003.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Ficha1003BE> Consultar_PK(
                              int m_Ficha1003Id
                              )
        {
            List<Ficha1003BE> lista = new List<Ficha1003BE>();
            try
            {
                Ficha1003DA o_Ficha1003 = new Ficha1003DA(m_BaseDatos);
                return o_Ficha1003.Consultar_PK(
                                                            m_Ficha1003Id
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
