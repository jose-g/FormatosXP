using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class OpinionMaestraDA : BaseDA
    {
        const string Nombre_Clase = "OpinionMaestraDA";
        private string m_BaseDatos = string.Empty;

        public OpinionMaestraDA() {  }

        public int Insertar(OpinionMaestraBE e_OpinionMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OpinionMaestraInsertar", connection);
                    ParametroSP("@OpinionMaestraId", e_OpinionMaestra.OpinionMaestraId);
                    ParametroSP("@Nombre", e_OpinionMaestra.Nombre);
                    ParametroSP("@Descripcion", e_OpinionMaestra.Descripcion);
                    ParametroSP("@EstadoId", e_OpinionMaestra.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_OpinionMaestra.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_OpinionMaestra.NroIpRegistro);
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

        public int Actualizar(OpinionMaestraBE e_OpinionMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OpinionMaestraActualizar", connection);
                    ParametroSP("@OpinionMaestraId", e_OpinionMaestra.OpinionMaestraId);
                    ParametroSP("@Nombre", e_OpinionMaestra.Nombre);
                    ParametroSP("@Descripcion", e_OpinionMaestra.Descripcion);
                    ParametroSP("@EstadoId", e_OpinionMaestra.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_OpinionMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_OpinionMaestra.NroIpRegistro);
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

        public int Anular(OpinionMaestraBE e_OpinionMaestra)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OpinionMaestraAnular", connection);
                    ParametroSP("@OpinionMaestraId", e_OpinionMaestra.OpinionMaestraId);
                    ParametroSP("@UsuarioModificacionRegistro", e_OpinionMaestra.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_OpinionMaestra.NroIpRegistro);
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

        public List<OpinionMaestraBE> Consultar_Lista()
        {
            List<OpinionMaestraBE> lista = new List<OpinionMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OpinionMaestraConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OpinionMaestraBE(reader));
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

        public List<OpinionMaestraBE> Consultar_PK(
                int m_OpinionMaestraId)
        {
            List<OpinionMaestraBE> lista = new List<OpinionMaestraBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OpinionMaestraConsultar_PK", connection);
                    ParametroSP("@OpinionMaestraId", m_OpinionMaestraId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OpinionMaestraBE(reader));
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
                    ComandoSP("usp_OpinionMaestraGetMaxId", connection);
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


