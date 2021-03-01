using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class ContexturaDA : BaseDA
    {
        const string Nombre_Clase = "ContexturaDA";
        private string m_BaseDatos = string.Empty;

        public ContexturaDA() {  }

        public int Insertar(ContexturaBE e_Contextura)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ContexturaInsertar", connection);
                    ParametroSP("@ContexturaId", e_Contextura.ContexturaId);
                    ParametroSP("@Nombre", e_Contextura.Nombre);
                    ParametroSP("@EstadoId", e_Contextura.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Contextura.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Contextura.NroIpRegistro);
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

        public int Actualizar(ContexturaBE e_Contextura)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ContexturaActualizar", connection);
                    ParametroSP("@ContexturaId", e_Contextura.ContexturaId);
                    ParametroSP("@Nombre", e_Contextura.Nombre);
                    ParametroSP("@EstadoId", e_Contextura.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Contextura.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Contextura.NroIpRegistro);
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

        public int Anular(ContexturaBE e_Contextura)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ContexturaAnular", connection);
                    ParametroSP("@ContexturaId", e_Contextura.ContexturaId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Contextura.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Contextura.NroIpRegistro);
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

        public List<ContexturaBE> Consultar_Lista()
        {
            List<ContexturaBE> lista = new List<ContexturaBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ContexturaConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ContexturaBE(reader));
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

        public List<ContexturaBE> Consultar_PK(
                int m_ContexturaId)
        {
            List<ContexturaBE> lista = new List<ContexturaBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ContexturaConsultar_PK", connection);
                    ParametroSP("@ContexturaId", m_ContexturaId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ContexturaBE(reader));
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
                    ComandoSP("usp_ContexturaGetMaxId", connection);
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


