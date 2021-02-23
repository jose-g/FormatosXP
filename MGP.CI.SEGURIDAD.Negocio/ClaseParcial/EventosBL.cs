using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades;
using MGP.CI.SEGURIDAD.AccesoDatos;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public class EventosBL : BaseBL
    {
        const string Nombre_Clase = "EventosBL";
        private string m_BaseDatos = string.Empty;

        public EventosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public EventosBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }


        public bool Insertar(EventosBE e_Eventos)
        {
            try
            {
                EventosDA o_Eventos = new EventosDA(m_BaseDatos);
                int resp = o_Eventos.Insertar(e_Eventos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(EventosBE e_Eventos)
        {
            try
            {
                EventosDA o_Eventos = new EventosDA(m_BaseDatos);
                int resp = o_Eventos.Actualizar(e_Eventos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(EventosBE e_Eventos)
        {
            try
            {
                EventosDA o_Eventos = new EventosDA(m_BaseDatos);
                int resp = o_Eventos.Anular(e_Eventos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EventosBE> Consultar_Lista()
        {
            List<EventosBE> lista = new List<EventosBE>();
            try
            {
                EventosDA o_Eventos = new EventosDA(m_BaseDatos);
                return o_Eventos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<EventosBE> Consultar_PK(int m_EventoId)
        {
            List<EventosBE> lista = new List<EventosBE>();
            try
            {
                EventosDA o_Eventos = new EventosDA(m_BaseDatos);
                return o_Eventos.Consultar_PK(
                                                            m_EventoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
