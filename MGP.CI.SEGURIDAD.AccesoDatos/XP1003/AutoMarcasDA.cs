using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class AutoMarcasDA : BaseDA
    {
        const string Nombre_Clase = "AutoMarcasDA";
        private string m_BaseDatos = string.Empty;

        public AutoMarcasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(AutoMarcasBE e_AutoMarcas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoMarcasInsertar", connection);
                    ParametroSP("@AutoMarcaId", e_AutoMarcas.AutoMarcaId);
                    ParametroSP("@Nombre", e_AutoMarcas.Nombre);
                    ParametroSP("@Descripcion", e_AutoMarcas.Descripcion);
                    ParametroSP("@EstadoId", e_AutoMarcas.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_AutoMarcas.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_AutoMarcas.NroIpRegistro);
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

        public int Actualizar(AutoMarcasBE e_AutoMarcas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoMarcasActualizar", connection);
                    ParametroSP("@AutoMarcaId", e_AutoMarcas.AutoMarcaId);
                    ParametroSP("@Nombre", e_AutoMarcas.Nombre);
                    ParametroSP("@Descripcion", e_AutoMarcas.Descripcion);
                    ParametroSP("@EstadoId", e_AutoMarcas.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_AutoMarcas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_AutoMarcas.NroIpRegistro);
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

        public int Anular(AutoMarcasBE e_AutoMarcas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoMarcasAnular", connection);
                    ParametroSP("@AutoMarcaId", e_AutoMarcas.AutoMarcaId);
                    ParametroSP("@UsuarioModificacionRegistro", e_AutoMarcas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_AutoMarcas.NroIpRegistro);
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

        public List<AutoMarcasBE> Consultar_Lista()
        {
            List<AutoMarcasBE> lista = new List<AutoMarcasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoMarcasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AutoMarcasBE(reader));
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

        public List<AutoMarcasBE> Consultar_PK(int m_AutoMarcaId)
        {
            List<AutoMarcasBE> lista = new List<AutoMarcasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoMarcasConsultar_PK", connection);
                    ParametroSP("@AutoMarcaId", m_AutoMarcaId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AutoMarcasBE(reader));
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
