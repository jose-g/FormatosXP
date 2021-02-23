using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class EstadoCivilBL : BaseBL
    {
        const string Nombre_Clase = "EstadoCivilBL";
        private string m_BaseDatos = string.Empty;

        public EstadoCivilBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public EstadoCivilBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(EstadoCivilBE e_EstadoCivil)
        {
            try
            {
                EstadoCivilDA o_EstadoCivil = new EstadoCivilDA(m_BaseDatos);
                int resp = o_EstadoCivil.Insertar(e_EstadoCivil);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(EstadoCivilBE e_EstadoCivil)
        {
            try
            {
                EstadoCivilDA o_EstadoCivil = new EstadoCivilDA(m_BaseDatos);
                int resp = o_EstadoCivil.Actualizar(e_EstadoCivil);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(EstadoCivilBE e_EstadoCivil)
        {
            try
            {
                EstadoCivilDA o_EstadoCivil = new EstadoCivilDA(m_BaseDatos);
                int resp = o_EstadoCivil.Anular(e_EstadoCivil);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EstadoCivilBE> Consultar_Lista()
        {
            List<EstadoCivilBE> lista = new List<EstadoCivilBE>();
            try
            {
                EstadoCivilDA o_EstadoCivil = new EstadoCivilDA(m_BaseDatos);
                return o_EstadoCivil.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EstadoCivilBE> Consultar_PK(
                              int m_EstadoCivilId
                              )
        {
            List<EstadoCivilBE> lista = new List<EstadoCivilBE>();
            try
            {
                EstadoCivilDA o_EstadoCivil = new EstadoCivilDA(m_BaseDatos);
                return o_EstadoCivil.Consultar_PK(
                                                            m_EstadoCivilId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
