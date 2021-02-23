using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class TiposUsuariosDA : BaseDA
    {
        const string Nombre_Clase = "TiposUsuariosDA";
        private string m_BaseDatos = string.Empty;

        public TiposUsuariosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public int Insertar(TiposUsuariosBE e_TiposUsuarios)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_TiposUsuariosInsertar", connection);
                    ParametroSP("@DescCorta", e_TiposUsuarios.DescCorta);
                    ParametroSP("@DescLarga", e_TiposUsuarios.DescLarga);
                    ParametroSP("@EstadoId", e_TiposUsuarios.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_TiposUsuarios.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_TiposUsuarios.NroIpRegistro);
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
        public int Actualizar(TiposUsuariosBE e_TiposUsuarios)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_TiposUsuariosActualizar", connection);
                    ParametroSP("@TipoUsuarioId", e_TiposUsuarios.TipoUsuarioId);
                    ParametroSP("@DescCorta", e_TiposUsuarios.DescCorta);
                    ParametroSP("@DescLarga", e_TiposUsuarios.DescLarga);
                    ParametroSP("@EstadoId", e_TiposUsuarios.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_TiposUsuarios.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_TiposUsuarios.NroIpRegistro);
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
        public int Anular(TiposUsuariosBE e_TiposUsuarios)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_TiposUsuariosAnular", connection);
                    ParametroSP("@TipoUsuarioId", e_TiposUsuarios.TipoUsuarioId);
                    ParametroSP("@UsuarioModificacionRegistro", e_TiposUsuarios.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_TiposUsuarios.NroIpRegistro);
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
        public List<TiposUsuariosBE> Consultar_Lista()
        {
            List<TiposUsuariosBE> lista = new List<TiposUsuariosBE>();
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_TiposUsuariosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new TiposUsuariosBE(reader));
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
        public List<TiposUsuariosBE> Consultar_PK(int m_TipoUsuarioId)
        {
            List<TiposUsuariosBE> lista = new List<TiposUsuariosBE>();
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_TiposUsuariosConsultar_PK", connection);
                    ParametroSP("@TipoUsuarioId", m_TipoUsuarioId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new TiposUsuariosBE(reader));
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
                    ComandoSP("usp_TipoUsuariosGetMaxId", connection);


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
        public int CambiarEstado(TiposUsuariosBE e_documentoIdentidadTiposBE)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_TipoUsuarioCambiarEstado", connection);
                    ParametroSP("@TipoUsuarioId", e_documentoIdentidadTiposBE.TipoUsuarioId);
                    ParametroSP("@UsuarioModificacionRegistro", e_documentoIdentidadTiposBE.UsuarioModificacionRegistro);
                    ParametroSP("@EstadoId", e_documentoIdentidadTiposBE.EstadoId);
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
        public List<TiposUsuariosBE> ListarRegistrosFiltrados(TiposUsuariosBE ent)
        {
            List<TiposUsuariosBE> lst = new List<TiposUsuariosBE>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_TipoUsuariosConsultarRegistrosFiltrados", connection);
                    ParametroSP("@DescCorta", ent.DescCorta);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new TiposUsuariosBE(reader));
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
