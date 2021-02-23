using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class CargosFuncionesX1003DA : BaseDA
    {
        const string Nombre_Clase = "CargosFuncionesX1003DA";
        private string m_BaseDatos = string.Empty;

        public CargosFuncionesX1003DA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public CargosFuncionesX1003DA() {  }

        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesGetMaxId", connection);


                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!DBNull.Value.Equals(reader["CodigoMaxId"])) { maxId = Convert.ToInt32(reader["CodigoMaxId"]); }
                        }
                    }
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
            return maxId;
        }

        public int Insertar(CargosFuncionesX1003BE e_CargosFuncionesX1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesX1003Insertar", connection);
                    ParametroSP("@CargosFuncionesX1003Id", e_CargosFuncionesX1003.CargosFuncionesX1003Id);
                    ParametroSP("@FichaId", e_CargosFuncionesX1003.FichaId);
                    ParametroSP("@UbigeoId", e_CargosFuncionesX1003.UbigeoId);
                    ParametroSP("@EstadoId", e_CargosFuncionesX1003.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CargosFuncionesX1003.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosFuncionesX1003.NroIpRegistro);
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

        public int Actualizar(CargosFuncionesX1003BE e_CargosFuncionesX1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesX1003Actualizar", connection);
                    ParametroSP("@CargosFuncionesX1003Id", e_CargosFuncionesX1003.CargosFuncionesX1003Id);
                    ParametroSP("@FichaId", e_CargosFuncionesX1003.FichaId);
                    ParametroSP("@UbigeoId", e_CargosFuncionesX1003.UbigeoId);
                    ParametroSP("@EstadoId", e_CargosFuncionesX1003.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CargosFuncionesX1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosFuncionesX1003.NroIpRegistro);
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

        public int Anular(CargosFuncionesX1003BE e_CargosFuncionesX1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesX1003Anular", connection);
                    ParametroSP("@CargosFuncionesX1003Id", e_CargosFuncionesX1003.CargosFuncionesX1003Id);
                    ParametroSP("@UsuarioModificacionRegistro", e_CargosFuncionesX1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosFuncionesX1003.NroIpRegistro);
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

        public List<CargosFuncionesX1003BE> Consultar_Lista()
        {
            List<CargosFuncionesX1003BE> lista = new List<CargosFuncionesX1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesX1003Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CargosFuncionesX1003BE(reader));
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

        public List<CargosFuncionesX1003BE> Consultar_PK(
                int m_CargosFuncionesX1003Id)
        {
            List<CargosFuncionesX1003BE> lista = new List<CargosFuncionesX1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesX1003Consultar_PK", connection);
                    ParametroSP("@CargosFuncionesX1003Id", m_CargosFuncionesX1003Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CargosFuncionesX1003BE(reader));
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

    }
}
