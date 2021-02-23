using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class PerfilModulosDA : BaseDA
    {
        const string Nombre_Clase = "PerfilModulosDA";
        private string m_BaseDatos = string.Empty;

        public PerfilModulosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public PerfilModulosDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(PerfilModulosBE e_PerfilModulos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilModulosInsertar", connection);
                    ParametroSP("@PerfilModuloId", e_PerfilModulos.PerfilModuloId);
                    ParametroSP("@ModuloId", e_PerfilModulos.ModuloId);
                    ParametroSP("@PerfilId", e_PerfilModulos.PerfilId);
                    ParametroSP("@EstadoId", e_PerfilModulos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_PerfilModulos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_PerfilModulos.NroIpRegistro);
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

        public int Actualizar(PerfilModulosBE e_PerfilModulos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilModulosActualizar", connection);
                    ParametroSP("@PerfilModuloId", e_PerfilModulos.PerfilModuloId);
                    ParametroSP("@ModuloId", e_PerfilModulos.ModuloId);
                    ParametroSP("@PerfilId", e_PerfilModulos.PerfilId);
                    ParametroSP("@EstadoId", e_PerfilModulos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PerfilModulos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PerfilModulos.NroIpRegistro);
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

        public int Anular(PerfilModulosBE e_PerfilModulos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilModulosAnular", connection);
                    ParametroSP("@PerfilModuloId", e_PerfilModulos.PerfilModuloId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PerfilModulos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PerfilModulos.NroIpRegistro);
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

        public List<PerfilModulosBE> Consultar_Lista()
        {
            List<PerfilModulosBE> lista = new List<PerfilModulosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilModulosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PerfilModulosBE(reader));
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

        public List<PerfilModulosBE> Consultar_PK(
                int m_PerfilModuloId)
        {
            List<PerfilModulosBE> lista = new List<PerfilModulosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PerfilModulosConsultar_PK", connection);
                    ParametroSP("@PerfilModuloId", m_PerfilModuloId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PerfilModulosBE(reader));
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

        public List<PerfilModulosBE> Listar_grilla(PerfilModulosBE ent)
        {
            List<PerfilModulosBE> lst = new List<PerfilModulosBE>();

            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PERFIL_MODULOConsultar_Lista", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla");
                    ParametroSP("@PERFIL_MODULO_ID", ent.PerfilModuloId);
                    ParametroSP("@MODULO_ID", ent.ModuloId);
                    ParametroSP("@PERFIL_ID", ent.PerfilId);
                    //ParametroSP("@ESTADO_ID", ent.ESTADO_ID);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new PerfilModulosBE(reader));
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
