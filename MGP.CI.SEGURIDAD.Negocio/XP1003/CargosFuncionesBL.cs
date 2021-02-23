using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class CargosFuncionesBL : BaseBL
    {
        const string Nombre_Clase = "CargosFuncionesBL";
        private string m_BaseDatos = string.Empty;

        public CargosFuncionesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public CargosFuncionesBL() { }


        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new CargosFuncionesDA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }



        public bool Insertar(CargosFuncionesBE e_CargosFunciones)
        {
            try
            {
                CargosFuncionesDA o_CargosFunciones = new CargosFuncionesDA(m_BaseDatos);
                int resp = o_CargosFunciones.Insertar(e_CargosFunciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(CargosFuncionesBE e_CargosFunciones)
        {
            try
            {
                CargosFuncionesDA o_CargosFunciones = new CargosFuncionesDA(m_BaseDatos);
                int resp = o_CargosFunciones.Actualizar(e_CargosFunciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(CargosFuncionesBE e_CargosFunciones)
        {
            try
            {
                CargosFuncionesDA o_CargosFunciones = new CargosFuncionesDA(m_BaseDatos);
                int resp = o_CargosFunciones.Anular(e_CargosFunciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CargosFuncionesBE> Consultar_Lista()
        {
            List<CargosFuncionesBE> lista = new List<CargosFuncionesBE>();
            try
            {
                CargosFuncionesDA o_CargosFunciones = new CargosFuncionesDA(m_BaseDatos);
                return o_CargosFunciones.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CargosFuncionesBE> Consultar_PK(
                              int m_CargosFuncionesId
                              )
        {
            List<CargosFuncionesBE> lista = new List<CargosFuncionesBE>();
            try
            {
                CargosFuncionesDA o_CargosFunciones = new CargosFuncionesDA(m_BaseDatos);
                return o_CargosFunciones.Consultar_PK(
                                                            m_CargosFuncionesId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
