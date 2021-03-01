using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class Vinculaciones1005DA : BaseDA
    {
        const string Nombre_Clase = "Vinculaciones1005DA";
        private string m_BaseDatos = string.Empty;

        public Vinculaciones1005DA() {  }

        public int Insertar(Vinculaciones1005BE e_Vinculaciones1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Vinculaciones1005Insertar", connection);
                    ParametroSP("@Vinculaciones1005d", e_Vinculaciones1005.Vinculaciones1005d);
                    ParametroSP("@FichaId", e_Vinculaciones1005.FichaId);
                    ParametroSP("@TendenciaIdelogica", e_Vinculaciones1005.TendenciaIdelogica);
                    ParametroSP("@LineaPolitica", e_Vinculaciones1005.LineaPolitica);
                    ParametroSP("@EstadoId", e_Vinculaciones1005.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Vinculaciones1005.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Vinculaciones1005.NroIpRegistro);
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

        public int Actualizar(Vinculaciones1005BE e_Vinculaciones1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Vinculaciones1005Actualizar", connection);
                    ParametroSP("@Vinculaciones1005d", e_Vinculaciones1005.Vinculaciones1005d);
                    ParametroSP("@FichaId", e_Vinculaciones1005.FichaId);
                    ParametroSP("@TendenciaIdelogica", e_Vinculaciones1005.TendenciaIdelogica);
                    ParametroSP("@LineaPolitica", e_Vinculaciones1005.LineaPolitica);
                    ParametroSP("@EstadoId", e_Vinculaciones1005.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Vinculaciones1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Vinculaciones1005.NroIpRegistro);
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

        public int Anular(Vinculaciones1005BE e_Vinculaciones1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Vinculaciones1005Anular", connection);
                    ParametroSP("@Vinculaciones1005d", e_Vinculaciones1005.Vinculaciones1005d);
                    ParametroSP("@UsuarioModificacionRegistro", e_Vinculaciones1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Vinculaciones1005.NroIpRegistro);
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

        public List<Vinculaciones1005BE> Consultar_Lista()
        {
            List<Vinculaciones1005BE> lista = new List<Vinculaciones1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Vinculaciones1005Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Vinculaciones1005BE(reader));
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

        public List<Vinculaciones1005BE> Consultar_PK(
                int m_Vinculaciones1005d)
        {
            List<Vinculaciones1005BE> lista = new List<Vinculaciones1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Vinculaciones1005Consultar_PK", connection);
                    ParametroSP("@Vinculaciones1005d", m_Vinculaciones1005d);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Vinculaciones1005BE(reader));
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
                    ComandoSP("usp_Vinculaciones1005GetMaxId", connection);
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


