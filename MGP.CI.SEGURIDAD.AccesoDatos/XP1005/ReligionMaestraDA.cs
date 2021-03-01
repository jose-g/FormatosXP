using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class ReligionMaestraDA : BaseDA
    {
        const string Nombre_Clase = "ReligionMaestraDA";
        private string m_BaseDatos = string.Empty;

        public ReligionMaestraDA() {  }

        public int Insertar(ReligionMaestraBE e_ReligionMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionMaestraInsertar", connection);
                    ParametroSP("@ReligionMaestraId", e_ReligionMaestra.ReligionMaestraId);
                    ParametroSP("@Nombre", e_ReligionMaestra.Nombre);
                    ParametroSP("@EstadoId", e_ReligionMaestra.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_ReligionMaestra.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_ReligionMaestra.NroIpRegistro);
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

        public int Actualizar(ReligionMaestraBE e_ReligionMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionMaestraActualizar", connection);
                    ParametroSP("@ReligionMaestraId", e_ReligionMaestra.ReligionMaestraId);
                    ParametroSP("@Nombre", e_ReligionMaestra.Nombre);
                    ParametroSP("@EstadoId", e_ReligionMaestra.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ReligionMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ReligionMaestra.NroIpRegistro);
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

        public int Anular(ReligionMaestraBE e_ReligionMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionMaestraAnular", connection);
                    ParametroSP("@ReligionMaestraId", e_ReligionMaestra.ReligionMaestraId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ReligionMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ReligionMaestra.NroIpRegistro);
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

        public List<ReligionMaestraBE> Consultar_Lista()
        {
            List<ReligionMaestraBE> lista = new List<ReligionMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionMaestraConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ReligionMaestraBE(reader));
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

        public List<ReligionMaestraBE> Consultar_PK(
                int m_ReligionMaestraId)
        {
            List<ReligionMaestraBE> lista = new List<ReligionMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionMaestraConsultar_PK", connection);
                    ParametroSP("@ReligionMaestraId", m_ReligionMaestraId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ReligionMaestraBE(reader));
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
                    ComandoSP("usp_ReligionMaestraGetMaxId", connection);
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


