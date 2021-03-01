using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class IdiomasHabladosDA : BaseDA
    {
        const string Nombre_Clase = "IdiomasHabladosDA";
        private string m_BaseDatos = string.Empty;

        public IdiomasHabladosDA() {  }

        public int Insertar(IdiomasHabladosBE e_IdiomasHablados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomasHabladosInsertar", connection);
                    ParametroSP("@IdiomasHabladosId", e_IdiomasHablados.IdiomasHabladosId);
                    ParametroSP("@DatosGeneralesId", e_IdiomasHablados.DatosGeneralesId);
                    ParametroSP("@IdiomaId", e_IdiomasHablados.IdiomaId);
                    ParametroSP("@EstadoId", e_IdiomasHablados.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_IdiomasHablados.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_IdiomasHablados.NroIpRegistro);
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

        public int Actualizar(IdiomasHabladosBE e_IdiomasHablados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomasHabladosActualizar", connection);
                    ParametroSP("@IdiomasHabladosId", e_IdiomasHablados.IdiomasHabladosId);
                    ParametroSP("@DatosGeneralesId", e_IdiomasHablados.DatosGeneralesId);
                    ParametroSP("@IdiomaId", e_IdiomasHablados.IdiomaId);
                    ParametroSP("@EstadoId", e_IdiomasHablados.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_IdiomasHablados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_IdiomasHablados.NroIpRegistro);
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

        public int Anular(IdiomasHabladosBE e_IdiomasHablados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomasHabladosAnular", connection);
                    ParametroSP("@IdiomasHabladosId", e_IdiomasHablados.IdiomasHabladosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_IdiomasHablados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_IdiomasHablados.NroIpRegistro);
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

        public List<IdiomasHabladosBE> Consultar_Lista()
        {
            List<IdiomasHabladosBE> lista = new List<IdiomasHabladosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomasHabladosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IdiomasHabladosBE(reader));
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

        public List<IdiomasHabladosBE> Consultar_PK(
                int m_IdiomasHabladosId)
        {
            List<IdiomasHabladosBE> lista = new List<IdiomasHabladosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomasHabladosConsultar_PK", connection);
                    ParametroSP("@IdiomasHabladosId", m_IdiomasHabladosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IdiomasHabladosBE(reader));
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
                    ComandoSP("usp_IdiomasHabladosGetMaxId", connection);
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


