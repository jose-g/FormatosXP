using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class CategoriaMilitarDA : BaseDA
    {
        const string Nombre_Clase = "CategoriaMilitarDA";
        private string m_BaseDatos = string.Empty;

        public CategoriaMilitarDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(CategoriaMilitarBE e_CategoriaMilitar)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CategoriaMilitarInsertar", connection);
                    ParametroSP("@CategoriaMilitarId", e_CategoriaMilitar.CategoriaMilitarId);
                    ParametroSP("@Nombre", e_CategoriaMilitar.Nombre);
                    ParametroSP("@Descripcion", e_CategoriaMilitar.Descripcion);
                    ParametroSP("@EstadoId", e_CategoriaMilitar.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CategoriaMilitar.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CategoriaMilitar.NroIpRegistro);
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

        public int Actualizar(CategoriaMilitarBE e_CategoriaMilitar)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CategoriaMilitarActualizar", connection);
                    ParametroSP("@CategoriaMilitarId", e_CategoriaMilitar.CategoriaMilitarId);
                    ParametroSP("@Nombre", e_CategoriaMilitar.Nombre);
                    ParametroSP("@Descripcion", e_CategoriaMilitar.Descripcion);
                    ParametroSP("@EstadoId", e_CategoriaMilitar.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CategoriaMilitar.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CategoriaMilitar.NroIpRegistro);
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

        public int Anular(CategoriaMilitarBE e_CategoriaMilitar)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CategoriaMilitarAnular", connection);
                    ParametroSP("@CategoriaMilitarId", e_CategoriaMilitar.CategoriaMilitarId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CategoriaMilitar.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CategoriaMilitar.NroIpRegistro);
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

        public List<CategoriaMilitarBE> Consultar_Lista()
        {
            List<CategoriaMilitarBE> lista = new List<CategoriaMilitarBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CategoriaMilitarConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CategoriaMilitarBE(reader));
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

        public List<CategoriaMilitarBE> Consultar_PK(
                int m_CategoriaMilitarId)
        {
            List<CategoriaMilitarBE> lista = new List<CategoriaMilitarBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CategoriaMilitarConsultar_PK", connection);
                    ParametroSP("@CategoriaMilitarId", m_CategoriaMilitarId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CategoriaMilitarBE(reader));
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
