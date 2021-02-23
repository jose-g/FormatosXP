using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class FichasBL : BaseBL
    {
        const string Nombre_Clase = "FichasBL";
        private string m_BaseDatos = string.Empty;

        public FichasBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public FichasBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public int GetMaxId()
        {

            int l = -1;
            try
            {
                l = (new FichasDA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }

        public  bool Insertar(FichasBE e_Fichas)
        {
            try
            {
                FichasDA o_Fichas = new FichasDA(m_BaseDatos);
                int resp = o_Fichas.Insertar(e_Fichas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(FichasBE e_Fichas)
        {
            try
            {
                FichasDA o_Fichas = new FichasDA(m_BaseDatos);
                int resp = o_Fichas.Actualizar(e_Fichas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(FichasBE e_Fichas)
        {
            try
            {
                FichasDA o_Fichas = new FichasDA(m_BaseDatos);
                int resp = o_Fichas.Anular(e_Fichas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<FichasBE> Consultar_Lista()
        {
            List<FichasBE> lista = new List<FichasBE>();
            try
            {
                FichasDA o_Fichas = new FichasDA(m_BaseDatos);
                return o_Fichas.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<FichasBE> Consultar_PK(
                              int m_FichaId
                              )
        {
            List<FichasBE> lista = new List<FichasBE>();
            try
            {
                FichasDA o_Fichas = new FichasDA(m_BaseDatos);
                return o_Fichas.Consultar_PK(
                                                            m_FichaId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
