using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class PsicologicoInteresesHabitosDA : BaseDA
    {
        const string Nombre_Clase = "PsicologicoInteresesHabitosDA";
        private string m_BaseDatos = string.Empty;

        public PsicologicoInteresesHabitosDA() {  }

        public int Insertar(PsicologicoInteresesHabitosBE e_PsicologicoInteresesHabitos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PsicologicoInteresesHabitosInsertar", connection);
                    ParametroSP("@PsicologicoInteresesHabitosId", e_PsicologicoInteresesHabitos.PsicologicoInteresesHabitosId);
                    ParametroSP("@PerfilPsicologicoDetallesId", e_PsicologicoInteresesHabitos.PerfilPsicologicoDetallesId);
                    ParametroSP("@NivelesMadurez1005Id", e_PsicologicoInteresesHabitos.NivelesMadurez1005Id);
                    ParametroSP("@InteresHabitosId", e_PsicologicoInteresesHabitos.InteresHabitosId);
                    ParametroSP("@Descripcion", e_PsicologicoInteresesHabitos.Descripcion);
                    ParametroSP("@EstadoId", e_PsicologicoInteresesHabitos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_PsicologicoInteresesHabitos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_PsicologicoInteresesHabitos.NroIpRegistro);
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

        public int Actualizar(PsicologicoInteresesHabitosBE e_PsicologicoInteresesHabitos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PsicologicoInteresesHabitosActualizar", connection);
                    ParametroSP("@PsicologicoInteresesHabitosId", e_PsicologicoInteresesHabitos.PsicologicoInteresesHabitosId);
                    ParametroSP("@PerfilPsicologicoDetallesId", e_PsicologicoInteresesHabitos.PerfilPsicologicoDetallesId);
                    ParametroSP("@NivelesMadurez1005Id", e_PsicologicoInteresesHabitos.NivelesMadurez1005Id);
                    ParametroSP("@InteresHabitosId", e_PsicologicoInteresesHabitos.InteresHabitosId);
                    ParametroSP("@Descripcion", e_PsicologicoInteresesHabitos.Descripcion);
                    ParametroSP("@EstadoId", e_PsicologicoInteresesHabitos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PsicologicoInteresesHabitos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PsicologicoInteresesHabitos.NroIpRegistro);
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

        public int Anular(PsicologicoInteresesHabitosBE e_PsicologicoInteresesHabitos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PsicologicoInteresesHabitosAnular", connection);
                    ParametroSP("@PsicologicoInteresesHabitosId", e_PsicologicoInteresesHabitos.PsicologicoInteresesHabitosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PsicologicoInteresesHabitos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PsicologicoInteresesHabitos.NroIpRegistro);
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

        public List<PsicologicoInteresesHabitosBE> Consultar_Lista()
        {
            List<PsicologicoInteresesHabitosBE> lista = new List<PsicologicoInteresesHabitosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PsicologicoInteresesHabitosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PsicologicoInteresesHabitosBE(reader));
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

        public List<PsicologicoInteresesHabitosBE> Consultar_PK(
                int m_PsicologicoInteresesHabitosId)
        {
            List<PsicologicoInteresesHabitosBE> lista = new List<PsicologicoInteresesHabitosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PsicologicoInteresesHabitosConsultar_PK", connection);
                    ParametroSP("@PsicologicoInteresesHabitosId", m_PsicologicoInteresesHabitosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PsicologicoInteresesHabitosBE(reader));
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
                    ComandoSP("usp_PsicologicoInteresesHabitosGetMaxId", connection);
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


