using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class CaracterTrato1005BL : BaseBL
    {
        const string Nombre_Clase = "CaracterTrato1005BL";
        private string m_BaseDatos = string.Empty;

        public CaracterTrato1005BL() {  }

        public bool Insertar(CaracterTrato1005BE e_CaracterTrato1005)
        {
            try
            {
                CaracterTrato1005DA o_CaracterTrato1005 = new CaracterTrato1005DA();
                int resp = o_CaracterTrato1005.Insertar(e_CaracterTrato1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(CaracterTrato1005BE e_CaracterTrato1005)
        {
            try
            {
                CaracterTrato1005DA o_CaracterTrato1005 = new CaracterTrato1005DA();
                int resp = o_CaracterTrato1005.Actualizar(e_CaracterTrato1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(CaracterTrato1005BE e_CaracterTrato1005)
        {
            try
            {
                CaracterTrato1005DA o_CaracterTrato1005 = new CaracterTrato1005DA();
                int resp = o_CaracterTrato1005.Anular(e_CaracterTrato1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CaracterTrato1005BE> Consultar_Lista()
        {
            List<CaracterTrato1005BE> lista = new List<CaracterTrato1005BE>();
            try
            {
                CaracterTrato1005DA o_CaracterTrato1005 = new CaracterTrato1005DA();
                return o_CaracterTrato1005.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CaracterTrato1005BE> Consultar_PK(
                              int m_CaracterTrato1005Id
                              )
        {
            List<CaracterTrato1005BE> lista = new List<CaracterTrato1005BE>();
            try
            {
                CaracterTrato1005DA o_CaracterTrato1005 = new CaracterTrato1005DA();
                return o_CaracterTrato1005.Consultar_PK(
                                                            m_CaracterTrato1005Id
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
                CaracterTrato1005DA o_CaracterTrato1005 = new CaracterTrato1005DA();
                idMax = o_CaracterTrato1005.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
