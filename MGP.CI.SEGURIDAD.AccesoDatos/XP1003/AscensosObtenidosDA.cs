using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class AscensosObtenidosDA : BaseDA
    {
        const string Nombre_Clase = "AscensosObtenidosDA";
        private string m_BaseDatos = string.Empty;

        public AscensosObtenidosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public AscensosObtenidosDA() { }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_AscensosObtenidosGetMaxId", connection);


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
        public int Insertar(AscensosObtenidosBE e_AscensosObtenidos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AscensosObtenidosInsertar", connection);
                    ParametroSP("@AscensosObtenidosId", e_AscensosObtenidos.AscensosObtenidosId);
                    ParametroSP("@GradoExtranjeroId", e_AscensosObtenidos.GradoExtranjeroId);
                    ParametroSP("@InstitucionMilitarExtranjeroId ", e_AscensosObtenidos.@InstitucionMilitarExtranjeroId);
                    ParametroSP("@PaisId", e_AscensosObtenidos.PaisId);
                    ParametroSP("@InformacionCastrenseId", e_AscensosObtenidos.InformacionCastrenseId);
                    ParametroSP("@GradoExtranjeroAno", e_AscensosObtenidos.GradoExtranjeroAno);
                    ParametroSP("@EstadoId", e_AscensosObtenidos.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_AscensosObtenidos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_AscensosObtenidos.NroIpRegistro);
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

        public int Actualizar(AscensosObtenidosBE e_AscensosObtenidos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AscensosObtenidosActualizar", connection);
                    ParametroSP("@AscensosObtenidosId", e_AscensosObtenidos.AscensosObtenidosId);
                    ParametroSP("@GradoExtranjeroId", e_AscensosObtenidos.GradoExtranjeroId);
                    ParametroSP("@InformacionCastrenseId", e_AscensosObtenidos.InformacionCastrenseId);
                    ParametroSP("GradoExtranjeroAno", e_AscensosObtenidos.GradoExtranjeroAno);
                    ParametroSP("@EstadoId", e_AscensosObtenidos.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_AscensosObtenidos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_AscensosObtenidos.NroIpRegistro);
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

        public int Anular(AscensosObtenidosBE e_AscensosObtenidos)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AscensosObtenidosAnular", connection);
                    ParametroSP("@AscensosObtenidosId", e_AscensosObtenidos.AscensosObtenidosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_AscensosObtenidos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_AscensosObtenidos.NroIpRegistro);
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

        public List<AscensosObtenidosBE> Consultar_Lista()
        {
            List<AscensosObtenidosBE> lista = new List<AscensosObtenidosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AscensosObtenidosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AscensosObtenidosBE(reader));
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

        public List<AscensosObtenidosBE> Consultar_PK(
                int m_AscensosObtenidosId)
        {
            List<AscensosObtenidosBE> lista = new List<AscensosObtenidosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AscensosObtenidosConsultar_PK", connection);
                    ParametroSP("@AscensosObtenidosId", m_AscensosObtenidosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AscensosObtenidosBE(reader));
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
        public List<AscensosObtenidosBE> Consultar_FK(
                int m_Fk_Id)
        {
            List<AscensosObtenidosBE> lista = new List<AscensosObtenidosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_AscensosObtenidosConsultar_FK", connection);
                    ParametroSP("@InformacionCastrenseId", m_Fk_Id);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new AscensosObtenidosBE(reader));
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
