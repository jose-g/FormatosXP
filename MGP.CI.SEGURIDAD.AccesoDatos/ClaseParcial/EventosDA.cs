using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class EventosDA : BaseDA
    {
        const string Nombre_Clase = "EventosDA";
        private string m_BaseDatos = string.Empty;

        public EventosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public EventosDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(EventosBE e_Eventos)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_EventosInsertar", connection);
                    ParametroSP("@UsuarioId", e_Eventos.UsuarioId);
                    ParametroSP("@UsuarioLogin", e_Eventos.UsuarioLogin);
                    ParametroSP("@GFH", e_Eventos.GFH);
                    ParametroSP("@Accion", e_Eventos.Accion);
                    ParametroSP("@OperacionSatisfactorio", e_Eventos.OperacionSatisfactorio);
                    ParametroSP("@Mensaje", e_Eventos.Mensaje);
                    ParametroSP("@SistemaId", e_Eventos.SistemaId);
                    ParametroSP("@UsuarioRegistro", e_Eventos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Eventos.NroIpRegistro);
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

        public int Actualizar(EventosBE e_Eventos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EventosActualizar", connection);
                    ParametroSP("@EventoId", e_Eventos.EventoId);
                    ParametroSP("@UsuarioId", e_Eventos.UsuarioId);
                    ParametroSP("@UsuarioLogin", e_Eventos.UsuarioLogin);
                    ParametroSP("@GFH", e_Eventos.GFH);
                    ParametroSP("@Accion", e_Eventos.Accion);
                    ParametroSP("@OperacionSatisfactorio", e_Eventos.OperacionSatisfactorio);
                    ParametroSP("@Mensaje", e_Eventos.Mensaje);
                    ParametroSP("@SistemaId", e_Eventos.SistemaId);
                    ParametroSP("@EstadoId", e_Eventos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Eventos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Eventos.NroIpRegistro);
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

        public int Anular(EventosBE e_Eventos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EventosAnular", connection);
                    ParametroSP("@EventoId", e_Eventos.EventoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Eventos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Eventos.NroIpRegistro);
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

        public List<EventosBE> Consultar_Lista()
        {
            List<EventosBE> lista = new List<EventosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EventosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EventosBE(reader));
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

        public List<EventosBE> Consultar_PK(
                int m_EventoId)
        {
            List<EventosBE> lista = new List<EventosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_EventosConsultar_PK", connection);
                    ParametroSP("@EventoId", m_EventoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EventosBE(reader));
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
