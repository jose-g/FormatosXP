using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class RelacionesInterpersonalesDA : BaseDA
    {
        const string Nombre_Clase = "RelacionesInterpersonalesDA";
        private string m_BaseDatos = string.Empty;

        public RelacionesInterpersonalesDA() {  }

        public int Insertar(RelacionesInterpersonalesBE e_RelacionesInterpersonales)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RelacionesInterpersonalesInsertar", connection);
                    ParametroSP("@RelacionesInterpersonalesId", e_RelacionesInterpersonales.RelacionesInterpersonalesId);
                    ParametroSP("@RelacionesInterpersonalesTipo", e_RelacionesInterpersonales.RelacionesInterpersonalesTipo);
                    ParametroSP("@Nombre", e_RelacionesInterpersonales.Nombre);
                    ParametroSP("@EstadoId", e_RelacionesInterpersonales.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_RelacionesInterpersonales.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_RelacionesInterpersonales.NroIpRegistro);
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

        public int Actualizar(RelacionesInterpersonalesBE e_RelacionesInterpersonales)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RelacionesInterpersonalesActualizar", connection);
                    ParametroSP("@RelacionesInterpersonalesId", e_RelacionesInterpersonales.RelacionesInterpersonalesId);
                    ParametroSP("@RelacionesInterpersonalesTipo", e_RelacionesInterpersonales.RelacionesInterpersonalesTipo);
                    ParametroSP("@Nombre", e_RelacionesInterpersonales.Nombre);
                    ParametroSP("@EstadoId", e_RelacionesInterpersonales.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_RelacionesInterpersonales.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_RelacionesInterpersonales.NroIpRegistro);
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

        public int Anular(RelacionesInterpersonalesBE e_RelacionesInterpersonales)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RelacionesInterpersonalesAnular", connection);
                    ParametroSP("@RelacionesInterpersonalesId", e_RelacionesInterpersonales.RelacionesInterpersonalesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_RelacionesInterpersonales.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_RelacionesInterpersonales.NroIpRegistro);
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

        public List<RelacionesInterpersonalesBE> Consultar_Lista()
        {
            List<RelacionesInterpersonalesBE> lista = new List<RelacionesInterpersonalesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RelacionesInterpersonalesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new RelacionesInterpersonalesBE(reader));
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

        public List<RelacionesInterpersonalesBE> Consultar_PK(
                int m_RelacionesInterpersonalesId)
        {
            List<RelacionesInterpersonalesBE> lista = new List<RelacionesInterpersonalesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RelacionesInterpersonalesConsultar_PK", connection);
                    ParametroSP("@RelacionesInterpersonalesId", m_RelacionesInterpersonalesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new RelacionesInterpersonalesBE(reader));
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
                    ComandoSP("usp_RelacionesInterpersonalesGetMaxId", connection);
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


