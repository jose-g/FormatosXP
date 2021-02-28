using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class CargosFuncionesRealizadasDA : BaseDA
    {
        const string Nombre_Clase = "CargosFuncionesRealizadasDA";
        private string m_BaseDatos = string.Empty;

        public CargosFuncionesRealizadasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public CargosFuncionesRealizadasDA() { }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesRealizadasGetMaxId", connection);


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
        public int Insertar(CargosFuncionesRealizadasBE e_CargosFuncionesRealizadas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesRealizadasInsertar", connection);
                    ParametroSP("@CargosFuncionesRealizadasId", e_CargosFuncionesRealizadas.CargosFuncionesRealizadasId);
                    ParametroSP("@CargosFuncionesId", e_CargosFuncionesRealizadas.CargosFuncionesId);
                    ParametroSP("@InformacionCastrenseId", e_CargosFuncionesRealizadas.InformacionCastrenseId);
                    ParametroSP("@FechaInicio", e_CargosFuncionesRealizadas.Cargos_Funciones_FechaInicio);
                    ParametroSP("@FechaFin", e_CargosFuncionesRealizadas.Cargos_Funciones_FechaFin);
                    ParametroSP("@EstadoId", e_CargosFuncionesRealizadas.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CargosFuncionesRealizadas.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosFuncionesRealizadas.NroIpRegistro);
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

        public int Actualizar(CargosFuncionesRealizadasBE e_CargosFuncionesRealizadas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesRealizadasActualizar", connection);
                    ParametroSP("@CargosFuncionesRealizadasId", e_CargosFuncionesRealizadas.CargosFuncionesRealizadasId);
                    ParametroSP("@CargosFuncionesId", e_CargosFuncionesRealizadas.CargosFuncionesId);
                    ParametroSP("@InformacionCastrenseId", e_CargosFuncionesRealizadas.InformacionCastrenseId);
                    ParametroSP("@FechaInicio", e_CargosFuncionesRealizadas.Cargos_Funciones_FechaInicio);
                    ParametroSP("@FechaFin", e_CargosFuncionesRealizadas.Cargos_Funciones_FechaFin);
                    ParametroSP("@EstadoId", e_CargosFuncionesRealizadas.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CargosFuncionesRealizadas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosFuncionesRealizadas.NroIpRegistro);
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

        public int Anular(CargosFuncionesRealizadasBE e_CargosFuncionesRealizadas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesRealizadasAnular", connection);
                    ParametroSP("@CargosFuncionesRealizadasId", e_CargosFuncionesRealizadas.CargosFuncionesRealizadasId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CargosFuncionesRealizadas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosFuncionesRealizadas.NroIpRegistro);
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

        public List<CargosFuncionesRealizadasBE> Consultar_Lista()
        {
            List<CargosFuncionesRealizadasBE> lista = new List<CargosFuncionesRealizadasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesRealizadasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CargosFuncionesRealizadasBE(reader));
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

        public List<CargosFuncionesRealizadasBE> Consultar_PK(
                int m_CargosFuncionesRealizadas)
        {
            List<CargosFuncionesRealizadasBE> lista = new List<CargosFuncionesRealizadasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesRealizadasConsultar_PK", connection);
                    ParametroSP("@CargosFuncionesRealizadasId", m_CargosFuncionesRealizadas);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CargosFuncionesRealizadasBE(reader));
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
