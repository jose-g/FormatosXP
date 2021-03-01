using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class MotivoLugaresFrecuentadosDA : BaseDA
    {
        const string Nombre_Clase = "MotivoLugaresFrecuentadosDA";
        private string m_BaseDatos = string.Empty;

        public MotivoLugaresFrecuentadosDA() {  }

        public int Insertar(MotivoLugaresFrecuentadosBE e_MotivoLugaresFrecuentados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_MotivoLugaresFrecuentadosInsertar", connection);
                    ParametroSP("@MotivoLugaresFrecuentadosId", e_MotivoLugaresFrecuentados.MotivoLugaresFrecuentadosId);
                    ParametroSP("@Nombre", e_MotivoLugaresFrecuentados.Nombre);
                    ParametroSP("@EstadoId", e_MotivoLugaresFrecuentados.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_MotivoLugaresFrecuentados.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_MotivoLugaresFrecuentados.NroIpRegistro);
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

        public int Actualizar(MotivoLugaresFrecuentadosBE e_MotivoLugaresFrecuentados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_MotivoLugaresFrecuentadosActualizar", connection);
                    ParametroSP("@MotivoLugaresFrecuentadosId", e_MotivoLugaresFrecuentados.MotivoLugaresFrecuentadosId);
                    ParametroSP("@Nombre", e_MotivoLugaresFrecuentados.Nombre);
                    ParametroSP("@EstadoId", e_MotivoLugaresFrecuentados.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_MotivoLugaresFrecuentados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_MotivoLugaresFrecuentados.NroIpRegistro);
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

        public int Anular(MotivoLugaresFrecuentadosBE e_MotivoLugaresFrecuentados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_MotivoLugaresFrecuentadosAnular", connection);
                    ParametroSP("@MotivoLugaresFrecuentadosId", e_MotivoLugaresFrecuentados.MotivoLugaresFrecuentadosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_MotivoLugaresFrecuentados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_MotivoLugaresFrecuentados.NroIpRegistro);
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

        public List<MotivoLugaresFrecuentadosBE> Consultar_Lista()
        {
            List<MotivoLugaresFrecuentadosBE> lista = new List<MotivoLugaresFrecuentadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_MotivoLugaresFrecuentadosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new MotivoLugaresFrecuentadosBE(reader));
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

        public List<MotivoLugaresFrecuentadosBE> Consultar_PK(
                int m_MotivoLugaresFrecuentadosId)
        {
            List<MotivoLugaresFrecuentadosBE> lista = new List<MotivoLugaresFrecuentadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_MotivoLugaresFrecuentadosConsultar_PK", connection);
                    ParametroSP("@MotivoLugaresFrecuentadosId", m_MotivoLugaresFrecuentadosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new MotivoLugaresFrecuentadosBE(reader));
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
                    ComandoSP("usp_MotivoLugaresFrecuentadosGetMaxId", connection);
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


