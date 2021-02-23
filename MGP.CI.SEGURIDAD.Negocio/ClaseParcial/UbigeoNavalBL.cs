using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;
using System.Linq;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class UbigeoNavalBL : BaseBL
    {
        const string Nombre_Clase = "UbigeoNavalBL";
        private string m_BaseDatos = string.Empty;

        public UbigeoNavalBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        public UbigeoNavalBL() { }


        public bool Insertar(UbigeoNavalBE e_UbigeoNaval)
        {
            try
            {
                UbigeoNavalDA o_UbigeoNaval = new UbigeoNavalDA(m_BaseDatos);
                int resp = o_UbigeoNaval.Insertar(e_UbigeoNaval);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(UbigeoNavalBE e_UbigeoNaval)
        {
            try
            {
                UbigeoNavalDA o_UbigeoNaval = new UbigeoNavalDA(m_BaseDatos);
                int resp = o_UbigeoNaval.Actualizar(e_UbigeoNaval);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(UbigeoNavalBE e_UbigeoNaval)
        {
            try
            {
                UbigeoNavalDA o_UbigeoNaval = new UbigeoNavalDA(m_BaseDatos);
                int resp = o_UbigeoNaval.Anular(e_UbigeoNaval);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<UbigeoNavalBE> Consultar_Lista()
        {
            List<UbigeoNavalBE> lista = new List<UbigeoNavalBE>();
            try
            {
                UbigeoNavalDA o_UbigeoNaval = new UbigeoNavalDA(m_BaseDatos);
                return o_UbigeoNaval.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<UbigeoNavalBE> Consultar_PK(int m_UbigeoNavalId)
        {
            List<UbigeoNavalBE> lista = new List<UbigeoNavalBE>();
            try
            {
                UbigeoNavalDA o_UbigeoNaval = new UbigeoNavalDA(m_BaseDatos);
                return o_UbigeoNaval.Consultar_PK(m_UbigeoNavalId);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool CambiarEstado(int m_ubigeoNavalId, int estadoId, string UsuarioLogueado)
        {
            try
            {
                UbigeoNavalBE tipoDocumentoBE = new UbigeoNavalBE();
                tipoDocumentoBE = new UbigeoNavalDA(m_BaseDatos).Consultar_PK(m_ubigeoNavalId).FirstOrDefault();

                if (tipoDocumentoBE == null)
                    return false;

                tipoDocumentoBE.EstadoId = estadoId;
                tipoDocumentoBE.UsuarioModificacionRegistro = UsuarioLogueado;

                UbigeoNavalDA o_TipoDocumento = new UbigeoNavalDA(m_BaseDatos);
                int resp = o_TipoDocumento.CambiarEstado(tipoDocumentoBE);

                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
