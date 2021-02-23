using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class InstitucionesMilitaresExtranjerasDA : BaseDA
    {
        const string Nombre_Clase = "InstitucionesMilitaresExtranjerasDA";
        private string m_BaseDatos = string.Empty;

        public InstitucionesMilitaresExtranjerasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public InstitucionesMilitaresExtranjerasDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(InstitucionesMilitaresExtranjerasBE e_InstitucionesMilitaresExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InstitucionesMilitaresExtranjerasInsertar", connection);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_InstitucionesMilitaresExtranjeras.InstitucionMilitarExtranjeraId);
                    ParametroSP("@PaisId", e_InstitucionesMilitaresExtranjeras.PaisId);
                    ParametroSP("@Descripcion", e_InstitucionesMilitaresExtranjeras.Descripcion);
                    ParametroSP("@EstadoId", e_InstitucionesMilitaresExtranjeras.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_InstitucionesMilitaresExtranjeras.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_InstitucionesMilitaresExtranjeras.NroIpRegistro);
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

        public int Actualizar(InstitucionesMilitaresExtranjerasBE e_InstitucionesMilitaresExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InstitucionesMilitaresExtranjerasActualizar", connection);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_InstitucionesMilitaresExtranjeras.InstitucionMilitarExtranjeraId);
                    ParametroSP("@PaisId", e_InstitucionesMilitaresExtranjeras.PaisId);
                    ParametroSP("@Descripcion", e_InstitucionesMilitaresExtranjeras.Descripcion);
                    ParametroSP("@EstadoId", e_InstitucionesMilitaresExtranjeras.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_InstitucionesMilitaresExtranjeras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_InstitucionesMilitaresExtranjeras.NroIpRegistro);
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

        public int Anular(InstitucionesMilitaresExtranjerasBE e_InstitucionesMilitaresExtranjeras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InstitucionesMilitaresExtranjerasAnular", connection);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_InstitucionesMilitaresExtranjeras.InstitucionMilitarExtranjeraId);
                    ParametroSP("@UsuarioModificacionRegistro", e_InstitucionesMilitaresExtranjeras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_InstitucionesMilitaresExtranjeras.NroIpRegistro);
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

        public List<InstitucionesMilitaresExtranjerasBE> Consultar_Lista()
        {
            List<InstitucionesMilitaresExtranjerasBE> lista = new List<InstitucionesMilitaresExtranjerasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InstitucionesMilitaresExtranjerasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InstitucionesMilitaresExtranjerasBE(reader));
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

        public List<InstitucionesMilitaresExtranjerasBE> Consultar_PK(
                int m_InstitucionMilitarExtranjeraId)
        {
            List<InstitucionesMilitaresExtranjerasBE> lista = new List<InstitucionesMilitaresExtranjerasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InstitucionesMilitaresExtranjerasConsultar_PK", connection);
                    ParametroSP("@InstitucionMilitarExtranjeraId", m_InstitucionMilitarExtranjeraId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InstitucionesMilitaresExtranjerasBE(reader));
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
