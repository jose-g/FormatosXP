using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class NacionalidadDA : BaseDA
    {
        const string Nombre_Clase = "NacionalidadDA";
        private string m_BaseDatos = string.Empty;

        public NacionalidadDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(NacionalidadBE e_Nacionalidad)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NacionalidadInsertar", connection);
                    ParametroSP("@NacionalidadId", e_Nacionalidad.NacionalidadId);
                    ParametroSP("@PaisId", e_Nacionalidad.PaisId);
                    ParametroSP("@Nombre", e_Nacionalidad.Nombre);
                    ParametroSP("@Abreviatura", e_Nacionalidad.Abreviatura);
                    ParametroSP("@EstadoId", e_Nacionalidad.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Nacionalidad.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Nacionalidad.NroIpRegistro);
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

        public int Actualizar(NacionalidadBE e_Nacionalidad)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NacionalidadActualizar", connection);
                    ParametroSP("@NacionalidadId", e_Nacionalidad.NacionalidadId);
                    ParametroSP("@PaisId", e_Nacionalidad.PaisId);
                    ParametroSP("@Nombre", e_Nacionalidad.Nombre);
                    ParametroSP("@Abreviatura", e_Nacionalidad.Abreviatura);
                    ParametroSP("@EstadoId", e_Nacionalidad.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Nacionalidad.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Nacionalidad.NroIpRegistro);
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

        public int Anular(NacionalidadBE e_Nacionalidad)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NacionalidadAnular", connection);
                    ParametroSP("@NacionalidadId", e_Nacionalidad.NacionalidadId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Nacionalidad.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Nacionalidad.NroIpRegistro);
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

        public List<NacionalidadBE> Consultar_Lista()
        {
            List<NacionalidadBE> lista = new List<NacionalidadBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NacionalidadConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new NacionalidadBE(reader));
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

        public List<NacionalidadBE> Consultar_PK(
                int m_NacionalidadId)
        {
            List<NacionalidadBE> lista = new List<NacionalidadBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_NacionalidadConsultar_PK", connection);
                    ParametroSP("@NacionalidadId", m_NacionalidadId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new NacionalidadBE(reader));
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
