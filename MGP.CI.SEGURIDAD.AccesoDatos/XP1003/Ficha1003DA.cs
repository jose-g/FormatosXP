using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class Ficha1003DA : BaseDA
    {
        const string Nombre_Clase = "Ficha1003DA";
        private string m_BaseDatos = string.Empty;

        public Ficha1003DA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(Ficha1003BE e_Ficha1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Ficha1003Insertar", connection);
                    ParametroSP("@Ficha1003Id", e_Ficha1003.Ficha1003Id);
                    ParametroSP("@Nombre", e_Ficha1003.Nombre);
                    ParametroSP("@DeclaranteFichaId", e_Ficha1003.DeclaranteFichaId);
                    ParametroSP("@EstadoId", e_Ficha1003.EstadoId);
                    ParametroSP("@EstadoFicha", e_Ficha1003.EstadoFicha);
                    ParametroSP("@UsuarioRegistro", e_Ficha1003.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Ficha1003.NroIpRegistro);
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

        public int Actualizar(Ficha1003BE e_Ficha1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Ficha1003Actualizar", connection);
                    ParametroSP("@Ficha1003Id", e_Ficha1003.Ficha1003Id);
                    ParametroSP("@Nombre", e_Ficha1003.Nombre);
                    ParametroSP("@DeclaranteFichaId", e_Ficha1003.DeclaranteFichaId);
                    ParametroSP("@EstadoId", e_Ficha1003.EstadoId);
                    ParametroSP("@EstadoFicha", e_Ficha1003.EstadoFicha);
                    ParametroSP("@UsuarioModificacionRegistro", e_Ficha1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Ficha1003.NroIpRegistro);
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

        public int Anular(Ficha1003BE e_Ficha1003)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Ficha1003Anular", connection);
                    ParametroSP("@Ficha1003Id", e_Ficha1003.Ficha1003Id);
                    ParametroSP("@UsuarioModificacionRegistro", e_Ficha1003.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Ficha1003.NroIpRegistro);
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

        public List<Ficha1003BE> Consultar_Lista()
        {
            List<Ficha1003BE> lista = new List<Ficha1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Ficha1003Consultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Ficha1003BE(reader));
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

        public List<Ficha1003BE> Consultar_PK(
                int m_Ficha1003Id)
        {
            List<Ficha1003BE> lista = new List<Ficha1003BE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_Ficha1003Consultar_PK", connection);
                    ParametroSP("@Ficha1003Id", m_Ficha1003Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Ficha1003BE(reader));
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
