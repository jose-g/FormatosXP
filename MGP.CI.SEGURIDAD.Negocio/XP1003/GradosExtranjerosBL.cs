using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class GradosExtranjerosBL : BaseBL
    {
        const string Nombre_Clase = "GradosExtranjerosBL";
        private string m_BaseDatos = string.Empty;

        public GradosExtranjerosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public GradosExtranjerosBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(GradosExtranjerosBE e_GradosExtranjeros)
        {
            try
            {
                GradosExtranjerosDA o_GradosExtranjeros = new GradosExtranjerosDA(m_BaseDatos);
                int resp = o_GradosExtranjeros.Insertar(e_GradosExtranjeros);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(GradosExtranjerosBE e_GradosExtranjeros)
        {
            try
            {
                GradosExtranjerosDA o_GradosExtranjeros = new GradosExtranjerosDA(m_BaseDatos);
                int resp = o_GradosExtranjeros.Actualizar(e_GradosExtranjeros);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(GradosExtranjerosBE e_GradosExtranjeros)
        {
            try
            {
                GradosExtranjerosDA o_GradosExtranjeros = new GradosExtranjerosDA(m_BaseDatos);
                int resp = o_GradosExtranjeros.Anular(e_GradosExtranjeros);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<GradosExtranjerosBE> Consultar_Lista()
        {
            List<GradosExtranjerosBE> lista = new List<GradosExtranjerosBE>();
            try
            {
                GradosExtranjerosDA o_GradosExtranjeros = new GradosExtranjerosDA(m_BaseDatos);
                return o_GradosExtranjeros.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<GradosExtranjerosBE> Consultar_PK(
                              int m_GradoExtranjeroId
                              )
        {
            List<GradosExtranjerosBE> lista = new List<GradosExtranjerosBE>();
            try
            {
                GradosExtranjerosDA o_GradosExtranjeros = new GradosExtranjerosDA(m_BaseDatos);
                return o_GradosExtranjeros.Consultar_PK(
                                                            m_GradoExtranjeroId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
