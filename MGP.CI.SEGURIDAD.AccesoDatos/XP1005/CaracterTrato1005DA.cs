using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class CaracterTrato1005DA : BaseDA
    {
        const string Nombre_Clase = "CaracterTrato1005DA";
        private string m_BaseDatos = string.Empty;

        public CaracterTrato1005DA() {  }

        public int Insertar(CaracterTrato1005BE e_CaracterTrato1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CaracterTrato1005Insertar", connection);
                    ParametroSP("@CaracterTrato1005Id", e_CaracterTrato1005.CaracterTrato1005Id);
                    ParametroSP("@FichaId", e_CaracterTrato1005.FichaId);
                    ParametroSP("@NivelDesarrolloProfesional", e_CaracterTrato1005.NivelDesarrolloProfesional);
                    ParametroSP("@DescripcionDesarrolloProfesional", e_CaracterTrato1005.DescripcionDesarrolloProfesional);
                    ParametroSP("@NivelCI", e_CaracterTrato1005.NivelCI);
                    ParametroSP("@DescripcionCI", e_CaracterTrato1005.DescripcionCI);
                    ParametroSP("@RelacionConCompaneros", e_CaracterTrato1005.RelacionConCompaneros);
                    ParametroSP("@EstadoId", e_CaracterTrato1005.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CaracterTrato1005.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CaracterTrato1005.NroIpRegistro);
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

        public int Actualizar(CaracterTrato1005BE e_CaracterTrato1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CaracterTrato1005Actualizar", connection);
                    ParametroSP("@CaracterTrato1005Id", e_CaracterTrato1005.CaracterTrato1005Id);
                    ParametroSP("@FichaId", e_CaracterTrato1005.FichaId);
                    ParametroSP("@NivelDesarrolloProfesional", e_CaracterTrato1005.NivelDesarrolloProfesional);
                    ParametroSP("@DescripcionDesarrolloProfesional", e_CaracterTrato1005.DescripcionDesarrolloProfesional);
                    ParametroSP("@NivelCI", e_CaracterTrato1005.NivelCI);
                    ParametroSP("@DescripcionCI", e_CaracterTrato1005.DescripcionCI);
                    ParametroSP("@RelacionConCompaneros", e_CaracterTrato1005.RelacionConCompaneros);
                    ParametroSP("@EstadoId", e_CaracterTrato1005.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CaracterTrato1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CaracterTrato1005.NroIpRegistro);
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

        public int Anular(CaracterTrato1005BE e_CaracterTrato1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CaracterTrato1005Anular", connection);
                    ParametroSP("@CaracterTrato1005Id", e_CaracterTrato1005.CaracterTrato1005Id);
                    ParametroSP("@UsuarioModificacionRegistro", e_CaracterTrato1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CaracterTrato1005.NroIpRegistro);
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

        public List<CaracterTrato1005BE> Consultar_Lista()
        {
            List<CaracterTrato1005BE> lista = new List<CaracterTrato1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CaracterTrato1005Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CaracterTrato1005BE(reader));
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

        public List<CaracterTrato1005BE> Consultar_PK(
                int m_CaracterTrato1005Id)
        {
            List<CaracterTrato1005BE> lista = new List<CaracterTrato1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CaracterTrato1005Consultar_PK", connection);
                    ParametroSP("@CaracterTrato1005Id", m_CaracterTrato1005Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CaracterTrato1005BE(reader));
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
                    ComandoSP("usp_CaracterTrato1005GetMaxId", connection);
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


