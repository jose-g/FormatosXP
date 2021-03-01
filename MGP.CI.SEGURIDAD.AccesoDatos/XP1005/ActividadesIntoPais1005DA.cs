using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class ActividadesIntoPais1005DA : BaseDA
    {
        const string Nombre_Clase = "ActividadesIntoPais1005DA";
        private string m_BaseDatos = string.Empty;

        public ActividadesIntoPais1005DA() {  }

        public int Insertar(ActividadesIntoPais1005BE e_ActividadesIntoPais1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ActividadesIntoPais1005Insertar", connection);
                    ParametroSP("@ActividadesIntoPais1005Id", e_ActividadesIntoPais1005.ActividadesIntoPais1005Id);
                    ParametroSP("@FichaId", e_ActividadesIntoPais1005.FichaId);
                    ParametroSP("@CursoEscuelaExtranjeraId", e_ActividadesIntoPais1005.CursoEscuelaExtranjeraId);
                    ParametroSP("@EstadoId", e_ActividadesIntoPais1005.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_ActividadesIntoPais1005.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_ActividadesIntoPais1005.NroIpRegistro);
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

        public int Actualizar(ActividadesIntoPais1005BE e_ActividadesIntoPais1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ActividadesIntoPais1005Actualizar", connection);
                    ParametroSP("@ActividadesIntoPais1005Id", e_ActividadesIntoPais1005.ActividadesIntoPais1005Id);
                    ParametroSP("@FichaId", e_ActividadesIntoPais1005.FichaId);
                    ParametroSP("@CursoEscuelaExtranjeraId", e_ActividadesIntoPais1005.CursoEscuelaExtranjeraId);
                    ParametroSP("@EstadoId", e_ActividadesIntoPais1005.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ActividadesIntoPais1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ActividadesIntoPais1005.NroIpRegistro);
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

        public int Anular(ActividadesIntoPais1005BE e_ActividadesIntoPais1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ActividadesIntoPais1005Anular", connection);
                    ParametroSP("@ActividadesIntoPais1005Id", e_ActividadesIntoPais1005.ActividadesIntoPais1005Id);
                    ParametroSP("@UsuarioModificacionRegistro", e_ActividadesIntoPais1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ActividadesIntoPais1005.NroIpRegistro);
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

        public List<ActividadesIntoPais1005BE> Consultar_Lista()
        {
            List<ActividadesIntoPais1005BE> lista = new List<ActividadesIntoPais1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ActividadesIntoPais1005Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ActividadesIntoPais1005BE(reader));
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

        public List<ActividadesIntoPais1005BE> Consultar_PK(
                int m_ActividadesIntoPais1005Id)
        {
            List<ActividadesIntoPais1005BE> lista = new List<ActividadesIntoPais1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ActividadesIntoPais1005Consultar_PK", connection);
                    ParametroSP("@ActividadesIntoPais1005Id", m_ActividadesIntoPais1005Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ActividadesIntoPais1005BE(reader));
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
                    ComandoSP("usp_ActividadesIntoPais1005GetMaxId", connection);
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


