using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class CentrosMedicosDA : BaseDA
    {
        const string Nombre_Clase = "CentrosMedicosDA";
        private string m_BaseDatos = string.Empty;

        public CentrosMedicosDA() {  }

        public int Insertar(CentrosMedicosBE e_CentrosMedicos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CentrosMedicosInsertar", connection);
                    ParametroSP("@CentrosMedicosId", e_CentrosMedicos.CentrosMedicosId);
                    ParametroSP("@SectorCentroMedico", e_CentrosMedicos.SectorCentroMedico);
                    ParametroSP("@NombreCentroMedico", e_CentrosMedicos.NombreCentroMedico);
                    ParametroSP("@Direccion", e_CentrosMedicos.Direccion);
                    ParametroSP("@EstadoId", e_CentrosMedicos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CentrosMedicos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CentrosMedicos.NroIpRegistro);
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

        public int Actualizar(CentrosMedicosBE e_CentrosMedicos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CentrosMedicosActualizar", connection);
                    ParametroSP("@CentrosMedicosId", e_CentrosMedicos.CentrosMedicosId);
                    ParametroSP("@SectorCentroMedico", e_CentrosMedicos.SectorCentroMedico);
                    ParametroSP("@NombreCentroMedico", e_CentrosMedicos.NombreCentroMedico);
                    ParametroSP("@Direccion", e_CentrosMedicos.Direccion);
                    ParametroSP("@EstadoId", e_CentrosMedicos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CentrosMedicos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CentrosMedicos.NroIpRegistro);
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

        public int Anular(CentrosMedicosBE e_CentrosMedicos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CentrosMedicosAnular", connection);
                    ParametroSP("@CentrosMedicosId", e_CentrosMedicos.CentrosMedicosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CentrosMedicos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CentrosMedicos.NroIpRegistro);
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

        public List<CentrosMedicosBE> Consultar_Lista()
        {
            List<CentrosMedicosBE> lista = new List<CentrosMedicosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CentrosMedicosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CentrosMedicosBE(reader));
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

        public List<CentrosMedicosBE> Consultar_PK(
                int m_CentrosMedicosId)
        {
            List<CentrosMedicosBE> lista = new List<CentrosMedicosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CentrosMedicosConsultar_PK", connection);
                    ParametroSP("@CentrosMedicosId", m_CentrosMedicosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CentrosMedicosBE(reader));
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
                    ComandoSP("usp_CentrosMedicosGetMaxId", connection);
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


