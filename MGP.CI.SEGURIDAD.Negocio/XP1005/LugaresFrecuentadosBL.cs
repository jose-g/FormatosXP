using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class LugaresFrecuentadosBL : BaseBL
    {
        const string Nombre_Clase = "LugaresFrecuentadosBL";
        private string m_BaseDatos = string.Empty;

        public LugaresFrecuentadosBL() {  }

        public bool Insertar(LugaresFrecuentadosBE e_LugaresFrecuentados)
        {
            try
            {
                LugaresFrecuentadosDA o_LugaresFrecuentados = new LugaresFrecuentadosDA();
                int resp = o_LugaresFrecuentados.Insertar(e_LugaresFrecuentados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(LugaresFrecuentadosBE e_LugaresFrecuentados)
        {
            try
            {
                LugaresFrecuentadosDA o_LugaresFrecuentados = new LugaresFrecuentadosDA();
                int resp = o_LugaresFrecuentados.Actualizar(e_LugaresFrecuentados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(LugaresFrecuentadosBE e_LugaresFrecuentados)
        {
            try
            {
                LugaresFrecuentadosDA o_LugaresFrecuentados = new LugaresFrecuentadosDA();
                int resp = o_LugaresFrecuentados.Anular(e_LugaresFrecuentados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<LugaresFrecuentadosBE> Consultar_Lista()
        {
            List<LugaresFrecuentadosBE> lista = new List<LugaresFrecuentadosBE>();
            try
            {
                LugaresFrecuentadosDA o_LugaresFrecuentados = new LugaresFrecuentadosDA();
                return o_LugaresFrecuentados.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<LugaresFrecuentadosBE> Consultar_PK(
                              int m_LugaresFrecuentadosId
                              )
        {
            List<LugaresFrecuentadosBE> lista = new List<LugaresFrecuentadosBE>();
            try
            {
                LugaresFrecuentadosDA o_LugaresFrecuentados = new LugaresFrecuentadosDA();
                return o_LugaresFrecuentados.Consultar_PK(
                                                            m_LugaresFrecuentadosId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public int GetMaxId()
        {
            int idMax = -1;
            try
            {
                LugaresFrecuentadosDA o_LugaresFrecuentados = new LugaresFrecuentadosDA();
                idMax = o_LugaresFrecuentados.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
