using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;
using System.Linq;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class TiposUsuariosBL : BaseBL
    {
        const string Nombre_Clase = "TiposUsuariosBL";
        private string m_BaseDatos = string.Empty;

        public TiposUsuariosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public TiposUsuariosBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }
        public bool Insertar(TiposUsuariosBE e_TiposUsuarios)
        {
            try
            {
                TiposUsuariosDA o_TiposUsuarios = new TiposUsuariosDA(m_BaseDatos);
                int resp = o_TiposUsuarios.Insertar(e_TiposUsuarios);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Actualizar(TiposUsuariosBE e_TiposUsuarios)
        {
            try
            {
                TiposUsuariosDA o_TiposUsuarios = new TiposUsuariosDA(m_BaseDatos);
                int resp = o_TiposUsuarios.Actualizar(e_TiposUsuarios);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Anular(TiposUsuariosBE e_TiposUsuarios)
        {
            try
            {
                TiposUsuariosDA o_TiposUsuarios = new TiposUsuariosDA(m_BaseDatos);
                int resp = o_TiposUsuarios.Anular(e_TiposUsuarios);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<TiposUsuariosBE> Consultar_Lista()
        {
            List<TiposUsuariosBE> lista = new List<TiposUsuariosBE>();
            try
            {
                TiposUsuariosDA o_TiposUsuarios = new TiposUsuariosDA(m_BaseDatos);
                return o_TiposUsuarios.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<TiposUsuariosBE> Consultar_PK(int m_TipoUsuarioId)
        {
            List<TiposUsuariosBE> lista = new List<TiposUsuariosBE>();
            try
            {
                TiposUsuariosDA o_TiposUsuarios = new TiposUsuariosDA(m_BaseDatos);
                return o_TiposUsuarios.Consultar_PK(
                                                            m_TipoUsuarioId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new TiposUsuariosDA(m_BaseDatos)).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        public bool CambiarEstado(int m_tipoUsuarioId, int estadoId, string UsuarioLogueado)
        {
            try
            {
                TiposUsuariosBE tipoDocumentoBE = new TiposUsuariosBE();
                tipoDocumentoBE = new TiposUsuariosDA(m_BaseDatos).Consultar_PK(m_tipoUsuarioId).FirstOrDefault();

                if (tipoDocumentoBE == null)
                    return false;

                tipoDocumentoBE.EstadoId = estadoId;
                tipoDocumentoBE.UsuarioModificacionRegistro = UsuarioLogueado;

                TiposUsuariosDA o_TipoDocumento = new TiposUsuariosDA(m_BaseDatos);
                int resp = o_TipoDocumento.CambiarEstado(tipoDocumentoBE);

                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<TiposUsuariosBE> ListarRegistrosFiltrados(TiposUsuariosBE ent)
        {
            List<TiposUsuariosBE> l = new List<TiposUsuariosBE>();
            try
            {
                l = (new TiposUsuariosDA(m_BaseDatos)).ListarRegistrosFiltrados(ent);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

    }
}
