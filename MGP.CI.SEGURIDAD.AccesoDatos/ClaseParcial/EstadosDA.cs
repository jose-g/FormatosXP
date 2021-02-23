using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class EstadosDA : BaseDA
    {
        const string Nombre_Clase = "EstadosDA";
        private string m_BaseDatos = string.Empty;

        public EstadosDA(String BaseDatos) {
            m_BaseDatos = BaseDatos;
        }
        public EstadosDA() {
            m_BaseDatos = "DIN_XP_SEGURIDAD";
        }

        public int Insertar(EstadosBE e_Estados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadosInsertar", connection);
                    ParametroSP("@EstadoId", e_Estados.EstadoId);
                    ParametroSP("@Nombre", e_Estados.Nombre);
                    ParametroSP("@Descripcion", e_Estados.Descripcion);
                    ParametroSP("@Estado", e_Estados.FlagEliminado);
                    ParametroSP("@UsuarioRegistro", e_Estados.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Estados.NroIpRegistro);
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

        public int Actualizar(EstadosBE e_Estados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadosActualizar", connection);
                    ParametroSP("@EstadoId", e_Estados.EstadoId);
                    ParametroSP("@Nombre", e_Estados.Nombre);
                    ParametroSP("@Descripcion", e_Estados.Descripcion);
                    ParametroSP("@FlagEliminado", e_Estados.FlagEliminado);
                    ParametroSP("@UsuarioModificacionRegistro", e_Estados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Estados.NroIpRegistro);
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

        public int Anular(EstadosBE e_Estados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadosAnular", connection);
                    ParametroSP("@EstadoId", e_Estados.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Estados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Estados.NroIpRegistro);
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

        public List<EstadosBE> Consultar_Lista()
        {
            List<EstadosBE> lista = new List<EstadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EstadosBE(reader));
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

        public List<EstadosBE> Consultar_PK(int m_EstadoId)
        {
            List<EstadosBE> lista = new List<EstadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadosConsultar_PK", connection);
                    ParametroSP("@EstadoId", m_EstadoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EstadosBE(reader));
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

        public List<EstadosBE> Listar_grilla(EstadosBE ent)
        {
            List<EstadosBE> lst = new List<EstadosBE>();

            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EstadosConsultar_Lista_Grilla", connection);
                    ParametroSP("@accion", "lst");
                    ParametroSP("@opcion", "lst_grilla");
                    ParametroSP("@NOMBRE", ent.Nombre);
                    ParametroSP("@EstadoId", ent.EstadoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new EstadosBE(reader));
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
