using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class AutoModelosDA : BaseDA
    {
        const string Nombre_Clase = "AutoModelosDA";
        private string m_BaseDatos = string.Empty;

        public AutoModelosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(AutoModelosBE e_AutoModelos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoModelosInsertar", connection);
                    ParametroSP("@AutoModeloId", e_AutoModelos.AutoModeloId);
                    ParametroSP("@AutoMarcaId", e_AutoModelos.AutoMarcaId);
                    ParametroSP("@Nombre", e_AutoModelos.Nombre);
                    ParametroSP("@Descripcion", e_AutoModelos.Descripcion);
                    ParametroSP("@EstadoId", e_AutoModelos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_AutoModelos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_AutoModelos.NroIpRegistro);
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

        public int Actualizar(AutoModelosBE e_AutoModelos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoModelosActualizar", connection);
                    ParametroSP("@AutoModeloId", e_AutoModelos.AutoModeloId);
                    ParametroSP("@AutoMarcaId", e_AutoModelos.AutoMarcaId);
                    ParametroSP("@Nombre", e_AutoModelos.Nombre);
                    ParametroSP("@Descripcion", e_AutoModelos.Descripcion);
                    ParametroSP("@EstadoId", e_AutoModelos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_AutoModelos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_AutoModelos.NroIpRegistro);
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

        public int Anular(AutoModelosBE e_AutoModelos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoModelosAnular", connection);
                    ParametroSP("@AutoModeloId", e_AutoModelos.AutoModeloId);
                    ParametroSP("@UsuarioModificacionRegistro", e_AutoModelos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_AutoModelos.NroIpRegistro);
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

        public List<AutoModelosBE> Consultar_Lista()
        {
            List<AutoModelosBE> lista = new List<AutoModelosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoModelosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AutoModelosBE(reader));
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

        public List<AutoModelosBE> Consultar_PK(
                int m_AutoModeloId)
        {
            List<AutoModelosBE> lista = new List<AutoModelosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AutoModelosConsultar_PK", connection);
                    ParametroSP("@AutoModeloId", m_AutoModeloId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AutoModelosBE(reader));
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
