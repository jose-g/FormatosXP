using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class ReligionDA : BaseDA
    {
        const string Nombre_Clase = "ReligionDA";
        private string m_BaseDatos = string.Empty;

        public ReligionDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(ReligionBE e_Religion)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionInsertar", connection);
                    ParametroSP("@ReligionId", e_Religion.ReligionId);
                    ParametroSP("@Nombre", e_Religion.Nombre);
                    ParametroSP("@Descripcion", e_Religion.Descripcion);
                    ParametroSP("@EstadoId", e_Religion.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Religion.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Religion.NroIpRegistro);
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

        public int Actualizar(ReligionBE e_Religion)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionActualizar", connection);
                    ParametroSP("@ReligionId", e_Religion.ReligionId);
                    ParametroSP("@Nombre", e_Religion.Nombre);
                    ParametroSP("@Descripcion", e_Religion.Descripcion);
                    ParametroSP("@EstadoId", e_Religion.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Religion.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Religion.NroIpRegistro);
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

        public int Anular(ReligionBE e_Religion)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionAnular", connection);
                    ParametroSP("@ReligionId", e_Religion.ReligionId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Religion.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Religion.NroIpRegistro);
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

        public List<ReligionBE> Consultar_Lista()
        {
            List<ReligionBE> lista = new List<ReligionBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ReligionBE(reader));
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

        public List<ReligionBE> Consultar_PK(
                int m_ReligionId)
        {
            List<ReligionBE> lista = new List<ReligionBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ReligionConsultar_PK", connection);
                    ParametroSP("@ReligionId", m_ReligionId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ReligionBE(reader));
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
