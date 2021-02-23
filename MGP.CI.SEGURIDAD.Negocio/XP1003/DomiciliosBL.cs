using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class DomiciliosBL : BaseBL
    {
        const string Nombre_Clase = "DomiciliosBL";
        private string m_BaseDatos = string.Empty;

        public DomiciliosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public DomiciliosBL() {  }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new DomiciliosDA(m_BaseDatos)).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(DomiciliosBE e_Domicilios)
        {
            try
            {
                DomiciliosDA o_Domicilios = new DomiciliosDA(m_BaseDatos);
                int resp = o_Domicilios.Insertar(e_Domicilios);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(DomiciliosBE e_Domicilios)
        {
            try
            {
                DomiciliosDA o_Domicilios = new DomiciliosDA(m_BaseDatos);
                int resp = o_Domicilios.Actualizar(e_Domicilios);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DomiciliosBE e_Domicilios)
        {
            try
            {
                DomiciliosDA o_Domicilios = new DomiciliosDA(m_BaseDatos);
                int resp = o_Domicilios.Anular(e_Domicilios);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DomiciliosBE> Consultar_Lista()
        {
            List<DomiciliosBE> lista = new List<DomiciliosBE>();
            try
            {
                DomiciliosDA o_Domicilios = new DomiciliosDA(m_BaseDatos);
                return o_Domicilios.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DomiciliosBE> Consultar_PK(
                              int m_DomicilioId
                              )
        {
            List<DomiciliosBE> lista = new List<DomiciliosBE>();
            try
            {
                DomiciliosDA o_Domicilios = new DomiciliosDA(m_BaseDatos);
                return o_Domicilios.Consultar_PK(
                                                            m_DomicilioId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
