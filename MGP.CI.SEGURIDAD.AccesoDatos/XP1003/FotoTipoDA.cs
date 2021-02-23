using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class FotoTipoDA : BaseDA
    {
        const string Nombre_Clase = "FotoTipoDA";
        private string m_BaseDatos = string.Empty;

        public FotoTipoDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public FotoTipoDA() { }

        public int Insertar(FotoTipoBE e_FotoTipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotoTipoInsertar", connection);
                    ParametroSP("@FotoTipoId", e_FotoTipo.FotoTipoId);
                    ParametroSP("@Descripcion", e_FotoTipo.Descripcion);
                    ParametroSP("@EstadoId", e_FotoTipo.EstadoId);
                    ParametroSP("@UsuarioRegistro", e_FotoTipo.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_FotoTipo.NroIpRegistro);
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

        public int Actualizar(FotoTipoBE e_FotoTipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotoTipoActualizar", connection);
                    ParametroSP("@FotoTipoId", e_FotoTipo.FotoTipoId);
                    ParametroSP("@Descripcion", e_FotoTipo.Descripcion);
                    ParametroSP("@EstadoId", e_FotoTipo.EstadoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_FotoTipo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_FotoTipo.NroIpRegistro);
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

        public int Anular(FotoTipoBE e_FotoTipo)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotoTipoAnular", connection);
                    ParametroSP("@FotoTipoId", e_FotoTipo.FotoTipoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_FotoTipo.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_FotoTipo.NroIpRegistro);
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

        public List<FotoTipoBE> Consultar_Lista()
        {
            List<FotoTipoBE> lista = new List<FotoTipoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotoTipoConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FotoTipoBE(reader));
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

        public List<FotoTipoBE> Consultar_PK(
                int m_FotoTipoId)
        {
            List<FotoTipoBE> lista = new List<FotoTipoBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotoTipoConsultar_PK", connection);
                    ParametroSP("@FotoTipoId", m_FotoTipoId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FotoTipoBE(reader));
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
