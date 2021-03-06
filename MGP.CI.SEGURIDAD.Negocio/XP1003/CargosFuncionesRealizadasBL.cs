using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class CargosFuncionesRealizadasBL : BaseBL
    {
        const string Nombre_Clase = "CargosFuncionesRealizadasBL";
        private string m_BaseDatos = string.Empty;

        public CargosFuncionesRealizadasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public CargosFuncionesRealizadasBL() { }

        protected internal bool Insertar(CargosFuncionesRealizadasBE e_CargosFuncionesRealizadas)
        {
            try
            {
                CargosFuncionesRealizadasDA o_CargosFuncionesRealizadas = new CargosFuncionesRealizadasDA(m_BaseDatos);
                int resp = o_CargosFuncionesRealizadas.Insertar(e_CargosFuncionesRealizadas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(CargosFuncionesRealizadasBE e_CargosFuncionesRealizadas)
        {
            try
            {
                CargosFuncionesRealizadasDA o_CargosFuncionesRealizadas = new CargosFuncionesRealizadasDA(m_BaseDatos);
                int resp = o_CargosFuncionesRealizadas.Actualizar(e_CargosFuncionesRealizadas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(CargosFuncionesRealizadasBE e_CargosFuncionesRealizadas)
        {
            try
            {
                CargosFuncionesRealizadasDA o_CargosFuncionesRealizadas = new CargosFuncionesRealizadasDA(m_BaseDatos);
                int resp = o_CargosFuncionesRealizadas.Anular(e_CargosFuncionesRealizadas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CargosFuncionesRealizadasBE> Consultar_Lista()
        {
            List<CargosFuncionesRealizadasBE> lista = new List<CargosFuncionesRealizadasBE>();
            try
            {
                CargosFuncionesRealizadasDA o_CargosFuncionesRealizadas = new CargosFuncionesRealizadasDA(m_BaseDatos);
                return o_CargosFuncionesRealizadas.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CargosFuncionesRealizadasBE> Consultar_PK(
                              int m_CargosFuncionesRealizadas
                              )
        {
            List<CargosFuncionesRealizadasBE> lista = new List<CargosFuncionesRealizadasBE>();
            try
            {
                CargosFuncionesRealizadasDA o_CargosFuncionesRealizadas = new CargosFuncionesRealizadasDA(m_BaseDatos);
                return o_CargosFuncionesRealizadas.Consultar_PK(
                                                            m_CargosFuncionesRealizadas
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
