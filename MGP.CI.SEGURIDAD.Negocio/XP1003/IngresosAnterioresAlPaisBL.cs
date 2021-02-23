using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class IngresosAnterioresAlPaisBL : BaseBL
    {
        const string Nombre_Clase = "IngresosAnterioresAlPaisBL";
        private string m_BaseDatos = string.Empty;

        public IngresosAnterioresAlPaisBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public IngresosAnterioresAlPaisBL() { }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new IngresosAnterioresAlPaisDA(m_BaseDatos)).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(IngresosAnterioresAlPaisBE e_IngresosAnterioresAlPais)
        {
            try
            {
                IngresosAnterioresAlPaisDA o_IngresosAnterioresAlPais = new IngresosAnterioresAlPaisDA(m_BaseDatos);
                int resp = o_IngresosAnterioresAlPais.Insertar(e_IngresosAnterioresAlPais);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(IngresosAnterioresAlPaisBE e_IngresosAnterioresAlPais)
        {
            try
            {
                IngresosAnterioresAlPaisDA o_IngresosAnterioresAlPais = new IngresosAnterioresAlPaisDA(m_BaseDatos);
                int resp = o_IngresosAnterioresAlPais.Actualizar(e_IngresosAnterioresAlPais);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(IngresosAnterioresAlPaisBE e_IngresosAnterioresAlPais)
        {
            try
            {
                IngresosAnterioresAlPaisDA o_IngresosAnterioresAlPais = new IngresosAnterioresAlPaisDA(m_BaseDatos);
                int resp = o_IngresosAnterioresAlPais.Anular(e_IngresosAnterioresAlPais);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<IngresosAnterioresAlPaisBE> Consultar_Lista()
        {
            List<IngresosAnterioresAlPaisBE> lista = new List<IngresosAnterioresAlPaisBE>();
            try
            {
                IngresosAnterioresAlPaisDA o_IngresosAnterioresAlPais = new IngresosAnterioresAlPaisDA(m_BaseDatos);
                return o_IngresosAnterioresAlPais.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<IngresosAnterioresAlPaisBE> Consultar_PK(
                              int m_IngresosAnterioresAlPaisID
                              )
        {
            List<IngresosAnterioresAlPaisBE> lista = new List<IngresosAnterioresAlPaisBE>();
            try
            {
                IngresosAnterioresAlPaisDA o_IngresosAnterioresAlPais = new IngresosAnterioresAlPaisDA(m_BaseDatos);
                return o_IngresosAnterioresAlPais.Consultar_PK(
                                                            m_IngresosAnterioresAlPaisID
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
