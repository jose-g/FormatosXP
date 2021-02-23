using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class VehiculoTiposDA : BaseDA
    {
        const string Nombre_Clase = "VehiculoTiposDA";
        private string m_BaseDatos = string.Empty;

        public VehiculoTiposDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public VehiculoTiposDA() { }

        public int Insertar(VehiculoTiposBE e_VehiculoTipos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculoTiposInsertar", connection);
                    ParametroSP("@VehiculoTipoId", e_VehiculoTipos.VehiculoTipoId);
                    ParametroSP("@Nombre", e_VehiculoTipos.Nombre);
                    ParametroSP("@EstadoId", e_VehiculoTipos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_VehiculoTipos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_VehiculoTipos.NroIpRegistro);
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

        public int Actualizar(VehiculoTiposBE e_VehiculoTipos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculoTiposActualizar", connection);
                    ParametroSP("@VehiculoTipoId", e_VehiculoTipos.VehiculoTipoId);
                    ParametroSP("@Nombre", e_VehiculoTipos.Nombre);
                    ParametroSP("@EstadoId", e_VehiculoTipos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_VehiculoTipos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_VehiculoTipos.NroIpRegistro);
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

        public int Anular(VehiculoTiposBE e_VehiculoTipos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculoTiposAnular", connection);
                    ParametroSP("@VehiculoTipoId", e_VehiculoTipos.VehiculoTipoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_VehiculoTipos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_VehiculoTipos.NroIpRegistro);
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

        public List<VehiculoTiposBE> Consultar_Lista()
        {
            List<VehiculoTiposBE> lista = new List<VehiculoTiposBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculoTiposConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new VehiculoTiposBE(reader));
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

        public List<VehiculoTiposBE> Consultar_PK(
                int m_VehiculoTipoId)
        {
            List<VehiculoTiposBE> lista = new List<VehiculoTiposBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculoTiposConsultar_PK", connection);
                    ParametroSP("@VehiculoTipoId", m_VehiculoTipoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new VehiculoTiposBE(reader));
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
