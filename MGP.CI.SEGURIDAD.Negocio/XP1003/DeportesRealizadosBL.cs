using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class DeportesRealizadosBL : BaseBL
    {
        const string Nombre_Clase = "DeportesRealizadosBL";
        private string m_BaseDatos = string.Empty;

        public DeportesRealizadosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public DeportesRealizadosBL() { }

        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new DeportesRealizadosDA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        public bool Insertar(DeportesRealizadosBE e_DeportesRealizados)
        {
            try
            {
                DeportesRealizadosDA o_DeportesRealizados = new DeportesRealizadosDA(m_BaseDatos);
                int resp = o_DeportesRealizados.Insertar(e_DeportesRealizados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(DeportesRealizadosBE e_DeportesRealizados)
        {
            try
            {
                DeportesRealizadosDA o_DeportesRealizados = new DeportesRealizadosDA(m_BaseDatos);
                int resp = o_DeportesRealizados.Actualizar(e_DeportesRealizados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DeportesRealizadosBE e_DeportesRealizados)
        {
            try
            {
                DeportesRealizadosDA o_DeportesRealizados = new DeportesRealizadosDA(m_BaseDatos);
                int resp = o_DeportesRealizados.Anular(e_DeportesRealizados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DeportesRealizadosBE> Consultar_Lista()
        {
            List<DeportesRealizadosBE> lista = new List<DeportesRealizadosBE>();
            try
            {
                DeportesRealizadosDA o_DeportesRealizados = new DeportesRealizadosDA(m_BaseDatos);
                return o_DeportesRealizados.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DeportesRealizadosBE> Consultar_PK(
                              int m_DeportesRealizadosId
                              )
        {
            List<DeportesRealizadosBE> lista = new List<DeportesRealizadosBE>();
            try
            {
                DeportesRealizadosDA o_DeportesRealizados = new DeportesRealizadosDA(m_BaseDatos);
                return o_DeportesRealizados.Consultar_PK(
                                                            m_DeportesRealizadosId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
