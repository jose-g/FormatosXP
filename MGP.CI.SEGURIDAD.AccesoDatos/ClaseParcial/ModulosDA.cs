using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class ModulosDA : BaseDA
    {
        const string Nombre_Clase = "ModulosDA";
        private string m_BaseDatos = string.Empty;

        public ModulosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public ModulosDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(ModulosBE e_Modulos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ModulosInsertar", connection);
                    ParametroSP("@ModuloId", e_Modulos.ModuloId);
                    ParametroSP("@ModuloKey", e_Modulos.ModuloKey);
                    ParametroSP("@SistemaId", e_Modulos.SistemaId);
                    ParametroSP("@ModuloPadreId", e_Modulos.ModuloPadreId);
                    ParametroSP("@Nombre", e_Modulos.Nombre);
                    ParametroSP("@Descripcion", e_Modulos.Descripcion);
                    ParametroSP("@MenuDisplay", e_Modulos.MenuDisplay);
                    ParametroSP("@MenuIcono", e_Modulos.MenuIcono);
                    ParametroSP("@MenuNombre", e_Modulos.MenuNombre);
                    ParametroSP("@MenuPath", e_Modulos.MenuPath);
                    ParametroSP("@MenuPrioridad", e_Modulos.MenuPrioridad);
                    ParametroSP("@EstadoId", e_Modulos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Modulos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Modulos.NroIpRegistro);
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

        public int Actualizar(ModulosBE e_Modulos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ModulosActualizar", connection);
                    ParametroSP("@ModuloId", e_Modulos.ModuloId);
                    ParametroSP("@ModuloKey", e_Modulos.ModuloKey);
                    ParametroSP("@SistemaId", e_Modulos.SistemaId);
                    ParametroSP("@ModuloPadreId", e_Modulos.ModuloPadreId);
                    ParametroSP("@Nombre", e_Modulos.Nombre);
                    ParametroSP("@Descripcion", e_Modulos.Descripcion);
                    ParametroSP("@MenuDisplay", e_Modulos.MenuDisplay);
                    ParametroSP("@MenuIcono", e_Modulos.MenuIcono);
                    ParametroSP("@MenuNombre", e_Modulos.MenuNombre);
                    ParametroSP("@MenuPath", e_Modulos.MenuPath);
                    ParametroSP("@MenuPrioridad", e_Modulos.MenuPrioridad);
                    ParametroSP("@EstadoId", e_Modulos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Modulos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Modulos.NroIpRegistro);
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

        public int Anular(ModulosBE e_Modulos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ModulosAnular", connection);
                    ParametroSP("@ModuloId", e_Modulos.ModuloId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Modulos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Modulos.NroIpRegistro);
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

        public List<ModulosBE> Consultar_Lista()
        {
            List<ModulosBE> lista = new List<ModulosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ModulosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ModulosBE(reader));
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

        public List<ModulosBE> Consultar_PK(
                int m_ModuloId)
        {
            List<ModulosBE> lista = new List<ModulosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ModulosConsultar_PK", connection);
                    ParametroSP("@ModuloId", m_ModuloId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ModulosBE(reader));
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



        public List<ModulosBE> Listar_grilla(ModulosBE ent)
        {
            List<ModulosBE> lst = new List<ModulosBE>();

            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ModulosConsultar_Lista_Grilla", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla");
                    ParametroSP("@Nombre", ent.Nombre);
                    ParametroSP("@ModuloId", ent.ModuloId);
                    ParametroSP("@SistemaId", ent.SistemaId);
                    ParametroSP("@ModuloPadreId", ent.ModuloPadreId);
                    ParametroSP("@SistemaKey", ent.SistemaKey);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new ModulosBE(reader));
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
        public List<ModulosBE> Listar_Modulos_Raiz_x_sistema(string KEY_SISTEMA)
        {
            List<ModulosBE> lst = new List<ModulosBE>();

            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ModulosConsultar_Lista_Grilla", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla_modulos_raiz_x_sistema");
                    ParametroSP("@SistemaKey", KEY_SISTEMA);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new ModulosBE(reader));
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
        public List<ModulosBE> Listar_grilla_x_sistemaId(int id_sistema)
        {
            List<ModulosBE> lst = new List<ModulosBE>();

            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ModulosConsultar_Lista_Grilla", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla_sistema_id");
                    ParametroSP("@SistemaId", id_sistema);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new ModulosBE(reader));
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
        public List<ModulosBE> Listar_grilla_x_modpadre(ModulosBE ent)
        {
            List<ModulosBE> lst = new List<ModulosBE>();

            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ModulosConsultar_Lista_Grilla", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla_x_modulo_padre");
                    ParametroSP("@Nombre", ent.Nombre);
                    ParametroSP("@ModuloId", ent.ModuloId);
                    ParametroSP("@SistemaId", ent.SistemaId);
                    ParametroSP("@ModuloPadreId", ent.ModuloPadreId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new ModulosBE(reader));
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

        public List<ModulosBE> Listar_Modulos_Autorizados(string key_sistema, int id_usuario)
        {
            List<ModulosBE> lst = new List<ModulosBE>();

            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ModulosConsultar_Lista_Grilla", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_modulos_autorizados_por_usuario");
                    ParametroSP("@UsuarioId", id_usuario);
                    ParametroSP("@SistemaKey", key_sistema);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new ModulosBE(reader));
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
