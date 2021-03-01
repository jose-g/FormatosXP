using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class NivelesNumericos1005DA : BaseDA
    {
        const string Nombre_Clase = "NivelesNumericos1005DA";
        private string m_BaseDatos = string.Empty;

        public NivelesNumericos1005DA() {  }

        public int Insertar(NivelesNumericos1005BE e_NivelesNumericos1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesNumericos1005Insertar", connection);
                    ParametroSP("@NivelesNumericosId", e_NivelesNumericos1005.NivelesNumericosId);
                    ParametroSP("@Nombre", e_NivelesNumericos1005.Nombre);
                    ParametroSP("@EstadoId", e_NivelesNumericos1005.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_NivelesNumericos1005.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_NivelesNumericos1005.NroIpRegistro);
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

        public int Actualizar(NivelesNumericos1005BE e_NivelesNumericos1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesNumericos1005Actualizar", connection);
                    ParametroSP("@NivelesNumericosId", e_NivelesNumericos1005.NivelesNumericosId);
                    ParametroSP("@Nombre", e_NivelesNumericos1005.Nombre);
                    ParametroSP("@EstadoId", e_NivelesNumericos1005.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_NivelesNumericos1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_NivelesNumericos1005.NroIpRegistro);
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

        public int Anular(NivelesNumericos1005BE e_NivelesNumericos1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesNumericos1005Anular", connection);
                    ParametroSP("@NivelesNumericosId", e_NivelesNumericos1005.NivelesNumericosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_NivelesNumericos1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_NivelesNumericos1005.NroIpRegistro);
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

        public List<NivelesNumericos1005BE> Consultar_Lista()
        {
            List<NivelesNumericos1005BE> lista = new List<NivelesNumericos1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesNumericos1005Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new NivelesNumericos1005BE(reader));
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

        public List<NivelesNumericos1005BE> Consultar_PK(
                int m_NivelesNumericosId)
        {
            List<NivelesNumericos1005BE> lista = new List<NivelesNumericos1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesNumericos1005Consultar_PK", connection);
                    ParametroSP("@NivelesNumericosId", m_NivelesNumericosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new NivelesNumericos1005BE(reader));
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
                    ComandoSP("usp_NivelesNumericos1005GetMaxId", connection);
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


