using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class DefectosMaestraDA : BaseDA
    {
        const string Nombre_Clase = "DefectosMaestraDA";
        private string m_BaseDatos = string.Empty;

        public DefectosMaestraDA() {  }

        public int Insertar(DefectosMaestraBE e_DefectosMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DefectosMaestraInsertar", connection);
                    ParametroSP("@DefectosMaestraId", e_DefectosMaestra.DefectosMaestraId);
                    ParametroSP("@Nombre", e_DefectosMaestra.Nombre);
                    ParametroSP("@EstadoId", e_DefectosMaestra.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_DefectosMaestra.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DefectosMaestra.NroIpRegistro);
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

        public int Actualizar(DefectosMaestraBE e_DefectosMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DefectosMaestraActualizar", connection);
                    ParametroSP("@DefectosMaestraId", e_DefectosMaestra.DefectosMaestraId);
                    ParametroSP("@Nombre", e_DefectosMaestra.Nombre);
                    ParametroSP("@EstadoId", e_DefectosMaestra.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DefectosMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DefectosMaestra.NroIpRegistro);
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

        public int Anular(DefectosMaestraBE e_DefectosMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DefectosMaestraAnular", connection);
                    ParametroSP("@DefectosMaestraId", e_DefectosMaestra.DefectosMaestraId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DefectosMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DefectosMaestra.NroIpRegistro);
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

        public List<DefectosMaestraBE> Consultar_Lista()
        {
            List<DefectosMaestraBE> lista = new List<DefectosMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DefectosMaestraConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DefectosMaestraBE(reader));
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

        public List<DefectosMaestraBE> Consultar_PK(
                int m_DefectosMaestraId)
        {
            List<DefectosMaestraBE> lista = new List<DefectosMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DefectosMaestraConsultar_PK", connection);
                    ParametroSP("@DefectosMaestraId", m_DefectosMaestraId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DefectosMaestraBE(reader));
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
                    ComandoSP("usp_DefectosMaestraGetMaxId", connection);
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


