using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class CursosEscuelasExtranjerasBL : BaseBL
    {
        const string Nombre_Clase = "CursosEscuelasExtranjerasBL";
        private string m_BaseDatos = string.Empty;

        public CursosEscuelasExtranjerasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public CursosEscuelasExtranjerasBL() { }

        protected internal bool Insertar(CursosEscuelasExtranjerasBE e_CursosEscuelasExtranjeras)
        {
            try
            {
                CursosEscuelasExtranjerasDA o_CursosEscuelasExtranjeras = new CursosEscuelasExtranjerasDA(m_BaseDatos);
                int resp = o_CursosEscuelasExtranjeras.Insertar(e_CursosEscuelasExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(CursosEscuelasExtranjerasBE e_CursosEscuelasExtranjeras)
        {
            try
            {
                CursosEscuelasExtranjerasDA o_CursosEscuelasExtranjeras = new CursosEscuelasExtranjerasDA(m_BaseDatos);
                int resp = o_CursosEscuelasExtranjeras.Actualizar(e_CursosEscuelasExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(CursosEscuelasExtranjerasBE e_CursosEscuelasExtranjeras)
        {
            try
            {
                CursosEscuelasExtranjerasDA o_CursosEscuelasExtranjeras = new CursosEscuelasExtranjerasDA(m_BaseDatos);
                int resp = o_CursosEscuelasExtranjeras.Anular(e_CursosEscuelasExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CursosEscuelasExtranjerasBE> Consultar_Lista()
        {
            List<CursosEscuelasExtranjerasBE> lista = new List<CursosEscuelasExtranjerasBE>();
            try
            {
                CursosEscuelasExtranjerasDA o_CursosEscuelasExtranjeras = new CursosEscuelasExtranjerasDA(m_BaseDatos);
                return o_CursosEscuelasExtranjeras.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CursosEscuelasExtranjerasBE> Consultar_PK(
                              int m_CursoEscuelaExtranjeraId
                              )
        {
            List<CursosEscuelasExtranjerasBE> lista = new List<CursosEscuelasExtranjerasBE>();
            try
            {
                CursosEscuelasExtranjerasDA o_CursosEscuelasExtranjeras = new CursosEscuelasExtranjerasDA(m_BaseDatos);
                return o_CursosEscuelasExtranjeras.Consultar_PK(
                                                            m_CursoEscuelaExtranjeraId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
