using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class LugaresFrecuentadosDA : BaseDA
    {
        const string Nombre_Clase = "LugaresFrecuentadosDA";
        private string m_BaseDatos = string.Empty;

        public LugaresFrecuentadosDA() {  }

        public int Insertar(LugaresFrecuentadosBE e_LugaresFrecuentados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_LugaresFrecuentadosInsertar", connection);
                    ParametroSP("@LugaresFrecuentadosId", e_LugaresFrecuentados.LugaresFrecuentadosId);
                    ParametroSP("@DatosGeneralesId", e_LugaresFrecuentados.DatosGeneralesId);
                    ParametroSP("@UbigeoId", e_LugaresFrecuentados.UbigeoId);
                    ParametroSP("@MotivoLugaresFrecuentadosId", e_LugaresFrecuentados.MotivoLugaresFrecuentadosId);
                    ParametroSP("@Observacion", e_LugaresFrecuentados.Observacion);
                    ParametroSP("@EstadoId", e_LugaresFrecuentados.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_LugaresFrecuentados.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_LugaresFrecuentados.NroIpRegistro);
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

        public int Actualizar(LugaresFrecuentadosBE e_LugaresFrecuentados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_LugaresFrecuentadosActualizar", connection);
                    ParametroSP("@LugaresFrecuentadosId", e_LugaresFrecuentados.LugaresFrecuentadosId);
                    ParametroSP("@DatosGeneralesId", e_LugaresFrecuentados.DatosGeneralesId);
                    ParametroSP("@UbigeoId", e_LugaresFrecuentados.UbigeoId);
                    ParametroSP("@MotivoLugaresFrecuentadosId", e_LugaresFrecuentados.MotivoLugaresFrecuentadosId);
                    ParametroSP("@Observacion", e_LugaresFrecuentados.Observacion);
                    ParametroSP("@EstadoId", e_LugaresFrecuentados.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_LugaresFrecuentados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_LugaresFrecuentados.NroIpRegistro);
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

        public int Anular(LugaresFrecuentadosBE e_LugaresFrecuentados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_LugaresFrecuentadosAnular", connection);
                    ParametroSP("@LugaresFrecuentadosId", e_LugaresFrecuentados.LugaresFrecuentadosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_LugaresFrecuentados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_LugaresFrecuentados.NroIpRegistro);
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

        public List<LugaresFrecuentadosBE> Consultar_Lista()
        {
            List<LugaresFrecuentadosBE> lista = new List<LugaresFrecuentadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_LugaresFrecuentadosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new LugaresFrecuentadosBE(reader));
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

        public List<LugaresFrecuentadosBE> Consultar_PK(
                int m_LugaresFrecuentadosId)
        {
            List<LugaresFrecuentadosBE> lista = new List<LugaresFrecuentadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_LugaresFrecuentadosConsultar_PK", connection);
                    ParametroSP("@LugaresFrecuentadosId", m_LugaresFrecuentadosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new LugaresFrecuentadosBE(reader));
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
                    ComandoSP("usp_LugaresFrecuentadosGetMaxId", connection);
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


