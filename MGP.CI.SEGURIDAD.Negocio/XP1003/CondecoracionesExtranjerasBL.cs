using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class CondecoracionesExtranjerasBL : BaseBL
    {
        const string Nombre_Clase = "CondecoracionesExtranjerasBL";
        private string m_BaseDatos = string.Empty;

        public CondecoracionesExtranjerasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public CondecoracionesExtranjerasBL() { }

        protected internal bool Insertar(CondecoracionesExtranjerasBE e_CondecoracionesExtranjeras)
        {
            try
            {
                CondecoracionesExtranjerasDA o_CondecoracionesExtranjeras = new CondecoracionesExtranjerasDA(m_BaseDatos);
                int resp = o_CondecoracionesExtranjeras.Insertar(e_CondecoracionesExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(CondecoracionesExtranjerasBE e_CondecoracionesExtranjeras)
        {
            try
            {
                CondecoracionesExtranjerasDA o_CondecoracionesExtranjeras = new CondecoracionesExtranjerasDA(m_BaseDatos);
                int resp = o_CondecoracionesExtranjeras.Actualizar(e_CondecoracionesExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(CondecoracionesExtranjerasBE e_CondecoracionesExtranjeras)
        {
            try
            {
                CondecoracionesExtranjerasDA o_CondecoracionesExtranjeras = new CondecoracionesExtranjerasDA(m_BaseDatos);
                int resp = o_CondecoracionesExtranjeras.Anular(e_CondecoracionesExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CondecoracionesExtranjerasBE> Consultar_Lista()
        {
            List<CondecoracionesExtranjerasBE> lista = new List<CondecoracionesExtranjerasBE>();
            try
            {
                CondecoracionesExtranjerasDA o_CondecoracionesExtranjeras = new CondecoracionesExtranjerasDA(m_BaseDatos);
                return o_CondecoracionesExtranjeras.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CondecoracionesExtranjerasBE> Consultar_PK(
                              int m_CondecoracionesExtranjerasId
                              )
        {
            List<CondecoracionesExtranjerasBE> lista = new List<CondecoracionesExtranjerasBE>();
            try
            {
                CondecoracionesExtranjerasDA o_CondecoracionesExtranjeras = new CondecoracionesExtranjerasDA(m_BaseDatos);
                return o_CondecoracionesExtranjeras.Consultar_PK(
                                                            m_CondecoracionesExtranjerasId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
