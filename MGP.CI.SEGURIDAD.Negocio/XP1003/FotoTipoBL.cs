using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class FotoTipoBL : BaseBL
    {
        const string Nombre_Clase = "FotoTipoBL";
        private string m_BaseDatos = string.Empty;

        public FotoTipoBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public FotoTipoBL() { }

        public bool Insertar(FotoTipoBE e_FotoTipo)
        {
            try
            {
                FotoTipoDA o_FotoTipo = new FotoTipoDA(m_BaseDatos);
                int resp = o_FotoTipo.Insertar(e_FotoTipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(FotoTipoBE e_FotoTipo)
        {
            try
            {
                FotoTipoDA o_FotoTipo = new FotoTipoDA(m_BaseDatos);
                int resp = o_FotoTipo.Actualizar(e_FotoTipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(FotoTipoBE e_FotoTipo)
        {
            try
            {
                FotoTipoDA o_FotoTipo = new FotoTipoDA(m_BaseDatos);
                int resp = o_FotoTipo.Anular(e_FotoTipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<FotoTipoBE> Consultar_Lista()
        {
            List<FotoTipoBE> lista = new List<FotoTipoBE>();
            try
            {
                FotoTipoDA o_FotoTipo = new FotoTipoDA(m_BaseDatos);
                return o_FotoTipo.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<FotoTipoBE> Consultar_PK(
                              int m_FotoTipoId
                              )
        {
            List<FotoTipoBE> lista = new List<FotoTipoBE>();
            try
            {
                FotoTipoDA o_FotoTipo = new FotoTipoDA(m_BaseDatos);
                return o_FotoTipo.Consultar_PK(
                                                            m_FotoTipoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
