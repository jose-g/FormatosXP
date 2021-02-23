using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class GrupoSanguineoDA : BaseDA
    {
        const string Nombre_Clase = "GrupoSanguineoDA";
        private string m_BaseDatos = string.Empty;

        public GrupoSanguineoDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(GrupoSanguineoBE e_GrupoSanguineo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GrupoSanguineoInsertar", connection);
                    ParametroSP("@GrupoSanguineoId", e_GrupoSanguineo.GrupoSanguineoId);
                    ParametroSP("@Nombre", e_GrupoSanguineo.Nombre);
                    ParametroSP("@Descripcion", e_GrupoSanguineo.Descripcion);
                    ParametroSP("@EstadoId", e_GrupoSanguineo.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_GrupoSanguineo.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_GrupoSanguineo.NroIpRegistro);
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

        public int Actualizar(GrupoSanguineoBE e_GrupoSanguineo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GrupoSanguineoActualizar", connection);
                    ParametroSP("@GrupoSanguineoId", e_GrupoSanguineo.GrupoSanguineoId);
                    ParametroSP("@Nombre", e_GrupoSanguineo.Nombre);
                    ParametroSP("@Descripcion", e_GrupoSanguineo.Descripcion);
                    ParametroSP("@EstadoId", e_GrupoSanguineo.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_GrupoSanguineo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_GrupoSanguineo.NroIpRegistro);
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

        public int Anular(GrupoSanguineoBE e_GrupoSanguineo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GrupoSanguineoAnular", connection);
                    ParametroSP("@GrupoSanguineoId", e_GrupoSanguineo.GrupoSanguineoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_GrupoSanguineo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_GrupoSanguineo.NroIpRegistro);
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

        public List<GrupoSanguineoBE> Consultar_Lista()
        {
            List<GrupoSanguineoBE> lista = new List<GrupoSanguineoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GrupoSanguineoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new GrupoSanguineoBE(reader));
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

        public List<GrupoSanguineoBE> Consultar_PK(
                int m_GrupoSanguineoId)
        {
            List<GrupoSanguineoBE> lista = new List<GrupoSanguineoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GrupoSanguineoConsultar_PK", connection);
                    ParametroSP("@GrupoSanguineoId", m_GrupoSanguineoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new GrupoSanguineoBE(reader));
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
