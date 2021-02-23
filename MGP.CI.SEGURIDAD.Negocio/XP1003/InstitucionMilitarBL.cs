using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class InstitucionMilitarBL : BaseBL
    {
        const string Nombre_Clase = "InstitucionMilitarBL";
        private string m_BaseDatos = string.Empty;

        public InstitucionMilitarBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public InstitucionMilitarBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(InstitucionMilitarBE e_InstitucionMilitar)
        {
            try
            {
                InstitucionMilitarDA o_InstitucionMilitar = new InstitucionMilitarDA(m_BaseDatos);
                int resp = o_InstitucionMilitar.Insertar(e_InstitucionMilitar);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(InstitucionMilitarBE e_InstitucionMilitar)
        {
            try
            {
                InstitucionMilitarDA o_InstitucionMilitar = new InstitucionMilitarDA(m_BaseDatos);
                int resp = o_InstitucionMilitar.Actualizar(e_InstitucionMilitar);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(InstitucionMilitarBE e_InstitucionMilitar)
        {
            try
            {
                InstitucionMilitarDA o_InstitucionMilitar = new InstitucionMilitarDA(m_BaseDatos);
                int resp = o_InstitucionMilitar.Anular(e_InstitucionMilitar);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<InstitucionMilitarBE> Consultar_Lista()
        {
            List<InstitucionMilitarBE> lista = new List<InstitucionMilitarBE>();
            try
            {
                InstitucionMilitarDA o_InstitucionMilitar = new InstitucionMilitarDA(m_BaseDatos);
                return o_InstitucionMilitar.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<InstitucionMilitarBE> Consultar_PK(
                              int m_InstitucionMilitarId
                              )
        {
            List<InstitucionMilitarBE> lista = new List<InstitucionMilitarBE>();
            try
            {
                InstitucionMilitarDA o_InstitucionMilitar = new InstitucionMilitarDA(m_BaseDatos);
                return o_InstitucionMilitar.Consultar_PK(
                                                            m_InstitucionMilitarId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
