using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class IngresosAlPaisBL : BaseBL
    {
        const string Nombre_Clase = "IngresosAlPaisBL";
        private string m_BaseDatos = string.Empty;

        public IngresosAlPaisBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public IngresosAlPaisBL() {  }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new IngresosAlPaisDA(m_BaseDatos)).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(IngresosAlPaisBE e_IngresosAlPais)
        {
            try
            {
                IngresosAlPaisDA o_IngresosAlPais = new IngresosAlPaisDA(m_BaseDatos);
                int resp = o_IngresosAlPais.Insertar(e_IngresosAlPais);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(IngresosAlPaisBE e_IngresosAlPais)
        {
            try
            {
                IngresosAlPaisDA o_IngresosAlPais = new IngresosAlPaisDA(m_BaseDatos);
                int resp = o_IngresosAlPais.Actualizar(e_IngresosAlPais);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(IngresosAlPaisBE e_IngresosAlPais)
        {
            try
            {
                IngresosAlPaisDA o_IngresosAlPais = new IngresosAlPaisDA(m_BaseDatos);
                int resp = o_IngresosAlPais.Anular(e_IngresosAlPais);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<IngresosAlPaisBE> Consultar_Lista()
        {
            List<IngresosAlPaisBE> lista = new List<IngresosAlPaisBE>();
            try
            {
                IngresosAlPaisDA o_IngresosAlPais = new IngresosAlPaisDA(m_BaseDatos);
                return o_IngresosAlPais.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<IngresosAlPaisBE> Consultar_PK(
                              int m_IngresoPaisId
                              )
        {
            List<IngresosAlPaisBE> lista = new List<IngresosAlPaisBE>();
            try
            {
                IngresosAlPaisDA o_IngresosAlPais = new IngresosAlPaisDA(m_BaseDatos);
                return o_IngresosAlPais.Consultar_PK(
                                                            m_IngresoPaisId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<IngresosAlPaisBE> Consultar_FK(
                      int m_Fk_Id
                      )
        {
            List<IngresosAlPaisBE> lista = new List<IngresosAlPaisBE>();
            try
            {
                IngresosAlPaisDA o_IngresosAlPais = new IngresosAlPaisDA(m_BaseDatos);
                return o_IngresosAlPais.Consultar_FK(
                                                            m_Fk_Id
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
    }
}
