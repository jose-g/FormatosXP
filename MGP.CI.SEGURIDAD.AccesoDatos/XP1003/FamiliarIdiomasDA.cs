using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class FamiliarIdiomasDA : BaseDA
    {
        const string Nombre_Clase = "FamiliarIdiomas";
        private string m_BaseDatos = string.Empty;

        public FamiliarIdiomasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public FamiliarIdiomasDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_FamiliarIdiomasGetMaxId", connection);


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
        public int Insertar(FamiliarIdiomasBE e_FamiliarIdiomas)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FamiliarIdiomasInsertar", connection);
                    ParametroSP("@FamiliarIdiomasId", e_FamiliarIdiomas.FamiliarIdiomasId);
                    ParametroSP("@IdiomaId", e_FamiliarIdiomas.IdiomaId);
                    ParametroSP("@EstadoId", e_FamiliarIdiomas.EstadoId);
                    ParametroSP("@FamiliarId", e_FamiliarIdiomas.FamiliarId);
                    ParametroSP("@UsuarioRegistro", e_FamiliarIdiomas.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_FamiliarIdiomas.NroIpRegistro);
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

    }
}
