using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class InstitucionMilitarDA : BaseDA
    {
        const string Nombre_Clase = "InstitucionMilitarDA";
        private string m_BaseDatos = string.Empty;

        public InstitucionMilitarDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(InstitucionMilitarBE e_InstitucionMilitar)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InstitucionMilitarInsertar", connection);
                    ParametroSP("@InstitucionMilitarId", e_InstitucionMilitar.InstitucionMilitarId);
                    ParametroSP("@Nombre", e_InstitucionMilitar.Nombre);
                    ParametroSP("@Descripcion", e_InstitucionMilitar.Descripcion);
                    ParametroSP("@EstadoId", e_InstitucionMilitar.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_InstitucionMilitar.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_InstitucionMilitar.NroIpRegistro);
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

        public int Actualizar(InstitucionMilitarBE e_InstitucionMilitar)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InstitucionMilitarActualizar", connection);
                    ParametroSP("@InstitucionMilitarId", e_InstitucionMilitar.InstitucionMilitarId);
                    ParametroSP("@Nombre", e_InstitucionMilitar.Nombre);
                    ParametroSP("@Descripcion", e_InstitucionMilitar.Descripcion);
                    ParametroSP("@EstadoId", e_InstitucionMilitar.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_InstitucionMilitar.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_InstitucionMilitar.NroIpRegistro);
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

        public int Anular(InstitucionMilitarBE e_InstitucionMilitar)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InstitucionMilitarAnular", connection);
                    ParametroSP("@InstitucionMilitarId", e_InstitucionMilitar.InstitucionMilitarId);
                    ParametroSP("@UsuarioModificacionRegistro", e_InstitucionMilitar.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_InstitucionMilitar.NroIpRegistro);
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

        public List<InstitucionMilitarBE> Consultar_Lista()
        {
            List<InstitucionMilitarBE> lista = new List<InstitucionMilitarBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InstitucionMilitarConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InstitucionMilitarBE(reader));
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

        public List<InstitucionMilitarBE> Consultar_PK(
                int m_InstitucionMilitarId)
        {
            List<InstitucionMilitarBE> lista = new List<InstitucionMilitarBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_InstitucionMilitarConsultar_PK", connection);
                    ParametroSP("@InstitucionMilitarId", m_InstitucionMilitarId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new InstitucionMilitarBE(reader));
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
