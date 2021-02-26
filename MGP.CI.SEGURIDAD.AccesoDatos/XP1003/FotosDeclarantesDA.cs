using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class FotosDeclarantesDA : BaseDA
    {
        const string Nombre_Clase = "FotosDeclarantesDA";
        private string m_BaseDatos = string.Empty;

        public FotosDeclarantesDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public FotosDeclarantesDA() {  }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_FotoDeclaranteGetMaxId", connection);


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
        public int Insertar(FotosDeclarantesBE e_FotosDeclarantes)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosDeclarantesInsertar", connection);
                    ParametroSP("@FotoDeclaranteId", e_FotosDeclarantes.FotoDeclaranteId);
                    ParametroSP("@DatosPersonalesId", e_FotosDeclarantes.DatosPersonalesId);
                    ParametroSP("@FotoTipoId", e_FotosDeclarantes.FotoTipoId);
                    ParametroSP("@EstadoId", e_FotosDeclarantes.EstadoId);
                    ParametroSP("@Foto", e_FotosDeclarantes.Foto);
                    ParametroSP("@UsuarioRegistro", e_FotosDeclarantes.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_FotosDeclarantes.NroIpRegistro);
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

        public int Actualizar(FotosDeclarantesBE e_FotosDeclarantes)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosDeclarantesActualizar", connection);
                    ParametroSP("@FotoDeclaranteId", e_FotosDeclarantes.FotoDeclaranteId);
                    ParametroSP("@DatosPersonalesId", e_FotosDeclarantes.DatosPersonalesId);
                    ParametroSP("@FotoTipoId", e_FotosDeclarantes.FotoTipoId);
                    ParametroSP("@EstadoId", e_FotosDeclarantes.EstadoId);
                    ParametroSP("@Foto", e_FotosDeclarantes.Foto);
                    ParametroSP("@UsuarioModificacionRegistro", e_FotosDeclarantes.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_FotosDeclarantes.NroIpRegistro);
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

        public int Anular(FotosDeclarantesBE e_FotosDeclarantes)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosDeclarantesAnular", connection);
                    ParametroSP("@FotoDeclaranteId", e_FotosDeclarantes.FotoDeclaranteId);
                    ParametroSP("@UsuarioModificacionRegistro", e_FotosDeclarantes.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_FotosDeclarantes.NroIpRegistro);
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

        public List<FotosDeclarantesBE> Consultar_Lista()
        {
            List<FotosDeclarantesBE> lista = new List<FotosDeclarantesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosDeclarantesConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FotosDeclarantesBE(reader));
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

        public List<FotosDeclarantesBE> Consultar_PK(
                int m_FotoDeclaranteId)
        {
            List<FotosDeclarantesBE> lista = new List<FotosDeclarantesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosDeclarantesConsultar_PK", connection);
                    ParametroSP("@FotoDeclaranteId", m_FotoDeclaranteId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FotosDeclarantesBE(reader));
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
        public List<FotosDeclarantesBE> Consultar_FK(
                int m_DatosPersonalesId)
        {
            List<FotosDeclarantesBE> lista = new List<FotosDeclarantesBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosDeclarantesConsultar_FK", connection);
                    ParametroSP("@DatosPersonalesId", m_DatosPersonalesId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FotosDeclarantesBE(reader));
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
