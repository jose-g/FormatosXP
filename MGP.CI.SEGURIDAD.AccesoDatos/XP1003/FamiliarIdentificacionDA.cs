using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.AccesoDatos.XP1003
{
    [Serializable]
    public partial class FamiliarIdentificacionDA : BaseDA
    {
        const string Nombre_Clase = "FamiliarIdentificacionDA";
        private string m_BaseDatos = string.Empty;

        public FamiliarIdentificacionDA(String BaseDatos) { m_BaseDatos = BaseDatos; }
        public FamiliarIdentificacionDA() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_FamiliarIdentificacionGetMaxId", connection);


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
        public int Insertar(FamiliarIdentificacionBE e_FamiliarIdentificaciones)
        {
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FamiliarIdentificacionInsertar", connection);
                    ParametroSP("@FamiliarIdentificacionId", e_FamiliarIdentificaciones.FamiliarIdentificacionId);
                    ParametroSP("@DocumentoIdentidadTipoId", e_FamiliarIdentificaciones.DocumentoIdentidadTipoId);
                    ParametroSP("@FamiliarNumeroDocumento", e_FamiliarIdentificaciones.FamiliarNumeroDocumento);
                    ParametroSP("@EstadoId", e_FamiliarIdentificaciones.EstadoId);
                    ParametroSP("@FamiliarId", e_FamiliarIdentificaciones.FamiliarId);
                    ParametroSP("@UsuarioRegistro", e_FamiliarIdentificaciones.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_FamiliarIdentificaciones.NroIpRegistro);
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

        //public int Actualizar(DeclaranteIdentificacionesBE e_DeclaranteIdentificaciones)
        //{
        //    using (SqlConnection connection = Conectar(m_BaseDatos))
        //    {
        //        try
        //        {
        //            ComandoSP("usp_DeclaranteIdentificacionesActualizar", connection);
        //            ParametroSP("@DeclaranteIdentificacionId", e_DeclaranteIdentificaciones.DeclaranteIdentificacionId);
        //            ParametroSP("@DocumentoIdentidadTipoId", e_DeclaranteIdentificaciones.DocumentoIdentidadTipoId);
        //            ParametroSP("@DeclaranteNumeroDocumento", e_DeclaranteIdentificaciones.DeclaranteNumeroDocumento);
        //            ParametroSP("@EstadoId", e_DeclaranteIdentificaciones.EstadoId);
        //            ParametroSP("@DatosPersonalesId", e_DeclaranteIdentificaciones.DatosPersonalesId);
        //            ParametroSP("@UsuarioModificacionRegistro", e_DeclaranteIdentificaciones.UsuarioModificacionRegistro);
        //            ParametroSP("@NroIpRegistro", e_DeclaranteIdentificaciones.NroIpRegistro);
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

        //public int Anular(DeclaranteIdentificacionesBE e_DeclaranteIdentificaciones)
        //{
        //    using (SqlConnection connection = Conectar(m_BaseDatos))
        //    {
        //        try
        //        {
        //            ComandoSP("usp_DeclaranteIdentificacionesAnular", connection);
        //            ParametroSP("@DeclaranteIdentificacionId", e_DeclaranteIdentificaciones.DeclaranteIdentificacionId);
        //            ParametroSP("@UsuarioModificacionRegistro", e_DeclaranteIdentificaciones.UsuarioModificacionRegistro);
        //            ParametroSP("@NroIpRegistro", e_DeclaranteIdentificaciones.NroIpRegistro);
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

        //public List<DeclaranteIdentificacionesBE> Consultar_Lista()
        //{
        //    List<DeclaranteIdentificacionesBE> lista = new List<DeclaranteIdentificacionesBE>();
        //    using (SqlConnection connection = Conectar(m_BaseDatos))
        //    {
        //        try
        //        {
        //            ComandoSP("usp_DeclaranteIdentificacionesConsultar_Lista", connection);
        //            using (SqlDataReader reader = comando.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    lista.Add(new DeclaranteIdentificacionesBE(reader));
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

        //public List<DeclaranteIdentificacionesBE> Consultar_PK(
        //        int m_DeclaranteIdentificacionId)
        //{
        //    List<DeclaranteIdentificacionesBE> lista = new List<DeclaranteIdentificacionesBE>();
        //    using (SqlConnection connection = Conectar(m_BaseDatos))
        //    {
        //        try
        //        {
        //            ComandoSP("usp_DeclaranteIdentificacionesConsultar_PK", connection);
        //            ParametroSP("@DeclaranteIdentificacionId", m_DeclaranteIdentificacionId);
        //            using (SqlDataReader reader = comando.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    lista.Add(new DeclaranteIdentificacionesBE(reader));
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
        public List<FamiliarIdentificacionBE> Consultar_FK(int m_FamiliarId)
        {
            List<FamiliarIdentificacionBE> lista = new List<FamiliarIdentificacionBE>();
            using (SqlConnection connection = Conectar(m_BaseDatos))
            {
                try
                {
                    ComandoSP("usp_FamiliarIdentificacionConsultar_FK", connection);
                    ParametroSP("@FamiliarId", m_FamiliarId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FamiliarIdentificacionBE(reader));
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
