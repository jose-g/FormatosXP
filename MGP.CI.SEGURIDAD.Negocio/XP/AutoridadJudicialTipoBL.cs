using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class AutoridadJudicialTipoBL : BaseBL
    {
        const string Nombre_Clase = "AutoridadJudicialTipoBL";
        private string m_BaseDatos = string.Empty;

        public AutoridadJudicialTipoBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(AutoridadJudicialTipoBE e_AutoridadJudicialTipo)
        {
            try
            {
                AutoridadJudicialTipoDA o_AutoridadJudicialTipo = new AutoridadJudicialTipoDA(m_BaseDatos);
                int resp = o_AutoridadJudicialTipo.Insertar(e_AutoridadJudicialTipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(AutoridadJudicialTipoBE e_AutoridadJudicialTipo)
        {
            try
            {
                AutoridadJudicialTipoDA o_AutoridadJudicialTipo = new AutoridadJudicialTipoDA(m_BaseDatos);
                int resp = o_AutoridadJudicialTipo.Actualizar(e_AutoridadJudicialTipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(AutoridadJudicialTipoBE e_AutoridadJudicialTipo)
        {
            try
            {
                AutoridadJudicialTipoDA o_AutoridadJudicialTipo = new AutoridadJudicialTipoDA(m_BaseDatos);
                int resp = o_AutoridadJudicialTipo.Anular(e_AutoridadJudicialTipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<AutoridadJudicialTipoBE> Consultar_Lista()
        {
            List<AutoridadJudicialTipoBE> lista = new List<AutoridadJudicialTipoBE>();
            try
            {
                AutoridadJudicialTipoDA o_AutoridadJudicialTipo = new AutoridadJudicialTipoDA(m_BaseDatos);
                return o_AutoridadJudicialTipo.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<AutoridadJudicialTipoBE> Consultar_PK(
                              int m_AutoridadJudicialTipoId
                              )
        {
            List<AutoridadJudicialTipoBE> lista = new List<AutoridadJudicialTipoBE>();
            try
            {
                AutoridadJudicialTipoDA o_AutoridadJudicialTipo = new AutoridadJudicialTipoDA(m_BaseDatos);
                return o_AutoridadJudicialTipo.Consultar_PK(
                                                            m_AutoridadJudicialTipoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
