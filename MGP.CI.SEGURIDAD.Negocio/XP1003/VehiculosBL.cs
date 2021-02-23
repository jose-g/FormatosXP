using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class VehiculosBL : BaseBL
    {
        const string Nombre_Clase = "VehiculosBL";
        private string m_BaseDatos = string.Empty;

        public VehiculosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public VehiculosBL() {  }

        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new VehiculosDA(m_BaseDatos)).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(VehiculosBE e_Vehiculos)
        {
            try
            {
                VehiculosDA o_Vehiculos = new VehiculosDA(m_BaseDatos);
                int resp = o_Vehiculos.Insertar(e_Vehiculos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(VehiculosBE e_Vehiculos)
        {
            try
            {
                VehiculosDA o_Vehiculos = new VehiculosDA(m_BaseDatos);
                int resp = o_Vehiculos.Actualizar(e_Vehiculos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(VehiculosBE e_Vehiculos)
        {
            try
            {
                VehiculosDA o_Vehiculos = new VehiculosDA(m_BaseDatos);
                int resp = o_Vehiculos.Anular(e_Vehiculos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<VehiculosBE> Consultar_Lista()
        {
            List<VehiculosBE> lista = new List<VehiculosBE>();
            try
            {
                VehiculosDA o_Vehiculos = new VehiculosDA(m_BaseDatos);
                return o_Vehiculos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<VehiculosBE> Consultar_PK(
                              int m_VehiculoId
                              )
        {
            List<VehiculosBE> lista = new List<VehiculosBE>();
            try
            {
                VehiculosDA o_Vehiculos = new VehiculosDA(m_BaseDatos);
                return o_Vehiculos.Consultar_PK(
                                                            m_VehiculoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
