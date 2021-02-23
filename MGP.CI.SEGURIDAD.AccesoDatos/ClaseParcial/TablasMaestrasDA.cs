using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public class TablasMaestrasDA : BaseDA
    {
        const string Nombre_Clase = "TablasMaestrasDA";
        private string m_BaseDatos = string.Empty;
        public TablasMaestrasDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public TablasMaestrasDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }
        public int Insertar(TablasMaestrasBE e_TablasMaestras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_TablasMaestrasInsertar", connection);
                    ParametroSP("@TablaNombre", e_TablasMaestras.TablaNombre);
                    ParametroSP("@TablaDescripcion", e_TablasMaestras.TablaDescripcion);
                    ParametroSP("@SistemaId", e_TablasMaestras.SistemaId);
                    ParametroSP("@UsuarioRegistro", e_TablasMaestras.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_TablasMaestras.NroIpRegistro);
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
        public int Anular(TablasMaestrasBE e_TablasMaestras)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_TablasMaestrasAnular", connection);
                    ParametroSP("@UsuarioModificacionRegistro", e_TablasMaestras.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_TablasMaestras.NroIpRegistro);
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
        public List<TablasMaestrasBE> Consultar_Lista()
        {
            List<TablasMaestrasBE> lista = new List<TablasMaestrasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_TablasMaestrasConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new TablasMaestrasBE(reader));
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
        public List<TablasMaestrasBE> Consultar_PK()
        {
            List<TablasMaestrasBE> lista = new List<TablasMaestrasBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_TablasMaestrasConsultar_PK", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new TablasMaestrasBE(reader));
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
        public List<TablasMaestrasBE> ListarTablasFiltradas(TablasMaestrasBE ent)
        {
            List<TablasMaestrasBE> lst = new List<TablasMaestrasBE>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_TablaMaestraConsultarTablasFiltradas", connection);
                    ParametroSP("@TablaNombre", ent.TablaNombre);
                    ParametroSP("@Descripcion", ent.TablaDescripcion);
                    ParametroSP("@SistemaId", ent.SistemaId);
                    ParametroSP("@EstadoId", ent.EstadoId);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new TablasMaestrasBE(reader));
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
