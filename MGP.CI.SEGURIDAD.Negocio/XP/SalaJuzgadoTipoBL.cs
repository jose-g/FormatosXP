using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class SalaJuzgadoTipoBL : BaseBL
    {
        const string Nombre_Clase = "SalaJuzgadoTipoBL";
        private string m_BaseDatos = string.Empty;

        public SalaJuzgadoTipoBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(SalaJuzgadoTipoBE e_SalaJuzgadoTipo)
        {
            try
            {
                SalaJuzgadoTipoDA o_SalaJuzgadoTipo = new SalaJuzgadoTipoDA(m_BaseDatos);
                int resp = o_SalaJuzgadoTipo.Insertar(e_SalaJuzgadoTipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(SalaJuzgadoTipoBE e_SalaJuzgadoTipo)
        {
            try
            {
                SalaJuzgadoTipoDA o_SalaJuzgadoTipo = new SalaJuzgadoTipoDA(m_BaseDatos);
                int resp = o_SalaJuzgadoTipo.Actualizar(e_SalaJuzgadoTipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(SalaJuzgadoTipoBE e_SalaJuzgadoTipo)
        {
            try
            {
                SalaJuzgadoTipoDA o_SalaJuzgadoTipo = new SalaJuzgadoTipoDA(m_BaseDatos);
                int resp = o_SalaJuzgadoTipo.Anular(e_SalaJuzgadoTipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<SalaJuzgadoTipoBE> Consultar_Lista()
        {
            List<SalaJuzgadoTipoBE> lista = new List<SalaJuzgadoTipoBE>();
            try
            {
                SalaJuzgadoTipoDA o_SalaJuzgadoTipo = new SalaJuzgadoTipoDA(m_BaseDatos);
                return o_SalaJuzgadoTipo.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<SalaJuzgadoTipoBE> Consultar_PK(
                              int m_SalaJuzgadoTipoId
                              )
        {
            List<SalaJuzgadoTipoBE> lista = new List<SalaJuzgadoTipoBE>();
            try
            {
                SalaJuzgadoTipoDA o_SalaJuzgadoTipo = new SalaJuzgadoTipoDA(m_BaseDatos);
                return o_SalaJuzgadoTipo.Consultar_PK(
                                                            m_SalaJuzgadoTipoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
