using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class DelitosGenericosDA : BaseDA
    {
        const string Nombre_Clase = "DelitosGenericosDA";
        private string m_BaseDatos = string.Empty;

        public DelitosGenericosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(DelitosGenericosBE e_DelitosGenericos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DelitosGenericosInsertar", connection);
                    ParametroSP("@DelitoGenericoId", e_DelitosGenericos.DelitoGenericoId);
                    ParametroSP("@Nombre", e_DelitosGenericos.Nombre);
                    ParametroSP("@Descripcion", e_DelitosGenericos.Descripcion);
                    ParametroSP("@EstadoId", e_DelitosGenericos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_DelitosGenericos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DelitosGenericos.NroIpRegistro);
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

        public int Actualizar(DelitosGenericosBE e_DelitosGenericos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DelitosGenericosActualizar", connection);
                    ParametroSP("@DelitoGenericoId", e_DelitosGenericos.DelitoGenericoId);
                    ParametroSP("@Nombre", e_DelitosGenericos.Nombre);
                    ParametroSP("@Descripcion", e_DelitosGenericos.Descripcion);
                    ParametroSP("@EstadoId", e_DelitosGenericos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DelitosGenericos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DelitosGenericos.NroIpRegistro);
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

        public int Anular(DelitosGenericosBE e_DelitosGenericos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DelitosGenericosAnular", connection);
                    ParametroSP("@DelitoGenericoId", e_DelitosGenericos.DelitoGenericoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DelitosGenericos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DelitosGenericos.NroIpRegistro);
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

        public List<DelitosGenericosBE> Consultar_Lista()
        {
            List<DelitosGenericosBE> lista = new List<DelitosGenericosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DelitosGenericosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DelitosGenericosBE(reader));
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

        public List<DelitosGenericosBE> Consultar_PK(
                int m_DelitoGenericoId)
        {
            List<DelitosGenericosBE> lista = new List<DelitosGenericosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DelitosGenericosConsultar_PK", connection);
                    ParametroSP("@DelitoGenericoId", m_DelitoGenericoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DelitosGenericosBE(reader));
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
