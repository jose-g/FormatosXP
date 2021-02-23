using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class PermisosBL : BaseBL
    {
        const string Nombre_Clase = "PermisosBL";
        private string m_BaseDatos = string.Empty;

        public PermisosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public PermisosBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(PermisosBE e_Permisos)
        {
            try
            {
                PermisosDA o_Permisos = new PermisosDA(m_BaseDatos);
                int resp = o_Permisos.Insertar(e_Permisos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(PermisosBE e_Permisos)
        {
            try
            {
                PermisosDA o_Permisos = new PermisosDA(m_BaseDatos);
                int resp = o_Permisos.Actualizar(e_Permisos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Anular(PermisosBE e_Permisos)
        {
            try
            {
                PermisosDA o_Permisos = new PermisosDA(m_BaseDatos);
                int resp = o_Permisos.Anular(e_Permisos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PermisosBE> Consultar_Lista()
        {
            List<PermisosBE> lista = new List<PermisosBE>();
            try
            {
                PermisosDA o_Permisos = new PermisosDA(m_BaseDatos);
                return o_Permisos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PermisosBE> ConsultaxPerfil_PK(int m_perfilId)
        {
            List<PermisosBE> lista = new List<PermisosBE>();
            try
            {
                PermisosDA o_Permisos = new PermisosDA(m_BaseDatos);
                return o_Permisos.ConsultaxPerfil_PK(m_perfilId);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PermisosBE> Consultar_PK( int m_PermisoId)
        {
            List<PermisosBE> lista = new List<PermisosBE>();
            try
            {
                PermisosDA o_Permisos = new PermisosDA(m_BaseDatos);
                return o_Permisos.Consultar_PK(
                                                            m_PermisoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
