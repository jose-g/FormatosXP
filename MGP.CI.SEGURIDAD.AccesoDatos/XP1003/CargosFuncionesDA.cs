using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class CargosFuncionesDA : BaseDA
    {
        const string Nombre_Clase = "CargosFuncionesDA";
        private string m_BaseDatos = string.Empty;

        public CargosFuncionesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public CargosFuncionesDA() { }

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


        public int Insertar(CargosFuncionesBE e_CargosFunciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesInsertar", connection);
                    ParametroSP("@CargosFuncionesId", e_CargosFunciones.CargosFuncionesId);
                    ParametroSP("@Nombre", e_CargosFunciones.Nombre);
                    ParametroSP("@EstadoId", e_CargosFunciones.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CargosFunciones.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosFunciones.NroIpRegistro);
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

        public int Actualizar(CargosFuncionesBE e_CargosFunciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesActualizar", connection);
                    ParametroSP("@CargosFuncionesId", e_CargosFunciones.CargosFuncionesId);
                    ParametroSP("@Nombre", e_CargosFunciones.Nombre);
                    ParametroSP("@EstadoId", e_CargosFunciones.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CargosFunciones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosFunciones.NroIpRegistro);
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

        public int Anular(CargosFuncionesBE e_CargosFunciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesAnular", connection);
                    ParametroSP("@CargosFuncionesId", e_CargosFunciones.CargosFuncionesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CargosFunciones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosFunciones.NroIpRegistro);
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

        public List<CargosFuncionesBE> Consultar_Lista()
        {
            List<CargosFuncionesBE> lista = new List<CargosFuncionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CargosFuncionesBE(reader));
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

        public List<CargosFuncionesBE> Consultar_PK(
                int m_CargosFuncionesId)
        {
            List<CargosFuncionesBE> lista = new List<CargosFuncionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosFuncionesConsultar_PK", connection);
                    ParametroSP("@CargosFuncionesId", m_CargosFuncionesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CargosFuncionesBE(reader));
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
