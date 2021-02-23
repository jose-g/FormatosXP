using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class EscuelasExtranjerasDA : BaseDA
    {
        const string Nombre_Clase = "EscuelasExtranjerasDA";
        private string m_BaseDatos = string.Empty;

        public EscuelasExtranjerasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public EscuelasExtranjerasDA() { }

        public int Insertar(EscuelasExtranjerasBE e_EscuelasExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EscuelasExtranjerasInsertar", connection);
                    ParametroSP("@EscuelaExtranjeraId", e_EscuelasExtranjeras.EscuelaExtranjeraId);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_EscuelasExtranjeras.InstitucionMilitarExtranjeraId);
                    ParametroSP("@Nombre", e_EscuelasExtranjeras.Nombre);
                    ParametroSP("@Descripcion", e_EscuelasExtranjeras.Descripcion);
                    ParametroSP("@EstadoId", e_EscuelasExtranjeras.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_EscuelasExtranjeras.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_EscuelasExtranjeras.NroIpRegistro);
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

        public int Actualizar(EscuelasExtranjerasBE e_EscuelasExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EscuelasExtranjerasActualizar", connection);
                    ParametroSP("@EscuelaExtranjeraId", e_EscuelasExtranjeras.EscuelaExtranjeraId);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_EscuelasExtranjeras.InstitucionMilitarExtranjeraId);
                    ParametroSP("@Nombre", e_EscuelasExtranjeras.Nombre);
                    ParametroSP("@Descripcion", e_EscuelasExtranjeras.Descripcion);
                    ParametroSP("@EstadoId", e_EscuelasExtranjeras.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_EscuelasExtranjeras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_EscuelasExtranjeras.NroIpRegistro);
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

        public int Anular(EscuelasExtranjerasBE e_EscuelasExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EscuelasExtranjerasAnular", connection);
                    ParametroSP("@EscuelaExtranjeraId", e_EscuelasExtranjeras.EscuelaExtranjeraId);
                    ParametroSP("@UsuarioModificacionRegistro", e_EscuelasExtranjeras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_EscuelasExtranjeras.NroIpRegistro);
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

        public List<EscuelasExtranjerasBE> Consultar_Lista()
        {
            List<EscuelasExtranjerasBE> lista = new List<EscuelasExtranjerasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EscuelasExtranjerasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EscuelasExtranjerasBE(reader));
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

        public List<EscuelasExtranjerasBE> Consultar_PK(
                int m_EscuelaExtranjeraId)
        {
            List<EscuelasExtranjerasBE> lista = new List<EscuelasExtranjerasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EscuelasExtranjerasConsultar_PK", connection);
                    ParametroSP("@EscuelaExtranjeraId", m_EscuelaExtranjeraId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EscuelasExtranjerasBE(reader));
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
