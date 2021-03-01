using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class CargosDesempenadosDA : BaseDA
    {
        const string Nombre_Clase = "CargosDesempenadosDA";
        private string m_BaseDatos = string.Empty;

        public CargosDesempenadosDA() {  }

        public int Insertar(CargosDesempenadosBE e_CargosDesempenados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosDesempenadosInsertar", connection);
                    ParametroSP("@CargosDesempenadosId", e_CargosDesempenados.CargosDesempenadosId);
                    ParametroSP("@CargosMaestraId", e_CargosDesempenados.CargosMaestraId);
                    ParametroSP("@DatosGeneralesId", e_CargosDesempenados.DatosGeneralesId);
                    ParametroSP("@SolvenciaEconomica", e_CargosDesempenados.SolvenciaEconomica);
                    ParametroSP("@ProblemasEconomicos", e_CargosDesempenados.ProblemasEconomicos);
                    ParametroSP("@VidaDeHogar", e_CargosDesempenados.VidaDeHogar);
                    ParametroSP("@VidaDeHogarDescripcion", e_CargosDesempenados.VidaDeHogarDescripcion);
                    ParametroSP("@EstadoId", e_CargosDesempenados.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CargosDesempenados.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosDesempenados.NroIpRegistro);
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

        public int Actualizar(CargosDesempenadosBE e_CargosDesempenados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosDesempenadosActualizar", connection);
                    ParametroSP("@CargosDesempenadosId", e_CargosDesempenados.CargosDesempenadosId);
                    ParametroSP("@CargosMaestraId", e_CargosDesempenados.CargosMaestraId);
                    ParametroSP("@DatosGeneralesId", e_CargosDesempenados.DatosGeneralesId);
                    ParametroSP("@SolvenciaEconomica", e_CargosDesempenados.SolvenciaEconomica);
                    ParametroSP("@ProblemasEconomicos", e_CargosDesempenados.ProblemasEconomicos);
                    ParametroSP("@VidaDeHogar", e_CargosDesempenados.VidaDeHogar);
                    ParametroSP("@VidaDeHogarDescripcion", e_CargosDesempenados.VidaDeHogarDescripcion);
                    ParametroSP("@EstadoId", e_CargosDesempenados.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CargosDesempenados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosDesempenados.NroIpRegistro);
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

        public int Anular(CargosDesempenadosBE e_CargosDesempenados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosDesempenadosAnular", connection);
                    ParametroSP("@CargosDesempenadosId", e_CargosDesempenados.CargosDesempenadosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CargosDesempenados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CargosDesempenados.NroIpRegistro);
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

        public List<CargosDesempenadosBE> Consultar_Lista()
        {
            List<CargosDesempenadosBE> lista = new List<CargosDesempenadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosDesempenadosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CargosDesempenadosBE(reader));
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

        public List<CargosDesempenadosBE> Consultar_PK(
                int m_CargosDesempenadosId)
        {
            List<CargosDesempenadosBE> lista = new List<CargosDesempenadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CargosDesempenadosConsultar_PK", connection);
                    ParametroSP("@CargosDesempenadosId", m_CargosDesempenadosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CargosDesempenadosBE(reader));
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
                    ComandoSP("usp_CargosDesempenadosGetMaxId", connection);
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


