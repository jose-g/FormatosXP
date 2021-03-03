using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class FotosFamiliaresDA : BaseDA
    {
        const string Nombre_Clase = "FotosFamiliaresDA";
        private string m_BaseDatos = string.Empty;

        public FotosFamiliaresDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public FotosFamiliaresDA() {  }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_FotosFamiliaresGetMaxId", connection);


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
        public int Insertar(FotosFamiliaresBE e_FotosFamiliares)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosFamiliaresInsertar", connection);
                    ParametroSP("@FotoFamiliaresId", e_FotosFamiliares.FotoFamiliaresId);
                    ParametroSP("@FamiliarId", e_FotosFamiliares.FamiliarId);
                    ParametroSP("@FotoTipoId", e_FotosFamiliares.FotoTipoId);
                    ParametroSP("@EstadoId", e_FotosFamiliares.EstadoId);
                    ParametroSP("@Foto", e_FotosFamiliares.Foto);
                    ParametroSP("@UsuarioRegistro", e_FotosFamiliares.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_FotosFamiliares.NroIpRegistro);
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

        //public int Actualizar(FotosDeclarantesBE e_FotosDeclarantes)
        //{
        //    using (SqlConnection connection = Conectar(m_BaseDatos))
        //    {
        //        try
        //        {
        //            ComandoSP("usp_FotosDeclarantesActualizar", connection);
        //            ParametroSP("@FotoDeclaranteId", e_FotosDeclarantes.FotoDeclaranteId);
        //            ParametroSP("@DatosPersonalesId", e_FotosDeclarantes.DatosPersonalesId);
        //            ParametroSP("@FotoTipoId", e_FotosDeclarantes.FotoTipoId);
        //            ParametroSP("@EstadoId", e_FotosDeclarantes.EstadoId);
        //            ParametroSP("@Foto", e_FotosDeclarantes.Foto);
        //            ParametroSP("@UsuarioModificacionRegistro", e_FotosDeclarantes.UsuarioModificacionRegistro);
        //            ParametroSP("@NroIpRegistro", e_FotosDeclarantes.NroIpRegistro);
        //            return comando.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Dispose();
        //        }
        //    }
        //}

        //public int Anular(FotosDeclarantesBE e_FotosDeclarantes)
        //{
        //    using (SqlConnection connection = Conectar(m_BaseDatos))
        //    {
        //        try
        //        {
        //            ComandoSP("usp_FotosDeclarantesAnular", connection);
        //            ParametroSP("@FotoDeclaranteId", e_FotosDeclarantes.FotoDeclaranteId);
        //            ParametroSP("@UsuarioModificacionRegistro", e_FotosDeclarantes.UsuarioModificacionRegistro);
        //            ParametroSP("@NroIpRegistro", e_FotosDeclarantes.NroIpRegistro);
        //            return comando.ExecuteNonQuery();
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Dispose();
        //        }
        //    }
        //}

        //public List<FotosDeclarantesBE> Consultar_Lista()
        //{
        //    List<FotosDeclarantesBE> lista = new List<FotosDeclarantesBE>();
        //    using (SqlConnection connection = Conectar(m_BaseDatos))
        //    {
        //        try
        //        {
        //            ComandoSP("usp_FotosDeclarantesConsultar_Lista", connection);
        //            using (SqlDataReader reader = comando.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    lista.Add(new FotosDeclarantesBE(reader));
        //                }
        //            }
        //            return lista;
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw new Exception("Clase DataAccess: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Dispose();
        //        }
        //    }
        //}

        //public List<FotosDeclarantesBE> Consultar_PK(
        //        int m_FotoDeclaranteId)
        //{
        //    List<FotosDeclarantesBE> lista = new List<FotosDeclarantesBE>();
        //    using (SqlConnection connection = Conectar(m_BaseDatos))
        //    {
        //        try
        //        {
        //            ComandoSP("usp_FotosDeclarantesConsultar_PK", connection);
        //            ParametroSP("@FotoDeclaranteId", m_FotoDeclaranteId);
        //            using (SqlDataReader reader = comando.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    lista.Add(new FotosDeclarantesBE(reader));
        //                }
        //            }
        //            return lista;
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw new Exception("Clase DataAccess " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Dispose();
        //        }
        //    }
        //}
        public List<FotosFamiliaresBE> Consultar_FK(int m_FamiliarId)
        {
            List<FotosFamiliaresBE> lista = new List<FotosFamiliaresBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FotosFamiliaresConsultar_FK", connection);
                    ParametroSP("@FamiliarId", m_FamiliarId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FotosFamiliaresBE(reader));
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
