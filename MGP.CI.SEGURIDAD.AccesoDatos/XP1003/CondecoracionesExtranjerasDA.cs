using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class CondecoracionesExtranjerasDA : BaseDA
    {
        const string Nombre_Clase = "CondecoracionesExtranjerasDA";
        private string m_BaseDatos = string.Empty;

        public CondecoracionesExtranjerasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public CondecoracionesExtranjerasDA() { }

        public int Insertar(CondecoracionesExtranjerasBE e_CondecoracionesExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CondecoracionesExtranjerasInsertar", connection);
                    ParametroSP("@CondecoracionesExtranjerasId", e_CondecoracionesExtranjeras.CondecoracionesExtranjerasId);
                    ParametroSP("@Nombre", e_CondecoracionesExtranjeras.Nombre);
                    ParametroSP("@Descripcion", e_CondecoracionesExtranjeras.Descripcion);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_CondecoracionesExtranjeras.InstitucionMilitarExtranjeraId);
                    ParametroSP("@CategoriaMilitarId", e_CondecoracionesExtranjeras.CategoriaMilitarId);
                    ParametroSP("@EstadoId", e_CondecoracionesExtranjeras.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CondecoracionesExtranjeras.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CondecoracionesExtranjeras.NroIpRegistro);
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

        public int Actualizar(CondecoracionesExtranjerasBE e_CondecoracionesExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CondecoracionesExtranjerasActualizar", connection);
                    ParametroSP("@CondecoracionesExtranjerasId", e_CondecoracionesExtranjeras.CondecoracionesExtranjerasId);
                    ParametroSP("@Nombre", e_CondecoracionesExtranjeras.Nombre);
                    ParametroSP("@Descripcion", e_CondecoracionesExtranjeras.Descripcion);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_CondecoracionesExtranjeras.InstitucionMilitarExtranjeraId);
                    ParametroSP("@CategoriaMilitarId", e_CondecoracionesExtranjeras.CategoriaMilitarId);
                    ParametroSP("@EstadoId", e_CondecoracionesExtranjeras.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CondecoracionesExtranjeras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CondecoracionesExtranjeras.NroIpRegistro);
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

        public int Anular(CondecoracionesExtranjerasBE e_CondecoracionesExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CondecoracionesExtranjerasAnular", connection);
                    ParametroSP("@CondecoracionesExtranjerasId", e_CondecoracionesExtranjeras.CondecoracionesExtranjerasId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CondecoracionesExtranjeras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CondecoracionesExtranjeras.NroIpRegistro);
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

        public List<CondecoracionesExtranjerasBE> Consultar_Lista()
        {
            List<CondecoracionesExtranjerasBE> lista = new List<CondecoracionesExtranjerasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CondecoracionesExtranjerasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CondecoracionesExtranjerasBE(reader));
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

        public List<CondecoracionesExtranjerasBE> Consultar_PK(
                int m_CondecoracionesExtranjerasId)
        {
            List<CondecoracionesExtranjerasBE> lista = new List<CondecoracionesExtranjerasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CondecoracionesExtranjerasConsultar_PK", connection);
                    ParametroSP("@CondecoracionesExtranjerasId", m_CondecoracionesExtranjerasId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CondecoracionesExtranjerasBE(reader));
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
