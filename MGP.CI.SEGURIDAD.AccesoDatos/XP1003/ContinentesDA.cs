using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class ContinentesDA : BaseDA
    {
        const string Nombre_Clase = "ContinentesDA";
        private string m_BaseDatos = string.Empty;

        public ContinentesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(ContinentesBE e_Continentes)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ContinentesInsertar", connection);
                    ParametroSP("@ContinenteId", e_Continentes.ContinenteId);
                    ParametroSP("@Nombre", e_Continentes.Nombre);
                    ParametroSP("@Descripcion", e_Continentes.Descripcion);
                    ParametroSP("@EstadoId", e_Continentes.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Continentes.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Continentes.NroIpRegistro);
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

        public int Actualizar(ContinentesBE e_Continentes)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ContinentesActualizar", connection);
                    ParametroSP("@ContinenteId", e_Continentes.ContinenteId);
                    ParametroSP("@Nombre", e_Continentes.Nombre);
                    ParametroSP("@Descripcion", e_Continentes.Descripcion);
                    ParametroSP("@EstadoId", e_Continentes.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Continentes.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Continentes.NroIpRegistro);
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

        public int Anular(ContinentesBE e_Continentes)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ContinentesAnular", connection);
                    ParametroSP("@ContinenteId", e_Continentes.ContinenteId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Continentes.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Continentes.NroIpRegistro);
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

        public List<ContinentesBE> Consultar_Lista()
        {
            List<ContinentesBE> lista = new List<ContinentesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ContinentesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ContinentesBE(reader));
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

        public List<ContinentesBE> Consultar_PK(
                int m_ContinenteId)
        {
            List<ContinentesBE> lista = new List<ContinentesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ContinentesConsultar_PK", connection);
                    ParametroSP("@ContinenteId", m_ContinenteId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ContinentesBE(reader));
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
