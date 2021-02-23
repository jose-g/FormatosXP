using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class ProfesionesDA : BaseDA
    {
        const string Nombre_Clase = "ProfesionesDA";
        private string m_BaseDatos = string.Empty;

        public ProfesionesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public int Insertar(ProfesionesBE e_Profesiones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ProfesionesInsertar", connection);
                    ParametroSP("@ProfesionId", e_Profesiones.ProfesionId);
                    ParametroSP("@Nombre", e_Profesiones.Nombre);
                    ParametroSP("@Descripcion", e_Profesiones.Descripcion);
                    ParametroSP("@EstadoId", e_Profesiones.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Profesiones.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Profesiones.NroIpRegistro);
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

        public int Actualizar(ProfesionesBE e_Profesiones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ProfesionesActualizar", connection);
                    ParametroSP("@ProfesionId", e_Profesiones.ProfesionId);
                    ParametroSP("@Nombre", e_Profesiones.Nombre);
                    ParametroSP("@Descripcion", e_Profesiones.Descripcion);
                    ParametroSP("@EstadoId", e_Profesiones.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Profesiones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Profesiones.NroIpRegistro);
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

        public int Anular(ProfesionesBE e_Profesiones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ProfesionesAnular", connection);
                    ParametroSP("@ProfesionId", e_Profesiones.ProfesionId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Profesiones.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Profesiones.NroIpRegistro);
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

        public List<ProfesionesBE> Consultar_Lista()
        {
            List<ProfesionesBE> lista = new List<ProfesionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ProfesionesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ProfesionesBE(reader));
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

        public List<ProfesionesBE> Consultar_PK(
                int m_ProfesionId)
        {
            List<ProfesionesBE> lista = new List<ProfesionesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_ProfesionesConsultar_PK", connection);
                    ParametroSP("@ProfesionId", m_ProfesionId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ProfesionesBE(reader));
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
