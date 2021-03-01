using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class Observaciones1005TipoDA : BaseDA
    {
        const string Nombre_Clase = "Observaciones1005TipoDA";
        private string m_BaseDatos = string.Empty;

        public Observaciones1005TipoDA() {  }

        public int Insertar(Observaciones1005TipoBE e_Observaciones1005Tipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005TipoInsertar", connection);
                    ParametroSP("@Observaciones1005TipoId", e_Observaciones1005Tipo.Observaciones1005TipoId);
                    ParametroSP("@Nombre", e_Observaciones1005Tipo.Nombre);
                    ParametroSP("@EstadoId", e_Observaciones1005Tipo.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Observaciones1005Tipo.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones1005Tipo.NroIpRegistro);
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

        public int Actualizar(Observaciones1005TipoBE e_Observaciones1005Tipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005TipoActualizar", connection);
                    ParametroSP("@Observaciones1005TipoId", e_Observaciones1005Tipo.Observaciones1005TipoId);
                    ParametroSP("@Nombre", e_Observaciones1005Tipo.Nombre);
                    ParametroSP("@EstadoId", e_Observaciones1005Tipo.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Observaciones1005Tipo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones1005Tipo.NroIpRegistro);
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

        public int Anular(Observaciones1005TipoBE e_Observaciones1005Tipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005TipoAnular", connection);
                    ParametroSP("@Observaciones1005TipoId", e_Observaciones1005Tipo.Observaciones1005TipoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Observaciones1005Tipo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones1005Tipo.NroIpRegistro);
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

        public List<Observaciones1005TipoBE> Consultar_Lista()
        {
            List<Observaciones1005TipoBE> lista = new List<Observaciones1005TipoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005TipoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Observaciones1005TipoBE(reader));
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

        public List<Observaciones1005TipoBE> Consultar_PK(
                int m_Observaciones1005TipoId)
        {
            List<Observaciones1005TipoBE> lista = new List<Observaciones1005TipoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005TipoConsultar_PK", connection);
                    ParametroSP("@Observaciones1005TipoId", m_Observaciones1005TipoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Observaciones1005TipoBE(reader));
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
                    ComandoSP("usp_Observaciones1005TipoGetMaxId", connection);
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


