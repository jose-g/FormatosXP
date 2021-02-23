using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class PerfilesDA : BaseDA
    {
        const string Nombre_Clase = "PerfilesDA";
        private string m_BaseDatos = string.Empty;

        public PerfilesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public PerfilesDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(PerfilesBE e_Perfiles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilesInsertar", connection);
                    ParametroSP("@PerfilId", e_Perfiles.PerfilesId);
                    ParametroSP("@PerfilKey", e_Perfiles.PerfilKey);
                    ParametroSP("@Nombre", e_Perfiles.Nombre);
                    ParametroSP("@Descripcion", e_Perfiles.Descripcion);
                    ParametroSP("@EstadoID", e_Perfiles.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Perfiles.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Perfiles.NroIpRegistro);
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

        public int Actualizar(PerfilesBE e_Perfiles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilesActualizar", connection);
                    ParametroSP("@PerfilId", e_Perfiles.PerfilesId);
                    ParametroSP("@PerfilKey", e_Perfiles.PerfilKey);
                    ParametroSP("@Nombre", e_Perfiles.Nombre);
                    ParametroSP("@Descripcion", e_Perfiles.Descripcion);
                    ParametroSP("@EstadoID", e_Perfiles.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Perfiles.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Perfiles.NroIpRegistro);
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

        public int Anular(PerfilesBE e_Perfiles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilesAnular", connection);
                    ParametroSP("@PerfilId", e_Perfiles.PerfilesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Perfiles.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Perfiles.NroIpRegistro);
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

        public List<PerfilesBE> Consultar_Lista()
        {
            List<PerfilesBE> lista = new List<PerfilesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PerfilesBE(reader));
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

        public List<PerfilesBE> Consultar_PK(int m_PerfilId)
        {
            List<PerfilesBE> lista = new List<PerfilesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilesConsultar_PK", connection);
                    ParametroSP("@PerfilId", m_PerfilId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PerfilesBE(reader));
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

        public List<PerfilesBE> Listar_grilla(PerfilesBE ent)
        {
            List<PerfilesBE> lst = new List<PerfilesBE>();

            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PERFILConsultar_Lista_Grilla", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla");
                    ParametroSP("@Nombre", ent.Nombre);
                    ParametroSP("@PerfilId", ent.PerfilesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new PerfilesBE(reader));
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

        public List<PerfilesBE> ListarPerfilesDisponibles(int UsuarioId)
        {
            List<PerfilesBE> lst = new List<PerfilesBE>();

            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PERFILConsultarPerfilesFaltantes", connection);
                    ParametroSP("@UsuarioId", UsuarioId);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new PerfilesBE(reader));
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
