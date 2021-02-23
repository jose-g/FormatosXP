using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class SalasJuzgadosBL : BaseBL
    {
        const string Nombre_Clase = "SalasJuzgadosBL";
        private string m_BaseDatos = string.Empty;

        public SalasJuzgadosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(SalasJuzgadosBE e_SalasJuzgados)
        {
            try
            {
                SalasJuzgadosDA o_SalasJuzgados = new SalasJuzgadosDA(m_BaseDatos);
                int resp = o_SalasJuzgados.Insertar(e_SalasJuzgados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(SalasJuzgadosBE e_SalasJuzgados)
        {
            try
            {
                SalasJuzgadosDA o_SalasJuzgados = new SalasJuzgadosDA(m_BaseDatos);
                int resp = o_SalasJuzgados.Actualizar(e_SalasJuzgados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(SalasJuzgadosBE e_SalasJuzgados)
        {
            try
            {
                SalasJuzgadosDA o_SalasJuzgados = new SalasJuzgadosDA(m_BaseDatos);
                int resp = o_SalasJuzgados.Anular(e_SalasJuzgados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<SalasJuzgadosBE> Consultar_Lista()
        {
            List<SalasJuzgadosBE> lista = new List<SalasJuzgadosBE>();
            try
            {
                SalasJuzgadosDA o_SalasJuzgados = new SalasJuzgadosDA(m_BaseDatos);
                return o_SalasJuzgados.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<SalasJuzgadosBE> Consultar_PK(
                              int m_SalaJuzgadoId
                              )
        {
            List<SalasJuzgadosBE> lista = new List<SalasJuzgadosBE>();
            try
            {
                SalasJuzgadosDA o_SalasJuzgados = new SalasJuzgadosDA(m_BaseDatos);
                return o_SalasJuzgados.Consultar_PK(
                                                            m_SalaJuzgadoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
