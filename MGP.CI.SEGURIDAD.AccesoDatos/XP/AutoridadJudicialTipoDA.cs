using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class AutoridadJudicialTipoDA : BaseDA
    {
        const string Nombre_Clase = "AutoridadJudicialTipoDA";
        private string m_BaseDatos = string.Empty;

        public AutoridadJudicialTipoDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(AutoridadJudicialTipoBE e_AutoridadJudicialTipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoridadJudicialTipoInsertar", connection);
                    ParametroSP("@AutoridadJudicialTipoId", e_AutoridadJudicialTipo.AutoridadJudicialTipoId);
                    ParametroSP("@Nombre", e_AutoridadJudicialTipo.Nombre);
                    ParametroSP("@Descripcion", e_AutoridadJudicialTipo.Descripcion);
                    ParametroSP("@EstadoId", e_AutoridadJudicialTipo.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_AutoridadJudicialTipo.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_AutoridadJudicialTipo.NroIpRegistro);
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

        public int Actualizar(AutoridadJudicialTipoBE e_AutoridadJudicialTipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoridadJudicialTipoActualizar", connection);
                    ParametroSP("@AutoridadJudicialTipoId", e_AutoridadJudicialTipo.AutoridadJudicialTipoId);
                    ParametroSP("@Nombre", e_AutoridadJudicialTipo.Nombre);
                    ParametroSP("@Descripcion", e_AutoridadJudicialTipo.Descripcion);
                    ParametroSP("@EstadoId", e_AutoridadJudicialTipo.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_AutoridadJudicialTipo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_AutoridadJudicialTipo.NroIpRegistro);
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

        public int Anular(AutoridadJudicialTipoBE e_AutoridadJudicialTipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoridadJudicialTipoAnular", connection);
                    ParametroSP("@AutoridadJudicialTipoId", e_AutoridadJudicialTipo.AutoridadJudicialTipoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_AutoridadJudicialTipo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_AutoridadJudicialTipo.NroIpRegistro);
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

        public List<AutoridadJudicialTipoBE> Consultar_Lista()
        {
            List<AutoridadJudicialTipoBE> lista = new List<AutoridadJudicialTipoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoridadJudicialTipoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AutoridadJudicialTipoBE(reader));
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

        public List<AutoridadJudicialTipoBE> Consultar_PK(
                int m_AutoridadJudicialTipoId)
        {
            List<AutoridadJudicialTipoBE> lista = new List<AutoridadJudicialTipoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoridadJudicialTipoConsultar_PK", connection);
                    ParametroSP("@AutoridadJudicialTipoId", m_AutoridadJudicialTipoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AutoridadJudicialTipoBE(reader));
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
