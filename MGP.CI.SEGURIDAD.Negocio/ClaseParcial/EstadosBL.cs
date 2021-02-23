using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class EstadosBL : BaseBL
    {
        const string Nombre_Clase = "EstadosBL";
        private string m_BaseDatos = string.Empty;

        public EstadosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public EstadosBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(EstadosBE e_Estados)
        {
            try
            {
                EstadosDA o_Estados = new EstadosDA(m_BaseDatos);
                int resp = o_Estados.Insertar(e_Estados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(EstadosBE e_Estados)
        {
            try
            {
                EstadosDA o_Estados = new EstadosDA(m_BaseDatos);
                int resp = o_Estados.Actualizar(e_Estados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(EstadosBE e_Estados)
        {
            try
            {
                EstadosDA o_Estados = new EstadosDA(m_BaseDatos);
                int resp = o_Estados.Anular(e_Estados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EstadosBE> Consultar_Lista()
        {
            List<EstadosBE> lista = new List<EstadosBE>();
            try
            {
                EstadosDA o_Estados = new EstadosDA(m_BaseDatos);
                return o_Estados.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EstadosBE> Consultar_PK(
                              int m_EstadoId
                              )
        {
            List<EstadosBE> lista = new List<EstadosBE>();
            try
            {
                EstadosDA o_Estados = new EstadosDA(m_BaseDatos);
                return o_Estados.Consultar_PK(m_EstadoId);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
