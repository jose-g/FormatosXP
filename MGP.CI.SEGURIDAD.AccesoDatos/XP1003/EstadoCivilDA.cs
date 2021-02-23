using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class EstadoCivilDA : BaseDA
    {
        const string Nombre_Clase = "EstadoCivilDA";
        private string m_BaseDatos = string.Empty;

        public EstadoCivilDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(EstadoCivilBE e_EstadoCivil)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadoCivilInsertar", connection);
                    ParametroSP("@EstadoCivilId", e_EstadoCivil.EstadoCivilId);
                    ParametroSP("@Nombre", e_EstadoCivil.Nombre);
                    ParametroSP("@Descripcion", e_EstadoCivil.Descripcion);
                    ParametroSP("@EstadoId", e_EstadoCivil.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_EstadoCivil.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_EstadoCivil.NroIpRegistro);
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

        public int Actualizar(EstadoCivilBE e_EstadoCivil)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadoCivilActualizar", connection);
                    ParametroSP("@EstadoCivilId", e_EstadoCivil.EstadoCivilId);
                    ParametroSP("@Nombre", e_EstadoCivil.Nombre);
                    ParametroSP("@Descripcion", e_EstadoCivil.Descripcion);
                    ParametroSP("@EstadoId", e_EstadoCivil.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_EstadoCivil.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_EstadoCivil.NroIpRegistro);
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

        public int Anular(EstadoCivilBE e_EstadoCivil)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadoCivilAnular", connection);
                    ParametroSP("@EstadoCivilId", e_EstadoCivil.EstadoCivilId);
                    ParametroSP("@UsuarioModificacionRegistro", e_EstadoCivil.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_EstadoCivil.NroIpRegistro);
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

        public List<EstadoCivilBE> Consultar_Lista()
        {
            List<EstadoCivilBE> lista = new List<EstadoCivilBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadoCivilConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EstadoCivilBE(reader));
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

        public List<EstadoCivilBE> Consultar_PK(
                int m_EstadoCivilId)
        {
            List<EstadoCivilBE> lista = new List<EstadoCivilBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadoCivilConsultar_PK", connection);
                    ParametroSP("@EstadoCivilId", m_EstadoCivilId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EstadoCivilBE(reader));
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
