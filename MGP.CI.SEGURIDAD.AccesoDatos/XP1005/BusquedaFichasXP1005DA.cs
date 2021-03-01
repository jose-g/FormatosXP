using MGP.CI.SEGURIDAD.Entidades.XP1005;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1005
{
    public class BusquedaFichasXP1005DA : BaseDA
    {
        const string Nombre_Clase = "BusquedaDeclaranteDA";
        private string m_BaseDatos = string.Empty;

        public BusquedaFichasXP1005DA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public BusquedaFichasXP1005DA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public List<BusquedaFichasXP1005BE> ListarFichasFromDeclarante(int DeclaranteId)
        {
            List<BusquedaFichasXP1005BE> lst = new List<BusquedaFichasXP1005BE>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_FichasXP1005ConsultarFichas", connection);
                    ParametroSP("@DeclaranteId", DeclaranteId);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new BusquedaFichasXP1005BE(reader));
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
