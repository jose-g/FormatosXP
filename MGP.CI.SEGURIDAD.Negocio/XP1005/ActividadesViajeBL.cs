using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class ActividadesViajeBL : BaseBL
    {
        const string Nombre_Clase = "ActividadesViajeBL";
        private string m_BaseDatos = string.Empty;

        public ActividadesViajeBL() {  }

        public bool Insertar(ActividadesViajeBE e_ActividadesViaje)
        {
            try
            {
                ActividadesViajeDA o_ActividadesViaje = new ActividadesViajeDA();
                int resp = o_ActividadesViaje.Insertar(e_ActividadesViaje);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(ActividadesViajeBE e_ActividadesViaje)
        {
            try
            {
                ActividadesViajeDA o_ActividadesViaje = new ActividadesViajeDA();
                int resp = o_ActividadesViaje.Actualizar(e_ActividadesViaje);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(ActividadesViajeBE e_ActividadesViaje)
        {
            try
            {
                ActividadesViajeDA o_ActividadesViaje = new ActividadesViajeDA();
                int resp = o_ActividadesViaje.Anular(e_ActividadesViaje);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ActividadesViajeBE> Consultar_Lista()
        {
            List<ActividadesViajeBE> lista = new List<ActividadesViajeBE>();
            try
            {
                ActividadesViajeDA o_ActividadesViaje = new ActividadesViajeDA();
                return o_ActividadesViaje.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ActividadesViajeBE> Consultar_PK(
                              int m_ActividadesViajeId
                              )
        {
            List<ActividadesViajeBE> lista = new List<ActividadesViajeBE>();
            try
            {
                ActividadesViajeDA o_ActividadesViaje = new ActividadesViajeDA();
                return o_ActividadesViaje.Consultar_PK(
                                                            m_ActividadesViajeId
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
                ActividadesViajeDA o_ActividadesViaje = new ActividadesViajeDA();
                idMax = o_ActividadesViaje.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
