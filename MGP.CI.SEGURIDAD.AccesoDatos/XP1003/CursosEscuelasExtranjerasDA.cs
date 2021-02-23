using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class CursosEscuelasExtranjerasDA : BaseDA
    {
        const string Nombre_Clase = "CursosEscuelasExtranjerasDA";
        private string m_BaseDatos = string.Empty;

        public CursosEscuelasExtranjerasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public CursosEscuelasExtranjerasDA() { }

        public int Insertar(CursosEscuelasExtranjerasBE e_CursosEscuelasExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CursosEscuelasExtranjerasInsertar", connection);
                    ParametroSP("@CursoEscuelaExtranjeraId", e_CursosEscuelasExtranjeras.CursoEscuelaExtranjeraId);
                    ParametroSP("@EscuelaExtranjeraId", e_CursosEscuelasExtranjeras.EscuelaExtranjeraId);
                    ParametroSP("@Nombre", e_CursosEscuelasExtranjeras.Nombre);
                    ParametroSP("@EstadoId", e_CursosEscuelasExtranjeras.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CursosEscuelasExtranjeras.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CursosEscuelasExtranjeras.NroIpRegistro);
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

        public int Actualizar(CursosEscuelasExtranjerasBE e_CursosEscuelasExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CursosEscuelasExtranjerasActualizar", connection);
                    ParametroSP("@CursoEscuelaExtranjeraId", e_CursosEscuelasExtranjeras.CursoEscuelaExtranjeraId);
                    ParametroSP("@EscuelaExtranjeraId", e_CursosEscuelasExtranjeras.EscuelaExtranjeraId);
                    ParametroSP("@Nombre", e_CursosEscuelasExtranjeras.Nombre);
                    ParametroSP("@EstadoId", e_CursosEscuelasExtranjeras.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CursosEscuelasExtranjeras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CursosEscuelasExtranjeras.NroIpRegistro);
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

        public int Anular(CursosEscuelasExtranjerasBE e_CursosEscuelasExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CursosEscuelasExtranjerasAnular", connection);
                    ParametroSP("@CursoEscuelaExtranjeraId", e_CursosEscuelasExtranjeras.CursoEscuelaExtranjeraId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CursosEscuelasExtranjeras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CursosEscuelasExtranjeras.NroIpRegistro);
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

        public List<CursosEscuelasExtranjerasBE> Consultar_Lista()
        {
            List<CursosEscuelasExtranjerasBE> lista = new List<CursosEscuelasExtranjerasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CursosEscuelasExtranjerasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CursosEscuelasExtranjerasBE(reader));
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

        public List<CursosEscuelasExtranjerasBE> Consultar_PK(
                int m_CursoEscuelaExtranjeraId)
        {
            List<CursosEscuelasExtranjerasBE> lista = new List<CursosEscuelasExtranjerasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CursosEscuelasExtranjerasConsultar_PK", connection);
                    ParametroSP("@CursoEscuelaExtranjeraId", m_CursoEscuelaExtranjeraId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CursosEscuelasExtranjerasBE(reader));
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
