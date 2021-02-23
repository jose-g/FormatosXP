using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class SexoDA : BaseDA
    {
        const string Nombre_Clase = "SexoDA";
        private string m_BaseDatos = string.Empty;

        public SexoDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(SexoBE e_Sexo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SexoInsertar", connection);
                    ParametroSP("@SexoId", e_Sexo.SexoId);
                    ParametroSP("@Nombre", e_Sexo.Nombre);
                    ParametroSP("@Descripcion", e_Sexo.Descripcion);
                    ParametroSP("@EstadoId", e_Sexo.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Sexo.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Sexo.NroIpRegistro);
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

        public int Actualizar(SexoBE e_Sexo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SexoActualizar", connection);
                    ParametroSP("@SexoId", e_Sexo.SexoId);
                    ParametroSP("@Nombre", e_Sexo.Nombre);
                    ParametroSP("@Descripcion", e_Sexo.Descripcion);
                    ParametroSP("@EstadoId", e_Sexo.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Sexo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Sexo.NroIpRegistro);
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

        public int Anular(SexoBE e_Sexo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SexoAnular", connection);
                    ParametroSP("@SexoId", e_Sexo.SexoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Sexo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Sexo.NroIpRegistro);
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

        public List<SexoBE> Consultar_Lista()
        {
            List<SexoBE> lista = new List<SexoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SexoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SexoBE(reader));
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

        public List<SexoBE> Consultar_PK(
                int m_SexoId)
        {
            List<SexoBE> lista = new List<SexoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SexoConsultar_PK", connection);
                    ParametroSP("@SexoId", m_SexoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SexoBE(reader));
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
