using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class SistemasDA : BaseDA
    {
        const string Nombre_Clase = "SistemasDA";
        private string m_BaseDatos = string.Empty;

        public SistemasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public SistemasDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(SistemasBE e_Sistemas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SistemasInsertar", connection);
                    ParametroSP("@SistemaId", e_Sistemas.SistemaId);
                    ParametroSP("@SistemaKey", e_Sistemas.SistemaKey);
                    ParametroSP("@Nombre", e_Sistemas.Nombre);
                    ParametroSP("@Abreviatura", e_Sistemas.Abreviatura);
                    ParametroSP("@Tipo", e_Sistemas.Tipo);
                    ParametroSP("@Descripcion", e_Sistemas.Descripcion);
                    ParametroSP("@Path", e_Sistemas.Path);
                    ParametroSP("@Icon", e_Sistemas.Icon);
                    ParametroSP("@EstadoId", e_Sistemas.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Sistemas.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Sistemas.NroIpRegistro);
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

        public int Actualizar(SistemasBE e_Sistemas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SistemasActualizar", connection);
                    ParametroSP("@SistemaId", e_Sistemas.SistemaId);
                    ParametroSP("@SistemaKey", e_Sistemas.SistemaKey);
                    ParametroSP("@Nombre", e_Sistemas.Nombre);
                    ParametroSP("@Abreviatura", e_Sistemas.Abreviatura);
                    ParametroSP("@Tipo", e_Sistemas.Tipo);
                    ParametroSP("@Descripcion", e_Sistemas.Descripcion);
                    ParametroSP("@Path", e_Sistemas.Path);
                    ParametroSP("@Icon", e_Sistemas.Icon);
                    ParametroSP("@EstadoId", e_Sistemas.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Sistemas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Sistemas.NroIpRegistro);
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

        public int Anular(SistemasBE e_Sistemas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SistemasAnular", connection);
                    ParametroSP("@SistemaId", e_Sistemas.SistemaId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Sistemas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Sistemas.NroIpRegistro);
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

        public List<SistemasBE> Consultar_Lista()
        {
            List<SistemasBE> lista = new List<SistemasBE>();
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_SistemasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SistemasBE(reader));
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

        public List<SistemasBE> Consultar_PK(int m_SistemaId)
        {
            List<SistemasBE> lista = new List<SistemasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_SistemasConsultar_PK", connection);
                    ParametroSP("@SistemaId", m_SistemaId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new SistemasBE(reader));
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


        public List<SistemasBE> Listar_grilla(SistemasBE ent)
        {
            List<SistemasBE> lst = new List<SistemasBE>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_SISTEMAConsultar_Lista", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla");
                    ParametroSP("@NOMBRE", ent.Nombre);
                    ParametroSP("@SISTEMA_ID", ent.SistemaId);
                    ParametroSP("@KEY_SISTEMA", ent.SistemaKey);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new SistemasBE(reader));
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

            return lst;
        }

    }
}
