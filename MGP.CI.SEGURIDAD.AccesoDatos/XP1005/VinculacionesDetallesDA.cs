using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class VinculacionesDetallesDA : BaseDA
    {
        const string Nombre_Clase = "VinculacionesDetallesDA";
        private string m_BaseDatos = string.Empty;

        public VinculacionesDetallesDA() {  }

        public int Insertar(VinculacionesDetallesBE e_VinculacionesDetalles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VinculacionesDetallesInsertar", connection);
                    ParametroSP("@VinculacionesDetallesId", e_VinculacionesDetalles.VinculacionesDetallesId);
                    ParametroSP("@Vinculaciones1005d", e_VinculacionesDetalles.Vinculaciones1005d);
                    ParametroSP("@VinculoId", e_VinculacionesDetalles.VinculoId);
                    ParametroSP("@Descripcion", e_VinculacionesDetalles.Descripcion);
                    ParametroSP("@EstadoId", e_VinculacionesDetalles.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_VinculacionesDetalles.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_VinculacionesDetalles.NroIpRegistro);
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

        public int Actualizar(VinculacionesDetallesBE e_VinculacionesDetalles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VinculacionesDetallesActualizar", connection);
                    ParametroSP("@VinculacionesDetallesId", e_VinculacionesDetalles.VinculacionesDetallesId);
                    ParametroSP("@Vinculaciones1005d", e_VinculacionesDetalles.Vinculaciones1005d);
                    ParametroSP("@VinculoId", e_VinculacionesDetalles.VinculoId);
                    ParametroSP("@Descripcion", e_VinculacionesDetalles.Descripcion);
                    ParametroSP("@EstadoId", e_VinculacionesDetalles.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_VinculacionesDetalles.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_VinculacionesDetalles.NroIpRegistro);
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

        public int Anular(VinculacionesDetallesBE e_VinculacionesDetalles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VinculacionesDetallesAnular", connection);
                    ParametroSP("@VinculacionesDetallesId", e_VinculacionesDetalles.VinculacionesDetallesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_VinculacionesDetalles.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_VinculacionesDetalles.NroIpRegistro);
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

        public List<VinculacionesDetallesBE> Consultar_Lista()
        {
            List<VinculacionesDetallesBE> lista = new List<VinculacionesDetallesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VinculacionesDetallesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new VinculacionesDetallesBE(reader));
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

        public List<VinculacionesDetallesBE> Consultar_PK(
                int m_VinculacionesDetallesId)
        {
            List<VinculacionesDetallesBE> lista = new List<VinculacionesDetallesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VinculacionesDetallesConsultar_PK", connection);
                    ParametroSP("@VinculacionesDetallesId", m_VinculacionesDetallesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new VinculacionesDetallesBE(reader));
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
                    ComandoSP("usp_VinculacionesDetallesGetMaxId", connection);
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


