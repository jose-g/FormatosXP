using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class EnfermedadesBL : BaseBL
    {
        const string Nombre_Clase = "EnfermedadesBL";
        private string m_BaseDatos = string.Empty;

        public EnfermedadesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public EnfermedadesBL() { }

        protected internal bool Insertar(EnfermedadesBE e_Enfermedades)
        {
            try
            {
                EnfermedadesDA o_Enfermedades = new EnfermedadesDA(m_BaseDatos);
                int resp = o_Enfermedades.Insertar(e_Enfermedades);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(EnfermedadesBE e_Enfermedades)
        {
            try
            {
                EnfermedadesDA o_Enfermedades = new EnfermedadesDA(m_BaseDatos);
                int resp = o_Enfermedades.Actualizar(e_Enfermedades);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(EnfermedadesBE e_Enfermedades)
        {
            try
            {
                EnfermedadesDA o_Enfermedades = new EnfermedadesDA(m_BaseDatos);
                int resp = o_Enfermedades.Anular(e_Enfermedades);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EnfermedadesBE> Consultar_Lista()
        {
            List<EnfermedadesBE> lista = new List<EnfermedadesBE>();
            try
            {
                EnfermedadesDA o_Enfermedades = new EnfermedadesDA(m_BaseDatos);
                return o_Enfermedades.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EnfermedadesBE> Consultar_PK(
                              int m_EnfermedadesId
                              )
        {
            List<EnfermedadesBE> lista = new List<EnfermedadesBE>();
            try
            {
                EnfermedadesDA o_Enfermedades = new EnfermedadesDA(m_BaseDatos);
                return o_Enfermedades.Consultar_PK(
                                                            m_EnfermedadesId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
