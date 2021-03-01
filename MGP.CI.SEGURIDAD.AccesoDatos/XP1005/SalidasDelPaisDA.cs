using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class SalidasDelPaisDA : BaseDA
    {
        const string Nombre_Clase = "SalidasDelPaisDA";
        private string m_BaseDatos = string.Empty;

        public SalidasDelPaisDA() {  }

        public int Insertar(SalidasDelPaisBE e_SalidasDelPais)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalidasDelPaisInsertar", connection);
                    ParametroSP("@SalidasDelPaisId", e_SalidasDelPais.SalidasDelPaisId);
                    ParametroSP("@DatosGeneralesId", e_SalidasDelPais.DatosGeneralesId);
                    ParametroSP("@FechaSalida", e_SalidasDelPais.FechaSalida);
                    ParametroSP("@FechaIngreso", e_SalidasDelPais.FechaIngreso);
                    ParametroSP("@EstadoId", e_SalidasDelPais.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_SalidasDelPais.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_SalidasDelPais.NroIpRegistro);
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

        public int Actualizar(SalidasDelPaisBE e_SalidasDelPais)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalidasDelPaisActualizar", connection);
                    ParametroSP("@SalidasDelPaisId", e_SalidasDelPais.SalidasDelPaisId);
                    ParametroSP("@DatosGeneralesId", e_SalidasDelPais.DatosGeneralesId);
                    ParametroSP("@FechaSalida", e_SalidasDelPais.FechaSalida);
                    ParametroSP("@FechaIngreso", e_SalidasDelPais.FechaIngreso);
                    ParametroSP("@EstadoId", e_SalidasDelPais.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_SalidasDelPais.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_SalidasDelPais.NroIpRegistro);
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

        public int Anular(SalidasDelPaisBE e_SalidasDelPais)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalidasDelPaisAnular", connection);
                    ParametroSP("@SalidasDelPaisId", e_SalidasDelPais.SalidasDelPaisId);
                    ParametroSP("@UsuarioModificacionRegistro", e_SalidasDelPais.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_SalidasDelPais.NroIpRegistro);
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

        public List<SalidasDelPaisBE> Consultar_Lista()
        {
            List<SalidasDelPaisBE> lista = new List<SalidasDelPaisBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalidasDelPaisConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SalidasDelPaisBE(reader));
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

        public List<SalidasDelPaisBE> Consultar_PK(
                int m_SalidasDelPaisId)
        {
            List<SalidasDelPaisBE> lista = new List<SalidasDelPaisBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalidasDelPaisConsultar_PK", connection);
                    ParametroSP("@SalidasDelPaisId", m_SalidasDelPaisId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SalidasDelPaisBE(reader));
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

        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_SalidasDelPaisGetMaxId", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                        if (!DBNull.Value.Equals(reader["CodigoMaxId"]))
                            {
                             maxId = Convert.ToInt32(reader["CodigoMaxId"]);
                            }
                        }
                }
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
            return maxId;
        }

    }
}


