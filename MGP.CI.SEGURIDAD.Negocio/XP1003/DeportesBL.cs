using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class DeportesBL : BaseBL
    {
        const string Nombre_Clase = "DeportesBL";
        private string m_BaseDatos = string.Empty;

        public DeportesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public DeportesBL() { }

        protected internal bool Insertar(DeportesBE e_Deportes)
        {
            try
            {
                DeportesDA o_Deportes = new DeportesDA(m_BaseDatos);
                int resp = o_Deportes.Insertar(e_Deportes);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(DeportesBE e_Deportes)
        {
            try
            {
                DeportesDA o_Deportes = new DeportesDA(m_BaseDatos);
                int resp = o_Deportes.Actualizar(e_Deportes);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(DeportesBE e_Deportes)
        {
            try
            {
                DeportesDA o_Deportes = new DeportesDA(m_BaseDatos);
                int resp = o_Deportes.Anular(e_Deportes);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DeportesBE> Consultar_Lista()
        {
            List<DeportesBE> lista = new List<DeportesBE>();
            try
            {
                DeportesDA o_Deportes = new DeportesDA(m_BaseDatos);
                return o_Deportes.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DeportesBE> Consultar_PK(
                              int m_DeportesId
                              )
        {
            List<DeportesBE> lista = new List<DeportesBE>();
            try
            {
                DeportesDA o_Deportes = new DeportesDA(m_BaseDatos);
                return o_Deportes.Consultar_PK(
                                                            m_DeportesId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
