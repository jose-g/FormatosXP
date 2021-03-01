using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class CargosDesempenadosBL : BaseBL
    {
        const string Nombre_Clase = "CargosDesempenadosBL";
        private string m_BaseDatos = string.Empty;

        public CargosDesempenadosBL() {  }

        public bool Insertar(CargosDesempenadosBE e_CargosDesempenados)
        {
            try
            {
                CargosDesempenadosDA o_CargosDesempenados = new CargosDesempenadosDA();
                int resp = o_CargosDesempenados.Insertar(e_CargosDesempenados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(CargosDesempenadosBE e_CargosDesempenados)
        {
            try
            {
                CargosDesempenadosDA o_CargosDesempenados = new CargosDesempenadosDA();
                int resp = o_CargosDesempenados.Actualizar(e_CargosDesempenados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(CargosDesempenadosBE e_CargosDesempenados)
        {
            try
            {
                CargosDesempenadosDA o_CargosDesempenados = new CargosDesempenadosDA();
                int resp = o_CargosDesempenados.Anular(e_CargosDesempenados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CargosDesempenadosBE> Consultar_Lista()
        {
            List<CargosDesempenadosBE> lista = new List<CargosDesempenadosBE>();
            try
            {
                CargosDesempenadosDA o_CargosDesempenados = new CargosDesempenadosDA();
                return o_CargosDesempenados.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CargosDesempenadosBE> Consultar_PK(
                              int m_CargosDesempenadosId
                              )
        {
            List<CargosDesempenadosBE> lista = new List<CargosDesempenadosBE>();
            try
            {
                CargosDesempenadosDA o_CargosDesempenados = new CargosDesempenadosDA();
                return o_CargosDesempenados.Consultar_PK(
                                                            m_CargosDesempenadosId
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
                CargosDesempenadosDA o_CargosDesempenados = new CargosDesempenadosDA();
                idMax = o_CargosDesempenados.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
