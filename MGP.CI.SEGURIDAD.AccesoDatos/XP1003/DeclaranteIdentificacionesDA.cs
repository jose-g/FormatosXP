using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class DeclaranteIdentificacionesDA : BaseDA
    {
        const string Nombre_Clase = "DeclaranteIdentificacionesDA";
        private string m_BaseDatos = string.Empty;

        public DeclaranteIdentificacionesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public DeclaranteIdentificacionesDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(DeclaranteIdentificacionesBE e_DeclaranteIdentificaciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeclaranteIdentificacionesInsertar", connection);
                    ParametroSP("@DocumentoIdentidadTipoId", e_DeclaranteIdentificaciones.DocumentoIdentidadTipoId);
                    ParametroSP("@DeclaranteNumeroDocumento", e_DeclaranteIdentificaciones.DeclaranteNumeroDocumento);
                    ParametroSP("@EstadoId", e_DeclaranteIdentificaciones.EstadoId);
                    ParametroSP("@DatosPersonalesId", e_DeclaranteIdentificaciones.DatosPersonalesId);
                    ParametroSP("@UsuarioRegistro", e_DeclaranteIdentificaciones.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DeclaranteIdentificaciones.NroIpRegistro);
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

        public int Actualizar(DeclaranteIdentificacionesBE e_DeclaranteIdentificaciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeclaranteIdentificacionesActualizar", connection);
                    ParametroSP("@DeclaranteIdentificacionId", e_DeclaranteIdentificaciones.DeclaranteIdentificacionId);
                    ParametroSP("@DocumentoIdentidadTipoId", e_DeclaranteIdentificaciones.DocumentoIdentidadTipoId);
                    ParametroSP("@DeclaranteNumeroDocumento", e_DeclaranteIdentificaciones.DeclaranteNumeroDocumento);
                    ParametroSP("@EstadoId", e_DeclaranteIdentificaciones.EstadoId);
                    ParametroSP("@DatosPersonalesId", e_DeclaranteIdentificaciones.DatosPersonalesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DeclaranteIdentificaciones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DeclaranteIdentificaciones.NroIpRegistro);
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

        public int Anular(DeclaranteIdentificacionesBE e_DeclaranteIdentificaciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeclaranteIdentificacionesAnular", connection);
                    ParametroSP("@DeclaranteIdentificacionId", e_DeclaranteIdentificaciones.DeclaranteIdentificacionId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DeclaranteIdentificaciones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DeclaranteIdentificaciones.NroIpRegistro);
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

        public List<DeclaranteIdentificacionesBE> Consultar_Lista()
        {
            List<DeclaranteIdentificacionesBE> lista = new List<DeclaranteIdentificacionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeclaranteIdentificacionesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DeclaranteIdentificacionesBE(reader));
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

        public List<DeclaranteIdentificacionesBE> Consultar_PK(
                int m_DeclaranteIdentificacionId)
        {
            List<DeclaranteIdentificacionesBE> lista = new List<DeclaranteIdentificacionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeclaranteIdentificacionesConsultar_PK", connection);
                    ParametroSP("@DeclaranteIdentificacionId", m_DeclaranteIdentificacionId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DeclaranteIdentificacionesBE(reader));
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
