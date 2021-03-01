using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class ActividadesViajeDA : BaseDA
    {
        const string Nombre_Clase = "ActividadesViajeDA";
        private string m_BaseDatos = string.Empty;

        public ActividadesViajeDA() {  }

        public int Insertar(ActividadesViajeBE e_ActividadesViaje)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ActividadesViajeInsertar", connection);
                    ParametroSP("@ActividadesViajeId", e_ActividadesViaje.ActividadesViajeId);
                    ParametroSP("@ActividadesIntoPais1005Id", e_ActividadesViaje.ActividadesIntoPais1005Id);
                    ParametroSP("@MotivosViajeId", e_ActividadesViaje.MotivosViajeId);
                    ParametroSP("@FechaViaje", e_ActividadesViaje.FechaViaje);
                    ParametroSP("@PaisId", e_ActividadesViaje.PaisId);
                    ParametroSP("@EstadoId", e_ActividadesViaje.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_ActividadesViaje.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_ActividadesViaje.NroIpRegistro);
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

        public int Actualizar(ActividadesViajeBE e_ActividadesViaje)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ActividadesViajeActualizar", connection);
                    ParametroSP("@ActividadesViajeId", e_ActividadesViaje.ActividadesViajeId);
                    ParametroSP("@ActividadesIntoPais1005Id", e_ActividadesViaje.ActividadesIntoPais1005Id);
                    ParametroSP("@MotivosViajeId", e_ActividadesViaje.MotivosViajeId);
                    ParametroSP("@FechaViaje", e_ActividadesViaje.FechaViaje);
                    ParametroSP("@PaisId", e_ActividadesViaje.PaisId);
                    ParametroSP("@EstadoId", e_ActividadesViaje.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ActividadesViaje.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ActividadesViaje.NroIpRegistro);
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

        public int Anular(ActividadesViajeBE e_ActividadesViaje)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ActividadesViajeAnular", connection);
                    ParametroSP("@ActividadesViajeId", e_ActividadesViaje.ActividadesViajeId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ActividadesViaje.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ActividadesViaje.NroIpRegistro);
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

        public List<ActividadesViajeBE> Consultar_Lista()
        {
            List<ActividadesViajeBE> lista = new List<ActividadesViajeBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ActividadesViajeConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ActividadesViajeBE(reader));
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

        public List<ActividadesViajeBE> Consultar_PK(
                int m_ActividadesViajeId)
        {
            List<ActividadesViajeBE> lista = new List<ActividadesViajeBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ActividadesViajeConsultar_PK", connection);
                    ParametroSP("@ActividadesViajeId", m_ActividadesViajeId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ActividadesViajeBE(reader));
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
                    ComandoSP("usp_ActividadesViajeGetMaxId", connection);
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


