using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class MotivosViajeBL : BaseBL
    {
        const string Nombre_Clase = "MotivosViajeBL";
        private string m_BaseDatos = string.Empty;

        public MotivosViajeBL() {  }

        public bool Insertar(MotivosViajeBE e_MotivosViaje)
        {
            try
            {
                MotivosViajeDA o_MotivosViaje = new MotivosViajeDA();
                int resp = o_MotivosViaje.Insertar(e_MotivosViaje);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(MotivosViajeBE e_MotivosViaje)
        {
            try
            {
                MotivosViajeDA o_MotivosViaje = new MotivosViajeDA();
                int resp = o_MotivosViaje.Actualizar(e_MotivosViaje);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(MotivosViajeBE e_MotivosViaje)
        {
            try
            {
                MotivosViajeDA o_MotivosViaje = new MotivosViajeDA();
                int resp = o_MotivosViaje.Anular(e_MotivosViaje);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<MotivosViajeBE> Consultar_Lista()
        {
            List<MotivosViajeBE> lista = new List<MotivosViajeBE>();
            try
            {
                MotivosViajeDA o_MotivosViaje = new MotivosViajeDA();
                return o_MotivosViaje.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<MotivosViajeBE> Consultar_PK(
                              int m_MotivosViajeId
                              )
        {
            List<MotivosViajeBE> lista = new List<MotivosViajeBE>();
            try
            {
                MotivosViajeDA o_MotivosViaje = new MotivosViajeDA();
                return o_MotivosViaje.Consultar_PK(
                                                            m_MotivosViajeId
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
                MotivosViajeDA o_MotivosViaje = new MotivosViajeDA();
                idMax = o_MotivosViaje.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
