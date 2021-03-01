using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class NivelesBuenoBL : BaseBL
    {
        const string Nombre_Clase = "NivelesBuenoBL";
        private string m_BaseDatos = string.Empty;

        public NivelesBuenoBL() {  }

        public bool Insertar(NivelesBuenoBE e_NivelesBueno)
        {
            try
            {
                NivelesBuenoDA o_NivelesBueno = new NivelesBuenoDA();
                int resp = o_NivelesBueno.Insertar(e_NivelesBueno);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(NivelesBuenoBE e_NivelesBueno)
        {
            try
            {
                NivelesBuenoDA o_NivelesBueno = new NivelesBuenoDA();
                int resp = o_NivelesBueno.Actualizar(e_NivelesBueno);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(NivelesBuenoBE e_NivelesBueno)
        {
            try
            {
                NivelesBuenoDA o_NivelesBueno = new NivelesBuenoDA();
                int resp = o_NivelesBueno.Anular(e_NivelesBueno);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<NivelesBuenoBE> Consultar_Lista()
        {
            List<NivelesBuenoBE> lista = new List<NivelesBuenoBE>();
            try
            {
                NivelesBuenoDA o_NivelesBueno = new NivelesBuenoDA();
                return o_NivelesBueno.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<NivelesBuenoBE> Consultar_PK(
                              int m_NivelesBuenoId
                              )
        {
            List<NivelesBuenoBE> lista = new List<NivelesBuenoBE>();
            try
            {
                NivelesBuenoDA o_NivelesBueno = new NivelesBuenoDA();
                return o_NivelesBueno.Consultar_PK(
                                                            m_NivelesBuenoId
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
                NivelesBuenoDA o_NivelesBueno = new NivelesBuenoDA();
                idMax = o_NivelesBueno.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
