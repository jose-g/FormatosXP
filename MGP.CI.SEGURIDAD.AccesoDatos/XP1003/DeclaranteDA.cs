using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class DeclaranteDA : BaseDA
    {
        const string Nombre_Clase = "DeclaranteDA";
        private string m_BaseDatos = string.Empty;

        public DeclaranteDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public DeclaranteDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int Insertar(DeclaranteBE e_Declarante)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeclaranteInsertar", connection);
                    ParametroSP("@DeclaranteId", e_Declarante.DeclaranteId);
                    ParametroSP("@isUsuario", e_Declarante.isUsuario);
                    ParametroSP("@EstadoId", e_Declarante.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_Declarante.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_Declarante.NroIpRegistro);
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

        public int Actualizar(DeclaranteBE e_Declarante)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeclaranteActualizar", connection);
                    ParametroSP("@DeclaranteId", e_Declarante.DeclaranteId);
                    ParametroSP("@isUsuario", e_Declarante.isUsuario);
                    ParametroSP("@EstadoId", e_Declarante.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Declarante.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Declarante.NroIpRegistro);
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

        public int Anular(DeclaranteBE e_Declarante)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeclaranteAnular", connection);
                    ParametroSP("@DeclaranteId", e_Declarante.DeclaranteId);
                    ParametroSP("@UsuarioModificacionRegistro", e_Declarante.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_Declarante.NroIpRegistro);
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

        public List<DeclaranteBE> Consultar_Lista()
        {
            List<DeclaranteBE> lista = new List<DeclaranteBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeclaranteConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DeclaranteBE(reader));
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

        public List<DeclaranteBE> Consultar_PK(
                int m_DeclaranteId)
        {
            List<DeclaranteBE> lista = new List<DeclaranteBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_DeclaranteConsultar_PK", connection);
                    ParametroSP("@DeclaranteId", m_DeclaranteId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DeclaranteBE(reader));
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
                    ComandoSP("usp_DeclaranteGetMaxId", connection);


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
    }
}