using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class PermisoPerfilModulosDA : BaseDA
    {
        const string Nombre_Clase = "PermisoPerfilModulosDA";
        private string m_BaseDatos = string.Empty;

        public PermisoPerfilModulosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public PermisoPerfilModulosDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(PermisoPerfilModulosBE e_PermisoPerfilModulos)
        {
            int id = -1;

            using (SqlConnection connection = Conectar(m_BaseDatos))
            {

                try
                {
                    ComandoSP("usp_PermisoPerfilModulosInsertar", connection);
                    //ParametroSP("@PermisoPerfilModuloId", e_PermisoPerfilModulos.PermisoPerfilModuloId);
                    ParametroSP("@PerfilModuloId", e_PermisoPerfilModulos.PerfilModuloId);
                    //ParametroSP("@UsuarioId", e_PermisoPerfilModulos.UsuarioId);
                    ParametroSP("@PermisoId", e_PermisoPerfilModulos.PermisoId);
                    //ParametroSP("@EstadoId", e_PermisoPerfilModulos.EstadoId);
                    //ParametroSP("@UsuarioModuloId", e_PermisoPerfilModulos.UsuarioModuloId);
                    //ParametroSP("@ModuloId", e_PermisoPerfilModulos.ModuloId);
                    ParametroSP("@UsuarioRegistro", e_PermisoPerfilModulos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_PermisoPerfilModulos.NroIpRegistro);
                    //comando.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    return comando.ExecuteNonQuery();

                    id = int.Parse(comando.Parameters["@id"].Value.ToString());

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
            return id;

        }

        public int Actualizar(PermisoPerfilModulosBE e_PermisoPerfilModulos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PermisoPerfilModulosActualizar", connection);
                    ParametroSP("@PermisoPerfilModuloId", e_PermisoPerfilModulos.PermisoPerfilModuloId);
                    ParametroSP("@PerfilModuloId", e_PermisoPerfilModulos.PerfilModuloId);
                    ParametroSP("@UsuarioId", e_PermisoPerfilModulos.UsuarioId);
                    ParametroSP("@PermisoId", e_PermisoPerfilModulos.PermisoId);
                    ParametroSP("@EstadoId", e_PermisoPerfilModulos.EstadoId);
                    ParametroSP("@UsuarioModuloId", e_PermisoPerfilModulos.UsuarioModuloId);
                    ParametroSP("@ModuloId", e_PermisoPerfilModulos.ModuloId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PermisoPerfilModulos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PermisoPerfilModulos.NroIpRegistro);
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

        public int Anular(PermisoPerfilModulosBE e_PermisoPerfilModulos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PermisoPerfilModulosAnular", connection);
                    ParametroSP("@PermisoPerfilModuloId", e_PermisoPerfilModulos.PermisoPerfilModuloId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PermisoPerfilModulos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PermisoPerfilModulos.NroIpRegistro);
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

        public List<PermisoPerfilModulosBE> Consultar_Lista()
        {
            List<PermisoPerfilModulosBE> lista = new List<PermisoPerfilModulosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PermisoPerfilModulosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PermisoPerfilModulosBE(reader));
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

        public List<PermisoPerfilModulosBE> Consultar_PK(int m_PermisoPerfilModuloId)
        {
            List<PermisoPerfilModulosBE> lista = new List<PermisoPerfilModulosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PermisoPerfilModulosConsultar_PK", connection);
                    ParametroSP("@PermisoPerfilModuloId", m_PermisoPerfilModuloId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PermisoPerfilModulosBE(reader));
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

        public int CambiarEstado(PermisoPerfilModulosBE m_PermisoPerfilModulos)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_PERMISO_PERFIL_MODULOActualizar", connection);
                    ParametroSP("@accion", "");
                    ParametroSP("@opcion", "upd_cambio_estado");
                    ParametroSP("@PERMISO_PERFIL_MODULO_ID", m_PermisoPerfilModulos.PermisoPerfilModuloId);
                    ParametroSP("@PERMISO_ID", m_PermisoPerfilModulos.PermisoId);
                    ParametroSP("@ESTADO_ID", m_PermisoPerfilModulos.EstadoId);
                    ParametroSP("@USUARIO_CREA", m_PermisoPerfilModulos.UsuarioRegistro);
                    ParametroSP("@USUARIO_MOD", m_PermisoPerfilModulos.UsuarioModificacionRegistro);
                    ParametroSP("@FECHA_CREA", m_PermisoPerfilModulos.FechaRegistro);
                    ParametroSP("@FECHA_MOD", m_PermisoPerfilModulos.FechaModificacionRegistro);
                    ParametroSP("@USUARIO_MODULO_ID", m_PermisoPerfilModulos.UsuarioModuloId);
                    ParametroSP("@MODULO_ID", m_PermisoPerfilModulos.ModuloId);
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


        public List<Permiso_Perfil_ModuloDTO> Listar_grilla_x_perfil(Permiso_Perfil_ModuloDTO ent)
        {
            List<Permiso_Perfil_ModuloDTO> lst = new List<Permiso_Perfil_ModuloDTO>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_PERMISO_PERFIL_MODULOConsultar_Lista", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla_x_perfil");
                    ParametroSP("@PERMISO_PERFIL_MODULO_ID", ent.PermisoPerfilModuloId);
                    ParametroSP("@USUARIO_ID", ent.USUARIO_ID);
                    ParametroSP("@PERFIL_ID", ent.PERFIL_ID);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new Permiso_Perfil_ModuloDTO(reader));
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
        public List<Permiso_Perfil_ModuloDTO> Listar_grilla_x_usuario(Permiso_Perfil_ModuloDTO ent)
        {
            List<Permiso_Perfil_ModuloDTO> lst = new List<Permiso_Perfil_ModuloDTO>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_PERMISO_PERFIL_MODULOConsultar_Lista", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla_x_user_modulo");
                    ParametroSP("@PERMISO_PERFIL_MODULO_ID", ent.PermisoPerfilModuloId);
                    ParametroSP("@USUARIO_ID", ent.UsuarioId);
                    ParametroSP("@PERFIL_ID", ent.PERFIL_ID);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new Permiso_Perfil_ModuloDTO(reader));
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
        public List<Permiso_Perfil_ModuloDTO> Listar_permiso_activo(int id_usuario, int id_sistema)
        {
            List<Permiso_Perfil_ModuloDTO> lst = new List<Permiso_Perfil_ModuloDTO>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_PERMISO_PERFIL_MODULOConsultar_Lista", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_permisos_activo_session");
                    ParametroSP("@USUARIO_ID", id_usuario);
                    ParametroSP("@SISTEMA_ID", id_sistema);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new Permiso_Perfil_ModuloDTO(reader));
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

        // Para llegar a permisos : Usuario ; perfiles ; modulos ; permisos

        public List<Permiso_Perfil_ModuloDTO> Listar_permiso_activo_x_perfil(int id_usuario, string key_sistema)
        {
            List<Permiso_Perfil_ModuloDTO> lst = new List<Permiso_Perfil_ModuloDTO>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    //ComandoSP("usp_PERMISO_PERFIL_MODULOConsultar_Lista", connection);
                    //ParametroSP("@accion", "lst");
                    //ParametroSP("@opcion", "lst_permisos_activo_session_x_perfil");
                    //ParametroSP("@USUARIO_ID", id_usuario);
                    //ParametroSP("@SISTEMA_ID", id_sistema);
                    //ParametroSP("@KEY_SISTEMA", key_sistema);
                    ComandoSP("usp_PermisoPerfilModuloConsultar_ListaDTO", connection);
                    ParametroSP("@USUARIO_ID", id_usuario);
                    ParametroSP("@KEY_SISTEMA", key_sistema);


                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new Permiso_Perfil_ModuloDTO(reader));
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
        public List<Permiso_Perfil_ModuloDTO> Listar_permiso_sistema_x_perfil(int id_usuario)
        {
            List<Permiso_Perfil_ModuloDTO> lst = new List<Permiso_Perfil_ModuloDTO>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_PERMISO_PERFIL_MODULOConsultar_Lista", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_permisos_sistema_activo_session_x_perfil");
                    ParametroSP("@USUARIO_ID", id_usuario);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new Permiso_Perfil_ModuloDTO(reader));
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
