using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class EspecialidadesExtranjerasDA : BaseDA
    {
        const string Nombre_Clase = "EspecialidadesExtranjerasDA";
        private string m_BaseDatos = string.Empty;

        public EspecialidadesExtranjerasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public EspecialidadesExtranjerasDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(EspecialidadesExtranjerasBE e_EspecialidadesExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EspecialidadesExtranjerasInsertar", connection);
                    ParametroSP("@EspecialidadesExtranjerasId", e_EspecialidadesExtranjeras.EspecialidadesExtranjerasId);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_EspecialidadesExtranjeras.InstitucionMilitarExtranjeraId);
                    ParametroSP("@Escalafon", e_EspecialidadesExtranjeras.Escalafon);
                    ParametroSP("@CategoriaMilitarId", e_EspecialidadesExtranjeras.CategoriaMilitarId);
                    ParametroSP("@Descripcion", e_EspecialidadesExtranjeras.Descripcion);
                    ParametroSP("@EstadoId", e_EspecialidadesExtranjeras.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_EspecialidadesExtranjeras.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_EspecialidadesExtranjeras.NroIpRegistro);
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

        public int Actualizar(EspecialidadesExtranjerasBE e_EspecialidadesExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EspecialidadesExtranjerasActualizar", connection);
                    ParametroSP("@EspecialidadesExtranjerasId", e_EspecialidadesExtranjeras.EspecialidadesExtranjerasId);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_EspecialidadesExtranjeras.InstitucionMilitarExtranjeraId);
                    ParametroSP("@Escalafon", e_EspecialidadesExtranjeras.Escalafon);
                    ParametroSP("@CategoriaMilitarId", e_EspecialidadesExtranjeras.CategoriaMilitarId);
                    ParametroSP("@Descripcion", e_EspecialidadesExtranjeras.Descripcion);
                    ParametroSP("@EstadoId", e_EspecialidadesExtranjeras.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_EspecialidadesExtranjeras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_EspecialidadesExtranjeras.NroIpRegistro);
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

        public int Anular(EspecialidadesExtranjerasBE e_EspecialidadesExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EspecialidadesExtranjerasAnular", connection);
                    ParametroSP("@EspecialidadesExtranjerasId", e_EspecialidadesExtranjeras.EspecialidadesExtranjerasId);
                    ParametroSP("@UsuarioModificacionRegistro", e_EspecialidadesExtranjeras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_EspecialidadesExtranjeras.NroIpRegistro);
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

        public List<EspecialidadesExtranjerasBE> Consultar_Lista()
        {
            List<EspecialidadesExtranjerasBE> lista = new List<EspecialidadesExtranjerasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EspecialidadesExtranjerasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EspecialidadesExtranjerasBE(reader));
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

        public List<EspecialidadesExtranjerasBE> Consultar_PK(
                int m_EspecialidadesExtranjerasId)
        {
            List<EspecialidadesExtranjerasBE> lista = new List<EspecialidadesExtranjerasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EspecialidadesExtranjerasConsultar_PK", connection);
                    ParametroSP("@EspecialidadesExtranjerasId", m_EspecialidadesExtranjerasId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EspecialidadesExtranjerasBE(reader));
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
