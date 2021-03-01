using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class DependenciasDeVisitaDA : BaseDA
    {
        const string Nombre_Clase = "DependenciasDeVisitaDA";
        private string m_BaseDatos = string.Empty;

        public DependenciasDeVisitaDA() {  }

        public int Insertar(DependenciasDeVisitaBE e_DependenciasDeVisita)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DependenciasDeVisitaInsertar", connection);
                    ParametroSP("@DependenciasDeVisitaId", e_DependenciasDeVisita.DependenciasDeVisitaId);
                    ParametroSP("@DatosGeneralesId", e_DependenciasDeVisita.DatosGeneralesId);
                    ParametroSP("@UbigeoNavalId", e_DependenciasDeVisita.UbigeoNavalId);
                    ParametroSP("@EstadoId", e_DependenciasDeVisita.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_DependenciasDeVisita.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DependenciasDeVisita.NroIpRegistro);
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

        public int Actualizar(DependenciasDeVisitaBE e_DependenciasDeVisita)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DependenciasDeVisitaActualizar", connection);
                    ParametroSP("@DependenciasDeVisitaId", e_DependenciasDeVisita.DependenciasDeVisitaId);
                    ParametroSP("@DatosGeneralesId", e_DependenciasDeVisita.DatosGeneralesId);
                    ParametroSP("@UbigeoNavalId", e_DependenciasDeVisita.UbigeoNavalId);
                    ParametroSP("@EstadoId", e_DependenciasDeVisita.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DependenciasDeVisita.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DependenciasDeVisita.NroIpRegistro);
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

        public int Anular(DependenciasDeVisitaBE e_DependenciasDeVisita)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DependenciasDeVisitaAnular", connection);
                    ParametroSP("@DependenciasDeVisitaId", e_DependenciasDeVisita.DependenciasDeVisitaId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DependenciasDeVisita.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DependenciasDeVisita.NroIpRegistro);
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

        public List<DependenciasDeVisitaBE> Consultar_Lista()
        {
            List<DependenciasDeVisitaBE> lista = new List<DependenciasDeVisitaBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DependenciasDeVisitaConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DependenciasDeVisitaBE(reader));
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

        public List<DependenciasDeVisitaBE> Consultar_PK(
                int m_DependenciasDeVisitaId)
        {
            List<DependenciasDeVisitaBE> lista = new List<DependenciasDeVisitaBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DependenciasDeVisitaConsultar_PK", connection);
                    ParametroSP("@DependenciasDeVisitaId", m_DependenciasDeVisitaId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DependenciasDeVisitaBE(reader));
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
                    ComandoSP("usp_DependenciasDeVisitaGetMaxId", connection);
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


