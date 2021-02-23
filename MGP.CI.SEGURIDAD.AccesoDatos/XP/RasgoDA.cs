using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class RasgoDA : BaseDA
    {
        const string Nombre_Clase = "RasgoDA";
        private string m_BaseDatos = string.Empty;

        public RasgoDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(RasgoBE e_Rasgo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RasgoInsertar", connection);
                    ParametroSP("@RasgoId", e_Rasgo.RasgoId);
                    ParametroSP("@RasgoTipoId", e_Rasgo.RasgoTipoId);
                    ParametroSP("@Nombre", e_Rasgo.Nombre);
                    ParametroSP("@Descripcion", e_Rasgo.Descripcion);
                    ParametroSP("@EstadoId", e_Rasgo.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Rasgo.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Rasgo.NroIpRegistro);
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

        public int Actualizar(RasgoBE e_Rasgo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RasgoActualizar", connection);
                    ParametroSP("@RasgoId", e_Rasgo.RasgoId);
                    ParametroSP("@RasgoTipoId", e_Rasgo.RasgoTipoId);
                    ParametroSP("@Nombre", e_Rasgo.Nombre);
                    ParametroSP("@Descripcion", e_Rasgo.Descripcion);
                    ParametroSP("@EstadoId", e_Rasgo.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Rasgo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Rasgo.NroIpRegistro);
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

        public int Anular(RasgoBE e_Rasgo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RasgoAnular", connection);
                    ParametroSP("@RasgoId", e_Rasgo.RasgoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Rasgo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Rasgo.NroIpRegistro);
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

        public List<RasgoBE> Consultar_Lista()
        {
            List<RasgoBE> lista = new List<RasgoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RasgoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new RasgoBE(reader));
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

        public List<RasgoBE> Consultar_PK(
                int m_RasgoId)
        {
            List<RasgoBE> lista = new List<RasgoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_RasgoConsultar_PK", connection);
                    ParametroSP("@RasgoId", m_RasgoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new RasgoBE(reader));
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
