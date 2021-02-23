using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.AccesoDatos
{
    [Serializable]
    public partial class DocumentoIdentidadTiposDA : BaseDA
    {
        const string Nombre_Clase = "DocumentoIdentidadTiposDA";
        private string m_BaseDatos = string.Empty;

        public DocumentoIdentidadTiposDA(String BaseDatos) {
            m_BaseDatos = BaseDatos;
        }
        public DocumentoIdentidadTiposDA() {
            m_BaseDatos = "DIN_XP_SEGURIDAD";
        }
        public int Insertar(DocumentoIdentidadTiposBE e_DocumentoIdentidadTipos)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DocumentoIdentidadTiposInsertar", connection);
                    ParametroSP("@CodigoDocumento", e_DocumentoIdentidadTipos.CodigoDocumento);
                    ParametroSP("@Descripcion", e_DocumentoIdentidadTipos.Descripcion);
                    ParametroSP("@UsuarioRegistro", e_DocumentoIdentidadTipos.UsuarioRegistro);
                    ParametroSP("@NroIpRegistro", e_DocumentoIdentidadTipos.NroIpRegistro);
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
        public int Actualizar(DocumentoIdentidadTiposBE e_DocumentoIdentidadTipos)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DocumentoIdentidadTiposActualizar", connection);
                    ParametroSP("@DocumentoIdentidadId", e_DocumentoIdentidadTipos.DocumentoIdentidadTipoId);
                    ParametroSP("@CodigoDocumento", e_DocumentoIdentidadTipos.CodigoDocumento);
                    ParametroSP("@Descripcion", e_DocumentoIdentidadTipos.Descripcion);
                    ParametroSP("@UsuarioModificacionRegistro", e_DocumentoIdentidadTipos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DocumentoIdentidadTipos.NroIpRegistro);
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
        public int Anular(DocumentoIdentidadTiposBE e_DocumentoIdentidadTipos)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DocumentoIdentidadTiposAnular", connection);
                    ParametroSP("@DocumentoIdentidadId", e_DocumentoIdentidadTipos.DocumentoIdentidadTipoId);
                    ParametroSP("@UsuarioModificacionRegistro", e_DocumentoIdentidadTipos.UsuarioModificacionRegistro);
                    ParametroSP("@NroIpRegistro", e_DocumentoIdentidadTipos.NroIpRegistro);
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
        public List<DocumentoIdentidadTiposBE> Consultar_Lista()
        {
            List<DocumentoIdentidadTiposBE> lista = new List<DocumentoIdentidadTiposBE>();
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DocumentoIdentidadTiposConsultar_Lista", connection);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DocumentoIdentidadTiposBE(reader));
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
        public List<DocumentoIdentidadTiposBE> Consultar_PK(int m_DocumentoIdentidadId)
        {
            List<DocumentoIdentidadTiposBE> lista = new List<DocumentoIdentidadTiposBE>();
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DocumentoIdentidadTiposConsultar_PK", connection);
                    ParametroSP("@DocumentoIdentidadId", m_DocumentoIdentidadId);
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DocumentoIdentidadTiposBE(reader));
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
        public List<DocumentoIdentidadTiposBE> ListarRegistrosFiltrados(DocumentoIdentidadTiposBE ent)
        {
            List<DocumentoIdentidadTiposBE> lst = new List<DocumentoIdentidadTiposBE>();

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DocumentoIdentidadTIposConsultarRegistrosFiltrados", connection);
                    ParametroSP("@Descripcion", ent.Descripcion);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lst.Add(new DocumentoIdentidadTiposBE(reader));
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
        public int CambiarEstado(DocumentoIdentidadTiposBE e_documentoIdentidadTiposBE)
        {
            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DocumentoIdentidadTIposCambiarEstado", connection);
                    ParametroSP("@Codigo", e_documentoIdentidadTiposBE.CodigoDocumento);
                    ParametroSP("@UsuarioModificacionRegistro", e_documentoIdentidadTiposBE.UsuarioModificacionRegistro);
                    ParametroSP("@EstadoId", e_documentoIdentidadTiposBE.EstadoId);
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
        public int GetMaxId()
        {
            int maxId = -1;

            using (SqlConnection connection = Conectar())
            {
                try
                {
                    ComandoSP("usp_DocumentoIdentidadTiposGetMaxId", connection);


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




    }
}
