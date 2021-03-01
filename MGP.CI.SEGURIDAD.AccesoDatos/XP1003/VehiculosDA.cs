using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class VehiculosDA : BaseDA
    {
        const string Nombre_Clase = "VehiculosDA";
        private string m_BaseDatos = string.Empty;

        public VehiculosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_VehiculosGetMaxId", connection);


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
        public int Insertar(VehiculosBE e_Vehiculos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculosInsertar", connection);
                    ParametroSP("@VehiculoId", e_Vehiculos.VehiculoId);
                    ParametroSP("@VehiculoTipoId", e_Vehiculos.VehiculoTipoId);
                    ParametroSP("@AutoModeloId", e_Vehiculos.AutoModeloId);
                    ParametroSP("@Placa", e_Vehiculos.Placa);
                    ParametroSP("@AutoMarcaId", e_Vehiculos.AutoMarcaId);
                    ParametroSP("@CargosFuncionesX1003Id", e_Vehiculos.CargosFuncionesX1003Id);
                    ParametroSP("@EstadoId", e_Vehiculos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Vehiculos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Vehiculos.NroIpRegistro);
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

        public int Actualizar(VehiculosBE e_Vehiculos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculosActualizar", connection);
                    ParametroSP("@VehiculoId", e_Vehiculos.VehiculoId);
                    ParametroSP("@VehiculoTipoId", e_Vehiculos.VehiculoTipoId);
                    ParametroSP("@AutoModeloId", e_Vehiculos.AutoModeloId);
                    ParametroSP("@Placa", e_Vehiculos.Placa);
                    ParametroSP("@AutoMarcaId", e_Vehiculos.AutoMarcaId);
                    ParametroSP("@CargosFuncionesX1003Id", e_Vehiculos.CargosFuncionesX1003Id);
                    ParametroSP("@EstadoId", e_Vehiculos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Vehiculos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Vehiculos.NroIpRegistro);
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

        public int Anular(VehiculosBE e_Vehiculos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculosAnular", connection);
                    ParametroSP("@VehiculoId", e_Vehiculos.VehiculoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Vehiculos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Vehiculos.NroIpRegistro);
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

        public List<VehiculosBE> Consultar_Lista()
        {
            List<VehiculosBE> lista = new List<VehiculosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new VehiculosBE(reader));
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

        public List<VehiculosBE> Consultar_PK(int m_VehiculoId)
        {
            List<VehiculosBE> lista = new List<VehiculosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculosConsultar_PK", connection);
                    ParametroSP("@VehiculoId", m_VehiculoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new VehiculosBE(reader));
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
        public List<VehiculosBE> Consultar_FK(int m_Fk_Id)
        {
            List<VehiculosBE> lista = new List<VehiculosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_VehiculosConsultar_FK", connection);
                    ParametroSP("@CargosFuncionesX1003Id", m_Fk_Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new VehiculosBE(reader));
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
