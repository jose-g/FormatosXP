using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class ParentescoDA : BaseDA
    {
        const string Nombre_Clase = "ParentescoDA";
        private string m_BaseDatos = string.Empty;

        public ParentescoDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(ParentescoBE e_Parentesco)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ParentescoInsertar", connection);
                    ParametroSP("@ParentescoId", e_Parentesco.ParentescoId);
                    ParametroSP("@Nombre", e_Parentesco.Nombre);
                    ParametroSP("@Descripcion", e_Parentesco.Descripcion);
                    ParametroSP("@EstadoId", e_Parentesco.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Parentesco.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Parentesco.NroIpRegistro);
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

        public int Actualizar(ParentescoBE e_Parentesco)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ParentescoActualizar", connection);
                    ParametroSP("@ParentescoId", e_Parentesco.ParentescoId);
                    ParametroSP("@Nombre", e_Parentesco.Nombre);
                    ParametroSP("@Descripcion", e_Parentesco.Descripcion);
                    ParametroSP("@EstadoId", e_Parentesco.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Parentesco.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Parentesco.NroIpRegistro);
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

        public int Anular(ParentescoBE e_Parentesco)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ParentescoAnular", connection);
                    ParametroSP("@ParentescoId", e_Parentesco.ParentescoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Parentesco.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Parentesco.NroIpRegistro);
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

        public List<ParentescoBE> Consultar_Lista()
        {
            List<ParentescoBE> lista = new List<ParentescoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ParentescoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ParentescoBE(reader));
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

        public List<ParentescoBE> Consultar_PK(
                int m_ParentescoId)
        {
            List<ParentescoBE> lista = new List<ParentescoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ParentescoConsultar_PK", connection);
                    ParametroSP("@ParentescoId", m_ParentescoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ParentescoBE(reader));
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
