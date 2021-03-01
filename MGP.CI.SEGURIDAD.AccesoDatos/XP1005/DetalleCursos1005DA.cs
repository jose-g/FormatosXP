using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class DetalleCursos1005DA : BaseDA
    {
        const string Nombre_Clase = "DetalleCursos1005DA";
        private string m_BaseDatos = string.Empty;

        public DetalleCursos1005DA() {  }

        public int Insertar(DetalleCursos1005BE e_DetalleCursos1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DetalleCursos1005Insertar", connection);
                    ParametroSP("@DetalleCursos1005Id", e_DetalleCursos1005.DetalleCursos1005Id);
                    ParametroSP("@ActividadesIntoPais1005Id", e_DetalleCursos1005.ActividadesIntoPais1005Id);
                    ParametroSP("@EstadoId", e_DetalleCursos1005.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_DetalleCursos1005.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DetalleCursos1005.NroIpRegistro);
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

        public int Actualizar(DetalleCursos1005BE e_DetalleCursos1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DetalleCursos1005Actualizar", connection);
                    ParametroSP("@DetalleCursos1005Id", e_DetalleCursos1005.DetalleCursos1005Id);
                    ParametroSP("@ActividadesIntoPais1005Id", e_DetalleCursos1005.ActividadesIntoPais1005Id);
                    ParametroSP("@EstadoId", e_DetalleCursos1005.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DetalleCursos1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DetalleCursos1005.NroIpRegistro);
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

        public int Anular(DetalleCursos1005BE e_DetalleCursos1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DetalleCursos1005Anular", connection);
                    ParametroSP("@DetalleCursos1005Id", e_DetalleCursos1005.DetalleCursos1005Id);
                    ParametroSP("@UsuarioModificacionRegistro", e_DetalleCursos1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DetalleCursos1005.NroIpRegistro);
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

        public List<DetalleCursos1005BE> Consultar_Lista()
        {
            List<DetalleCursos1005BE> lista = new List<DetalleCursos1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DetalleCursos1005Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DetalleCursos1005BE(reader));
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

        public List<DetalleCursos1005BE> Consultar_PK(
                int m_DetalleCursos1005Id)
        {
            List<DetalleCursos1005BE> lista = new List<DetalleCursos1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DetalleCursos1005Consultar_PK", connection);
                    ParametroSP("@DetalleCursos1005Id", m_DetalleCursos1005Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DetalleCursos1005BE(reader));
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
                    ComandoSP("usp_DetalleCursos1005GetMaxId", connection);
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


