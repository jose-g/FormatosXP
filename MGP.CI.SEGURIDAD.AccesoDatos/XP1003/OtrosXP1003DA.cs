using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class OtrosXP1003DA : BaseDA
    {
        const string Nombre_Clase = "OtrosXP1003DA";
        private string m_BaseDatos = string.Empty;

        public OtrosXP1003DA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public OtrosXP1003DA() { }

        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_OtrosXP1003GetMaxId", connection);


                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!DBNull.Value.Equals(reader["CodigoMaxId"])) { maxId = Convert.ToInt32(reader["CodigoMaxId"]); }
                        }
                    }
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
            return maxId;
        }



        public int Insertar(OtrosXP1003BE e_OtrosXP1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OtrosXP1003Insertar", connection);
                    ParametroSP("@OtrosId", e_OtrosXP1003.OtrosId);
                    ParametroSP("@FichaId", e_OtrosXP1003.FichaId);
                    ParametroSP("@PathCV", e_OtrosXP1003.PathCV);
                    ParametroSP("@EstadoId", e_OtrosXP1003.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_OtrosXP1003.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_OtrosXP1003.NroIpRegistro);
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

        public int Actualizar(OtrosXP1003BE e_OtrosXP1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OtrosXP1003Actualizar", connection);
                    ParametroSP("@OtrosId", e_OtrosXP1003.OtrosId);
                    ParametroSP("@FichaId", e_OtrosXP1003.FichaId);
                    ParametroSP("@PathCV", e_OtrosXP1003.PathCV);
                    ParametroSP("@EstadoId", e_OtrosXP1003.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_OtrosXP1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_OtrosXP1003.NroIpRegistro);
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

        public int Anular(OtrosXP1003BE e_OtrosXP1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OtrosXP1003Anular", connection);
                    ParametroSP("@OtrosId", e_OtrosXP1003.OtrosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_OtrosXP1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_OtrosXP1003.NroIpRegistro);
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

        public List<OtrosXP1003BE> Consultar_Lista()
        {
            List<OtrosXP1003BE> lista = new List<OtrosXP1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OtrosXP1003Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OtrosXP1003BE(reader));
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

        public List<OtrosXP1003BE> Consultar_PK(int m_OtrosId)
        {
            List<OtrosXP1003BE> lista = new List<OtrosXP1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OtrosXP1003Consultar_PK", connection);
                    ParametroSP("@OtrosId", m_OtrosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OtrosXP1003BE(reader));
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
        public List<OtrosXP1003BE> Consultar_FK(int m_FichaId)
        {
            List<OtrosXP1003BE> lista = new List<OtrosXP1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OtrosXP1003Consultar_FK", connection);
                    ParametroSP("@FichaId", m_FichaId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OtrosXP1003BE(reader));
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
    }
}
