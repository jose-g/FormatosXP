using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class AutoModelosBL : BaseBL
    {
        const string Nombre_Clase = "AutoModelosBL";
        private string m_BaseDatos = string.Empty;

        public AutoModelosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public AutoModelosBL() { }


        protected internal bool Insertar(AutoModelosBE e_AutoModelos)
        {
            try
            {
                AutoModelosDA o_AutoModelos = new AutoModelosDA(m_BaseDatos);
                int resp = o_AutoModelos.Insertar(e_AutoModelos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(AutoModelosBE e_AutoModelos)
        {
            try
            {
                AutoModelosDA o_AutoModelos = new AutoModelosDA(m_BaseDatos);
                int resp = o_AutoModelos.Actualizar(e_AutoModelos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(AutoModelosBE e_AutoModelos)
        {
            try
            {
                AutoModelosDA o_AutoModelos = new AutoModelosDA(m_BaseDatos);
                int resp = o_AutoModelos.Anular(e_AutoModelos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<AutoModelosBE> Consultar_Lista()
        {
            List<AutoModelosBE> lista = new List<AutoModelosBE>();
            try
            {
                AutoModelosDA o_AutoModelos = new AutoModelosDA(m_BaseDatos);
                return o_AutoModelos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<AutoModelosBE> Consultar_PK(
                              int m_AutoModeloId
                              )
        {
            List<AutoModelosBE> lista = new List<AutoModelosBE>();
            try
            {
                AutoModelosDA o_AutoModelos = new AutoModelosDA(m_BaseDatos);
                return o_AutoModelos.Consultar_PK(
                                                            m_AutoModeloId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
