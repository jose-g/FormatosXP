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
    public partial class BusquedaFichaDA : BaseDA
    {
        const string Nombre_Clase = "BusquedaDeclaranteDA";
        private string m_BaseDatos = string.Empty;

        public BusquedaFichaDA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public BusquedaFichaDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public List<BusquedaFichaXP1003DTO> ListarFichasFiltrados(BusquedaFichaXP1003DTO ent)
        {
            List<BusquedaFichaXP1003DTO> lst = new List<BusquedaFichaXP1003DTO>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_FICHASConsultarFiltrados", connection);
                    ParametroSP("@DeclaranteId", ent.DatosPersonalesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new BusquedaFichaXP1003DTO(reader));
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
