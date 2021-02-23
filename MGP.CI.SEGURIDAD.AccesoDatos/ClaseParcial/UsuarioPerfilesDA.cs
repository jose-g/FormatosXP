using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class UsuarioPerfilesDA : BaseDA
    {
        const string Nombre_Clase = "UsuarioPerfilesDA";
        private string m_BaseDatos = string.Empty;

        public UsuarioPerfilesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public UsuarioPerfilesDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(UsuarioPerfilesBE e_UsuarioPerfiles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioPerfilesInsertar", connection);
                    ParametroSP("@UsuarioId", e_UsuarioPerfiles.UsuarioId);
                    ParametroSP("@PerfilId", e_UsuarioPerfiles.PerfilId);
                    ParametroSP("@EstadoId", e_UsuarioPerfiles.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_UsuarioPerfiles.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_UsuarioPerfiles.NroIpRegistro);
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

        public int Actualizar(UsuarioPerfilesBE e_UsuarioPerfiles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioPerfilesActualizar", connection);
                    ParametroSP("@UsuarioPerfilId", e_UsuarioPerfiles.UsuarioPerfilId);
                    ParametroSP("@UsuarioId", e_UsuarioPerfiles.UsuarioId);
                    ParametroSP("@PerfilId", e_UsuarioPerfiles.PerfilId);
                    ParametroSP("@EstadoId", e_UsuarioPerfiles.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_UsuarioPerfiles.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_UsuarioPerfiles.NroIpRegistro);
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

        public int Anular(UsuarioPerfilesBE e_UsuarioPerfiles)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioPerfilesAnular", connection);
                    ParametroSP("@UsuarioPerfilId", e_UsuarioPerfiles.UsuarioPerfilId);
                    ParametroSP("@UsuarioModificacionRegistro", e_UsuarioPerfiles.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_UsuarioPerfiles.NroIpRegistro);
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

        public List<UsuarioPerfilesBE> Consultar_Lista()
        {
            List<UsuarioPerfilesBE> lista = new List<UsuarioPerfilesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioPerfilesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuarioPerfilesBE(reader));
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

        public List<UsuarioPerfilesBE> Consultar_PK( int m_UsuarioPerfilId)
        {
            List<UsuarioPerfilesBE> lista = new List<UsuarioPerfilesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_UsuarioPerfilesConsultar_PK", connection);
                    ParametroSP("@UsuarioPerfilId", m_UsuarioPerfilId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuarioPerfilesBE(reader));
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

        public int CambiarEstadoRegistro(int idUsuarioPerfil, int estadoId)
        {
            UsuarioPerfilesBE e_USUARIO_PERFIL = new UsuarioPerfilesBE();
            e_USUARIO_PERFIL.UsuarioPerfilId = idUsuarioPerfil;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UsuariosPerfilesCambiarEstadoRegistro", connection);
                    ParametroSP("@UsuarioPerfileId", idUsuarioPerfil);
                    ParametroSP("@EstadoId", estadoId);

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

        //public List<UsuarioPerfilesBE> Listar_grilla(UsuarioPerfilesBE ent)
        //{
        //    List<UsuarioPerfilesBE> lst = new List<UsuarioPerfilesBE>();

        //    using (SqlConnection connection = Conectar())
        //    {
        //        try
        //        {
        //            ComandoSP("usp_USUARIO_PERFILConsultar_Lista", connection);
        //            ParametroSP("@accion", "lst");
        //            ParametroSP("@opcion", "lst_grilla");

        //            ParametroSP("@USUARIO_PERFIL_ID", ent.UsuarioPerfilId);
        //            ParametroSP("@PERFIL_ID", ent.PerfilId);
        //            ParametroSP("@USUARIO_ID", ent.UsuarioId);
        //            ParametroSP("@ESTADO_ID", ent.EstadoId);

        //            using (SqlDataReader reader = comando.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    lst.Add(new UsuarioPerfilesBE(reader));
        //                }
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw new Exception("Clase DataAccess: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Dispose();
        //        }
        //    }

        //    return lst;
        //}

    }
}
