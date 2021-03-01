using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class ValoresDemostradosDA : BaseDA
    {
        const string Nombre_Clase = "ValoresDemostradosDA";
        private string m_BaseDatos = string.Empty;

        public ValoresDemostradosDA() {  }

        public int Insertar(ValoresDemostradosBE e_ValoresDemostrados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ValoresDemostradosInsertar", connection);
                    ParametroSP("@ValoresDemostradosId", e_ValoresDemostrados.ValoresDemostradosId);
                    ParametroSP("@DatosGeneralesId", e_ValoresDemostrados.DatosGeneralesId);
                    ParametroSP("@ValoresMaestraId", e_ValoresDemostrados.ValoresMaestraId);
                    ParametroSP("@EstadoId", e_ValoresDemostrados.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_ValoresDemostrados.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_ValoresDemostrados.NroIpRegistro);
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

        public int Actualizar(ValoresDemostradosBE e_ValoresDemostrados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ValoresDemostradosActualizar", connection);
                    ParametroSP("@ValoresDemostradosId", e_ValoresDemostrados.ValoresDemostradosId);
                    ParametroSP("@DatosGeneralesId", e_ValoresDemostrados.DatosGeneralesId);
                    ParametroSP("@ValoresMaestraId", e_ValoresDemostrados.ValoresMaestraId);
                    ParametroSP("@EstadoId", e_ValoresDemostrados.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ValoresDemostrados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ValoresDemostrados.NroIpRegistro);
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

        public int Anular(ValoresDemostradosBE e_ValoresDemostrados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ValoresDemostradosAnular", connection);
                    ParametroSP("@ValoresDemostradosId", e_ValoresDemostrados.ValoresDemostradosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_ValoresDemostrados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_ValoresDemostrados.NroIpRegistro);
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

        public List<ValoresDemostradosBE> Consultar_Lista()
        {
            List<ValoresDemostradosBE> lista = new List<ValoresDemostradosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ValoresDemostradosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ValoresDemostradosBE(reader));
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

        public List<ValoresDemostradosBE> Consultar_PK(
                int m_ValoresDemostradosId)
        {
            List<ValoresDemostradosBE> lista = new List<ValoresDemostradosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ValoresDemostradosConsultar_PK", connection);
                    ParametroSP("@ValoresDemostradosId", m_ValoresDemostradosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ValoresDemostradosBE(reader));
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
                    ComandoSP("usp_ValoresDemostradosGetMaxId", connection);
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


