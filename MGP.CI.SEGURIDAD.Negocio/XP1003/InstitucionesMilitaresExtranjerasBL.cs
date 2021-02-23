using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class InstitucionesMilitaresExtranjerasBL : BaseBL
    {
        const string Nombre_Clase = "InstitucionesMilitaresExtranjerasBL";
        private string m_BaseDatos = string.Empty;

        public InstitucionesMilitaresExtranjerasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public InstitucionesMilitaresExtranjerasBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(InstitucionesMilitaresExtranjerasBE e_InstitucionesMilitaresExtranjeras)
        {
            try
            {
                InstitucionesMilitaresExtranjerasDA o_InstitucionesMilitaresExtranjeras = new InstitucionesMilitaresExtranjerasDA(m_BaseDatos);
                int resp = o_InstitucionesMilitaresExtranjeras.Insertar(e_InstitucionesMilitaresExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(InstitucionesMilitaresExtranjerasBE e_InstitucionesMilitaresExtranjeras)
        {
            try
            {
                InstitucionesMilitaresExtranjerasDA o_InstitucionesMilitaresExtranjeras = new InstitucionesMilitaresExtranjerasDA(m_BaseDatos);
                int resp = o_InstitucionesMilitaresExtranjeras.Actualizar(e_InstitucionesMilitaresExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(InstitucionesMilitaresExtranjerasBE e_InstitucionesMilitaresExtranjeras)
        {
            try
            {
                InstitucionesMilitaresExtranjerasDA o_InstitucionesMilitaresExtranjeras = new InstitucionesMilitaresExtranjerasDA(m_BaseDatos);
                int resp = o_InstitucionesMilitaresExtranjeras.Anular(e_InstitucionesMilitaresExtranjeras);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<InstitucionesMilitaresExtranjerasBE> Consultar_Lista()
        {
            List<InstitucionesMilitaresExtranjerasBE> lista = new List<InstitucionesMilitaresExtranjerasBE>();
            try
            {
                InstitucionesMilitaresExtranjerasDA o_InstitucionesMilitaresExtranjeras = new InstitucionesMilitaresExtranjerasDA(m_BaseDatos);
                return o_InstitucionesMilitaresExtranjeras.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<InstitucionesMilitaresExtranjerasBE> Consultar_PK(
                              int m_InstitucionMilitarExtranjeraId
                              )
        {
            List<InstitucionesMilitaresExtranjerasBE> lista = new List<InstitucionesMilitaresExtranjerasBE>();
            try
            {
                InstitucionesMilitaresExtranjerasDA o_InstitucionesMilitaresExtranjeras = new InstitucionesMilitaresExtranjerasDA(m_BaseDatos);
                return o_InstitucionesMilitaresExtranjeras.Consultar_PK(
                                                            m_InstitucionMilitarExtranjeraId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
