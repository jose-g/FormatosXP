using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class UsuarioAutenticacionesDA : BaseDA
    {
        const string Nombre_Clase = "UsuarioAutenticacionesDA";
        private string m_BaseDatos = string.Empty;

        public UsuarioAutenticacionesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public UsuarioAutenticacionesDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(UsuarioAutenticacionesBE e_UsuarioAutenticaciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioAutenticacionesInsertar", connection);
                    ParametroSP("@AutenticacionId", e_UsuarioAutenticaciones.AutenticacionId);
                    ParametroSP("@UsuarioId", e_UsuarioAutenticaciones.UsuarioId);
                    ParametroSP("@CodigoAcceso", e_UsuarioAutenticaciones.CodigoAcceso);
                    ParametroSP("@FechaHoraCodigo", e_UsuarioAutenticaciones.FechaHoraCodigo);
                    ParametroSP("@FlagLogueo", e_UsuarioAutenticaciones.FlagLogueo);
                    ParametroSP("@EstadoId", e_UsuarioAutenticaciones.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_UsuarioAutenticaciones.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_UsuarioAutenticaciones.NroIpRegistro);
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

        public int Actualizar(UsuarioAutenticacionesBE e_UsuarioAutenticaciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioAutenticacionesActualizar", connection);
                    ParametroSP("@AutenticacionId", e_UsuarioAutenticaciones.AutenticacionId);
                    ParametroSP("@UsuarioId", e_UsuarioAutenticaciones.UsuarioId);
                    ParametroSP("@CodigoAcceso", e_UsuarioAutenticaciones.CodigoAcceso);
                    ParametroSP("@FechaHoraCodigo", e_UsuarioAutenticaciones.FechaHoraCodigo);
                    ParametroSP("@FlagLogueo", e_UsuarioAutenticaciones.FlagLogueo);
                    ParametroSP("@EstadoId", e_UsuarioAutenticaciones.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_UsuarioAutenticaciones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_UsuarioAutenticaciones.NroIpRegistro);
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

        public int Anular(UsuarioAutenticacionesBE e_UsuarioAutenticaciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioAutenticacionesAnular", connection);
                    ParametroSP("@AutenticacionId", e_UsuarioAutenticaciones.AutenticacionId);
                    ParametroSP("@UsuarioModificacionRegistro", e_UsuarioAutenticaciones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_UsuarioAutenticaciones.NroIpRegistro);
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

        public List<UsuarioAutenticacionesBE> Consultar_Lista()
        {
            List<UsuarioAutenticacionesBE> lista = new List<UsuarioAutenticacionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioAutenticacionesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuarioAutenticacionesBE(reader));
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

        public List<UsuarioAutenticacionesBE> Consultar_PK(
                int m_AutenticacionId)
        {
            List<UsuarioAutenticacionesBE> lista = new List<UsuarioAutenticacionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioAutenticacionesConsultar_PK", connection);
                    ParametroSP("@AutenticacionId", m_AutenticacionId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuarioAutenticacionesBE(reader));
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
