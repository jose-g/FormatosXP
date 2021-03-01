using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class CargosMaestraDA : BaseDA
    {
        const string Nombre_Clase = "CargosMaestraDA";
        private string m_BaseDatos = string.Empty;

        public CargosMaestraDA() {  }

        public int Insertar(CargosMaestraBE e_CargosMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosMaestraInsertar", connection);
                    ParametroSP("@CargosMaestraId", e_CargosMaestra.CargosMaestraId);
                    ParametroSP("@PaisId", e_CargosMaestra.PaisId);
                    ParametroSP("@Nombre", e_CargosMaestra.Nombre);
                    ParametroSP("@EstadoId", e_CargosMaestra.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CargosMaestra.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosMaestra.NroIpRegistro);
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

        public int Actualizar(CargosMaestraBE e_CargosMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosMaestraActualizar", connection);
                    ParametroSP("@CargosMaestraId", e_CargosMaestra.CargosMaestraId);
                    ParametroSP("@PaisId", e_CargosMaestra.PaisId);
                    ParametroSP("@Nombre", e_CargosMaestra.Nombre);
                    ParametroSP("@EstadoId", e_CargosMaestra.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CargosMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosMaestra.NroIpRegistro);
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

        public int Anular(CargosMaestraBE e_CargosMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosMaestraAnular", connection);
                    ParametroSP("@CargosMaestraId", e_CargosMaestra.CargosMaestraId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CargosMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosMaestra.NroIpRegistro);
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

        public List<CargosMaestraBE> Consultar_Lista()
        {
            List<CargosMaestraBE> lista = new List<CargosMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosMaestraConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CargosMaestraBE(reader));
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

        public List<CargosMaestraBE> Consultar_PK(
                int m_CargosMaestraId)
        {
            List<CargosMaestraBE> lista = new List<CargosMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosMaestraConsultar_PK", connection);
                    ParametroSP("@CargosMaestraId", m_CargosMaestraId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CargosMaestraBE(reader));
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
                    ComandoSP("usp_CargosMaestraGetMaxId", connection);
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


