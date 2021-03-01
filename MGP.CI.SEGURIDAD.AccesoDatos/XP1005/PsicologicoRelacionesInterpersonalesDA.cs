using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class PsicologicoRelacionesInterpersonalesDA : BaseDA
    {
        const string Nombre_Clase = "PsicologicoRelacionesInterpersonalesDA";
        private string m_BaseDatos = string.Empty;

        public PsicologicoRelacionesInterpersonalesDA() {  }

        public int Insertar(PsicologicoRelacionesInterpersonalesBE e_PsicologicoRelacionesInterpersonales)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PsicologicoRelacionesInterpersonalesInsertar", connection);
                    ParametroSP("@PsicologicoRelacionesInterpersonales", e_PsicologicoRelacionesInterpersonales.PsicologicoRelacionesInterpersonales);
                    ParametroSP("@PerfilPsicologicoDetallesId", e_PsicologicoRelacionesInterpersonales.PerfilPsicologicoDetallesId);
                    ParametroSP("@NivelesNumericosId", e_PsicologicoRelacionesInterpersonales.NivelesNumericosId);
                    ParametroSP("@RelacionesInterpersonalesId", e_PsicologicoRelacionesInterpersonales.RelacionesInterpersonalesId);
                    ParametroSP("@EstadoId", e_PsicologicoRelacionesInterpersonales.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_PsicologicoRelacionesInterpersonales.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_PsicologicoRelacionesInterpersonales.NroIpRegistro);
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

        public int Actualizar(PsicologicoRelacionesInterpersonalesBE e_PsicologicoRelacionesInterpersonales)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PsicologicoRelacionesInterpersonalesActualizar", connection);
                    ParametroSP("@PsicologicoRelacionesInterpersonales", e_PsicologicoRelacionesInterpersonales.PsicologicoRelacionesInterpersonales);
                    ParametroSP("@PerfilPsicologicoDetallesId", e_PsicologicoRelacionesInterpersonales.PerfilPsicologicoDetallesId);
                    ParametroSP("@NivelesNumericosId", e_PsicologicoRelacionesInterpersonales.NivelesNumericosId);
                    ParametroSP("@RelacionesInterpersonalesId", e_PsicologicoRelacionesInterpersonales.RelacionesInterpersonalesId);
                    ParametroSP("@EstadoId", e_PsicologicoRelacionesInterpersonales.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PsicologicoRelacionesInterpersonales.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PsicologicoRelacionesInterpersonales.NroIpRegistro);
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

        public int Anular(PsicologicoRelacionesInterpersonalesBE e_PsicologicoRelacionesInterpersonales)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PsicologicoRelacionesInterpersonalesAnular", connection);
                    ParametroSP("@PsicologicoRelacionesInterpersonales", e_PsicologicoRelacionesInterpersonales.PsicologicoRelacionesInterpersonales);
                    ParametroSP("@UsuarioModificacionRegistro", e_PsicologicoRelacionesInterpersonales.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PsicologicoRelacionesInterpersonales.NroIpRegistro);
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

        public List<PsicologicoRelacionesInterpersonalesBE> Consultar_Lista()
        {
            List<PsicologicoRelacionesInterpersonalesBE> lista = new List<PsicologicoRelacionesInterpersonalesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PsicologicoRelacionesInterpersonalesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PsicologicoRelacionesInterpersonalesBE(reader));
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

        public List<PsicologicoRelacionesInterpersonalesBE> Consultar_PK(
                int m_PsicologicoRelacionesInterpersonales)
        {
            List<PsicologicoRelacionesInterpersonalesBE> lista = new List<PsicologicoRelacionesInterpersonalesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PsicologicoRelacionesInterpersonalesConsultar_PK", connection);
                    ParametroSP("@PsicologicoRelacionesInterpersonales", m_PsicologicoRelacionesInterpersonales);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PsicologicoRelacionesInterpersonalesBE(reader));
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

        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_PsicologicoRelacionesInterpersonalesGetMaxId", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                        if (!DBNull.Value.Equals(reader["CodigoMaxId"]))
                            {
                             maxId = Convert.ToInt32(reader["CodigoMaxId"]);
                            }
                        }
                }
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
            return maxId;
        }

    }
}


