using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class OcupacionDA : BaseDA
    {
        const string Nombre_Clase = "OcupacionDA";
        private string m_BaseDatos = string.Empty;

        public OcupacionDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(OcupacionBE e_Ocupacion)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OcupacionInsertar", connection);
                    ParametroSP("@OcupacionId", e_Ocupacion.OcupacionId);
                    ParametroSP("@Nombre", e_Ocupacion.Nombre);
                    ParametroSP("@Descripcion", e_Ocupacion.Descripcion);
                    ParametroSP("@EstadoId", e_Ocupacion.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Ocupacion.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Ocupacion.NroIpRegistro);
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

        public int Actualizar(OcupacionBE e_Ocupacion)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OcupacionActualizar", connection);
                    ParametroSP("@OcupacionId", e_Ocupacion.OcupacionId);
                    ParametroSP("@Nombre", e_Ocupacion.Nombre);
                    ParametroSP("@Descripcion", e_Ocupacion.Descripcion);
                    ParametroSP("@EstadoId", e_Ocupacion.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Ocupacion.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Ocupacion.NroIpRegistro);
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

        public int Anular(OcupacionBE e_Ocupacion)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OcupacionAnular", connection);
                    ParametroSP("@OcupacionId", e_Ocupacion.OcupacionId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Ocupacion.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Ocupacion.NroIpRegistro);
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

        public List<OcupacionBE> Consultar_Lista()
        {
            List<OcupacionBE> lista = new List<OcupacionBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OcupacionConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OcupacionBE(reader));
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

        public List<OcupacionBE> Consultar_PK(
                int m_OcupacionId)
        {
            List<OcupacionBE> lista = new List<OcupacionBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OcupacionConsultar_PK", connection);
                    ParametroSP("@OcupacionId", m_OcupacionId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OcupacionBE(reader));
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
