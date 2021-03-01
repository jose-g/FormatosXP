using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class BienesEconomicosMaestraDA : BaseDA
    {
        const string Nombre_Clase = "BienesEconomicosMaestraDA";
        private string m_BaseDatos = string.Empty;

        public BienesEconomicosMaestraDA() {  }

        public int Insertar(BienesEconomicosMaestraBE e_BienesEconomicosMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_BienesEconomicosMaestraInsertar", connection);
                    ParametroSP("@BienesEconomicosMaestraId", e_BienesEconomicosMaestra.BienesEconomicosMaestraId);
                    ParametroSP("@NombreRegistro", e_BienesEconomicosMaestra.NombreRegistro);
                    ParametroSP("@NombreTipo", e_BienesEconomicosMaestra.NombreTipo);
                    ParametroSP("@NombreBien", e_BienesEconomicosMaestra.NombreBien);
                    ParametroSP("@EstadoId", e_BienesEconomicosMaestra.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_BienesEconomicosMaestra.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_BienesEconomicosMaestra.NroIpRegistro);
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

        public int Actualizar(BienesEconomicosMaestraBE e_BienesEconomicosMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_BienesEconomicosMaestraActualizar", connection);
                    ParametroSP("@BienesEconomicosMaestraId", e_BienesEconomicosMaestra.BienesEconomicosMaestraId);
                    ParametroSP("@NombreRegistro", e_BienesEconomicosMaestra.NombreRegistro);
                    ParametroSP("@NombreTipo", e_BienesEconomicosMaestra.NombreTipo);
                    ParametroSP("@NombreBien", e_BienesEconomicosMaestra.NombreBien);
                    ParametroSP("@EstadoId", e_BienesEconomicosMaestra.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_BienesEconomicosMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_BienesEconomicosMaestra.NroIpRegistro);
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

        public int Anular(BienesEconomicosMaestraBE e_BienesEconomicosMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_BienesEconomicosMaestraAnular", connection);
                    ParametroSP("@BienesEconomicosMaestraId", e_BienesEconomicosMaestra.BienesEconomicosMaestraId);
                    ParametroSP("@UsuarioModificacionRegistro", e_BienesEconomicosMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_BienesEconomicosMaestra.NroIpRegistro);
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

        public List<BienesEconomicosMaestraBE> Consultar_Lista()
        {
            List<BienesEconomicosMaestraBE> lista = new List<BienesEconomicosMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_BienesEconomicosMaestraConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BienesEconomicosMaestraBE(reader));
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

        public List<BienesEconomicosMaestraBE> Consultar_PK(
                int m_BienesEconomicosMaestraId)
        {
            List<BienesEconomicosMaestraBE> lista = new List<BienesEconomicosMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_BienesEconomicosMaestraConsultar_PK", connection);
                    ParametroSP("@BienesEconomicosMaestraId", m_BienesEconomicosMaestraId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BienesEconomicosMaestraBE(reader));
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
                    ComandoSP("usp_BienesEconomicosMaestraGetMaxId", connection);
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


