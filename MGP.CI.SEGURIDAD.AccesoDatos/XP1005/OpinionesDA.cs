using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class OpinionesDA : BaseDA
    {
        const string Nombre_Clase = "OpinionesDA";
        private string m_BaseDatos = string.Empty;

        public OpinionesDA() {  }

        public int Insertar(OpinionesBE e_Opiniones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OpinionesInsertar", connection);
                    ParametroSP("@OpinionesId", e_Opiniones.OpinionesId);
                    ParametroSP("@Vinculaciones1005d", e_Opiniones.Vinculaciones1005d);
                    ParametroSP("@OpinionMaestraId", e_Opiniones.OpinionMaestraId);
                    ParametroSP("@NivelesBuenoId", e_Opiniones.NivelesBuenoId);
                    ParametroSP("@Descripcion", e_Opiniones.Descripcion);
                    ParametroSP("@EstadoId", e_Opiniones.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Opiniones.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Opiniones.NroIpRegistro);
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

        public int Actualizar(OpinionesBE e_Opiniones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OpinionesActualizar", connection);
                    ParametroSP("@OpinionesId", e_Opiniones.OpinionesId);
                    ParametroSP("@Vinculaciones1005d", e_Opiniones.Vinculaciones1005d);
                    ParametroSP("@OpinionMaestraId", e_Opiniones.OpinionMaestraId);
                    ParametroSP("@NivelesBuenoId", e_Opiniones.NivelesBuenoId);
                    ParametroSP("@Descripcion", e_Opiniones.Descripcion);
                    ParametroSP("@EstadoId", e_Opiniones.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Opiniones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Opiniones.NroIpRegistro);
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

        public int Anular(OpinionesBE e_Opiniones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OpinionesAnular", connection);
                    ParametroSP("@OpinionesId", e_Opiniones.OpinionesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Opiniones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Opiniones.NroIpRegistro);
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

        public List<OpinionesBE> Consultar_Lista()
        {
            List<OpinionesBE> lista = new List<OpinionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OpinionesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OpinionesBE(reader));
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

        public List<OpinionesBE> Consultar_PK(
                int m_OpinionesId)
        {
            List<OpinionesBE> lista = new List<OpinionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_OpinionesConsultar_PK", connection);
                    ParametroSP("@OpinionesId", m_OpinionesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new OpinionesBE(reader));
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
                    ComandoSP("usp_OpinionesGetMaxId", connection);
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


