using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.Entidades.ClaseDTO;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class BusquedaDeclaranteDA : BaseDA
    {
        const string Nombre_Clase = "BusquedaDeclaranteDA";
        private string m_BaseDatos = string.Empty;

        public BusquedaDeclaranteDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public BusquedaDeclaranteDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public List<BusquedaDeclaranteXP1003DTO> ListarUsuariosFiltrados(BusquedaDeclaranteXP1003DTO ent)
        {
            List<BusquedaDeclaranteXP1003DTO> lst = new List<BusquedaDeclaranteXP1003DTO>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DECLARANTESConsultarFiltrados", connection);
                    ParametroSP("@Paterno", ent.Paterno);
                    ParametroSP("@Materno", ent.Materno);
                    ParametroSP("@Nombres", ent.Nombres);
                    ParametroSP("@TipoDocumento", ent.TipoDocumento);
                    ParametroSP("@NroDocumento", ent.NroDocumento);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new BusquedaDeclaranteXP1003DTO(reader));
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
