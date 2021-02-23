using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class UbigeoNavalDA : BaseDA
    {
        const string Nombre_Clase = "UbigeoNavalDA";
        private string m_BaseDatos = string.Empty;

        public UbigeoNavalDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public UbigeoNavalDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(UbigeoNavalBE e_UbigeoNaval)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UbigeoNavalInsertar", connection);
                    ParametroSP("@ZonaNavalId", e_UbigeoNaval.ZonaNavalId);
                    ParametroSP("@ZonaNavalDescCorta", e_UbigeoNaval.ZonaNavalDescCorta);
                    ParametroSP("@ZonaNavalDescLarga", e_UbigeoNaval.ZonaNavalDescLarga);
                    ParametroSP("@DependenciaId", e_UbigeoNaval.DependenciaId);
                    ParametroSP("@DependenciaDescCorta", e_UbigeoNaval.DependenciaDescCorta);
                    ParametroSP("@DependenciaDescLarga", e_UbigeoNaval.DependenciaDescLarga);
                    ParametroSP("@UsuarioRegistro", e_UbigeoNaval.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_UbigeoNaval.NroIpRegistro);
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

        public int Actualizar(UbigeoNavalBE e_UbigeoNaval)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UbigeoNavalActualizar", connection);
                    ParametroSP("@UbigeoNavalId", e_UbigeoNaval.UbigeoNavalId);
                    ParametroSP("@ZonaNavalId", e_UbigeoNaval.ZonaNavalId);
                    ParametroSP("@ZonaNavalDescCorta", e_UbigeoNaval.ZonaNavalDescCorta);
                    ParametroSP("@ZonaNavalDescLarga", e_UbigeoNaval.ZonaNavalDescLarga);
                    ParametroSP("@DependenciaId", e_UbigeoNaval.DependenciaId);
                    ParametroSP("@DependenciaDescCorta", e_UbigeoNaval.DependenciaDescCorta);
                    ParametroSP("@DependenciaDescLarga", e_UbigeoNaval.DependenciaDescLarga);
                    ParametroSP("@UsuarioModificacionRegistro", e_UbigeoNaval.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_UbigeoNaval.NroIpRegistro);
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

        public int Anular(UbigeoNavalBE e_UbigeoNaval)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UbigeoNavalAnular", connection);
                    ParametroSP("@UbigeoNavalId", e_UbigeoNaval.UbigeoNavalId);
                    ParametroSP("@UsuarioModificacionRegistro", e_UbigeoNaval.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_UbigeoNaval.NroIpRegistro);
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

        public List<UbigeoNavalBE> Consultar_Lista()
        {
            List<UbigeoNavalBE> lista = new List<UbigeoNavalBE>();
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UbigeoNavalConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UbigeoNavalBE(reader));
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

        public List<UbigeoNavalBE> Consultar_PK(int m_UbigeoNavalId)
        {
            List<UbigeoNavalBE> lista = new List<UbigeoNavalBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UbigeoNavalConsultar_PK", connection);
                    ParametroSP("@UbigeoNavalId", m_UbigeoNavalId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UbigeoNavalBE(reader));
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
        public int CambiarEstado(UbigeoNavalBE m_UbigeoNavalId)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UbigeoNavalCambiarEstado", connection);
                    ParametroSP("@UbigeoNavalId", m_UbigeoNavalId.UbigeoNavalId);
                    ParametroSP("@UsuarioModificacionRegistro", m_UbigeoNavalId.UsuarioModificacionRegistro);
                    ParametroSP("@EstadoId", m_UbigeoNavalId.EstadoId);
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


    }
}
