using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class GradoInstruccionDA : BaseDA
    {
        const string Nombre_Clase = "GradoInstruccionDA";
        private string m_BaseDatos = string.Empty;

        public GradoInstruccionDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(GradoInstruccionBE e_GradoInstruccion)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradoInstruccionInsertar", connection);
                    ParametroSP("@GradoInstruccionId", e_GradoInstruccion.GradoInstruccionId);
                    ParametroSP("@Nombre", e_GradoInstruccion.Nombre);
                    ParametroSP("@Descripcion", e_GradoInstruccion.Descripcion);
                    ParametroSP("@EstadoId", e_GradoInstruccion.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_GradoInstruccion.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_GradoInstruccion.NroIpRegistro);
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

        public int Actualizar(GradoInstruccionBE e_GradoInstruccion)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradoInstruccionActualizar", connection);
                    ParametroSP("@GradoInstruccionId", e_GradoInstruccion.GradoInstruccionId);
                    ParametroSP("@Nombre", e_GradoInstruccion.Nombre);
                    ParametroSP("@Descripcion", e_GradoInstruccion.Descripcion);
                    ParametroSP("@EstadoId", e_GradoInstruccion.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_GradoInstruccion.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_GradoInstruccion.NroIpRegistro);
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

        public int Anular(GradoInstruccionBE e_GradoInstruccion)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradoInstruccionAnular", connection);
                    ParametroSP("@GradoInstruccionId", e_GradoInstruccion.GradoInstruccionId);
                    ParametroSP("@UsuarioModificacionRegistro", e_GradoInstruccion.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_GradoInstruccion.NroIpRegistro);
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

        public List<GradoInstruccionBE> Consultar_Lista()
        {
            List<GradoInstruccionBE> lista = new List<GradoInstruccionBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradoInstruccionConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new GradoInstruccionBE(reader));
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

        public List<GradoInstruccionBE> Consultar_PK(
                int m_GradoInstruccionId)
        {
            List<GradoInstruccionBE> lista = new List<GradoInstruccionBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradoInstruccionConsultar_PK", connection);
                    ParametroSP("@GradoInstruccionId", m_GradoInstruccionId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new GradoInstruccionBE(reader));
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
