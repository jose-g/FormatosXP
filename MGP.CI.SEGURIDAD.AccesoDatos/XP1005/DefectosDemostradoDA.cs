using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class DefectosDemostradoDA : BaseDA
    {
        const string Nombre_Clase = "DefectosDemostradoDA";
        private string m_BaseDatos = string.Empty;

        public DefectosDemostradoDA() {  }

        public int Insertar(DefectosDemostradoBE e_DefectosDemostrado)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DefectosDemostradoInsertar", connection);
                    ParametroSP("@DefectosDemostradoId", e_DefectosDemostrado.DefectosDemostradoId);
                    ParametroSP("@DatosGeneralesId", e_DefectosDemostrado.DatosGeneralesId);
                    ParametroSP("@DefectosMaestraId", e_DefectosDemostrado.DefectosMaestraId);
                    ParametroSP("@EstadoId", e_DefectosDemostrado.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_DefectosDemostrado.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DefectosDemostrado.NroIpRegistro);
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

        public int Actualizar(DefectosDemostradoBE e_DefectosDemostrado)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DefectosDemostradoActualizar", connection);
                    ParametroSP("@DefectosDemostradoId", e_DefectosDemostrado.DefectosDemostradoId);
                    ParametroSP("@DatosGeneralesId", e_DefectosDemostrado.DatosGeneralesId);
                    ParametroSP("@DefectosMaestraId", e_DefectosDemostrado.DefectosMaestraId);
                    ParametroSP("@EstadoId", e_DefectosDemostrado.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DefectosDemostrado.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DefectosDemostrado.NroIpRegistro);
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

        public int Anular(DefectosDemostradoBE e_DefectosDemostrado)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DefectosDemostradoAnular", connection);
                    ParametroSP("@DefectosDemostradoId", e_DefectosDemostrado.DefectosDemostradoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DefectosDemostrado.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DefectosDemostrado.NroIpRegistro);
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

        public List<DefectosDemostradoBE> Consultar_Lista()
        {
            List<DefectosDemostradoBE> lista = new List<DefectosDemostradoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DefectosDemostradoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DefectosDemostradoBE(reader));
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

        public List<DefectosDemostradoBE> Consultar_PK(
                int m_DefectosDemostradoId)
        {
            List<DefectosDemostradoBE> lista = new List<DefectosDemostradoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DefectosDemostradoConsultar_PK", connection);
                    ParametroSP("@DefectosDemostradoId", m_DefectosDemostradoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DefectosDemostradoBE(reader));
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
                    ComandoSP("usp_DefectosDemostradoGetMaxId", connection);
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


