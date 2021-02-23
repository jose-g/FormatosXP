using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class RasgosTiposDA : BaseDA
    {
        const string Nombre_Clase = "RasgosTiposDA";
        private string m_BaseDatos = string.Empty;

        public RasgosTiposDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(RasgosTiposBE e_RasgosTipos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RasgosTiposInsertar", connection);
                    ParametroSP("@RasgoTipoId", e_RasgosTipos.RasgoTipoId);
                    ParametroSP("@Nombre", e_RasgosTipos.Nombre);
                    ParametroSP("@Descripcion", e_RasgosTipos.Descripcion);
                    ParametroSP("@EstadoId", e_RasgosTipos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_RasgosTipos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_RasgosTipos.NroIpRegistro);
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

        public int Actualizar(RasgosTiposBE e_RasgosTipos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RasgosTiposActualizar", connection);
                    ParametroSP("@RasgoTipoId", e_RasgosTipos.RasgoTipoId);
                    ParametroSP("@Nombre", e_RasgosTipos.Nombre);
                    ParametroSP("@Descripcion", e_RasgosTipos.Descripcion);
                    ParametroSP("@EstadoId", e_RasgosTipos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_RasgosTipos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_RasgosTipos.NroIpRegistro);
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

        public int Anular(RasgosTiposBE e_RasgosTipos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RasgosTiposAnular", connection);
                    ParametroSP("@RasgoTipoId", e_RasgosTipos.RasgoTipoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_RasgosTipos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_RasgosTipos.NroIpRegistro);
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

        public List<RasgosTiposBE> Consultar_Lista()
        {
            List<RasgosTiposBE> lista = new List<RasgosTiposBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RasgosTiposConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new RasgosTiposBE(reader));
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

        public List<RasgosTiposBE> Consultar_PK(
                int m_RasgoTipoId)
        {
            List<RasgosTiposBE> lista = new List<RasgosTiposBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RasgosTiposConsultar_PK", connection);
                    ParametroSP("@RasgoTipoId", m_RasgoTipoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new RasgosTiposBE(reader));
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
