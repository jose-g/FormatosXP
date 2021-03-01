using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class MotivoLugaresFrecuentadosBL : BaseBL
    {
        const string Nombre_Clase = "MotivoLugaresFrecuentadosBL";
        private string m_BaseDatos = string.Empty;

        public MotivoLugaresFrecuentadosBL() {  }

        public bool Insertar(MotivoLugaresFrecuentadosBE e_MotivoLugaresFrecuentados)
        {
            try
            {
                MotivoLugaresFrecuentadosDA o_MotivoLugaresFrecuentados = new MotivoLugaresFrecuentadosDA();
                int resp = o_MotivoLugaresFrecuentados.Insertar(e_MotivoLugaresFrecuentados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(MotivoLugaresFrecuentadosBE e_MotivoLugaresFrecuentados)
        {
            try
            {
                MotivoLugaresFrecuentadosDA o_MotivoLugaresFrecuentados = new MotivoLugaresFrecuentadosDA();
                int resp = o_MotivoLugaresFrecuentados.Actualizar(e_MotivoLugaresFrecuentados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(MotivoLugaresFrecuentadosBE e_MotivoLugaresFrecuentados)
        {
            try
            {
                MotivoLugaresFrecuentadosDA o_MotivoLugaresFrecuentados = new MotivoLugaresFrecuentadosDA();
                int resp = o_MotivoLugaresFrecuentados.Anular(e_MotivoLugaresFrecuentados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<MotivoLugaresFrecuentadosBE> Consultar_Lista()
        {
            List<MotivoLugaresFrecuentadosBE> lista = new List<MotivoLugaresFrecuentadosBE>();
            try
            {
                MotivoLugaresFrecuentadosDA o_MotivoLugaresFrecuentados = new MotivoLugaresFrecuentadosDA();
                return o_MotivoLugaresFrecuentados.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<MotivoLugaresFrecuentadosBE> Consultar_PK(
                              int m_MotivoLugaresFrecuentadosId
                              )
        {
            List<MotivoLugaresFrecuentadosBE> lista = new List<MotivoLugaresFrecuentadosBE>();
            try
            {
                MotivoLugaresFrecuentadosDA o_MotivoLugaresFrecuentados = new MotivoLugaresFrecuentadosDA();
                return o_MotivoLugaresFrecuentados.Consultar_PK(
                                                            m_MotivoLugaresFrecuentadosId
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
                MotivoLugaresFrecuentadosDA o_MotivoLugaresFrecuentados = new MotivoLugaresFrecuentadosDA();
                idMax = o_MotivoLugaresFrecuentados.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
