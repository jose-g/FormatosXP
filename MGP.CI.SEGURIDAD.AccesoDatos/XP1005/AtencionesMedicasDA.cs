using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class AtencionesMedicasDA : BaseDA
    {
        const string Nombre_Clase = "AtencionesMedicasDA";
        private string m_BaseDatos = string.Empty;

        public AtencionesMedicasDA() {  }

        public int Insertar(AtencionesMedicasBE e_AtencionesMedicas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AtencionesMedicasInsertar", connection);
                    ParametroSP("@AtencionesMedicasId", e_AtencionesMedicas.AtencionesMedicasId);
                    ParametroSP("@ActividadesIntoPais1005Id", e_AtencionesMedicas.ActividadesIntoPais1005Id);
                    ParametroSP("@CentrosMedicosId", e_AtencionesMedicas.CentrosMedicosId);
                    ParametroSP("@Motivo", e_AtencionesMedicas.Motivo);
                    ParametroSP("@Fecha", e_AtencionesMedicas.Fecha);
                    ParametroSP("@EstadoId", e_AtencionesMedicas.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_AtencionesMedicas.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_AtencionesMedicas.NroIpRegistro);
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

        public int Actualizar(AtencionesMedicasBE e_AtencionesMedicas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AtencionesMedicasActualizar", connection);
                    ParametroSP("@AtencionesMedicasId", e_AtencionesMedicas.AtencionesMedicasId);
                    ParametroSP("@ActividadesIntoPais1005Id", e_AtencionesMedicas.ActividadesIntoPais1005Id);
                    ParametroSP("@CentrosMedicosId", e_AtencionesMedicas.CentrosMedicosId);
                    ParametroSP("@Motivo", e_AtencionesMedicas.Motivo);
                    ParametroSP("@Fecha", e_AtencionesMedicas.Fecha);
                    ParametroSP("@EstadoId", e_AtencionesMedicas.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_AtencionesMedicas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_AtencionesMedicas.NroIpRegistro);
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

        public int Anular(AtencionesMedicasBE e_AtencionesMedicas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AtencionesMedicasAnular", connection);
                    ParametroSP("@AtencionesMedicasId", e_AtencionesMedicas.AtencionesMedicasId);
                    ParametroSP("@UsuarioModificacionRegistro", e_AtencionesMedicas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_AtencionesMedicas.NroIpRegistro);
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

        public List<AtencionesMedicasBE> Consultar_Lista()
        {
            List<AtencionesMedicasBE> lista = new List<AtencionesMedicasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AtencionesMedicasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AtencionesMedicasBE(reader));
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

        public List<AtencionesMedicasBE> Consultar_PK(
                int m_AtencionesMedicasId)
        {
            List<AtencionesMedicasBE> lista = new List<AtencionesMedicasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AtencionesMedicasConsultar_PK", connection);
                    ParametroSP("@AtencionesMedicasId", m_AtencionesMedicasId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AtencionesMedicasBE(reader));
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
                    ComandoSP("usp_AtencionesMedicasGetMaxId", connection);
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


