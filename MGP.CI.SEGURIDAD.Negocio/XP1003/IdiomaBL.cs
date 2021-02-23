using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class IdiomaBL : BaseBL
    {
        const string Nombre_Clase = "IdiomaBL";
        private string m_BaseDatos = string.Empty;

        public IdiomaBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public IdiomaBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(IdiomaBE e_Idioma)
        {
            try
            {
                IdiomaDA o_Idioma = new IdiomaDA(m_BaseDatos);
                int resp = o_Idioma.Insertar(e_Idioma);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(IdiomaBE e_Idioma)
        {
            try
            {
                IdiomaDA o_Idioma = new IdiomaDA(m_BaseDatos);
                int resp = o_Idioma.Actualizar(e_Idioma);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(IdiomaBE e_Idioma)
        {
            try
            {
                IdiomaDA o_Idioma = new IdiomaDA(m_BaseDatos);
                int resp = o_Idioma.Anular(e_Idioma);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<IdiomaBE> Consultar_Lista()
        {
            List<IdiomaBE> lista = new List<IdiomaBE>();
            try
            {
                IdiomaDA o_Idioma = new IdiomaDA(m_BaseDatos);
                return o_Idioma.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<IdiomaBE> Consultar_PK(
                              int m_IdiomaId
                              )
        {
            List<IdiomaBE> lista = new List<IdiomaBE>();
            try
            {
                IdiomaDA o_Idioma = new IdiomaDA(m_BaseDatos);
                return o_Idioma.Consultar_PK(
                                                            m_IdiomaId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
