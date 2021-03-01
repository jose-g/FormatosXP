using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class CargosFuncionesX1003BL : BaseBL
    {
        const string Nombre_Clase = "CargosFuncionesX1003BL";
        private string m_BaseDatos = string.Empty;

        public CargosFuncionesX1003BL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public CargosFuncionesX1003BL() { }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new CargosFuncionesX1003DA(m_BaseDatos)).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(CargosFuncionesX1003BE e_CargosFuncionesX1003)
        {
            try
            {
                CargosFuncionesX1003DA o_CargosFuncionesX1003 = new CargosFuncionesX1003DA(m_BaseDatos);
                int resp = o_CargosFuncionesX1003.Insertar(e_CargosFuncionesX1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(CargosFuncionesX1003BE e_CargosFuncionesX1003)
        {
            try
            {
                CargosFuncionesX1003DA o_CargosFuncionesX1003 = new CargosFuncionesX1003DA(m_BaseDatos);
                int resp = o_CargosFuncionesX1003.Actualizar(e_CargosFuncionesX1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(CargosFuncionesX1003BE e_CargosFuncionesX1003)
        {
            try
            {
                CargosFuncionesX1003DA o_CargosFuncionesX1003 = new CargosFuncionesX1003DA(m_BaseDatos);
                int resp = o_CargosFuncionesX1003.Anular(e_CargosFuncionesX1003);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CargosFuncionesX1003BE> Consultar_Lista()
        {
            List<CargosFuncionesX1003BE> lista = new List<CargosFuncionesX1003BE>();
            try
            {
                CargosFuncionesX1003DA o_CargosFuncionesX1003 = new CargosFuncionesX1003DA(m_BaseDatos);
                return o_CargosFuncionesX1003.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CargosFuncionesX1003BE> Consultar_PK(
                              int m_CargosFuncionesX1003Id
                              )
        {
            List<CargosFuncionesX1003BE> lista = new List<CargosFuncionesX1003BE>();
            try
            {
                CargosFuncionesX1003DA o_CargosFuncionesX1003 = new CargosFuncionesX1003DA(m_BaseDatos);
                return o_CargosFuncionesX1003.Consultar_PK(
                                                            m_CargosFuncionesX1003Id
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<CargosFuncionesX1003BE> Consultar_FK(
              int m_FichaId
              )
        {
            List<CargosFuncionesX1003BE> lista = new List<CargosFuncionesX1003BE>();
            try
            {
                CargosFuncionesX1003DA o_DatosPersonales1003 = new CargosFuncionesX1003DA(m_BaseDatos);
                return o_DatosPersonales1003.Consultar_FK(m_FichaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
    }
}
