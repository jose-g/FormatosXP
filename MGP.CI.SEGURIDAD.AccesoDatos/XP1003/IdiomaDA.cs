using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class IdiomaDA : BaseDA
    {
        const string Nombre_Clase = "IdiomaDA";
        private string m_BaseDatos = string.Empty;

        public IdiomaDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(IdiomaBE e_Idioma)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomaInsertar", connection);
                    ParametroSP("@IdiomaId", e_Idioma.IdiomaId);
                    ParametroSP("@Nombre", e_Idioma.Nombre);
                    ParametroSP("@Descripcion", e_Idioma.Descripcion);
                    ParametroSP("@EstadoId", e_Idioma.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Idioma.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Idioma.NroIpRegistro);
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

        public int Actualizar(IdiomaBE e_Idioma)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomaActualizar", connection);
                    ParametroSP("@IdiomaId", e_Idioma.IdiomaId);
                    ParametroSP("@Nombre", e_Idioma.Nombre);
                    ParametroSP("@Descripcion", e_Idioma.Descripcion);
                    ParametroSP("@EstadoId", e_Idioma.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Idioma.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Idioma.NroIpRegistro);
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

        public int Anular(IdiomaBE e_Idioma)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomaAnular", connection);
                    ParametroSP("@IdiomaId", e_Idioma.IdiomaId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Idioma.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Idioma.NroIpRegistro);
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

        public List<IdiomaBE> Consultar_Lista()
        {
            List<IdiomaBE> lista = new List<IdiomaBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomaConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IdiomaBE(reader));
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

        public List<IdiomaBE> Consultar_PK(
                int m_IdiomaId)
        {
            List<IdiomaBE> lista = new List<IdiomaBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomaConsultar_PK", connection);
                    ParametroSP("@IdiomaId", m_IdiomaId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IdiomaBE(reader));
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
