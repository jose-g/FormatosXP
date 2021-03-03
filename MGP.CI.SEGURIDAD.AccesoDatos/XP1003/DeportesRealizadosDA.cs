using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class DeportesRealizadosDA : BaseDA
    {
        const string Nombre_Clase = "DeportesRealizadosDA";
        private string m_BaseDatos = string.Empty;

        public DeportesRealizadosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public DeportesRealizadosDA() { }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DeportesRealizadosGetMaxId", connection);


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
        public int Insertar(DeportesRealizadosBE e_DeportesRealizados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesRealizadosInsertar", connection);
                    ParametroSP("@DeportesRealizadosId", e_DeportesRealizados.DeporteRealizadoId);
                    ParametroSP("@OtrosId", e_DeportesRealizados.OtrosId);
                    ParametroSP("@DeportesId", e_DeportesRealizados.DeportesId);
                    ParametroSP("@EstadoId", e_DeportesRealizados.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_DeportesRealizados.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DeportesRealizados.NroIpRegistro);
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

        public int Actualizar(DeportesRealizadosBE e_DeportesRealizados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesRealizadosActualizar", connection);
                    ParametroSP("@DeportesRealizadosId", e_DeportesRealizados.DeporteRealizadoId);
                    ParametroSP("@OtrosId", e_DeportesRealizados.OtrosId);
                    ParametroSP("@DeportesId", e_DeportesRealizados.DeportesId);
                    ParametroSP("@EstadoId", e_DeportesRealizados.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DeportesRealizados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DeportesRealizados.NroIpRegistro);
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

        public int Anular(DeportesRealizadosBE e_DeportesRealizados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesRealizadosAnular", connection);
                    ParametroSP("@DeportesRealizadosId", e_DeportesRealizados.DeporteRealizadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DeportesRealizados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DeportesRealizados.NroIpRegistro);
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

        public List<DeportesRealizadosBE> Consultar_Lista()
        {
            List<DeportesRealizadosBE> lista = new List<DeportesRealizadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesRealizadosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DeportesRealizadosBE(reader));
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

        public List<DeportesRealizadosBE> Consultar_PK(
                int m_DeportesRealizadosId)
        {
            List<DeportesRealizadosBE> lista = new List<DeportesRealizadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesRealizadosConsultar_PK", connection);
                    ParametroSP("@DeportesRealizadosId", m_DeportesRealizadosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DeportesRealizadosBE(reader));
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
        public List<DeportesRealizadosBE> Consultar_FK(
                int m_OtrosId)
        {
            List<DeportesRealizadosBE> lista = new List<DeportesRealizadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesRealizadosConsultar_FK", connection);
                    ParametroSP("@OtrosId", m_OtrosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DeportesRealizadosBE(reader));
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
