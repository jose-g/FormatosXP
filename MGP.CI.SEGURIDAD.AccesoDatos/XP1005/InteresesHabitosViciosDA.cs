using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class InteresesHabitosViciosDA : BaseDA
    {
        const string Nombre_Clase = "InteresesHabitosViciosDA";
        private string m_BaseDatos = string.Empty;

        public InteresesHabitosViciosDA() {  }

        public int Insertar(InteresesHabitosViciosBE e_InteresesHabitosVicios)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InteresesHabitosViciosInsertar", connection);
                    ParametroSP("@InteresHabitosId", e_InteresesHabitosVicios.InteresHabitosId);
                    ParametroSP("@InteresHabitosTipo", e_InteresesHabitosVicios.InteresHabitosTipo);
                    ParametroSP("@InteresHabitosNombre", e_InteresesHabitosVicios.InteresHabitosNombre);
                    ParametroSP("@EstadoId", e_InteresesHabitosVicios.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_InteresesHabitosVicios.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_InteresesHabitosVicios.NroIpRegistro);
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

        public int Actualizar(InteresesHabitosViciosBE e_InteresesHabitosVicios)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InteresesHabitosViciosActualizar", connection);
                    ParametroSP("@InteresHabitosId", e_InteresesHabitosVicios.InteresHabitosId);
                    ParametroSP("@InteresHabitosTipo", e_InteresesHabitosVicios.InteresHabitosTipo);
                    ParametroSP("@InteresHabitosNombre", e_InteresesHabitosVicios.InteresHabitosNombre);
                    ParametroSP("@EstadoId", e_InteresesHabitosVicios.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_InteresesHabitosVicios.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_InteresesHabitosVicios.NroIpRegistro);
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

        public int Anular(InteresesHabitosViciosBE e_InteresesHabitosVicios)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InteresesHabitosViciosAnular", connection);
                    ParametroSP("@InteresHabitosId", e_InteresesHabitosVicios.InteresHabitosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_InteresesHabitosVicios.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_InteresesHabitosVicios.NroIpRegistro);
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

        public List<InteresesHabitosViciosBE> Consultar_Lista()
        {
            List<InteresesHabitosViciosBE> lista = new List<InteresesHabitosViciosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InteresesHabitosViciosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InteresesHabitosViciosBE(reader));
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

        public List<InteresesHabitosViciosBE> Consultar_PK(
                int m_InteresHabitosId)
        {
            List<InteresesHabitosViciosBE> lista = new List<InteresesHabitosViciosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InteresesHabitosViciosConsultar_PK", connection);
                    ParametroSP("@InteresHabitosId", m_InteresHabitosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InteresesHabitosViciosBE(reader));
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
                    ComandoSP("usp_InteresesHabitosViciosGetMaxId", connection);
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


