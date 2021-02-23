using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class UsuarioDependenciasDA : BaseDA
    {
        const string Nombre_Clase = "UsuarioDependenciasDA";
        private string m_BaseDatos = string.Empty;

        public UsuarioDependenciasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public UsuarioDependenciasDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(UsuarioDependenciasBE e_UsuarioDependencias)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioDependenciasInsertar", connection);
                    ParametroSP("@UsuarioDependenciaId", e_UsuarioDependencias.UsuarioDependenciaId);
                    ParametroSP("@UsuarioId", e_UsuarioDependencias.UsuarioId);
                    ParametroSP("@DependenciaTipo", e_UsuarioDependencias.DependenciaTipo);
                    ParametroSP("@ZonaNavalId", e_UsuarioDependencias.ZonaNavalId);
                    ParametroSP("@DependenciaId", e_UsuarioDependencias.DependenciaId);
                    ParametroSP("@EstadoId", e_UsuarioDependencias.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_UsuarioDependencias.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_UsuarioDependencias.NroIpRegistro);
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

        public int Actualizar(UsuarioDependenciasBE e_UsuarioDependencias)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioDependenciasActualizar", connection);
                    ParametroSP("@UsuarioDependenciaId", e_UsuarioDependencias.UsuarioDependenciaId);
                    ParametroSP("@UsuarioId", e_UsuarioDependencias.UsuarioId);
                    ParametroSP("@DependenciaTipo", e_UsuarioDependencias.DependenciaTipo);
                    ParametroSP("@ZonaNavalId", e_UsuarioDependencias.ZonaNavalId);
                    ParametroSP("@DependenciaId", e_UsuarioDependencias.DependenciaId);
                    ParametroSP("@EstadoId", e_UsuarioDependencias.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_UsuarioDependencias.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_UsuarioDependencias.NroIpRegistro);
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

        public int Anular(UsuarioDependenciasBE e_UsuarioDependencias)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioDependenciasAnular", connection);
                    ParametroSP("@UsuarioDependenciaId", e_UsuarioDependencias.UsuarioDependenciaId);
                    ParametroSP("@UsuarioModificacionRegistro", e_UsuarioDependencias.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_UsuarioDependencias.NroIpRegistro);
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

        public List<UsuarioDependenciasBE> Consultar_Lista()
        {
            List<UsuarioDependenciasBE> lista = new List<UsuarioDependenciasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioDependenciasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuarioDependenciasBE(reader));
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

        public List<UsuarioDependenciasBE> Consultar_PK(
                int m_UsuarioDependenciaId)
        {
            List<UsuarioDependenciasBE> lista = new List<UsuarioDependenciasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioDependenciasConsultar_PK", connection);
                    ParametroSP("@UsuarioDependenciaId", m_UsuarioDependenciaId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuarioDependenciasBE(reader));
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
