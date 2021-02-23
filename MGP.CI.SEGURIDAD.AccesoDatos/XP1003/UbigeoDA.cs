using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class UbigeoDA : BaseDA
    {
        const string Nombre_Clase = "UbigeoDA";
        private string m_BaseDatos = string.Empty;

        public UbigeoDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public UbigeoDA() { }


        public int Insertar(UbigeoBE e_Ubigeo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UbigeoInsertar", connection);
                    ParametroSP("@UbigeoId", e_Ubigeo.UbigeoId);
                    ParametroSP("@UbigeoCodigo", e_Ubigeo.UbigeoCodigo);
                    ParametroSP("@Departamento", e_Ubigeo.Departamento);
                    ParametroSP("@Provincia", e_Ubigeo.Provincia);
                    ParametroSP("@Distrito", e_Ubigeo.Distrito);
                    ParametroSP("@EstadoId", e_Ubigeo.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Ubigeo.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Ubigeo.NroIpRegistro);
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

        public int Actualizar(UbigeoBE e_Ubigeo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UbigeoActualizar", connection);
                    ParametroSP("@UbigeoId", e_Ubigeo.UbigeoId);
                    ParametroSP("@UbigeoCodigo", e_Ubigeo.UbigeoCodigo);
                    ParametroSP("@Departamento", e_Ubigeo.Departamento);
                    ParametroSP("@Provincia", e_Ubigeo.Provincia);
                    ParametroSP("@Distrito", e_Ubigeo.Distrito);
                    ParametroSP("@EstadoId", e_Ubigeo.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Ubigeo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Ubigeo.NroIpRegistro);
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

        public int Anular(UbigeoBE e_Ubigeo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UbigeoAnular", connection);
                    ParametroSP("@UbigeoId", e_Ubigeo.UbigeoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Ubigeo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Ubigeo.NroIpRegistro);
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

        public List<UbigeoBE> Consultar_Lista()
        {
            List<UbigeoBE> lista = new List<UbigeoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UbigeoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UbigeoBE(reader));
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

        public List<UbigeoBE> Consultar_PK(
                int m_UbigeoId)
        {
            List<UbigeoBE> lista = new List<UbigeoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UbigeoConsultar_PK", connection);
                    ParametroSP("@UbigeoId", m_UbigeoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UbigeoBE(reader));
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
