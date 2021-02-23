using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class CentroPenitenciarioBL : BaseBL
    {
        const string Nombre_Clase = "CentroPenitenciarioBL";
        private string m_BaseDatos = string.Empty;

        public CentroPenitenciarioBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(CentroPenitenciarioBE e_CentroPenitenciario)
        {
            try
            {
                CentroPenitenciarioDA o_CentroPenitenciario = new CentroPenitenciarioDA(m_BaseDatos);
                int resp = o_CentroPenitenciario.Insertar(e_CentroPenitenciario);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(CentroPenitenciarioBE e_CentroPenitenciario)
        {
            try
            {
                CentroPenitenciarioDA o_CentroPenitenciario = new CentroPenitenciarioDA(m_BaseDatos);
                int resp = o_CentroPenitenciario.Actualizar(e_CentroPenitenciario);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(CentroPenitenciarioBE e_CentroPenitenciario)
        {
            try
            {
                CentroPenitenciarioDA o_CentroPenitenciario = new CentroPenitenciarioDA(m_BaseDatos);
                int resp = o_CentroPenitenciario.Anular(e_CentroPenitenciario);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CentroPenitenciarioBE> Consultar_Lista()
        {
            List<CentroPenitenciarioBE> lista = new List<CentroPenitenciarioBE>();
            try
            {
                CentroPenitenciarioDA o_CentroPenitenciario = new CentroPenitenciarioDA(m_BaseDatos);
                return o_CentroPenitenciario.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CentroPenitenciarioBE> Consultar_PK(
                              int m_CentroPenitenciarioId
                              )
        {
            List<CentroPenitenciarioBE> lista = new List<CentroPenitenciarioBE>();
            try
            {
                CentroPenitenciarioDA o_CentroPenitenciario = new CentroPenitenciarioDA(m_BaseDatos);
                return o_CentroPenitenciario.Consultar_PK(
                                                            m_CentroPenitenciarioId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
