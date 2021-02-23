using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class UsuarioAutenticacionesBL : BaseBL
    {
        const string Nombre_Clase = "UsuarioAutenticacionesBL";
        private string m_BaseDatos = string.Empty;

        public UsuarioAutenticacionesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public UsuarioAutenticacionesBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(UsuarioAutenticacionesBE e_UsuarioAutenticaciones)
        {
            try
            {
                UsuarioAutenticacionesDA o_UsuarioAutenticaciones = new UsuarioAutenticacionesDA(m_BaseDatos);
                int resp = o_UsuarioAutenticaciones.Insertar(e_UsuarioAutenticaciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(UsuarioAutenticacionesBE e_UsuarioAutenticaciones)
        {
            try
            {
                UsuarioAutenticacionesDA o_UsuarioAutenticaciones = new UsuarioAutenticacionesDA(m_BaseDatos);
                int resp = o_UsuarioAutenticaciones.Actualizar(e_UsuarioAutenticaciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(UsuarioAutenticacionesBE e_UsuarioAutenticaciones)
        {
            try
            {
                UsuarioAutenticacionesDA o_UsuarioAutenticaciones = new UsuarioAutenticacionesDA(m_BaseDatos);
                int resp = o_UsuarioAutenticaciones.Anular(e_UsuarioAutenticaciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<UsuarioAutenticacionesBE> Consultar_Lista()
        {
            List<UsuarioAutenticacionesBE> lista = new List<UsuarioAutenticacionesBE>();
            try
            {
                UsuarioAutenticacionesDA o_UsuarioAutenticaciones = new UsuarioAutenticacionesDA(m_BaseDatos);
                return o_UsuarioAutenticaciones.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<UsuarioAutenticacionesBE> Consultar_PK(
                              int m_AutenticacionId
                              )
        {
            List<UsuarioAutenticacionesBE> lista = new List<UsuarioAutenticacionesBE>();
            try
            {
                UsuarioAutenticacionesDA o_UsuarioAutenticaciones = new UsuarioAutenticacionesDA(m_BaseDatos);
                return o_UsuarioAutenticaciones.Consultar_PK(
                                                            m_AutenticacionId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
