using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class Observaciones1005DA : BaseDA
    {
        const string Nombre_Clase = "Observaciones1005DA";
        private string m_BaseDatos = string.Empty;

        public Observaciones1005DA() {  }

        public int Insertar(Observaciones1005BE e_Observaciones1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005Insertar", connection);
                    ParametroSP("@Observaciones1005Id", e_Observaciones1005.Observaciones1005Id);
                    ParametroSP("@FichaId", e_Observaciones1005.FichaId);
                    ParametroSP("@Foto", e_Observaciones1005.Foto);
                    ParametroSP("@InformanteId", e_Observaciones1005.InformanteId);
                    ParametroSP("@InformanteIdFirma", e_Observaciones1005.InformanteIdFirma);
                    ParametroSP("@EstadoId", e_Observaciones1005.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Observaciones1005.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones1005.NroIpRegistro);
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

        public int Actualizar(Observaciones1005BE e_Observaciones1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005Actualizar", connection);
                    ParametroSP("@Observaciones1005Id", e_Observaciones1005.Observaciones1005Id);
                    ParametroSP("@FichaId", e_Observaciones1005.FichaId);
                    ParametroSP("@Foto", e_Observaciones1005.Foto);
                    ParametroSP("@InformanteId", e_Observaciones1005.InformanteId);
                    ParametroSP("@InformanteIdFirma", e_Observaciones1005.InformanteIdFirma);
                    ParametroSP("@EstadoId", e_Observaciones1005.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Observaciones1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones1005.NroIpRegistro);
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

        public int Anular(Observaciones1005BE e_Observaciones1005)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005Anular", connection);
                    ParametroSP("@Observaciones1005Id", e_Observaciones1005.Observaciones1005Id);
                    ParametroSP("@UsuarioModificacionRegistro", e_Observaciones1005.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones1005.NroIpRegistro);
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

        public List<Observaciones1005BE> Consultar_Lista()
        {
            List<Observaciones1005BE> lista = new List<Observaciones1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Observaciones1005BE(reader));
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

        public List<Observaciones1005BE> Consultar_PK(
                int m_Observaciones1005Id)
        {
            List<Observaciones1005BE> lista = new List<Observaciones1005BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Observaciones1005Consultar_PK", connection);
                    ParametroSP("@Observaciones1005Id", m_Observaciones1005Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Observaciones1005BE(reader));
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
                    ComandoSP("usp_Observaciones1005GetMaxId", connection);
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


