using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class PerfilModulosBL : BaseBL
    {
        const string Nombre_Clase = "PerfilModulosBL";
        private string m_BaseDatos = string.Empty;

        public PerfilModulosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public PerfilModulosBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(PerfilModulosBE e_PerfilModulos)
        {
            try
            {
                PerfilModulosDA o_PerfilModulos = new PerfilModulosDA(m_BaseDatos);
                int resp = o_PerfilModulos.Insertar(e_PerfilModulos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(PerfilModulosBE e_PerfilModulos)
        {
            try
            {
                PerfilModulosDA o_PerfilModulos = new PerfilModulosDA(m_BaseDatos);
                int resp = o_PerfilModulos.Actualizar(e_PerfilModulos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(PerfilModulosBE e_PerfilModulos)
        {
            try
            {
                PerfilModulosDA o_PerfilModulos = new PerfilModulosDA(m_BaseDatos);
                int resp = o_PerfilModulos.Anular(e_PerfilModulos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PerfilModulosBE> Consultar_Lista()
        {
            List<PerfilModulosBE> lista = new List<PerfilModulosBE>();
            try
            {
                PerfilModulosDA o_PerfilModulos = new PerfilModulosDA(m_BaseDatos);
                return o_PerfilModulos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PerfilModulosBE> Consultar_PK( int m_PerfilModuloId)
        {
            List<PerfilModulosBE> lista = new List<PerfilModulosBE>();
            try
            {
                PerfilModulosDA o_PerfilModulos = new PerfilModulosDA(m_BaseDatos);
                return o_PerfilModulos.Consultar_PK(
                                                            m_PerfilModuloId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Permiso_Perfil_ModuloDTO> Listar_grilla_x_perfil(Permiso_Perfil_ModuloDTO ent)
        {
            List<Permiso_Perfil_ModuloDTO> l = new List<Permiso_Perfil_ModuloDTO>();
            try
            {
                l = (new PermisoPerfilModulosDA()).Listar_grilla_x_perfil(ent);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        public List<Permiso_Perfil_ModuloDTO> Listar_grilla_x_usuario(Permiso_Perfil_ModuloDTO ent)
        {
            List<Permiso_Perfil_ModuloDTO> l = new List<Permiso_Perfil_ModuloDTO>();
            try
            {
                l = (new PermisoPerfilModulosDA()).Listar_grilla_x_usuario(ent);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }


        public List<Permiso_Perfil_ModuloDTO> Listar_permiso_activo_x_perfil(int id_usuario, string key_sistema)
        {
            List<Permiso_Perfil_ModuloDTO> l = new List<Permiso_Perfil_ModuloDTO>();
            try
            {
                l = (new PermisoPerfilModulosDA()).Listar_permiso_activo_x_perfil(id_usuario, key_sistema);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        public List<Permiso_Perfil_ModuloDTO> Listar_permiso_sistema_x_perfil(int id_usuario)
        {
            List<Permiso_Perfil_ModuloDTO> l = new List<Permiso_Perfil_ModuloDTO>();
            try
            {
                l = (new PermisoPerfilModulosDA()).Listar_permiso_sistema_x_perfil(id_usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        public List<Permiso_Perfil_ModuloDTO> Listar_permiso_activo(int id_usuario, int id_sistema)
        {
            List<Permiso_Perfil_ModuloDTO> l = new List<Permiso_Perfil_ModuloDTO>();
            try
            {
                l = (new PermisoPerfilModulosDA()).Listar_permiso_activo(id_usuario, id_sistema);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

    }
}
