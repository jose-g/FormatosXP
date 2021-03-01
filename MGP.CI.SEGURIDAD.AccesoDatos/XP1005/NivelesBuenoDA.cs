using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class NivelesBuenoDA : BaseDA
    {
        const string Nombre_Clase = "NivelesBuenoDA";
        private string m_BaseDatos = string.Empty;

        public NivelesBuenoDA() {  }

        public int Insertar(NivelesBuenoBE e_NivelesBueno)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesBuenoInsertar", connection);
                    ParametroSP("@NivelesBuenoId", e_NivelesBueno.NivelesBuenoId);
                    ParametroSP("@Nombre", e_NivelesBueno.Nombre);
                    ParametroSP("@Descripcion", e_NivelesBueno.Descripcion);
                    ParametroSP("@EstadoId", e_NivelesBueno.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_NivelesBueno.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_NivelesBueno.NroIpRegistro);
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

        public int Actualizar(NivelesBuenoBE e_NivelesBueno)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesBuenoActualizar", connection);
                    ParametroSP("@NivelesBuenoId", e_NivelesBueno.NivelesBuenoId);
                    ParametroSP("@Nombre", e_NivelesBueno.Nombre);
                    ParametroSP("@Descripcion", e_NivelesBueno.Descripcion);
                    ParametroSP("@EstadoId", e_NivelesBueno.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_NivelesBueno.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_NivelesBueno.NroIpRegistro);
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

        public int Anular(NivelesBuenoBE e_NivelesBueno)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesBuenoAnular", connection);
                    ParametroSP("@NivelesBuenoId", e_NivelesBueno.NivelesBuenoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_NivelesBueno.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_NivelesBueno.NroIpRegistro);
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

        public List<NivelesBuenoBE> Consultar_Lista()
        {
            List<NivelesBuenoBE> lista = new List<NivelesBuenoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesBuenoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new NivelesBuenoBE(reader));
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

        public List<NivelesBuenoBE> Consultar_PK(
                int m_NivelesBuenoId)
        {
            List<NivelesBuenoBE> lista = new List<NivelesBuenoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NivelesBuenoConsultar_PK", connection);
                    ParametroSP("@NivelesBuenoId", m_NivelesBuenoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new NivelesBuenoBE(reader));
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
                    ComandoSP("usp_NivelesBuenoGetMaxId", connection);
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


