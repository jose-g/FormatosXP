using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;
using System.Linq;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class DocumentoIdentidadTiposBL : BaseBL
    {
        const string Nombre_Clase = "DocumentoIdentidadTiposBL";
        private string m_BaseDatos = string.Empty;

        public DocumentoIdentidadTiposBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        public DocumentoIdentidadTiposBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(DocumentoIdentidadTiposBE e_DocumentoIdentidadTipos)
        {
            try
            {
                DocumentoIdentidadTiposDA o_DocumentoIdentidadTipos = new DocumentoIdentidadTiposDA(m_BaseDatos);
                int resp = o_DocumentoIdentidadTipos.Insertar(e_DocumentoIdentidadTipos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Actualizar(DocumentoIdentidadTiposBE e_DocumentoIdentidadTipos)
        {
            try
            {
                DocumentoIdentidadTiposDA o_DocumentoIdentidadTipos = new DocumentoIdentidadTiposDA(m_BaseDatos);
                int resp = o_DocumentoIdentidadTipos.Actualizar(e_DocumentoIdentidadTipos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public bool Anular(DocumentoIdentidadTiposBE e_DocumentoIdentidadBE)
        {
            try
            {
                DocumentoIdentidadTiposDA o_DocumentoIdentidadTipos = new DocumentoIdentidadTiposDA(m_BaseDatos);
                int resp = o_DocumentoIdentidadTipos.Anular(e_DocumentoIdentidadBE);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<DocumentoIdentidadTiposBE> Consultar_Lista()
        {
            List<DocumentoIdentidadTiposBE> lista = new List<DocumentoIdentidadTiposBE>();
            try
            {
                DocumentoIdentidadTiposDA o_DocumentoIdentidadTipos = new DocumentoIdentidadTiposDA(m_BaseDatos);
                return o_DocumentoIdentidadTipos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<DocumentoIdentidadTiposBE> Consultar_PK(int m_DocumentoIdentidadId)
        {
            List<DocumentoIdentidadTiposBE> lista = new List<DocumentoIdentidadTiposBE>();
            try
            {
                DocumentoIdentidadTiposDA o_DocumentoIdentidadTipos = new DocumentoIdentidadTiposDA(m_BaseDatos);
                return o_DocumentoIdentidadTipos.Consultar_PK(m_DocumentoIdentidadId);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<DocumentoIdentidadTiposBE> ListarRegistrosFiltrados(DocumentoIdentidadTiposBE ent)
        {
            List<DocumentoIdentidadTiposBE> l = new List<DocumentoIdentidadTiposBE>();
            try
            {
                l = (new DocumentoIdentidadTiposDA()).ListarRegistrosFiltrados(ent);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool CambiarEstado(int m_DocumentoIdentidadId, int estadoId, string UsuarioLogueado)
        {
            try
            {
                DocumentoIdentidadTiposBE tipoDocumentoBE = new DocumentoIdentidadTiposBE();
                tipoDocumentoBE = new DocumentoIdentidadTiposDA(m_BaseDatos).Consultar_PK(m_DocumentoIdentidadId).FirstOrDefault();

                if (tipoDocumentoBE == null)
                    return false;

                tipoDocumentoBE.EstadoId = estadoId;
                tipoDocumentoBE.UsuarioModificacionRegistro = UsuarioLogueado;

                DocumentoIdentidadTiposDA o_TipoDocumento = new DocumentoIdentidadTiposDA();
                int resp = o_TipoDocumento.CambiarEstado(tipoDocumentoBE);

                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new DocumentoIdentidadTiposDA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }





    }
}

