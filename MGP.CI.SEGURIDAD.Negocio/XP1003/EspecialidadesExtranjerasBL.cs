using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class EspecialidadesExtranjerasBL : BaseBL
    {
        const string Nombre_Clase = "EspecialidadesExtranjerasBL";
        private string m_BaseDatos = string.Empty;

        public EspecialidadesExtranjerasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public EspecialidadesExtranjerasBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(EspecialidadesExtranjerasBE e_EspecialidadesExtranjeras)
        {
            try
            {
                EspecialidadesExtranjerasDA o_EspecialidadesExtranjeras = new EspecialidadesExtranjerasDA(m_BaseDatos);
                int resp = o_EspecialidadesExtranjeras.Insertar(e_EspecialidadesExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(EspecialidadesExtranjerasBE e_EspecialidadesExtranjeras)
        {
            try
            {
                EspecialidadesExtranjerasDA o_EspecialidadesExtranjeras = new EspecialidadesExtranjerasDA(m_BaseDatos);
                int resp = o_EspecialidadesExtranjeras.Actualizar(e_EspecialidadesExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(EspecialidadesExtranjerasBE e_EspecialidadesExtranjeras)
        {
            try
            {
                EspecialidadesExtranjerasDA o_EspecialidadesExtranjeras = new EspecialidadesExtranjerasDA(m_BaseDatos);
                int resp = o_EspecialidadesExtranjeras.Anular(e_EspecialidadesExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EspecialidadesExtranjerasBE> Consultar_Lista()
        {
            List<EspecialidadesExtranjerasBE> lista = new List<EspecialidadesExtranjerasBE>();
            try
            {
                EspecialidadesExtranjerasDA o_EspecialidadesExtranjeras = new EspecialidadesExtranjerasDA(m_BaseDatos);
                return o_EspecialidadesExtranjeras.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EspecialidadesExtranjerasBE> Consultar_PK(
                              int m_EspecialidadesExtranjerasId
                              )
        {
            List<EspecialidadesExtranjerasBE> lista = new List<EspecialidadesExtranjerasBE>();
            try
            {
                EspecialidadesExtranjerasDA o_EspecialidadesExtranjeras = new EspecialidadesExtranjerasDA(m_BaseDatos);
                return o_EspecialidadesExtranjeras.Consultar_PK(
                                                            m_EspecialidadesExtranjerasId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
