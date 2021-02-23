using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class RasgosTiposBL : BaseBL
    {
        const string Nombre_Clase = "RasgosTiposBL";
        private string m_BaseDatos = string.Empty;

        public RasgosTiposBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(RasgosTiposBE e_RasgosTipos)
        {
            try
            {
                RasgosTiposDA o_RasgosTipos = new RasgosTiposDA(m_BaseDatos);
                int resp = o_RasgosTipos.Insertar(e_RasgosTipos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(RasgosTiposBE e_RasgosTipos)
        {
            try
            {
                RasgosTiposDA o_RasgosTipos = new RasgosTiposDA(m_BaseDatos);
                int resp = o_RasgosTipos.Actualizar(e_RasgosTipos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(RasgosTiposBE e_RasgosTipos)
        {
            try
            {
                RasgosTiposDA o_RasgosTipos = new RasgosTiposDA(m_BaseDatos);
                int resp = o_RasgosTipos.Anular(e_RasgosTipos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<RasgosTiposBE> Consultar_Lista()
        {
            List<RasgosTiposBE> lista = new List<RasgosTiposBE>();
            try
            {
                RasgosTiposDA o_RasgosTipos = new RasgosTiposDA(m_BaseDatos);
                return o_RasgosTipos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<RasgosTiposBE> Consultar_PK(
                              int m_RasgoTipoId
                              )
        {
            List<RasgosTiposBE> lista = new List<RasgosTiposBE>();
            try
            {
                RasgosTiposDA o_RasgosTipos = new RasgosTiposDA(m_BaseDatos);
                return o_RasgosTipos.Consultar_PK(
                                                            m_RasgoTipoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
