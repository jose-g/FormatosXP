using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class GradoMilitarDA : BaseDA
    {
        const string Nombre_Clase = "GradoMilitarDA";
        private string m_BaseDatos = string.Empty;

        public GradoMilitarDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(GradoMilitarBE e_GradoMilitar)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradoMilitarInsertar", connection);
                    ParametroSP("@GradoMilitarId", e_GradoMilitar.GradoMilitarId);
                    ParametroSP("@InstitucionMilitarId", e_GradoMilitar.InstitucionMilitarId);
                    ParametroSP("@Nombre", e_GradoMilitar.Nombre);
                    ParametroSP("@Descripcion", e_GradoMilitar.Descripcion);
                    ParametroSP("@EstadoId", e_GradoMilitar.EstadoId);
                    ParametroSP("@CategoriaMilitarId", e_GradoMilitar.CategoriaMilitarId);
                    ParametroSP("@UsuarioRegistro", e_GradoMilitar.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_GradoMilitar.NroIpRegistro);
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

        public int Actualizar(GradoMilitarBE e_GradoMilitar)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradoMilitarActualizar", connection);
                    ParametroSP("@GradoMilitarId", e_GradoMilitar.GradoMilitarId);
                    ParametroSP("@InstitucionMilitarId", e_GradoMilitar.InstitucionMilitarId);
                    ParametroSP("@Nombre", e_GradoMilitar.Nombre);
                    ParametroSP("@Descripcion", e_GradoMilitar.Descripcion);
                    ParametroSP("@EstadoId", e_GradoMilitar.EstadoId);
                    ParametroSP("@CategoriaMilitarId", e_GradoMilitar.CategoriaMilitarId);
                    ParametroSP("@UsuarioModificacionRegistro", e_GradoMilitar.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_GradoMilitar.NroIpRegistro);
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

        public int Anular(GradoMilitarBE e_GradoMilitar)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradoMilitarAnular", connection);
                    ParametroSP("@GradoMilitarId", e_GradoMilitar.GradoMilitarId);
                    ParametroSP("@UsuarioModificacionRegistro", e_GradoMilitar.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_GradoMilitar.NroIpRegistro);
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

        public List<GradoMilitarBE> Consultar_Lista()
        {
            List<GradoMilitarBE> lista = new List<GradoMilitarBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradoMilitarConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new GradoMilitarBE(reader));
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

        public List<GradoMilitarBE> Consultar_PK(
                int m_GradoMilitarId)
        {
            List<GradoMilitarBE> lista = new List<GradoMilitarBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_GradoMilitarConsultar_PK", connection);
                    ParametroSP("@GradoMilitarId", m_GradoMilitarId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new GradoMilitarBE(reader));
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
