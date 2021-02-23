using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class UsuarioDependenciasBL : BaseBL
    {
        const string Nombre_Clase = "UsuarioDependenciasBL";
        private string m_BaseDatos = string.Empty;

        public UsuarioDependenciasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public UsuarioDependenciasBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(UsuarioDependenciasBE e_UsuarioDependencias)
        {
            try
            {
                UsuarioDependenciasDA o_UsuarioDependencias = new UsuarioDependenciasDA(m_BaseDatos);
                int resp = o_UsuarioDependencias.Insertar(e_UsuarioDependencias);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(UsuarioDependenciasBE e_UsuarioDependencias)
        {
            try
            {
                UsuarioDependenciasDA o_UsuarioDependencias = new UsuarioDependenciasDA(m_BaseDatos);
                int resp = o_UsuarioDependencias.Actualizar(e_UsuarioDependencias);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(UsuarioDependenciasBE e_UsuarioDependencias)
        {
            try
            {
                UsuarioDependenciasDA o_UsuarioDependencias = new UsuarioDependenciasDA(m_BaseDatos);
                int resp = o_UsuarioDependencias.Anular(e_UsuarioDependencias);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<UsuarioDependenciasBE> Consultar_Lista()
        {
            List<UsuarioDependenciasBE> lista = new List<UsuarioDependenciasBE>();
            try
            {
                UsuarioDependenciasDA o_UsuarioDependencias = new UsuarioDependenciasDA(m_BaseDatos);
                return o_UsuarioDependencias.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<UsuarioDependenciasBE> Consultar_PK(
                              int m_UsuarioDependenciaId
                              )
        {
            List<UsuarioDependenciasBE> lista = new List<UsuarioDependenciasBE>();
            try
            {
                UsuarioDependenciasDA o_UsuarioDependencias = new UsuarioDependenciasDA(m_BaseDatos);
                return o_UsuarioDependencias.Consultar_PK(
                                                            m_UsuarioDependenciaId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
