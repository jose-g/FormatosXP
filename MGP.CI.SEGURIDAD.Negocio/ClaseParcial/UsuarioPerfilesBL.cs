using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;
using System.Linq;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class UsuarioPerfilesBL : BaseBL
    {
        const string Nombre_Clase = "UsuarioPerfilesBL";
        private string m_BaseDatos = string.Empty;

        public UsuarioPerfilesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public UsuarioPerfilesBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }
        public bool Insertar(UsuarioPerfilesBE e_UsuarioPerfiles, ref string outSms)
        {
            try
            {
                UsuarioPerfilesDA o_UsuarioPerfiles = new UsuarioPerfilesDA(m_BaseDatos);
                var aa = o_UsuarioPerfiles.Consultar_Lista();
                var a1 = aa.Where(x => x.UsuarioId == e_UsuarioPerfiles.UsuarioId && x.PerfilId == e_UsuarioPerfiles.PerfilId);
                var usuarioperfilesBE = o_UsuarioPerfiles.Consultar_Lista().Where(x => x.UsuarioId == e_UsuarioPerfiles.UsuarioId && x.PerfilId == e_UsuarioPerfiles.PerfilId).FirstOrDefault();

                if (usuarioperfilesBE != null)
                {
                    if (usuarioperfilesBE.EstadoId > 0)
                        return HabilitarRegistro(usuarioperfilesBE.UsuarioPerfilId);
                }

                int resp = o_UsuarioPerfiles.Insertar(e_UsuarioPerfiles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Actualizar(UsuarioPerfilesBE e_UsuarioPerfiles)
        {
            try
            {
                UsuarioPerfilesDA o_UsuarioPerfiles = new UsuarioPerfilesDA(m_BaseDatos);
                int resp = o_UsuarioPerfiles.Actualizar(e_UsuarioPerfiles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Actualizar(UsuarioPerfilesBE e_USUARIO_PERFIL, ref string outSms)
        {
            try
            {
                UsuarioPerfilesDA o_USUARIO_PERFIL = new UsuarioPerfilesDA();

                int resp = o_USUARIO_PERFIL.Actualizar(e_USUARIO_PERFIL);

                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool EliminarPerfil(int UsuarioPerfilId)
        {
            try
            {
                UsuarioPerfilesDA o_USUARIO_PERFIL = new UsuarioPerfilesDA();
                int resp = o_USUARIO_PERFIL.CambiarEstadoRegistro(UsuarioPerfilId, 0);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool HabilitarRegistro(int idUsuarioPerfil)
        {
            try
            {
                UsuarioPerfilesDA o_USUARIO_PERFIL = new UsuarioPerfilesDA();
                int resp = o_USUARIO_PERFIL.CambiarEstadoRegistro(idUsuarioPerfil, 1);//1=activo
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Anular(UsuarioPerfilesBE e_UsuarioPerfiles)
        {
            try
            {
                UsuarioPerfilesDA o_UsuarioPerfiles = new UsuarioPerfilesDA(m_BaseDatos);
                int resp = o_UsuarioPerfiles.Anular(e_UsuarioPerfiles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<UsuarioPerfilesBE> Consultar_Lista()
        {
            List<UsuarioPerfilesBE> lista = new List<UsuarioPerfilesBE>();
            try
            {
                UsuarioPerfilesDA o_UsuarioPerfiles = new UsuarioPerfilesDA(m_BaseDatos);
                return o_UsuarioPerfiles.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<UsuarioPerfilesBE> Consultar_PK(int m_UsuarioPerfilId)
        {
            List<UsuarioPerfilesBE> lista = new List<UsuarioPerfilesBE>();
            try
            {
                UsuarioPerfilesDA o_UsuarioPerfiles = new UsuarioPerfilesDA(m_BaseDatos);
                return o_UsuarioPerfiles.Consultar_PK(
                                                            m_UsuarioPerfilId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<UsuarioPerfilesBE> ListarPerfilesAsignados(UsuarioPerfilesBE ent)
        {
            return new UsuarioPerfilesDA().Consultar_Lista().Where(x => x.UsuarioId == ent.UsuarioId).ToList();
        }
    }
}
