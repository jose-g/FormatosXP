using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class InformacionCastrenseX1003DA : BaseDA
    {
        const string Nombre_Clase = "InformacionCastrenseX1003DA";
        private string m_BaseDatos = string.Empty;

        public InformacionCastrenseX1003DA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public InformacionCastrenseX1003DA() { }

        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_InformacionCastrenseGetMaxId", connection);


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


        public int Insertar(InformacionCastrenseX1003BE e_InformacionCastrenseX1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InformacionCastrenseX1003Insertar", connection);
                    ParametroSP("@InformacionCastrenseId", e_InformacionCastrenseX1003.InformacionCastrenseId);
                    ParametroSP("@FichaId", e_InformacionCastrenseX1003.FichaId);
                    ParametroSP("@EstadoId", e_InformacionCastrenseX1003.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_InformacionCastrenseX1003.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_InformacionCastrenseX1003.NroIpRegistro);
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

        public int Actualizar(InformacionCastrenseX1003BE e_InformacionCastrenseX1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InformacionCastrenseX1003Actualizar", connection);
                    ParametroSP("@InformacionCastrenseId", e_InformacionCastrenseX1003.InformacionCastrenseId);
                    ParametroSP("@FichaId", e_InformacionCastrenseX1003.FichaId);
                    ParametroSP("@EstadoId", e_InformacionCastrenseX1003.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_InformacionCastrenseX1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_InformacionCastrenseX1003.NroIpRegistro);
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

        public int Anular(InformacionCastrenseX1003BE e_InformacionCastrenseX1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InformacionCastrenseX1003Anular", connection);
                    ParametroSP("@InformacionCastrenseId", e_InformacionCastrenseX1003.InformacionCastrenseId);
                    ParametroSP("@UsuarioModificacionRegistro", e_InformacionCastrenseX1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_InformacionCastrenseX1003.NroIpRegistro);
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

        public List<InformacionCastrenseX1003BE> Consultar_Lista()
        {
            List<InformacionCastrenseX1003BE> lista = new List<InformacionCastrenseX1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InformacionCastrenseX1003Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InformacionCastrenseX1003BE(reader));
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

        public List<InformacionCastrenseX1003BE> Consultar_PK(
                int m_InformacionCastrenseId)
        {
            List<InformacionCastrenseX1003BE> lista = new List<InformacionCastrenseX1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InformacionCastrenseX1003Consultar_PK", connection);
                    ParametroSP("@InformacionCastrenseId", m_InformacionCastrenseId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InformacionCastrenseX1003BE(reader));
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
