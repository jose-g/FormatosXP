using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class IdiomasDominadosDA : BaseDA
    {
        const string Nombre_Clase = "IdiomasDominadosDA";
        private string m_BaseDatos = string.Empty;

        public IdiomasDominadosDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public IdiomasDominadosDA() { }
        public int Insertar(IdiomasDominadosBE e_IdiomasDominados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomasDominadosInsertar", connection);
                    ParametroSP("@IdiomasDominadosId", e_IdiomasDominados.IdiomasDominadosId);
                    ParametroSP("@IdiomaId", e_IdiomasDominados.IdiomaId);
                    ParametroSP("@Hablado", e_IdiomasDominados.Hablado);
                    ParametroSP("@Escrito", e_IdiomasDominados.Escrito);
                    ParametroSP("@Leido", e_IdiomasDominados.Leido);
                    ParametroSP("@EstadoId", e_IdiomasDominados.EstadoId);
                    ParametroSP("@InformacionCastrenseId", e_IdiomasDominados.InformacionCastrenseId);
                    ParametroSP("@UsuarioRegistro", e_IdiomasDominados.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_IdiomasDominados.NroIpRegistro);
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

        public int Actualizar(IdiomasDominadosBE e_IdiomasDominados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomasDominadosActualizar", connection);
                    ParametroSP("@IdiomasDominadosId", e_IdiomasDominados.IdiomasDominadosId);
                    ParametroSP("@IdiomaId", e_IdiomasDominados.IdiomaId);
                    ParametroSP("@Hablado", e_IdiomasDominados.Hablado);
                    ParametroSP("@Escrito", e_IdiomasDominados.Escrito);
                    ParametroSP("@Leido", e_IdiomasDominados.Leido);
                    ParametroSP("@EstadoId", e_IdiomasDominados.EstadoId);
                    ParametroSP("@InformacionCastrenseId", e_IdiomasDominados.InformacionCastrenseId);
                    ParametroSP("@UsuarioModificacionRegistro", e_IdiomasDominados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_IdiomasDominados.NroIpRegistro);
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

        public int Anular(IdiomasDominadosBE e_IdiomasDominados)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomasDominadosAnular", connection);
                    ParametroSP("@IdiomasDominadosId", e_IdiomasDominados.IdiomasDominadosId);
                    ParametroSP("@UsuarioModificacionRegistro", e_IdiomasDominados.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_IdiomasDominados.NroIpRegistro);
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

        public List<IdiomasDominadosBE> Consultar_Lista()
        {
            List<IdiomasDominadosBE> lista = new List<IdiomasDominadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomasDominadosConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IdiomasDominadosBE(reader));
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

        public List<IdiomasDominadosBE> Consultar_PK(
                int m_IdiomasDominadosId)
        {
            List<IdiomasDominadosBE> lista = new List<IdiomasDominadosBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_IdiomasDominadosConsultar_PK", connection);
                    ParametroSP("@IdiomasDominadosId", m_IdiomasDominadosId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new IdiomasDominadosBE(reader));
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
