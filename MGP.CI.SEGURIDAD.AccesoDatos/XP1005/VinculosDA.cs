using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class VinculosDA : BaseDA
    {
        const string Nombre_Clase = "VinculosDA";
        private string m_BaseDatos = string.Empty;

        public VinculosDA() {  }

        public int Insertar(VinculosBE e_Vinculos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VinculosInsertar", connection);
                    ParametroSP("@VinculoId", e_Vinculos.VinculoId);
                    ParametroSP("@Nombre", e_Vinculos.Nombre);
                    ParametroSP("@Descripcion", e_Vinculos.Descripcion);
                    ParametroSP("@EstadoId", e_Vinculos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Vinculos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Vinculos.NroIpRegistro);
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

        public int Actualizar(VinculosBE e_Vinculos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VinculosActualizar", connection);
                    ParametroSP("@VinculoId", e_Vinculos.VinculoId);
                    ParametroSP("@Nombre", e_Vinculos.Nombre);
                    ParametroSP("@Descripcion", e_Vinculos.Descripcion);
                    ParametroSP("@EstadoId", e_Vinculos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Vinculos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Vinculos.NroIpRegistro);
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

        public int Anular(VinculosBE e_Vinculos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VinculosAnular", connection);
                    ParametroSP("@VinculoId", e_Vinculos.VinculoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Vinculos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Vinculos.NroIpRegistro);
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

        public List<VinculosBE> Consultar_Lista()
        {
            List<VinculosBE> lista = new List<VinculosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VinculosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new VinculosBE(reader));
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

        public List<VinculosBE> Consultar_PK(
                int m_VinculoId)
        {
            List<VinculosBE> lista = new List<VinculosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VinculosConsultar_PK", connection);
                    ParametroSP("@VinculoId", m_VinculoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new VinculosBE(reader));
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
                    ComandoSP("usp_VinculosGetMaxId", connection);
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


