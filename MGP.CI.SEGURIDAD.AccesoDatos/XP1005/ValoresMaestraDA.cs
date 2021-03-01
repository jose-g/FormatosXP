using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class ValoresMaestraDA : BaseDA
    {
        const string Nombre_Clase = "ValoresMaestraDA";
        private string m_BaseDatos = string.Empty;

        public ValoresMaestraDA() {  }

        public int Insertar(ValoresMaestraBE e_ValoresMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ValoresMaestraInsertar", connection);
                    ParametroSP("@ValoresMaestraId", e_ValoresMaestra.ValoresMaestraId);
                    ParametroSP("@Nombre", e_ValoresMaestra.Nombre);
                    ParametroSP("@EstadoId", e_ValoresMaestra.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_ValoresMaestra.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_ValoresMaestra.NroIpRegistro);
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

        public int Actualizar(ValoresMaestraBE e_ValoresMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ValoresMaestraActualizar", connection);
                    ParametroSP("@ValoresMaestraId", e_ValoresMaestra.ValoresMaestraId);
                    ParametroSP("@Nombre", e_ValoresMaestra.Nombre);
                    ParametroSP("@EstadoId", e_ValoresMaestra.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ValoresMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ValoresMaestra.NroIpRegistro);
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

        public int Anular(ValoresMaestraBE e_ValoresMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ValoresMaestraAnular", connection);
                    ParametroSP("@ValoresMaestraId", e_ValoresMaestra.ValoresMaestraId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ValoresMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ValoresMaestra.NroIpRegistro);
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

        public List<ValoresMaestraBE> Consultar_Lista()
        {
            List<ValoresMaestraBE> lista = new List<ValoresMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ValoresMaestraConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ValoresMaestraBE(reader));
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

        public List<ValoresMaestraBE> Consultar_PK(
                int m_ValoresMaestraId)
        {
            List<ValoresMaestraBE> lista = new List<ValoresMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ValoresMaestraConsultar_PK", connection);
                    ParametroSP("@ValoresMaestraId", m_ValoresMaestraId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ValoresMaestraBE(reader));
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
                    ComandoSP("usp_ValoresMaestraGetMaxId", connection);
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


