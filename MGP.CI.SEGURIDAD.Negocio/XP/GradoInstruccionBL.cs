using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class GradoInstruccionBL : BaseBL
    {
        const string Nombre_Clase = "GradoInstruccionBL";
        private string m_BaseDatos = string.Empty;

        public GradoInstruccionBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(GradoInstruccionBE e_GradoInstruccion)
        {
            try
            {
                GradoInstruccionDA o_GradoInstruccion = new GradoInstruccionDA(m_BaseDatos);
                int resp = o_GradoInstruccion.Insertar(e_GradoInstruccion);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(GradoInstruccionBE e_GradoInstruccion)
        {
            try
            {
                GradoInstruccionDA o_GradoInstruccion = new GradoInstruccionDA(m_BaseDatos);
                int resp = o_GradoInstruccion.Actualizar(e_GradoInstruccion);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(GradoInstruccionBE e_GradoInstruccion)
        {
            try
            {
                GradoInstruccionDA o_GradoInstruccion = new GradoInstruccionDA(m_BaseDatos);
                int resp = o_GradoInstruccion.Anular(e_GradoInstruccion);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<GradoInstruccionBE> Consultar_Lista()
        {
            List<GradoInstruccionBE> lista = new List<GradoInstruccionBE>();
            try
            {
                GradoInstruccionDA o_GradoInstruccion = new GradoInstruccionDA(m_BaseDatos);
                return o_GradoInstruccion.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<GradoInstruccionBE> Consultar_PK(
                              int m_GradoInstruccionId
                              )
        {
            List<GradoInstruccionBE> lista = new List<GradoInstruccionBE>();
            try
            {
                GradoInstruccionDA o_GradoInstruccion = new GradoInstruccionDA(m_BaseDatos);
                return o_GradoInstruccion.Consultar_PK(
                                                            m_GradoInstruccionId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
