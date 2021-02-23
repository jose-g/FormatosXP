using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class UsuariosDA : BaseDA
    {
        const string Nombre_Clase = "UsuariosDA";
        private string m_BaseDatos = string.Empty;

        public UsuariosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public UsuariosDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(UsuariosBE e_Usuarios)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UsuariosInsertar", connection);
                    ParametroSP("@UsuarioId", e_Usuarios.UsuarioId);
                    ParametroSP("@TipoUsuarioId", e_Usuarios.TipoUsuarioId);
                    ParametroSP("@Login", e_Usuarios.Login);
                    ParametroSP("@CIP", e_Usuarios.CIP);
                    ParametroSP("@Password", e_Usuarios.Password);
                    ParametroSP("@PasswordOld", e_Usuarios.PasswordOld);
                    ParametroSP("@ApePaterno", e_Usuarios.ApePaterno);
                    ParametroSP("@ApeMaterno", e_Usuarios.ApeMaterno);
                    ParametroSP("@Nombres", e_Usuarios.Nombres);
                    ParametroSP("@DocumentoIdentidadId", e_Usuarios.DocumentoIdentidadId);
                    ParametroSP("@NumeroDoc", e_Usuarios.NumeroDoc);
                    ParametroSP("@FechaNacimiento", e_Usuarios.FechaNacimiento);
                    ParametroSP("@Email", e_Usuarios.Email);
                    ParametroSP("@Telefono", e_Usuarios.Celular);
                    ParametroSP("@DocReferencia", e_Usuarios.DocReferencia);
                    ParametroSP("@CargoTipoId", e_Usuarios.CargoTipoId);
                    ParametroSP("@Cargo", e_Usuarios.Cargo);
                    ParametroSP("@FinVigencia", e_Usuarios.FinVigencia);
                    ParametroSP("@FechaUltimoLogueo", e_Usuarios.FechaUltimoLogueo);
                    ParametroSP("@EstadoId", e_Usuarios.EstadoId);
                    ParametroSP("@UbigeoNavalId", e_Usuarios.UbigeoNavalId);
                    ParametroSP("@ResetPassword", e_Usuarios.ResetPassword);
                    ParametroSP("@AvatarPath", e_Usuarios.AvatarPath);
                    ParametroSP("@UsuarioNivel", e_Usuarios.UsuarioNivel);
                    ParametroSP("@UsuarioRegistro", e_Usuarios.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Usuarios.NroIpRegistro);
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

        public int Actualizar(UsuariosBE e_Usuarios)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UsuariosActualizar", connection);
                    ParametroSP("@UsuarioId", e_Usuarios.UsuarioId);
                    ParametroSP("@TipoUsuarioId", e_Usuarios.TipoUsuarioId);
                    ParametroSP("@Login", e_Usuarios.Login);
                    ParametroSP("@CIP", e_Usuarios.CIP);
                    ParametroSP("@ApePaterno", e_Usuarios.ApePaterno);
                    ParametroSP("@ApeMaterno", e_Usuarios.ApeMaterno);
                    ParametroSP("@Nombres", e_Usuarios.Nombres);
                    ParametroSP("@DocumentoIdentidadId", e_Usuarios.DocumentoIdentidadId);
                    ParametroSP("@NumeroDoc", e_Usuarios.NumeroDoc);
                    ParametroSP("@FechaNacimiento", e_Usuarios.FechaNacimiento);
                    ParametroSP("@Email", e_Usuarios.Email);
                    ParametroSP("@Telefono", e_Usuarios.Celular);
                    ParametroSP("@DocReferencia", e_Usuarios.DocReferencia);
                    ParametroSP("@CargoTipoId", e_Usuarios.CargoTipoId);
                    ParametroSP("@Cargo", e_Usuarios.Cargo);
                    ParametroSP("@FinVigencia", e_Usuarios.FinVigencia);
                    ParametroSP("@FechaUltimoLogueo", e_Usuarios.FechaUltimoLogueo);
                    ParametroSP("@EstadoId", e_Usuarios.EstadoId);
                    ParametroSP("@UbigeoNavalId", e_Usuarios.UbigeoNavalId);
                    ParametroSP("@ResetPassword", e_Usuarios.ResetPassword);
                    ParametroSP("@AvatarPath", e_Usuarios.AvatarPath);
                    ParametroSP("@UsuarioNivel", e_Usuarios.UsuarioNivel);
                    ParametroSP("@UsuarioModificacionRegistro", e_Usuarios.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Usuarios.NroIpRegistro);
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

        public int Anular(UsuariosBE e_Usuarios)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UsuariosAnular", connection);
                    ParametroSP("@UsuarioId", e_Usuarios.UsuarioId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Usuarios.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Usuarios.NroIpRegistro);

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

        public List<UsuariosBE> Consultar_Lista()
        {
            List<UsuariosBE> lista = new List<UsuariosBE>();
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UsuariosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuariosBE(reader));
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

        public List<UsuariosBE> ConsultarLogin(string m_UsuarioLogin)
        {
            List<UsuariosBE> lista = new List<UsuariosBE>();
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UsuariosConsultarLogin", connection);
                    ParametroSP("@UsuarioLogin", m_UsuarioLogin);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuariosBE(reader));
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

        public List<UsuariosBE> Consultar_PK(int m_UsuarioId)
        {
            List<UsuariosBE> lista = new List<UsuariosBE>();
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UsuariosConsultar_PK", connection);
                    ParametroSP("@UsuarioId", m_UsuarioId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuariosBE(reader));
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
        public int CambiarClave(UsuariosBE usuarioBE)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_USUARIOActualizarClave", connection);
                    ParametroSP("@UsuarioId", usuarioBE.UsuarioId);
                    ParametroSP("@Password", usuarioBE.Password);
                    ParametroSP("@UsuarioModificacionRegistro", usuarioBE.UsuarioModificacionRegistro);

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
        public List<UsuariosDTO> ListarUsuariosFiltrados(UsuariosDTO ent)
        {
            List<UsuariosDTO> lst = new List<UsuariosDTO>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_USUARIOConsultarUsuariosFiltrados", connection);
                    ParametroSP("@UsuarioId", ent.UsuarioId);
                    ParametroSP("@ApePaterno", ent.ApePaterno);
                    ParametroSP("@ApeMaterno", ent.ApeMaterno);
                    ParametroSP("@Nombres", ent.Nombres);
                    ParametroSP("@Login", ent.Login);
                    ParametroSP("@ZonaNaval", ent.ZonaNaval);
                    ParametroSP("@Dependencia", ent.Dependencia);
                    ParametroSP("@EstadoId", ent.EstadoId);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new UsuariosDTO(reader));
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
        public int CambiarEstado(UsuariosBE e_USUARIO)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UsuarioCambiarEstado", connection);
                    ParametroSP("@UsuarioId", e_USUARIO.UsuarioId);
                    ParametroSP("@UsuarioModificacionRegistro", e_USUARIO.Login);
                    ParametroSP("@EstadoId", e_USUARIO.EstadoId);
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
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UsuariosGetMaxId", connection);


                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!DBNull.Value.Equals(reader["UsuarioMaxId"])) { maxId = Convert.ToInt32(reader["UsuarioMaxId"]); }
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
















        public List<UsuariosDTO> Listar_grilla_inicial(UsuariosDTO ent)
        {
            List<UsuariosDTO> lst = new List<UsuariosDTO>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_UsuariosConsultarListaInicial", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new UsuariosDTO(reader));
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
        public List<UsuariosBE> Listar_grilla(UsuariosBE ent)
        {
            List<UsuariosBE> lst = new List<UsuariosBE>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_USUARIOConsultarUsuariosFiltrados", connection);
                    ParametroSP("@UsuarioId", ent.UsuarioId);
                    ParametroSP("@ApePaterno", ent.ApePaterno);
                    ParametroSP("@ApeMaterno", ent.ApeMaterno);
                    ParametroSP("@Nombres", ent.Nombres);
                    ParametroSP("@Login", ent.Login);
                    ParametroSP("@ZonaNaval", "");
                    ParametroSP("@Dependencia", "");
                    ParametroSP("@EstadoId", ent.EstadoId);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new UsuariosDTO(reader));
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
