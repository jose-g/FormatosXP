using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;
using MGP.CI.SEGURIDAD.Entidades.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class DeclaranteBL : BaseBL
    {
        const string Nombre_Clase = "DeclaranteBL";
        private string m_BaseDatos = string.Empty;

        public DeclaranteBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public DeclaranteBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }


        public int GetMaxId()
        {

            int l = -1;
            try
            {
                l = (new DeclaranteDA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        public bool Insertar(DeclaranteBE e_Declarante)
        {
            try
            {
                DeclaranteDA o_Declarante = new DeclaranteDA(m_BaseDatos);
                int resp = o_Declarante.Insertar(e_Declarante);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(DeclaranteBE e_Declarante)
        {
            try
            {
                DeclaranteDA o_Declarante = new DeclaranteDA(m_BaseDatos);
                int resp = o_Declarante.Actualizar(e_Declarante);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DeclaranteBE e_Declarante)
        {
            try
            {
                DeclaranteDA o_Declarante = new DeclaranteDA(m_BaseDatos);
                int resp = o_Declarante.Anular(e_Declarante);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DeclaranteBE> Consultar_Lista()
        {
            List<DeclaranteBE> lista = new List<DeclaranteBE>();
            try
            {
                DeclaranteDA o_Declarante = new DeclaranteDA(m_BaseDatos);
                return o_Declarante.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DeclaranteBE> Consultar_PK(
                              int m_DeclaranteId
                              )
        {
            List<DeclaranteBE> lista = new List<DeclaranteBE>();
            try
            {
                DeclaranteDA o_Declarante = new DeclaranteDA(m_BaseDatos);
                return o_Declarante.Consultar_PK(
                                                            m_DeclaranteId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
