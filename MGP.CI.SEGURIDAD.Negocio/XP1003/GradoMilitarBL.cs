using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class GradoMilitarBL : BaseBL
    {
        const string Nombre_Clase = "GradoMilitarBL";
        private string m_BaseDatos = string.Empty;

        public GradoMilitarBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public GradoMilitarBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(GradoMilitarBE e_GradoMilitar)
        {
            try
            {
                GradoMilitarDA o_GradoMilitar = new GradoMilitarDA(m_BaseDatos);
                int resp = o_GradoMilitar.Insertar(e_GradoMilitar);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(GradoMilitarBE e_GradoMilitar)
        {
            try
            {
                GradoMilitarDA o_GradoMilitar = new GradoMilitarDA(m_BaseDatos);
                int resp = o_GradoMilitar.Actualizar(e_GradoMilitar);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(GradoMilitarBE e_GradoMilitar)
        {
            try
            {
                GradoMilitarDA o_GradoMilitar = new GradoMilitarDA(m_BaseDatos);
                int resp = o_GradoMilitar.Anular(e_GradoMilitar);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<GradoMilitarBE> Consultar_Lista()
        {
            List<GradoMilitarBE> lista = new List<GradoMilitarBE>();
            try
            {
                GradoMilitarDA o_GradoMilitar = new GradoMilitarDA(m_BaseDatos);
                return o_GradoMilitar.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<GradoMilitarBE> Consultar_PK(
                              int m_GradoMilitarId
                              )
        {
            List<GradoMilitarBE> lista = new List<GradoMilitarBE>();
            try
            {
                GradoMilitarDA o_GradoMilitar = new GradoMilitarDA(m_BaseDatos);
                return o_GradoMilitar.Consultar_PK(
                                                            m_GradoMilitarId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
