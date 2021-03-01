using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class PreferenciaSexualProfesadaDA : BaseDA
    {
        const string Nombre_Clase = "PreferenciaSexualProfesadaDA";
        private string m_BaseDatos = string.Empty;

        public PreferenciaSexualProfesadaDA() {  }

        public int Insertar(PreferenciaSexualProfesadaBE e_PreferenciaSexualProfesada)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualProfesadaInsertar", connection);
                    ParametroSP("@PreferenciaSexualProfesadaID", e_PreferenciaSexualProfesada.PreferenciaSexualProfesadaID);
                    ParametroSP("@DatosGeneralesId", e_PreferenciaSexualProfesada.DatosGeneralesId);
                    ParametroSP("@PreferenciaSexualMaestraId", e_PreferenciaSexualProfesada.PreferenciaSexualMaestraId);
                    ParametroSP("@EstadoId", e_PreferenciaSexualProfesada.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_PreferenciaSexualProfesada.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_PreferenciaSexualProfesada.NroIpRegistro);
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

        public int Actualizar(PreferenciaSexualProfesadaBE e_PreferenciaSexualProfesada)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualProfesadaActualizar", connection);
                    ParametroSP("@PreferenciaSexualProfesadaID", e_PreferenciaSexualProfesada.PreferenciaSexualProfesadaID);
                    ParametroSP("@DatosGeneralesId", e_PreferenciaSexualProfesada.DatosGeneralesId);
                    ParametroSP("@PreferenciaSexualMaestraId", e_PreferenciaSexualProfesada.PreferenciaSexualMaestraId);
                    ParametroSP("@EstadoId", e_PreferenciaSexualProfesada.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PreferenciaSexualProfesada.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PreferenciaSexualProfesada.NroIpRegistro);
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

        public int Anular(PreferenciaSexualProfesadaBE e_PreferenciaSexualProfesada)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualProfesadaAnular", connection);
                    ParametroSP("@PreferenciaSexualProfesadaID", e_PreferenciaSexualProfesada.PreferenciaSexualProfesadaID);
                    ParametroSP("@UsuarioModificacionRegistro", e_PreferenciaSexualProfesada.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PreferenciaSexualProfesada.NroIpRegistro);
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

        public List<PreferenciaSexualProfesadaBE> Consultar_Lista()
        {
            List<PreferenciaSexualProfesadaBE> lista = new List<PreferenciaSexualProfesadaBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualProfesadaConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PreferenciaSexualProfesadaBE(reader));
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

        public List<PreferenciaSexualProfesadaBE> Consultar_PK(
                int m_PreferenciaSexualProfesadaID)
        {
            List<PreferenciaSexualProfesadaBE> lista = new List<PreferenciaSexualProfesadaBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PreferenciaSexualProfesadaConsultar_PK", connection);
                    ParametroSP("@PreferenciaSexualProfesadaID", m_PreferenciaSexualProfesadaID);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PreferenciaSexualProfesadaBE(reader));
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
                    ComandoSP("usp_PreferenciaSexualProfesadaGetMaxId", connection);
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


