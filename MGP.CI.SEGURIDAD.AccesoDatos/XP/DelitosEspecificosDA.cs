using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class DelitosEspecificosDA : BaseDA
    {
        const string Nombre_Clase = "DelitosEspecificosDA";
        private string m_BaseDatos = string.Empty;

        public DelitosEspecificosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(DelitosEspecificosBE e_DelitosEspecificos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DelitosEspecificosInsertar", connection);
                    ParametroSP("@DelitoEspecificoId", e_DelitosEspecificos.DelitoEspecificoId);
                    ParametroSP("@DelitoGenericoId", e_DelitosEspecificos.DelitoGenericoId);
                    ParametroSP("@Nombre", e_DelitosEspecificos.Nombre);
                    ParametroSP("@Descripcion", e_DelitosEspecificos.Descripcion);
                    ParametroSP("@EstadoId", e_DelitosEspecificos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_DelitosEspecificos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DelitosEspecificos.NroIpRegistro);
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

        public int Actualizar(DelitosEspecificosBE e_DelitosEspecificos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DelitosEspecificosActualizar", connection);
                    ParametroSP("@DelitoEspecificoId", e_DelitosEspecificos.DelitoEspecificoId);
                    ParametroSP("@DelitoGenericoId", e_DelitosEspecificos.DelitoGenericoId);
                    ParametroSP("@Nombre", e_DelitosEspecificos.Nombre);
                    ParametroSP("@Descripcion", e_DelitosEspecificos.Descripcion);
                    ParametroSP("@EstadoId", e_DelitosEspecificos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DelitosEspecificos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DelitosEspecificos.NroIpRegistro);
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

        public int Anular(DelitosEspecificosBE e_DelitosEspecificos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DelitosEspecificosAnular", connection);
                    ParametroSP("@DelitoEspecificoId", e_DelitosEspecificos.DelitoEspecificoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DelitosEspecificos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DelitosEspecificos.NroIpRegistro);
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

        public List<DelitosEspecificosBE> Consultar_Lista()
        {
            List<DelitosEspecificosBE> lista = new List<DelitosEspecificosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DelitosEspecificosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DelitosEspecificosBE(reader));
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

        public List<DelitosEspecificosBE> Consultar_PK(
                string m_DelitoEspecificoId)
        {
            List<DelitosEspecificosBE> lista = new List<DelitosEspecificosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DelitosEspecificosConsultar_PK", connection);
                    ParametroSP("@DelitoEspecificoId", m_DelitoEspecificoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DelitosEspecificosBE(reader));
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
