using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class PreferenciaSexualMaestraDA : BaseDA
    {
        const string Nombre_Clase = "PreferenciaSexualMaestraDA";
        private string m_BaseDatos = string.Empty;

        public PreferenciaSexualMaestraDA() {  }

        public int Insertar(PreferenciaSexualMaestraBE e_PreferenciaSexualMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualMaestraInsertar", connection);
                    ParametroSP("@PreferenciaSexualMaestraId", e_PreferenciaSexualMaestra.PreferenciaSexualMaestraId);
                    ParametroSP("@Nombre", e_PreferenciaSexualMaestra.Nombre);
                    ParametroSP("@EstadoId", e_PreferenciaSexualMaestra.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_PreferenciaSexualMaestra.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_PreferenciaSexualMaestra.NroIpRegistro);
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

        public int Actualizar(PreferenciaSexualMaestraBE e_PreferenciaSexualMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualMaestraActualizar", connection);
                    ParametroSP("@PreferenciaSexualMaestraId", e_PreferenciaSexualMaestra.PreferenciaSexualMaestraId);
                    ParametroSP("@Nombre", e_PreferenciaSexualMaestra.Nombre);
                    ParametroSP("@EstadoId", e_PreferenciaSexualMaestra.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PreferenciaSexualMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PreferenciaSexualMaestra.NroIpRegistro);
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

        public int Anular(PreferenciaSexualMaestraBE e_PreferenciaSexualMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualMaestraAnular", connection);
                    ParametroSP("@PreferenciaSexualMaestraId", e_PreferenciaSexualMaestra.PreferenciaSexualMaestraId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PreferenciaSexualMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PreferenciaSexualMaestra.NroIpRegistro);
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

        public List<PreferenciaSexualMaestraBE> Consultar_Lista()
        {
            List<PreferenciaSexualMaestraBE> lista = new List<PreferenciaSexualMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualMaestraConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PreferenciaSexualMaestraBE(reader));
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

        public List<PreferenciaSexualMaestraBE> Consultar_PK(
                int m_PreferenciaSexualMaestraId)
        {
            List<PreferenciaSexualMaestraBE> lista = new List<PreferenciaSexualMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualMaestraConsultar_PK", connection);
                    ParametroSP("@PreferenciaSexualMaestraId", m_PreferenciaSexualMaestraId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PreferenciaSexualMaestraBE(reader));
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

        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualMaestraGetMaxId", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                        if (!DBNull.Value.Equals(reader["CodigoMaxId"]))
                            {
                             maxId = Convert.ToInt32(reader["CodigoMaxId"]);
                            }
                        }
                }
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
            return maxId;
        }

    }
}


