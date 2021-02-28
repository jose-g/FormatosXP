using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class CondecoracionesObtenidasDA : BaseDA
    {
        const string Nombre_Clase = "CondecoracionesObtenidasDA";
        private string m_BaseDatos = string.Empty;

        public CondecoracionesObtenidasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public CondecoracionesObtenidasDA() { }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_CondecoracionesObtenidasGetMaxId", connection);


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
        public int Insertar(CondecoracionesObtenidasBE e_CondecoracionesObtenidas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CondecoracionesObtenidasInsertar", connection);
                    ParametroSP("@CondecoracionesObtenidasId", e_CondecoracionesObtenidas.CondecoracionesObtenidasId);
                    ParametroSP("@CondecoracionesPaisId", e_CondecoracionesObtenidas.Condecoraciones_PaisId);
                    ParametroSP("@CondecoracionesInstitucionMilitarExtranjeraId", e_CondecoracionesObtenidas.Condecoraciones_InstitucionMilitarExtranjeraId);
                    ParametroSP("@CondecoracionesExtranjerasId", e_CondecoracionesObtenidas.CondecoracionesExtranjerasId);
                    ParametroSP("@CondecoracionesExtranjerasAno", e_CondecoracionesObtenidas.CondecoracionesExtranjerasAno);
                    ParametroSP("@InformacionCastrenseId", e_CondecoracionesObtenidas.InformacionCastrenseId);
                    ParametroSP("@EstadoId", e_CondecoracionesObtenidas.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_CondecoracionesObtenidas.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_CondecoracionesObtenidas.NroIpRegistro);
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

        public int Actualizar(CondecoracionesObtenidasBE e_CondecoracionesObtenidas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CondecoracionesObtenidasActualizar", connection);
                    ParametroSP("@CondecoracionesObtenidasId", e_CondecoracionesObtenidas.CondecoracionesObtenidasId);
                    ParametroSP("@Condecoraciones_PaisId", e_CondecoracionesObtenidas.Condecoraciones_PaisId);
                    ParametroSP("@Condecoraciones_InstitucionMilitarExtranjeraId", e_CondecoracionesObtenidas.Condecoraciones_InstitucionMilitarExtranjeraId);
                    ParametroSP("@CondecoracionesExtranjerasId", e_CondecoracionesObtenidas.CondecoracionesExtranjerasId);
                    ParametroSP("@CondecoracionesExtranjerasAno", e_CondecoracionesObtenidas.CondecoracionesExtranjerasAno);
                    ParametroSP("@InformacionCastrenseId", e_CondecoracionesObtenidas.InformacionCastrenseId);
                    ParametroSP("@EstadoId", e_CondecoracionesObtenidas.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CondecoracionesObtenidas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CondecoracionesObtenidas.NroIpRegistro);
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

        public int Anular(CondecoracionesObtenidasBE e_CondecoracionesObtenidas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CondecoracionesObtenidasAnular", connection);
                    ParametroSP("@CondecoracionesObtenidasId", e_CondecoracionesObtenidas.CondecoracionesObtenidasId);
                    ParametroSP("@UsuarioModificacionRegistro", e_CondecoracionesObtenidas.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_CondecoracionesObtenidas.NroIpRegistro);
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

        public List<CondecoracionesObtenidasBE> Consultar_Lista()
        {
            List<CondecoracionesObtenidasBE> lista = new List<CondecoracionesObtenidasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CondecoracionesObtenidasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CondecoracionesObtenidasBE(reader));
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

        public List<CondecoracionesObtenidasBE> Consultar_PK(
                int m_CondecoracionesObtenidasId)
        {
            List<CondecoracionesObtenidasBE> lista = new List<CondecoracionesObtenidasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_CondecoracionesObtenidasConsultar_PK", connection);
                    ParametroSP("@CondecoracionesObtenidasId", m_CondecoracionesObtenidasId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new CondecoracionesObtenidasBE(reader));
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
