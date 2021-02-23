using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class PaisesBL : BaseBL
    {
        const string Nombre_Clase = "PaisesBL";
        private string m_BaseDatos = string.Empty;

        public PaisesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public PaisesBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(PaisesBE e_Paises)
        {
            try
            {
                PaisesDA o_Paises = new PaisesDA(m_BaseDatos);
                int resp = o_Paises.Insertar(e_Paises);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(PaisesBE e_Paises)
        {
            try
            {
                PaisesDA o_Paises = new PaisesDA(m_BaseDatos);
                int resp = o_Paises.Actualizar(e_Paises);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(PaisesBE e_Paises)
        {
            try
            {
                PaisesDA o_Paises = new PaisesDA(m_BaseDatos);
                int resp = o_Paises.Anular(e_Paises);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PaisesBE> Consultar_Lista()
        {
            List<PaisesBE> lista = new List<PaisesBE>();
            try
            {
                PaisesDA o_Paises = new PaisesDA(m_BaseDatos);
                return o_Paises.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PaisesBE> Consultar_PK(
                              int m_PaisId
                              )
        {
            List<PaisesBE> lista = new List<PaisesBE>();
            try
            {
                PaisesDA o_Paises = new PaisesDA(m_BaseDatos);
                return o_Paises.Consultar_PK(
                                                            m_PaisId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
