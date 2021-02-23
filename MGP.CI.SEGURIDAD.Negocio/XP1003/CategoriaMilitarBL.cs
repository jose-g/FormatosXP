using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class CategoriaMilitarBL : BaseBL
    {
        const string Nombre_Clase = "CategoriaMilitarBL";
        private string m_BaseDatos = string.Empty;

        public CategoriaMilitarBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public CategoriaMilitarBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(CategoriaMilitarBE e_CategoriaMilitar)
        {
            try
            {
                CategoriaMilitarDA o_CategoriaMilitar = new CategoriaMilitarDA(m_BaseDatos);
                int resp = o_CategoriaMilitar.Insertar(e_CategoriaMilitar);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(CategoriaMilitarBE e_CategoriaMilitar)
        {
            try
            {
                CategoriaMilitarDA o_CategoriaMilitar = new CategoriaMilitarDA(m_BaseDatos);
                int resp = o_CategoriaMilitar.Actualizar(e_CategoriaMilitar);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(CategoriaMilitarBE e_CategoriaMilitar)
        {
            try
            {
                CategoriaMilitarDA o_CategoriaMilitar = new CategoriaMilitarDA(m_BaseDatos);
                int resp = o_CategoriaMilitar.Anular(e_CategoriaMilitar);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CategoriaMilitarBE> Consultar_Lista()
        {
            List<CategoriaMilitarBE> lista = new List<CategoriaMilitarBE>();
            try
            {
                CategoriaMilitarDA o_CategoriaMilitar = new CategoriaMilitarDA(m_BaseDatos);
                return o_CategoriaMilitar.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CategoriaMilitarBE> Consultar_PK(
                              int m_CategoriaMilitarId
                              )
        {
            List<CategoriaMilitarBE> lista = new List<CategoriaMilitarBE>();
            try
            {
                CategoriaMilitarDA o_CategoriaMilitar = new CategoriaMilitarDA(m_BaseDatos);
                return o_CategoriaMilitar.Consultar_PK(
                                                            m_CategoriaMilitarId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
