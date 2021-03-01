using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class FotosFamiliaresDA : BaseDA
    {
        const string Nombre_Clase = "FotosFamiliaresDA";
        private string m_BaseDatos = string.Empty;

        public FotosFamiliaresDA() {  }

        public int Insertar(FotosFamiliaresBE e_FotosFamiliares)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosFamiliaresInsertar", connection);
                    ParametroSP("@FotoFamiliaresId", e_FotosFamiliares.FotoFamiliaresId);
                    ParametroSP("@FamiliarId", e_FotosFamiliares.FamiliarId);
                    ParametroSP("@FotoTipoId", e_FotosFamiliares.FotoTipoId);
                    ParametroSP("@Path", e_FotosFamiliares.Path);
                    ParametroSP("@EstadoId", e_FotosFamiliares.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_FotosFamiliares.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_FotosFamiliares.NroIpRegistro);
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

        public int Actualizar(FotosFamiliaresBE e_FotosFamiliares)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosFamiliaresActualizar", connection);
                    ParametroSP("@FotoFamiliaresId", e_FotosFamiliares.FotoFamiliaresId);
                    ParametroSP("@FamiliarId", e_FotosFamiliares.FamiliarId);
                    ParametroSP("@FotoTipoId", e_FotosFamiliares.FotoTipoId);
                    ParametroSP("@Path", e_FotosFamiliares.Path);
                    ParametroSP("@EstadoId", e_FotosFamiliares.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_FotosFamiliares.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_FotosFamiliares.NroIpRegistro);
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

        public int Anular(FotosFamiliaresBE e_FotosFamiliares)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosFamiliaresAnular", connection);
                    ParametroSP("@FotoFamiliaresId", e_FotosFamiliares.FotoFamiliaresId);
                    ParametroSP("@UsuarioModificacionRegistro", e_FotosFamiliares.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_FotosFamiliares.NroIpRegistro);
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

        public List<FotosFamiliaresBE> Consultar_Lista()
        {
            List<FotosFamiliaresBE> lista = new List<FotosFamiliaresBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosFamiliaresConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FotosFamiliaresBE(reader));
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

        public List<FotosFamiliaresBE> Consultar_PK(
                string m_FotoFamiliaresId)
        {
            List<FotosFamiliaresBE> lista = new List<FotosFamiliaresBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosFamiliaresConsultar_PK", connection);
                    ParametroSP("@FotoFamiliaresId", m_FotoFamiliaresId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FotosFamiliaresBE(reader));
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
                    ComandoSP("usp_FotosFamiliaresGetMaxId", connection);
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


