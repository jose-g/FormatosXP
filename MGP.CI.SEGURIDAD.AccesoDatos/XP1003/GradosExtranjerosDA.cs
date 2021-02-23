using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class GradosExtranjerosDA : BaseDA
    {
        const string Nombre_Clase = "GradosExtranjerosDA";
        private string m_BaseDatos = string.Empty;

        public GradosExtranjerosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public GradosExtranjerosDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(GradosExtranjerosBE e_GradosExtranjeros)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradosExtranjerosInsertar", connection);
                    ParametroSP("@GradoExtranjeroId", e_GradosExtranjeros.GradoExtranjeroId);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_GradosExtranjeros.InstitucionMilitarExtranjeraId);
                    ParametroSP("@CategoriaMilitarId", e_GradosExtranjeros.CategoriaMilitarId);
                    ParametroSP("@Descripcion", e_GradosExtranjeros.Descripcion);
                    ParametroSP("@EstadoId", e_GradosExtranjeros.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_GradosExtranjeros.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_GradosExtranjeros.NroIpRegistro);
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

        public int Actualizar(GradosExtranjerosBE e_GradosExtranjeros)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradosExtranjerosActualizar", connection);
                    ParametroSP("@GradoExtranjeroId", e_GradosExtranjeros.GradoExtranjeroId);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_GradosExtranjeros.InstitucionMilitarExtranjeraId);
                    ParametroSP("@CategoriaMilitarId", e_GradosExtranjeros.CategoriaMilitarId);
                    ParametroSP("@Descripcion", e_GradosExtranjeros.Descripcion);
                    ParametroSP("@EstadoId", e_GradosExtranjeros.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_GradosExtranjeros.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_GradosExtranjeros.NroIpRegistro);
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

        public int Anular(GradosExtranjerosBE e_GradosExtranjeros)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradosExtranjerosAnular", connection);
                    ParametroSP("@GradoExtranjeroId", e_GradosExtranjeros.GradoExtranjeroId);
                    ParametroSP("@UsuarioModificacionRegistro", e_GradosExtranjeros.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_GradosExtranjeros.NroIpRegistro);
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

        public List<GradosExtranjerosBE> Consultar_Lista()
        {
            List<GradosExtranjerosBE> lista = new List<GradosExtranjerosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradosExtranjerosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new GradosExtranjerosBE(reader));
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

        public List<GradosExtranjerosBE> Consultar_PK(
                int m_GradoExtranjeroId)
        {
            List<GradosExtranjerosBE> lista = new List<GradosExtranjerosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradosExtranjerosConsultar_PK", connection);
                    ParametroSP("@GradoExtranjeroId", m_GradoExtranjeroId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new GradosExtranjerosBE(reader));
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
