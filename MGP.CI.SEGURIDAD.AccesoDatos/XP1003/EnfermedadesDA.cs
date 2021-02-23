using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class EnfermedadesDA : BaseDA
    {
        const string Nombre_Clase = "EnfermedadesDA";
        private string m_BaseDatos = string.Empty;

        public EnfermedadesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public EnfermedadesDA() {  }

        public int Insertar(EnfermedadesBE e_Enfermedades)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EnfermedadesInsertar", connection);
                    ParametroSP("@EnfermedadesId", e_Enfermedades.EnfermedadesId);
                    ParametroSP("@EnfermedadTipo", e_Enfermedades.EnfermedadTipo);
                    ParametroSP("@Enfermedad", e_Enfermedades.Enfermedad);
                    ParametroSP("@EstadoId", e_Enfermedades.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Enfermedades.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Enfermedades.NroIpRegistro);
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

        public int Actualizar(EnfermedadesBE e_Enfermedades)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EnfermedadesActualizar", connection);
                    ParametroSP("@EnfermedadesId", e_Enfermedades.EnfermedadesId);
                    ParametroSP("@EnfermedadTipo", e_Enfermedades.EnfermedadTipo);
                    ParametroSP("@Enfermedad", e_Enfermedades.Enfermedad);
                    ParametroSP("@EstadoId", e_Enfermedades.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Enfermedades.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Enfermedades.NroIpRegistro);
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

        public int Anular(EnfermedadesBE e_Enfermedades)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EnfermedadesAnular", connection);
                    ParametroSP("@EnfermedadesId", e_Enfermedades.EnfermedadesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Enfermedades.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Enfermedades.NroIpRegistro);
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

        public List<EnfermedadesBE> Consultar_Lista()
        {
            List<EnfermedadesBE> lista = new List<EnfermedadesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EnfermedadesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EnfermedadesBE(reader));
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

        public List<EnfermedadesBE> Consultar_PK(
                int m_EnfermedadesId)
        {
            List<EnfermedadesBE> lista = new List<EnfermedadesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EnfermedadesConsultar_PK", connection);
                    ParametroSP("@EnfermedadesId", m_EnfermedadesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EnfermedadesBE(reader));
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
