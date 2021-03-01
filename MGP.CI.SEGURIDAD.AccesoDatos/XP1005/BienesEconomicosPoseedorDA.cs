using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class BienesEconomicosPoseedorDA : BaseDA
    {
        const string Nombre_Clase = "BienesEconomicosPoseedorDA";
        private string m_BaseDatos = string.Empty;

        public BienesEconomicosPoseedorDA() {  }

        public int Insertar(BienesEconomicosPoseedorBE e_BienesEconomicosPoseedor)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_BienesEconomicosPoseedorInsertar", connection);
                    ParametroSP("@BienesEconomicosPoseedorId", e_BienesEconomicosPoseedor.BienesEconomicosPoseedorId);
                    ParametroSP("@DatosGeneralesId", e_BienesEconomicosPoseedor.DatosGeneralesId);
                    ParametroSP("@BienesEconomicosMaestraId", e_BienesEconomicosPoseedor.BienesEconomicosMaestraId);
                    ParametroSP("@EstadoId", e_BienesEconomicosPoseedor.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_BienesEconomicosPoseedor.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_BienesEconomicosPoseedor.NroIpRegistro);
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

        public int Actualizar(BienesEconomicosPoseedorBE e_BienesEconomicosPoseedor)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_BienesEconomicosPoseedorActualizar", connection);
                    ParametroSP("@BienesEconomicosPoseedorId", e_BienesEconomicosPoseedor.BienesEconomicosPoseedorId);
                    ParametroSP("@DatosGeneralesId", e_BienesEconomicosPoseedor.DatosGeneralesId);
                    ParametroSP("@BienesEconomicosMaestraId", e_BienesEconomicosPoseedor.BienesEconomicosMaestraId);
                    ParametroSP("@EstadoId", e_BienesEconomicosPoseedor.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_BienesEconomicosPoseedor.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_BienesEconomicosPoseedor.NroIpRegistro);
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

        public int Anular(BienesEconomicosPoseedorBE e_BienesEconomicosPoseedor)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_BienesEconomicosPoseedorAnular", connection);
                    ParametroSP("@BienesEconomicosPoseedorId", e_BienesEconomicosPoseedor.BienesEconomicosPoseedorId);
                    ParametroSP("@UsuarioModificacionRegistro", e_BienesEconomicosPoseedor.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_BienesEconomicosPoseedor.NroIpRegistro);
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

        public List<BienesEconomicosPoseedorBE> Consultar_Lista()
        {
            List<BienesEconomicosPoseedorBE> lista = new List<BienesEconomicosPoseedorBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_BienesEconomicosPoseedorConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BienesEconomicosPoseedorBE(reader));
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

        public List<BienesEconomicosPoseedorBE> Consultar_PK(
                int m_BienesEconomicosPoseedorId)
        {
            List<BienesEconomicosPoseedorBE> lista = new List<BienesEconomicosPoseedorBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_BienesEconomicosPoseedorConsultar_PK", connection);
                    ParametroSP("@BienesEconomicosPoseedorId", m_BienesEconomicosPoseedorId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BienesEconomicosPoseedorBE(reader));
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
                    ComandoSP("usp_BienesEconomicosPoseedorGetMaxId", connection);
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


