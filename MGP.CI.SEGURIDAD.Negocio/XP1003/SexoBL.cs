using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class SexoBL : BaseBL
    {
        const string Nombre_Clase = "SexoBL";
        private string m_BaseDatos = string.Empty;

        public SexoBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public SexoBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(SexoBE e_Sexo)
        {
            try
            {
                SexoDA o_Sexo = new SexoDA(m_BaseDatos);
                int resp = o_Sexo.Insertar(e_Sexo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(SexoBE e_Sexo)
        {
            try
            {
                SexoDA o_Sexo = new SexoDA(m_BaseDatos);
                int resp = o_Sexo.Actualizar(e_Sexo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(SexoBE e_Sexo)
        {
            try
            {
                SexoDA o_Sexo = new SexoDA(m_BaseDatos);
                int resp = o_Sexo.Anular(e_Sexo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<SexoBE> Consultar_Lista()
        {
            List<SexoBE> lista = new List<SexoBE>();
            try
            {
                SexoDA o_Sexo = new SexoDA(m_BaseDatos);
                return o_Sexo.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<SexoBE> Consultar_PK(
                              int m_SexoId
                              )
        {
            List<SexoBE> lista = new List<SexoBE>();
            try
            {
                SexoDA o_Sexo = new SexoDA(m_BaseDatos);
                return o_Sexo.Consultar_PK(
                                                            m_SexoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
