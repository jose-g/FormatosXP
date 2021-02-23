using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class ContinentesBL : BaseBL
    {
        const string Nombre_Clase = "ContinentesBL";
        private string m_BaseDatos = string.Empty;

        public ContinentesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public ContinentesBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(ContinentesBE e_Continentes)
        {
            try
            {
                ContinentesDA o_Continentes = new ContinentesDA(m_BaseDatos);
                int resp = o_Continentes.Insertar(e_Continentes);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(ContinentesBE e_Continentes)
        {
            try
            {
                ContinentesDA o_Continentes = new ContinentesDA(m_BaseDatos);
                int resp = o_Continentes.Actualizar(e_Continentes);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(ContinentesBE e_Continentes)
        {
            try
            {
                ContinentesDA o_Continentes = new ContinentesDA(m_BaseDatos);
                int resp = o_Continentes.Anular(e_Continentes);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ContinentesBE> Consultar_Lista()
        {
            List<ContinentesBE> lista = new List<ContinentesBE>();
            try
            {
                ContinentesDA o_Continentes = new ContinentesDA(m_BaseDatos);
                return o_Continentes.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ContinentesBE> Consultar_PK(
                              int m_ContinenteId
                              )
        {
            List<ContinentesBE> lista = new List<ContinentesBE>();
            try
            {
                ContinentesDA o_Continentes = new ContinentesDA(m_BaseDatos);
                return o_Continentes.Consultar_PK(
                                                            m_ContinenteId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
