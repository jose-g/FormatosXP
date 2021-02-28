using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class IngresosAnterioresAlPaisDA : BaseDA
    {
        const string Nombre_Clase = "IngresosAnterioresAlPaisDA";
        private string m_BaseDatos = string.Empty;
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_IngresosAnterioresGetMaxId", connection);


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
        public IngresosAnterioresAlPaisDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public IngresosAnterioresAlPaisDA() { }

        public int Insertar(IngresosAnterioresAlPaisBE e_IngresosAnterioresAlPais)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAnterioresAlPaisInsertar", connection);
                    ParametroSP("@IngresosAnterioresAlPaisID", e_IngresosAnterioresAlPais.IngresosAnterioresAlPaisID);
                    ParametroSP("@CargosFuncionesX1003Id", e_IngresosAnterioresAlPais.CargosFuncionesX1003Id);
                    ParametroSP("@FechaIngreso", e_IngresosAnterioresAlPais.FechaIngreso);
                    ParametroSP("@FechaSalid", e_IngresosAnterioresAlPais.FechaSalid);
                    ParametroSP("@UbigeoId", e_IngresosAnterioresAlPais.UbigeoId);
                    ParametroSP("@Motivo", e_IngresosAnterioresAlPais.Motivo);
                    ParametroSP("@DondeResidio", e_IngresosAnterioresAlPais.DondeResidio);
                    ParametroSP("@Destino", e_IngresosAnterioresAlPais.Destino);
                    ParametroSP("@EstadoId", e_IngresosAnterioresAlPais.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_IngresosAnterioresAlPais.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_IngresosAnterioresAlPais.NroIpRegistro);
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

        public int Actualizar(IngresosAnterioresAlPaisBE e_IngresosAnterioresAlPais)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAnterioresAlPaisActualizar", connection);
                    ParametroSP("@IngresosAnterioresAlPaisID", e_IngresosAnterioresAlPais.IngresosAnterioresAlPaisID);
                    ParametroSP("@CargosFuncionesX1003Id", e_IngresosAnterioresAlPais.CargosFuncionesX1003Id);
                    ParametroSP("@FechaIngreso", e_IngresosAnterioresAlPais.FechaIngreso);
                    ParametroSP("@FechaSalid", e_IngresosAnterioresAlPais.FechaSalid);
                    ParametroSP("@UbigeoId", e_IngresosAnterioresAlPais.UbigeoId);
                    ParametroSP("@Motivo", e_IngresosAnterioresAlPais.Motivo);
                    ParametroSP("@DondeResidio", e_IngresosAnterioresAlPais.DondeResidio);
                    ParametroSP("@Destino", e_IngresosAnterioresAlPais.Destino);
                    ParametroSP("@EstadoId", e_IngresosAnterioresAlPais.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_IngresosAnterioresAlPais.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_IngresosAnterioresAlPais.NroIpRegistro);
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

        public int Anular(IngresosAnterioresAlPaisBE e_IngresosAnterioresAlPais)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAnterioresAlPaisAnular", connection);
                    ParametroSP("@IngresosAnterioresAlPaisID", e_IngresosAnterioresAlPais.IngresosAnterioresAlPaisID);
                    ParametroSP("@UsuarioModificacionRegistro", e_IngresosAnterioresAlPais.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_IngresosAnterioresAlPais.NroIpRegistro);
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

        public List<IngresosAnterioresAlPaisBE> Consultar_Lista()
        {
            List<IngresosAnterioresAlPaisBE> lista = new List<IngresosAnterioresAlPaisBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAnterioresAlPaisConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IngresosAnterioresAlPaisBE(reader));
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

        public List<IngresosAnterioresAlPaisBE> Consultar_PK(
                int m_IngresosAnterioresAlPaisID)
        {
            List<IngresosAnterioresAlPaisBE> lista = new List<IngresosAnterioresAlPaisBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAnterioresAlPaisConsultar_PK", connection);
                    ParametroSP("@IngresosAnterioresAlPaisID", m_IngresosAnterioresAlPaisID);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IngresosAnterioresAlPaisBE(reader));
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
