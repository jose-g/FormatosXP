using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class DeportesDA : BaseDA
    {
        const string Nombre_Clase = "DeportesDA";
        private string m_BaseDatos = string.Empty;

        public DeportesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public DeportesDA() { }

        public int Insertar(DeportesBE e_Deportes)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesInsertar", connection);
                    ParametroSP("@DeportesId", e_Deportes.DeporteId);
                    ParametroSP("@Nombre", e_Deportes.Nombre);
                    ParametroSP("@EstadoId", e_Deportes.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Deportes.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Deportes.NroIpRegistro);
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

        public int Actualizar(DeportesBE e_Deportes)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesActualizar", connection);
                    ParametroSP("@DeportesId", e_Deportes.DeporteId);
                    ParametroSP("@Nombre", e_Deportes.Nombre);
                    ParametroSP("@EstadoId", e_Deportes.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Deportes.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Deportes.NroIpRegistro);
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

        public int Anular(DeportesBE e_Deportes)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesAnular", connection);
                    ParametroSP("@DeportesId", e_Deportes.DeporteId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Deportes.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Deportes.NroIpRegistro);
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

        public List<DeportesBE> Consultar_Lista()
        {
            List<DeportesBE> lista = new List<DeportesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DeportesBE(reader));
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

        public List<DeportesBE> Consultar_PK(
                int m_DeportesId)
        {
            List<DeportesBE> lista = new List<DeportesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeportesConsultar_PK", connection);
                    ParametroSP("@DeportesId", m_DeportesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DeportesBE(reader));
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
