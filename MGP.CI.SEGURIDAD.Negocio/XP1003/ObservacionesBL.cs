using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class ObservacionesBL : BaseBL
    {
        const string Nombre_Clase = "ObservacionesBL";
        private string m_BaseDatos = string.Empty;

        public ObservacionesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public ObservacionesBL() { }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new ObservacionesDA()).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(ObservacionesBE e_Observaciones)
        {
            try
            {
                ObservacionesDA o_Observaciones = new ObservacionesDA(m_BaseDatos);
                int resp = o_Observaciones.Insertar(e_Observaciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(ObservacionesBE e_Observaciones)
        {
            try
            {
                ObservacionesDA o_Observaciones = new ObservacionesDA(m_BaseDatos);
                int resp = o_Observaciones.Actualizar(e_Observaciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(ObservacionesBE e_Observaciones)
        {
            try
            {
                ObservacionesDA o_Observaciones = new ObservacionesDA(m_BaseDatos);
                int resp = o_Observaciones.Anular(e_Observaciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ObservacionesBE> Consultar_Lista()
        {
            List<ObservacionesBE> lista = new List<ObservacionesBE>();
            try
            {
                ObservacionesDA o_Observaciones = new ObservacionesDA(m_BaseDatos);
                return o_Observaciones.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ObservacionesBE> Consultar_PK(
                              int m_ObservacionesId
                              )
        {
            List<ObservacionesBE> lista = new List<ObservacionesBE>();
            try
            {
                ObservacionesDA o_Observaciones = new ObservacionesDA(m_BaseDatos);
                return o_Observaciones.Consultar_PK(
                                                            m_ObservacionesId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<ObservacionesBE> Consultar_FK(
                              int m_OtrosId
                              )
        {
            List<ObservacionesBE> lista = new List<ObservacionesBE>();
            try
            {
                ObservacionesDA o_Observaciones = new ObservacionesDA(m_BaseDatos);
                return o_Observaciones.Consultar_FK(
                                                            m_OtrosId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
