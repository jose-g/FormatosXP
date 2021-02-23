using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class PermisosDA : BaseDA
    {
        const string Nombre_Clase = "PermisosDA";
        private string m_BaseDatos = string.Empty;

        public PermisosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public PermisosDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(PermisosBE e_Permisos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PermisosInsertar", connection);
                    ParametroSP("@PermisoId", e_Permisos.PermisoId);
                    ParametroSP("@EstadoId", e_Permisos.EstadoId);
                    ParametroSP("@Nombre", e_Permisos.Nombre);
                    ParametroSP("@UsuarioRegistro", e_Permisos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Permisos.NroIpRegistro);
                    return comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public int Actualizar(PermisosBE e_Permisos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PermisosActualizar", connection);
                    ParametroSP("@PermisoId", e_Permisos.PermisoId);
                    ParametroSP("@EstadoId", e_Permisos.EstadoId);
                    ParametroSP("@Nombre", e_Permisos.Nombre);
                    ParametroSP("@UsuarioModificacionRegistro", e_Permisos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Permisos.NroIpRegistro);
                    return comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public int Anular(PermisosBE e_Permisos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PermisosAnular", connection);
                    ParametroSP("@PermisoId", e_Permisos.PermisoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Permisos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Permisos.NroIpRegistro);
                    return comando.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public List<PermisosBE> Consultar_Lista()
        {
            List<PermisosBE> lista = new List<PermisosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PermisosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PermisosBE(reader));
                        }
                    }
                    return lista;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public List<PermisosBE> Consultar_PK(int m_PermisoId)
        {
            List<PermisosBE> lista = new List<PermisosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PermisosConsultar_PK", connection);
                    ParametroSP("@PermisoId", m_PermisoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PermisosBE(reader));
                        }
                    }
                    return lista;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        public List<PermisosBE> ConsultaxPerfil_PK(int m_perfilId)
        {
            List<PermisosBE> lista = new List<PermisosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PermisosConsultaxPerfil_PK", connection);
                    ParametroSP("@PerfilId", m_perfilId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PermisosBE(reader));
                        }
                    }
                    return lista;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }


        public List<PermisosBE> Listar_grilla(PermisosBE ent)
        {
            List<PermisosBE> lst = new List<PermisosBE>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_PERMISOConsultar_Lista", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla");
                    ParametroSP("@NOMBRE", ent.Nombre);
                    ParametroSP("@PERMISO_ID", ent.PermisoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new PermisosBE(reader));
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Clase DataAccess: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
                }
                finally
                {
                    connection.Dispose();
                }
            }

            return lst;
        }

    }
}
