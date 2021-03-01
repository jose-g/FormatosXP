using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class PerfilPsicologico1005DA : BaseDA
    {
        const string Nombre_Clase = "PerfilPsicologico1005DA";
        private string m_BaseDatos = string.Empty;

        public PerfilPsicologico1005DA() {  }

        public int Insertar(PerfilPsicologico1005BE e_PerfilPsicologico1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologico1005Insertar", connection);
                    ParametroSP("@PerfilPsicologico1005Id", e_PerfilPsicologico1005.PerfilPsicologico1005Id);
                    ParametroSP("@FichaId", e_PerfilPsicologico1005.FichaId);
                    ParametroSP("@EstadoId", e_PerfilPsicologico1005.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_PerfilPsicologico1005.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_PerfilPsicologico1005.NroIpRegistro);
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

        public int Actualizar(PerfilPsicologico1005BE e_PerfilPsicologico1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologico1005Actualizar", connection);
                    ParametroSP("@PerfilPsicologico1005Id", e_PerfilPsicologico1005.PerfilPsicologico1005Id);
                    ParametroSP("@FichaId", e_PerfilPsicologico1005.FichaId);
                    ParametroSP("@EstadoId", e_PerfilPsicologico1005.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PerfilPsicologico1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PerfilPsicologico1005.NroIpRegistro);
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

        public int Anular(PerfilPsicologico1005BE e_PerfilPsicologico1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologico1005Anular", connection);
                    ParametroSP("@PerfilPsicologico1005Id", e_PerfilPsicologico1005.PerfilPsicologico1005Id);
                    ParametroSP("@UsuarioModificacionRegistro", e_PerfilPsicologico1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PerfilPsicologico1005.NroIpRegistro);
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

        public List<PerfilPsicologico1005BE> Consultar_Lista()
        {
            List<PerfilPsicologico1005BE> lista = new List<PerfilPsicologico1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologico1005Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PerfilPsicologico1005BE(reader));
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

        public List<PerfilPsicologico1005BE> Consultar_PK(
                int m_PerfilPsicologico1005Id)
        {
            List<PerfilPsicologico1005BE> lista = new List<PerfilPsicologico1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilPsicologico1005Consultar_PK", connection);
                    ParametroSP("@PerfilPsicologico1005Id", m_PerfilPsicologico1005Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PerfilPsicologico1005BE(reader));
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
                    ComandoSP("usp_PerfilPsicologico1005GetMaxId", connection);
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


