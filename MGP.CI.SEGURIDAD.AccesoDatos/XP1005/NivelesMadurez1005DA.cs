using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class NivelesMadurez1005DA : BaseDA
    {
        const string Nombre_Clase = "NivelesMadurez1005DA";
        private string m_BaseDatos = string.Empty;

        public NivelesMadurez1005DA() {  }

        public int Insertar(NivelesMadurez1005BE e_NivelesMadurez1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesMadurez1005Insertar", connection);
                    ParametroSP("@NivelesMadurez1005Id", e_NivelesMadurez1005.NivelesMadurez1005Id);
                    ParametroSP("@Nombre", e_NivelesMadurez1005.Nombre);
                    ParametroSP("@EstadoId", e_NivelesMadurez1005.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_NivelesMadurez1005.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_NivelesMadurez1005.NroIpRegistro);
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

        public int Actualizar(NivelesMadurez1005BE e_NivelesMadurez1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesMadurez1005Actualizar", connection);
                    ParametroSP("@NivelesMadurez1005Id", e_NivelesMadurez1005.NivelesMadurez1005Id);
                    ParametroSP("@Nombre", e_NivelesMadurez1005.Nombre);
                    ParametroSP("@EstadoId", e_NivelesMadurez1005.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_NivelesMadurez1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_NivelesMadurez1005.NroIpRegistro);
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

        public int Anular(NivelesMadurez1005BE e_NivelesMadurez1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesMadurez1005Anular", connection);
                    ParametroSP("@NivelesMadurez1005Id", e_NivelesMadurez1005.NivelesMadurez1005Id);
                    ParametroSP("@UsuarioModificacionRegistro", e_NivelesMadurez1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_NivelesMadurez1005.NroIpRegistro);
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

        public List<NivelesMadurez1005BE> Consultar_Lista()
        {
            List<NivelesMadurez1005BE> lista = new List<NivelesMadurez1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesMadurez1005Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new NivelesMadurez1005BE(reader));
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

        public List<NivelesMadurez1005BE> Consultar_PK(
                int m_NivelesMadurez1005Id)
        {
            List<NivelesMadurez1005BE> lista = new List<NivelesMadurez1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesMadurez1005Consultar_PK", connection);
                    ParametroSP("@NivelesMadurez1005Id", m_NivelesMadurez1005Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new NivelesMadurez1005BE(reader));
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
                    ComandoSP("usp_NivelesMadurez1005GetMaxId", connection);
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


