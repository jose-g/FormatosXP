using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.X1005
{
    [Serializable]
    public partial class PaisesAfectosDA : BaseDA
    {
        const string Nombre_Clase = "PaisesAfectosDA";
        private string m_BaseDatos = string.Empty;

        public PaisesAfectosDA() {  }

        public int Insertar(PaisesAfectosBE e_PaisesAfectos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PaisesAfectosInsertar", connection);
                    ParametroSP("@PaisesAfectosId", e_PaisesAfectos.PaisesAfectosId);
                    ParametroSP("@Vinculaciones1005d", e_PaisesAfectos.Vinculaciones1005d);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_PaisesAfectos.InstitucionMilitarExtranjeraId);
                    ParametroSP("@Descripcion", e_PaisesAfectos.Descripcion);
                    ParametroSP("@EstadoId", e_PaisesAfectos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_PaisesAfectos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_PaisesAfectos.NroIpRegistro);
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

        public int Actualizar(PaisesAfectosBE e_PaisesAfectos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PaisesAfectosActualizar", connection);
                    ParametroSP("@PaisesAfectosId", e_PaisesAfectos.PaisesAfectosId);
                    ParametroSP("@Vinculaciones1005d", e_PaisesAfectos.Vinculaciones1005d);
                    ParametroSP("@InstitucionMilitarExtranjeraId", e_PaisesAfectos.InstitucionMilitarExtranjeraId);
                    ParametroSP("@Descripcion", e_PaisesAfectos.Descripcion);
                    ParametroSP("@EstadoId", e_PaisesAfectos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PaisesAfectos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PaisesAfectos.NroIpRegistro);
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

        public int Anular(PaisesAfectosBE e_PaisesAfectos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PaisesAfectosAnular", connection);
                    ParametroSP("@PaisesAfectosId", e_PaisesAfectos.PaisesAfectosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_PaisesAfectos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_PaisesAfectos.NroIpRegistro);
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

        public List<PaisesAfectosBE> Consultar_Lista()
        {
            List<PaisesAfectosBE> lista = new List<PaisesAfectosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PaisesAfectosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PaisesAfectosBE(reader));
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

        public List<PaisesAfectosBE> Consultar_PK(
                int m_PaisesAfectosId)
        {
            List<PaisesAfectosBE> lista = new List<PaisesAfectosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_PaisesAfectosConsultar_PK", connection);
                    ParametroSP("@PaisesAfectosId", m_PaisesAfectosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new PaisesAfectosBE(reader));
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
                    ComandoSP("usp_PaisesAfectosGetMaxId", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                        if (!DBNull.Value.Equals(reader["CodigoMaxId"]))
                            {
                             maxId = Convert.ToInt32(reader["CodigoMaxId"]);
                            }
                        }
                }
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
            return maxId;
        }

    }
}


