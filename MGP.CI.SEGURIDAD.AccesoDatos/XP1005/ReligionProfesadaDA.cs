using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class ReligionProfesadaDA : BaseDA
    {
        const string Nombre_Clase = "ReligionProfesadaDA";
        private string m_BaseDatos = string.Empty;

        public ReligionProfesadaDA() {  }

        public int Insertar(ReligionProfesadaBE e_ReligionProfesada)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionProfesadaInsertar", connection);
                    ParametroSP("@ReligionProfesadaId", e_ReligionProfesada.ReligionProfesadaId);
                    ParametroSP("@DatosGeneralesId", e_ReligionProfesada.DatosGeneralesId);
                    ParametroSP("@ReligionMaestraId", e_ReligionProfesada.ReligionMaestraId);
                    ParametroSP("@EstadoId", e_ReligionProfesada.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_ReligionProfesada.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_ReligionProfesada.NroIpRegistro);
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

        public int Actualizar(ReligionProfesadaBE e_ReligionProfesada)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionProfesadaActualizar", connection);
                    ParametroSP("@ReligionProfesadaId", e_ReligionProfesada.ReligionProfesadaId);
                    ParametroSP("@DatosGeneralesId", e_ReligionProfesada.DatosGeneralesId);
                    ParametroSP("@ReligionMaestraId", e_ReligionProfesada.ReligionMaestraId);
                    ParametroSP("@EstadoId", e_ReligionProfesada.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ReligionProfesada.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ReligionProfesada.NroIpRegistro);
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

        public int Anular(ReligionProfesadaBE e_ReligionProfesada)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionProfesadaAnular", connection);
                    ParametroSP("@ReligionProfesadaId", e_ReligionProfesada.ReligionProfesadaId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ReligionProfesada.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ReligionProfesada.NroIpRegistro);
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

        public List<ReligionProfesadaBE> Consultar_Lista()
        {
            List<ReligionProfesadaBE> lista = new List<ReligionProfesadaBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionProfesadaConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ReligionProfesadaBE(reader));
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

        public List<ReligionProfesadaBE> Consultar_PK(
                int m_ReligionProfesadaId)
        {
            List<ReligionProfesadaBE> lista = new List<ReligionProfesadaBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionProfesadaConsultar_PK", connection);
                    ParametroSP("@ReligionProfesadaId", m_ReligionProfesadaId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ReligionProfesadaBE(reader));
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
                    ComandoSP("usp_ReligionProfesadaGetMaxId", connection);
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


