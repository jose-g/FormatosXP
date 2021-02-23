using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class AutoMarcasBL : BaseBL
    {
        const string Nombre_Clase = "AutoMarcasBL";
        private string m_BaseDatos = string.Empty;

        public AutoMarcasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(AutoMarcasBE e_AutoMarcas)
        {
            try
            {
                AutoMarcasDA o_AutoMarcas = new AutoMarcasDA(m_BaseDatos);
                int resp = o_AutoMarcas.Insertar(e_AutoMarcas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(AutoMarcasBE e_AutoMarcas)
        {
            try
            {
                AutoMarcasDA o_AutoMarcas = new AutoMarcasDA(m_BaseDatos);
                int resp = o_AutoMarcas.Actualizar(e_AutoMarcas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(AutoMarcasBE e_AutoMarcas)
        {
            try
            {
                AutoMarcasDA o_AutoMarcas = new AutoMarcasDA(m_BaseDatos);
                int resp = o_AutoMarcas.Anular(e_AutoMarcas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<AutoMarcasBE> Consultar_Lista()
        {
            List<AutoMarcasBE> lista = new List<AutoMarcasBE>();
            try
            {
                AutoMarcasDA o_AutoMarcas = new AutoMarcasDA(m_BaseDatos);
                return o_AutoMarcas.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<AutoMarcasBE> Consultar_PK(
                              int m_AutoMarcaId
                              )
        {
            List<AutoMarcasBE> lista = new List<AutoMarcasBE>();
            try
            {
                AutoMarcasDA o_AutoMarcas = new AutoMarcasDA(m_BaseDatos);
                return o_AutoMarcas.Consultar_PK(
                                                            m_AutoMarcaId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
