using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class OcupacionBL : BaseBL
    {
        const string Nombre_Clase = "OcupacionBL";
        private string m_BaseDatos = string.Empty;

        public OcupacionBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(OcupacionBE e_Ocupacion)
        {
            try
            {
                OcupacionDA o_Ocupacion = new OcupacionDA(m_BaseDatos);
                int resp = o_Ocupacion.Insertar(e_Ocupacion);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(OcupacionBE e_Ocupacion)
        {
            try
            {
                OcupacionDA o_Ocupacion = new OcupacionDA(m_BaseDatos);
                int resp = o_Ocupacion.Actualizar(e_Ocupacion);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(OcupacionBE e_Ocupacion)
        {
            try
            {
                OcupacionDA o_Ocupacion = new OcupacionDA(m_BaseDatos);
                int resp = o_Ocupacion.Anular(e_Ocupacion);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<OcupacionBE> Consultar_Lista()
        {
            List<OcupacionBE> lista = new List<OcupacionBE>();
            try
            {
                OcupacionDA o_Ocupacion = new OcupacionDA(m_BaseDatos);
                return o_Ocupacion.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<OcupacionBE> Consultar_PK(
                              int m_OcupacionId
                              )
        {
            List<OcupacionBE> lista = new List<OcupacionBE>();
            try
            {
                OcupacionDA o_Ocupacion = new OcupacionDA(m_BaseDatos);
                return o_Ocupacion.Consultar_PK(
                                                            m_OcupacionId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
