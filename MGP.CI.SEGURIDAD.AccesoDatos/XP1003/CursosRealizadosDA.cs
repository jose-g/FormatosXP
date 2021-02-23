using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class CursosRealizadosDA : BaseDA
    {
        const string Nombre_Clase = "CursosRealizadosDA";
        private string m_BaseDatos = string.Empty;

        public CursosRealizadosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public CursosRealizadosDA() { }

        public int Insertar(CursosRealizadosBE e_CursosRealizados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CursosRealizadosInsertar", connection);
                    ParametroSP("@CursosRealizadosId", e_CursosRealizados.CursosRealizadosId);
                    ParametroSP("@CursoEscuelaExtranjeraId", e_CursosRealizados.CursoEscuelaExtranjeraId);
                    ParametroSP("@InformacionCastrenseId", e_CursosRealizados.InformacionCastrenseId);
                    ParametroSP("@EstadoId", e_CursosRealizados.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CursosRealizados.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CursosRealizados.NroIpRegistro);
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

        public int Actualizar(CursosRealizadosBE e_CursosRealizados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CursosRealizadosActualizar", connection);
                    ParametroSP("@CursosRealizadosId", e_CursosRealizados.CursosRealizadosId);
                    ParametroSP("@CursoEscuelaExtranjeraId", e_CursosRealizados.CursoEscuelaExtranjeraId);
                    ParametroSP("@InformacionCastrenseId", e_CursosRealizados.InformacionCastrenseId);
                    ParametroSP("@EstadoId", e_CursosRealizados.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CursosRealizados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CursosRealizados.NroIpRegistro);
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

        public int Anular(CursosRealizadosBE e_CursosRealizados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CursosRealizadosAnular", connection);
                    ParametroSP("@CursosRealizadosId", e_CursosRealizados.CursosRealizadosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CursosRealizados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CursosRealizados.NroIpRegistro);
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

        public List<CursosRealizadosBE> Consultar_Lista()
        {
            List<CursosRealizadosBE> lista = new List<CursosRealizadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CursosRealizadosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CursosRealizadosBE(reader));
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

        public List<CursosRealizadosBE> Consultar_PK(
                int m_CursosRealizadosId)
        {
            List<CursosRealizadosBE> lista = new List<CursosRealizadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CursosRealizadosConsultar_PK", connection);
                    ParametroSP("@CursosRealizadosId", m_CursosRealizadosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CursosRealizadosBE(reader));
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
