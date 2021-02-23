using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class SalasJuzgadosDA : BaseDA
    {
        const string Nombre_Clase = "SalasJuzgadosDA";
        private string m_BaseDatos = string.Empty;

        public SalasJuzgadosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(SalasJuzgadosBE e_SalasJuzgados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalasJuzgadosInsertar", connection);
                    ParametroSP("@SalaJuzgadoId", e_SalasJuzgados.SalaJuzgadoId);
                    ParametroSP("@SalaJuzgadoTipo", e_SalasJuzgados.SalaJuzgadoTipo);
                    ParametroSP("@Nombre", e_SalasJuzgados.Nombre);
                    ParametroSP("@Descripcion", e_SalasJuzgados.Descripcion);
                    ParametroSP("@EstadoId", e_SalasJuzgados.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_SalasJuzgados.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_SalasJuzgados.NroIpRegistro);
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

        public int Actualizar(SalasJuzgadosBE e_SalasJuzgados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalasJuzgadosActualizar", connection);
                    ParametroSP("@SalaJuzgadoId", e_SalasJuzgados.SalaJuzgadoId);
                    ParametroSP("@SalaJuzgadoTipo", e_SalasJuzgados.SalaJuzgadoTipo);
                    ParametroSP("@Nombre", e_SalasJuzgados.Nombre);
                    ParametroSP("@Descripcion", e_SalasJuzgados.Descripcion);
                    ParametroSP("@EstadoId", e_SalasJuzgados.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_SalasJuzgados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_SalasJuzgados.NroIpRegistro);
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

        public int Anular(SalasJuzgadosBE e_SalasJuzgados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalasJuzgadosAnular", connection);
                    ParametroSP("@SalaJuzgadoId", e_SalasJuzgados.SalaJuzgadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_SalasJuzgados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_SalasJuzgados.NroIpRegistro);
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

        public List<SalasJuzgadosBE> Consultar_Lista()
        {
            List<SalasJuzgadosBE> lista = new List<SalasJuzgadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalasJuzgadosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SalasJuzgadosBE(reader));
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

        public List<SalasJuzgadosBE> Consultar_PK(
                int m_SalaJuzgadoId)
        {
            List<SalasJuzgadosBE> lista = new List<SalasJuzgadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalasJuzgadosConsultar_PK", connection);
                    ParametroSP("@SalaJuzgadoId", m_SalaJuzgadoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SalasJuzgadosBE(reader));
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
