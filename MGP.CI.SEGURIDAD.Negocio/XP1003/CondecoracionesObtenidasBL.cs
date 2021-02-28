using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class CondecoracionesObtenidasBL : BaseBL
    {
        const string Nombre_Clase = "CondecoracionesObtenidasBL";
        private string m_BaseDatos = string.Empty;

        public CondecoracionesObtenidasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public CondecoracionesObtenidasBL() { }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new CondecoracionesObtenidasDA(m_BaseDatos)).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(CondecoracionesObtenidasBE e_CondecoracionesObtenidas)
        {
            try
            {
                CondecoracionesObtenidasDA o_CondecoracionesObtenidas = new CondecoracionesObtenidasDA(m_BaseDatos);
                int resp = o_CondecoracionesObtenidas.Insertar(e_CondecoracionesObtenidas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(CondecoracionesObtenidasBE e_CondecoracionesObtenidas)
        {
            try
            {
                CondecoracionesObtenidasDA o_CondecoracionesObtenidas = new CondecoracionesObtenidasDA(m_BaseDatos);
                int resp = o_CondecoracionesObtenidas.Actualizar(e_CondecoracionesObtenidas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(CondecoracionesObtenidasBE e_CondecoracionesObtenidas)
        {
            try
            {
                CondecoracionesObtenidasDA o_CondecoracionesObtenidas = new CondecoracionesObtenidasDA(m_BaseDatos);
                int resp = o_CondecoracionesObtenidas.Anular(e_CondecoracionesObtenidas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CondecoracionesObtenidasBE> Consultar_Lista()
        {
            List<CondecoracionesObtenidasBE> lista = new List<CondecoracionesObtenidasBE>();
            try
            {
                CondecoracionesObtenidasDA o_CondecoracionesObtenidas = new CondecoracionesObtenidasDA(m_BaseDatos);
                return o_CondecoracionesObtenidas.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CondecoracionesObtenidasBE> Consultar_PK(
                              int m_CondecoracionesObtenidasId
                              )
        {
            List<CondecoracionesObtenidasBE> lista = new List<CondecoracionesObtenidasBE>();
            try
            {
                CondecoracionesObtenidasDA o_CondecoracionesObtenidas = new CondecoracionesObtenidasDA(m_BaseDatos);
                return o_CondecoracionesObtenidas.Consultar_PK(
                                                            m_CondecoracionesObtenidasId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
