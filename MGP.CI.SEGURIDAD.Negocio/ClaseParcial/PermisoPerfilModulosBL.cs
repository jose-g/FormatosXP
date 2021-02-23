using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class PermisoPerfilModulosBL : BaseBL
    {
        const string Nombre_Clase = "PermisoPerfilModulosBL";
        private string m_BaseDatos = string.Empty;

        public PermisoPerfilModulosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public PermisoPerfilModulosBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(PermisoPerfilModulosBE e_PermisoPerfilModulos)
        {
            int resp = -1;

            try
            {
                PermisoPerfilModulosDA o_PermisoPerfilModulos = new PermisoPerfilModulosDA(m_BaseDatos);
                resp = o_PermisoPerfilModulos.Insertar(e_PermisoPerfilModulos);
                return (resp > 0);

            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(PermisoPerfilModulosBE e_PermisoPerfilModulos)
        {
            try
            {
                PermisoPerfilModulosDA o_PermisoPerfilModulos = new PermisoPerfilModulosDA(m_BaseDatos);
                int resp = o_PermisoPerfilModulos.Actualizar(e_PermisoPerfilModulos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(PermisoPerfilModulosBE e_PermisoPerfilModulos)
        {
            try
            {
                PermisoPerfilModulosDA o_PermisoPerfilModulos = new PermisoPerfilModulosDA(m_BaseDatos);
                int resp = o_PermisoPerfilModulos.Anular(e_PermisoPerfilModulos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PermisoPerfilModulosBE> Consultar_Lista()
        {
            List<PermisoPerfilModulosBE> lista = new List<PermisoPerfilModulosBE>();
            try
            {
                PermisoPerfilModulosDA o_PermisoPerfilModulos = new PermisoPerfilModulosDA(m_BaseDatos);
                return o_PermisoPerfilModulos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PermisoPerfilModulosBE> Consultar_PK(int m_PermisoPerfilModuloId)
        {
            List<PermisoPerfilModulosBE> lista = new List<PermisoPerfilModulosBE>();
            try
            {
                PermisoPerfilModulosDA o_PermisoPerfilModulos = new PermisoPerfilModulosDA(m_BaseDatos);
                return o_PermisoPerfilModulos.Consultar_PK(
                                                            m_PermisoPerfilModuloId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool CambiarEstado(PermisoPerfilModulosBE m_PermisoPerfilModulos)
        {
            try
            {
                PermisoPerfilModulosDA obj_permisoPM = new PermisoPerfilModulosDA();
                int resp = obj_permisoPM.CambiarEstado(m_PermisoPerfilModulos);
                return (resp > 0);
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

