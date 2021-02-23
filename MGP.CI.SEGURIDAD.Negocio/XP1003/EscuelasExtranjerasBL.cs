using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class EscuelasExtranjerasBL : BaseBL
    {
        const string Nombre_Clase = "EscuelasExtranjerasBL";
        private string m_BaseDatos = string.Empty;

        public EscuelasExtranjerasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public EscuelasExtranjerasBL() { }

        protected internal bool Insertar(EscuelasExtranjerasBE e_EscuelasExtranjeras)
        {
            try
            {
                EscuelasExtranjerasDA o_EscuelasExtranjeras = new EscuelasExtranjerasDA(m_BaseDatos);
                int resp = o_EscuelasExtranjeras.Insertar(e_EscuelasExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(EscuelasExtranjerasBE e_EscuelasExtranjeras)
        {
            try
            {
                EscuelasExtranjerasDA o_EscuelasExtranjeras = new EscuelasExtranjerasDA(m_BaseDatos);
                int resp = o_EscuelasExtranjeras.Actualizar(e_EscuelasExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(EscuelasExtranjerasBE e_EscuelasExtranjeras)
        {
            try
            {
                EscuelasExtranjerasDA o_EscuelasExtranjeras = new EscuelasExtranjerasDA(m_BaseDatos);
                int resp = o_EscuelasExtranjeras.Anular(e_EscuelasExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EscuelasExtranjerasBE> Consultar_Lista()
        {
            List<EscuelasExtranjerasBE> lista = new List<EscuelasExtranjerasBE>();
            try
            {
                EscuelasExtranjerasDA o_EscuelasExtranjeras = new EscuelasExtranjerasDA(m_BaseDatos);
                return o_EscuelasExtranjeras.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EscuelasExtranjerasBE> Consultar_PK(
                              int m_EscuelaExtranjeraId
                              )
        {
            List<EscuelasExtranjerasBE> lista = new List<EscuelasExtranjerasBE>();
            try
            {
                EscuelasExtranjerasDA o_EscuelasExtranjeras = new EscuelasExtranjerasDA(m_BaseDatos);
                return o_EscuelasExtranjeras.Consultar_PK(
                                                            m_EscuelaExtranjeraId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
