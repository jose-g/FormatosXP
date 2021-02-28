using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class ObservacionesDA : BaseDA
    {
        const string Nombre_Clase = "ObservacionesDA";
        private string m_BaseDatos = string.Empty;

        public ObservacionesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public ObservacionesDA() { }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_ObservacionesGetMaxId", connection);


                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!DBNull.Value.Equals(reader["CodigoMaxId"])) { maxId = Convert.ToInt32(reader["CodigoMaxId"]); }
                        }
                    }
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
            return maxId;
        }
        public int Insertar(ObservacionesBE e_Observaciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ObservacionesInsertar", connection);
                    ParametroSP("@ObservacionesId", e_Observaciones.ObservacionesId);
                    ParametroSP("@OtrosId", e_Observaciones.OtrosId);
                    ParametroSP("@Descripcion", e_Observaciones.Descripcion);
                    ParametroSP("@EstadoId", e_Observaciones.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Observaciones.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones.NroIpRegistro);
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

        public int Actualizar(ObservacionesBE e_Observaciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ObservacionesActualizar", connection);
                    ParametroSP("@ObservacionesId", e_Observaciones.ObservacionesId);
                    ParametroSP("@OtrosId", e_Observaciones.OtrosId);
                    ParametroSP("@Descripcion", e_Observaciones.Descripcion);
                    ParametroSP("@EstadoId", e_Observaciones.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Observaciones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones.NroIpRegistro);
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

        public int Anular(ObservacionesBE e_Observaciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ObservacionesAnular", connection);
                    ParametroSP("@ObservacionesId", e_Observaciones.ObservacionesId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Observaciones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Observaciones.NroIpRegistro);
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

        public List<ObservacionesBE> Consultar_Lista()
        {
            List<ObservacionesBE> lista = new List<ObservacionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ObservacionesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ObservacionesBE(reader));
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

        public List<ObservacionesBE> Consultar_PK(
                int m_ObservacionesId)
        {
            List<ObservacionesBE> lista = new List<ObservacionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ObservacionesConsultar_PK", connection);
                    ParametroSP("@ObservacionesId", m_ObservacionesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ObservacionesBE(reader));
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
