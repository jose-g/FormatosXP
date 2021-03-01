using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class Observaciones1005DetallesDA : BaseDA
    {
        const string Nombre_Clase = "Observaciones1005DetallesDA";
        private string m_BaseDatos = string.Empty;

        public Observaciones1005DetallesDA() {  }

        public int Insertar(Observaciones1005DetallesBE e_Observaciones1005Detalles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005DetallesInsertar", connection);
                    ParametroSP("@Observaciones1005DetallesId", e_Observaciones1005Detalles.Observaciones1005DetallesId);
                    ParametroSP("@Observaciones1005Id", e_Observaciones1005Detalles.Observaciones1005Id);
                    ParametroSP("@Observaciones1005TipoId", e_Observaciones1005Detalles.Observaciones1005TipoId);
                    ParametroSP("@Hechos", e_Observaciones1005Detalles.Hechos);
                    ParametroSP("@Observaciones", e_Observaciones1005Detalles.Observaciones);
                    ParametroSP("@EstadoId", e_Observaciones1005Detalles.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Observaciones1005Detalles.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones1005Detalles.NroIpRegistro);
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

        public int Actualizar(Observaciones1005DetallesBE e_Observaciones1005Detalles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005DetallesActualizar", connection);
                    ParametroSP("@Observaciones1005DetallesId", e_Observaciones1005Detalles.Observaciones1005DetallesId);
                    ParametroSP("@Observaciones1005Id", e_Observaciones1005Detalles.Observaciones1005Id);
                    ParametroSP("@Observaciones1005TipoId", e_Observaciones1005Detalles.Observaciones1005TipoId);
                    ParametroSP("@Hechos", e_Observaciones1005Detalles.Hechos);
                    ParametroSP("@Observaciones", e_Observaciones1005Detalles.Observaciones);
                    ParametroSP("@EstadoId", e_Observaciones1005Detalles.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Observaciones1005Detalles.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones1005Detalles.NroIpRegistro);
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

        public int Anular(Observaciones1005DetallesBE e_Observaciones1005Detalles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005DetallesAnular", connection);
                    ParametroSP("@Observaciones1005DetallesId", e_Observaciones1005Detalles.Observaciones1005DetallesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Observaciones1005Detalles.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones1005Detalles.NroIpRegistro);
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

        public List<Observaciones1005DetallesBE> Consultar_Lista()
        {
            List<Observaciones1005DetallesBE> lista = new List<Observaciones1005DetallesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005DetallesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Observaciones1005DetallesBE(reader));
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

        public List<Observaciones1005DetallesBE> Consultar_PK(
                int m_Observaciones1005DetallesId)
        {
            List<Observaciones1005DetallesBE> lista = new List<Observaciones1005DetallesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005DetallesConsultar_PK", connection);
                    ParametroSP("@Observaciones1005DetallesId", m_Observaciones1005DetallesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Observaciones1005DetallesBE(reader));
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
                    ComandoSP("usp_Observaciones1005DetallesGetMaxId", connection);
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


