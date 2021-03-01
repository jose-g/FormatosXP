using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class DomiciliosDA : BaseDA
    {
        const string Nombre_Clase = "DomiciliosDA";
        private string m_BaseDatos = string.Empty;

        public DomiciliosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public DomiciliosDA() {  }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DomiciliosGetMaxId", connection);


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
        public int Insertar(DomiciliosBE e_Domicilios)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DomiciliosInsertar", connection);
                    ParametroSP("@DomicilioId", e_Domicilios.DomicilioId);
                    ParametroSP("@CargosFuncionesX1003Id", e_Domicilios.CargosFuncionesX1003Id);
                    ParametroSP("@UbigeoId", e_Domicilios.UbigeoId);
                    ParametroSP("@LugardeResidencia", e_Domicilios.LugardeResidencia);
                    ParametroSP("@Referencia", e_Domicilios.Referencia);
                    ParametroSP("@Telefono", e_Domicilios.Telefono);
                    ParametroSP("@Email", e_Domicilios.Email);
                    ParametroSP("@EstadoId", e_Domicilios.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Domicilios.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Domicilios.NroIpRegistro);
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

        public int Actualizar(DomiciliosBE e_Domicilios)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DomiciliosActualizar", connection);
                    ParametroSP("@DomicilioId", e_Domicilios.DomicilioId);
                    ParametroSP("@CargosFuncionesX1003Id", e_Domicilios.CargosFuncionesX1003Id);
                    ParametroSP("@UbigeoId", e_Domicilios.UbigeoId);
                    ParametroSP("@LugardeResidencia", e_Domicilios.LugardeResidencia);
                    ParametroSP("@Referencia", e_Domicilios.Referencia);
                    ParametroSP("@Telefono", e_Domicilios.Telefono);
                    ParametroSP("@Email", e_Domicilios.Email);
                    ParametroSP("@EstadoId", e_Domicilios.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Domicilios.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Domicilios.NroIpRegistro);
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

        public int Anular(DomiciliosBE e_Domicilios)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DomiciliosAnular", connection);
                    ParametroSP("@DomicilioId", e_Domicilios.DomicilioId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Domicilios.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Domicilios.NroIpRegistro);
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

        public List<DomiciliosBE> Consultar_Lista()
        {
            List<DomiciliosBE> lista = new List<DomiciliosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DomiciliosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DomiciliosBE(reader));
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

        public List<DomiciliosBE> Consultar_PK(
                int m_DomicilioId)
        {
            List<DomiciliosBE> lista = new List<DomiciliosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DomiciliosConsultar_PK", connection);
                    ParametroSP("@DomicilioId", m_DomicilioId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DomiciliosBE(reader));
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
        public List<DomiciliosBE> Consultar_FK(int m_Fk_Id)
        {
            List<DomiciliosBE> lista = new List<DomiciliosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DomiciliosConsultar_FK", connection);
                    ParametroSP("@CargosFuncionesX1003Id", m_Fk_Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DomiciliosBE(reader));
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
