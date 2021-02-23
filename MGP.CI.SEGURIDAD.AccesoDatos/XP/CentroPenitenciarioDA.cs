using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class CentroPenitenciarioDA : BaseDA
    {
        const string Nombre_Clase = "CentroPenitenciarioDA";
        private string m_BaseDatos = string.Empty;

        public CentroPenitenciarioDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(CentroPenitenciarioBE e_CentroPenitenciario)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CentroPenitenciarioInsertar", connection);
                    ParametroSP("@CentroPenitenciarioId", e_CentroPenitenciario.CentroPenitenciarioId);
                    ParametroSP("@RegionId", e_CentroPenitenciario.RegionId);
                    ParametroSP("@RegionNombre", e_CentroPenitenciario.RegionNombre);
                    ParametroSP("@PenalId", e_CentroPenitenciario.PenalId);
                    ParametroSP("@PenalNombre", e_CentroPenitenciario.PenalNombre);
                    ParametroSP("@EstadoId", e_CentroPenitenciario.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CentroPenitenciario.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CentroPenitenciario.NroIpRegistro);
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

        public int Actualizar(CentroPenitenciarioBE e_CentroPenitenciario)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CentroPenitenciarioActualizar", connection);
                    ParametroSP("@CentroPenitenciarioId", e_CentroPenitenciario.CentroPenitenciarioId);
                    ParametroSP("@RegionId", e_CentroPenitenciario.RegionId);
                    ParametroSP("@RegionNombre", e_CentroPenitenciario.RegionNombre);
                    ParametroSP("@PenalId", e_CentroPenitenciario.PenalId);
                    ParametroSP("@PenalNombre", e_CentroPenitenciario.PenalNombre);
                    ParametroSP("@EstadoId", e_CentroPenitenciario.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CentroPenitenciario.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CentroPenitenciario.NroIpRegistro);
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

        public int Anular(CentroPenitenciarioBE e_CentroPenitenciario)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CentroPenitenciarioAnular", connection);
                    ParametroSP("@CentroPenitenciarioId", e_CentroPenitenciario.CentroPenitenciarioId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CentroPenitenciario.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CentroPenitenciario.NroIpRegistro);
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

        public List<CentroPenitenciarioBE> Consultar_Lista()
        {
            List<CentroPenitenciarioBE> lista = new List<CentroPenitenciarioBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CentroPenitenciarioConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CentroPenitenciarioBE(reader));
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

        public List<CentroPenitenciarioBE> Consultar_PK(
                int m_CentroPenitenciarioId)
        {
            List<CentroPenitenciarioBE> lista = new List<CentroPenitenciarioBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CentroPenitenciarioConsultar_PK", connection);
                    ParametroSP("@CentroPenitenciarioId", m_CentroPenitenciarioId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CentroPenitenciarioBE(reader));
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
