using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class IngresosAlPaisDA : BaseDA
    {
        const string Nombre_Clase = "IngresosAlPaisDA";
        private string m_BaseDatos = string.Empty;

        public IngresosAlPaisDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public IngresosAlPaisDA( ) {    }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_IngresosAlPaisGetMaxId", connection);


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
        public int Insertar(IngresosAlPaisBE e_IngresosAlPais)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAlPaisInsertar", connection);
                    ParametroSP("@IngresoPaisId", e_IngresosAlPais.IngresoPaisId);
                    ParametroSP("@FechaIngreso", e_IngresosAlPais.FechaIngreso);
                    ParametroSP("@FechaInicioMision", e_IngresosAlPais.FechaInicioMision);
                    ParametroSP("@FechaTerminoMision", e_IngresosAlPais.FechaTerminoMision);
                    ParametroSP("@CargosFuncionesX1003Id", e_IngresosAlPais.CargosFuncionesX1003Id);
                    ParametroSP("@EstadoId", e_IngresosAlPais.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_IngresosAlPais.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_IngresosAlPais.NroIpRegistro);
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

        public int Actualizar(IngresosAlPaisBE e_IngresosAlPais)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAlPaisActualizar", connection);
                    ParametroSP("@IngresoPaisId", e_IngresosAlPais.IngresoPaisId);
                    ParametroSP("@FechaIngreso", e_IngresosAlPais.FechaIngreso);
                    ParametroSP("@FechaInicioMision", e_IngresosAlPais.FechaInicioMision);
                    ParametroSP("@FechaTerminoMision", e_IngresosAlPais.FechaTerminoMision);
                    ParametroSP("@CargosFuncionesX1003Id", e_IngresosAlPais.CargosFuncionesX1003Id);
                    ParametroSP("@EstadoId", e_IngresosAlPais.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_IngresosAlPais.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_IngresosAlPais.NroIpRegistro);
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

        public int Anular(IngresosAlPaisBE e_IngresosAlPais)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAlPaisAnular", connection);
                    ParametroSP("@IngresoPaisId", e_IngresosAlPais.IngresoPaisId);
                    ParametroSP("@UsuarioModificacionRegistro", e_IngresosAlPais.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_IngresosAlPais.NroIpRegistro);
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

        public List<IngresosAlPaisBE> Consultar_Lista()
        {
            List<IngresosAlPaisBE> lista = new List<IngresosAlPaisBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAlPaisConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IngresosAlPaisBE(reader));
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

        public List<IngresosAlPaisBE> Consultar_PK(int m_IngresoPaisId)
        {
            List<IngresosAlPaisBE> lista = new List<IngresosAlPaisBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAlPaisConsultar_PK", connection);
                    ParametroSP("@IngresoPaisId", m_IngresoPaisId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IngresosAlPaisBE(reader));
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
        public List<IngresosAlPaisBE> Consultar_FK(int m_Fk_Id)
        {
            List<IngresosAlPaisBE> lista = new List<IngresosAlPaisBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IngresosAlPaisConsultar_FK", connection);
                    ParametroSP("@CargosFuncionesX1003Id", m_Fk_Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IngresosAlPaisBE(reader));
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
