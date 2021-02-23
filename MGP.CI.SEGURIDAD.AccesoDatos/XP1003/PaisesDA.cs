using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class PaisesDA : BaseDA
    {
        const string Nombre_Clase = "PaisesDA";
        private string m_BaseDatos = string.Empty;

        public PaisesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(PaisesBE e_Paises)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PaisesInsertar", connection);
                    ParametroSP("@PaisId", e_Paises.PaisId);
                    ParametroSP("@Nombre", e_Paises.Nombre);
                    ParametroSP("@ContinenteId", e_Paises.ContinenteId);
                    ParametroSP("@Descripcion", e_Paises.Descripcion);
                    ParametroSP("@EstadoId", e_Paises.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Paises.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Paises.NroIpRegistro);
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

        public int Actualizar(PaisesBE e_Paises)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PaisesActualizar", connection);
                    ParametroSP("@PaisId", e_Paises.PaisId);
                    ParametroSP("@Nombre", e_Paises.Nombre);
                    ParametroSP("@ContinenteId", e_Paises.ContinenteId);
                    ParametroSP("@Descripcion", e_Paises.Descripcion);
                    ParametroSP("@EstadoId", e_Paises.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Paises.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Paises.NroIpRegistro);
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

        public int Anular(PaisesBE e_Paises)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PaisesAnular", connection);
                    ParametroSP("@PaisId", e_Paises.PaisId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Paises.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Paises.NroIpRegistro);
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

        public List<PaisesBE> Consultar_Lista()
        {
            List<PaisesBE> lista = new List<PaisesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PaisesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PaisesBE(reader));
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

        public List<PaisesBE> Consultar_PK(
                int m_PaisId)
        {
            List<PaisesBE> lista = new List<PaisesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PaisesConsultar_PK", connection);
                    ParametroSP("@PaisId", m_PaisId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PaisesBE(reader));
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
