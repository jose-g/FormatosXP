using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class FichasDA : BaseDA
    {
        const string Nombre_Clase = "FichasDA";
        private string m_BaseDatos = string.Empty;

        public FichasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public FichasDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_FichaGetMaxId", connection);


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



        public int Insertar(FichasBE e_Fichas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FichasInsertar", connection);
                    ParametroSP("@FichaId", e_Fichas.FichaId);
                    ParametroSP("@FichaTipoId", e_Fichas.FichaTipoId);
                    ParametroSP("@DeclaranteId", e_Fichas.DeclaranteId);
                    ParametroSP("@EstadoFichaId", e_Fichas.EstadoFichaId);
                    ParametroSP("@EstadoId", e_Fichas.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Fichas.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Fichas.NroIpRegistro);
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

        public int Actualizar(FichasBE e_Fichas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FichasActualizar", connection);
                    ParametroSP("@FichaId", e_Fichas.FichaId);
                    ParametroSP("@FichaTipoId", e_Fichas.FichaTipoId);
                    ParametroSP("@DeclaranteId", e_Fichas.DeclaranteId);
                    ParametroSP("@EstadoFichaId", e_Fichas.EstadoFichaId);
                    ParametroSP("@EstadoId", e_Fichas.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Fichas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Fichas.NroIpRegistro);
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

        public int Anular(FichasBE e_Fichas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FichasAnular", connection);
                    ParametroSP("@FichaId", e_Fichas.FichaId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Fichas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Fichas.NroIpRegistro);
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

        public List<FichasBE> Consultar_Lista()
        {
            List<FichasBE> lista = new List<FichasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FichasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FichasBE(reader));
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

        public List<FichasBE> Consultar_PK(
                int m_FichaId)
        {
            List<FichasBE> lista = new List<FichasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FichasConsultar_PK", connection);
                    ParametroSP("@FichaId", m_FichaId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FichasBE(reader));
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
