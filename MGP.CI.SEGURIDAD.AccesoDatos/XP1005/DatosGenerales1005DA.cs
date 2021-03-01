using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class DatosGenerales1005DA : BaseDA
    {
        const string Nombre_Clase = "DatosGenerales1005DA";
        private string m_BaseDatos = string.Empty;

        public DatosGenerales1005DA() {  }

        public int Insertar(DatosGenerales1005BE e_DatosGenerales1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosGenerales1005Insertar", connection);
                    ParametroSP("@DatosGeneralesId", e_DatosGenerales1005.DatosGeneralesId);
                    ParametroSP("@DatosPersonalesId", e_DatosGenerales1005.DatosPersonalesId);
                    ParametroSP("@FichaId", e_DatosGenerales1005.FichaId);
                    ParametroSP("@EstadoId", e_DatosGenerales1005.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_DatosGenerales1005.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosGenerales1005.NroIpRegistro);
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

        public int Actualizar(DatosGenerales1005BE e_DatosGenerales1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosGenerales1005Actualizar", connection);
                    ParametroSP("@DatosGeneralesId", e_DatosGenerales1005.DatosGeneralesId);
                    ParametroSP("@DatosPersonalesId", e_DatosGenerales1005.DatosPersonalesId);
                    ParametroSP("@FichaId", e_DatosGenerales1005.FichaId);
                    ParametroSP("@EstadoId", e_DatosGenerales1005.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DatosGenerales1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosGenerales1005.NroIpRegistro);
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

        public int Anular(DatosGenerales1005BE e_DatosGenerales1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosGenerales1005Anular", connection);
                    ParametroSP("@DatosGeneralesId", e_DatosGenerales1005.DatosGeneralesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DatosGenerales1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DatosGenerales1005.NroIpRegistro);
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

        public List<DatosGenerales1005BE> Consultar_Lista()
        {
            List<DatosGenerales1005BE> lista = new List<DatosGenerales1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosGenerales1005Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DatosGenerales1005BE(reader));
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

        public List<DatosGenerales1005BE> Consultar_PK(
                int m_DatosGeneralesId)
        {
            List<DatosGenerales1005BE> lista = new List<DatosGenerales1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DatosGenerales1005Consultar_PK", connection);
                    ParametroSP("@DatosGeneralesId", m_DatosGeneralesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DatosGenerales1005BE(reader));
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
                    ComandoSP("usp_DatosGenerales1005GetMaxId", connection);
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


