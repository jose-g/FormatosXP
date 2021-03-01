using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class MotivosViajeDA : BaseDA
    {
        const string Nombre_Clase = "MotivosViajeDA";
        private string m_BaseDatos = string.Empty;

        public MotivosViajeDA() {  }

        public int Insertar(MotivosViajeBE e_MotivosViaje)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_MotivosViajeInsertar", connection);
                    ParametroSP("@MotivosViajeId", e_MotivosViaje.MotivosViajeId);
                    ParametroSP("@Nombre", e_MotivosViaje.Nombre);
                    ParametroSP("@EstadoId", e_MotivosViaje.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_MotivosViaje.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_MotivosViaje.NroIpRegistro);
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

        public int Actualizar(MotivosViajeBE e_MotivosViaje)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_MotivosViajeActualizar", connection);
                    ParametroSP("@MotivosViajeId", e_MotivosViaje.MotivosViajeId);
                    ParametroSP("@Nombre", e_MotivosViaje.Nombre);
                    ParametroSP("@EstadoId", e_MotivosViaje.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_MotivosViaje.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_MotivosViaje.NroIpRegistro);
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

        public int Anular(MotivosViajeBE e_MotivosViaje)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_MotivosViajeAnular", connection);
                    ParametroSP("@MotivosViajeId", e_MotivosViaje.MotivosViajeId);
                    ParametroSP("@UsuarioModificacionRegistro", e_MotivosViaje.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_MotivosViaje.NroIpRegistro);
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

        public List<MotivosViajeBE> Consultar_Lista()
        {
            List<MotivosViajeBE> lista = new List<MotivosViajeBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_MotivosViajeConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new MotivosViajeBE(reader));
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

        public List<MotivosViajeBE> Consultar_PK(
                int m_MotivosViajeId)
        {
            List<MotivosViajeBE> lista = new List<MotivosViajeBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_MotivosViajeConsultar_PK", connection);
                    ParametroSP("@MotivosViajeId", m_MotivosViajeId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new MotivosViajeBE(reader));
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
                    ComandoSP("usp_MotivosViajeGetMaxId", connection);
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


