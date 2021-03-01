using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGP.CI.SEGURIDAD.Entidades.X1005;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1005
{
    public class BusquedaDeclaranteXP1005DA : BaseDA
    {

        const string Nombre_Clase = "BusquedaDeclaranteDA";
        private string m_BaseDatos = string.Empty;

        public BusquedaDeclaranteXP1005DA(String BaseDatos) { m_BaseDatos = BaseDatos; }

        public BusquedaDeclaranteXP1005DA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public List<BusquedaDeclaranteXP1005DTO> ListarUsuariosFiltrados(BusquedaDeclaranteXP1005DTO ent)
        {
            List<BusquedaDeclaranteXP1005DTO> lst = new List<BusquedaDeclaranteXP1005DTO>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DeclaranteXP1005ConsultarFiltrados", connection);
                    ParametroSP("@Paterno", ent.Paterno);
                    ParametroSP("@Materno", ent.Materno);
                    ParametroSP("@Nombres", ent.Nombres);
                    ParametroSP("@TipoDocumento", ent.TipoDocumento);
                    ParametroSP("@NroDocumento", ent.NroDocumento);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new BusquedaDeclaranteXP1005DTO(reader));
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
