using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class SalaJuzgadoTipoDA : BaseDA
    {
        const string Nombre_Clase = "SalaJuzgadoTipoDA";
        private string m_BaseDatos = string.Empty;

        public SalaJuzgadoTipoDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(SalaJuzgadoTipoBE e_SalaJuzgadoTipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalaJuzgadoTipoInsertar", connection);
                    ParametroSP("@SalaJuzgadoTipoId", e_SalaJuzgadoTipo.SalaJuzgadoTipoId);
                    ParametroSP("@Nombre", e_SalaJuzgadoTipo.Nombre);
                    ParametroSP("@Descripcion", e_SalaJuzgadoTipo.Descripcion);
                    ParametroSP("@EstadoId", e_SalaJuzgadoTipo.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_SalaJuzgadoTipo.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_SalaJuzgadoTipo.NroIpRegistro);
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

        public int Actualizar(SalaJuzgadoTipoBE e_SalaJuzgadoTipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalaJuzgadoTipoActualizar", connection);
                    ParametroSP("@SalaJuzgadoTipoId", e_SalaJuzgadoTipo.SalaJuzgadoTipoId);
                    ParametroSP("@Nombre", e_SalaJuzgadoTipo.Nombre);
                    ParametroSP("@Descripcion", e_SalaJuzgadoTipo.Descripcion);
                    ParametroSP("@EstadoId", e_SalaJuzgadoTipo.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_SalaJuzgadoTipo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_SalaJuzgadoTipo.NroIpRegistro);
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

        public int Anular(SalaJuzgadoTipoBE e_SalaJuzgadoTipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalaJuzgadoTipoAnular", connection);
                    ParametroSP("@SalaJuzgadoTipoId", e_SalaJuzgadoTipo.SalaJuzgadoTipoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_SalaJuzgadoTipo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_SalaJuzgadoTipo.NroIpRegistro);
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

        public List<SalaJuzgadoTipoBE> Consultar_Lista()
        {
            List<SalaJuzgadoTipoBE> lista = new List<SalaJuzgadoTipoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalaJuzgadoTipoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SalaJuzgadoTipoBE(reader));
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

        public List<SalaJuzgadoTipoBE> Consultar_PK(
                int m_SalaJuzgadoTipoId)
        {
            List<SalaJuzgadoTipoBE> lista = new List<SalaJuzgadoTipoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SalaJuzgadoTipoConsultar_PK", connection);
                    ParametroSP("@SalaJuzgadoTipoId", m_SalaJuzgadoTipoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SalaJuzgadoTipoBE(reader));
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
