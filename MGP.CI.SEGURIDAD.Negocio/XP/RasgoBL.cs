using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class RasgoBL : BaseBL
    {
        const string Nombre_Clase = "RasgoBL";
        private string m_BaseDatos = string.Empty;

        public RasgoBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(RasgoBE e_Rasgo)
        {
            try
            {
                RasgoDA o_Rasgo = new RasgoDA(m_BaseDatos);
                int resp = o_Rasgo.Insertar(e_Rasgo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(RasgoBE e_Rasgo)
        {
            try
            {
                RasgoDA o_Rasgo = new RasgoDA(m_BaseDatos);
                int resp = o_Rasgo.Actualizar(e_Rasgo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(RasgoBE e_Rasgo)
        {
            try
            {
                RasgoDA o_Rasgo = new RasgoDA(m_BaseDatos);
                int resp = o_Rasgo.Anular(e_Rasgo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<RasgoBE> Consultar_Lista()
        {
            List<RasgoBE> lista = new List<RasgoBE>();
            try
            {
                RasgoDA o_Rasgo = new RasgoDA(m_BaseDatos);
                return o_Rasgo.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<RasgoBE> Consultar_PK(
                              int m_RasgoId
                              )
        {
            List<RasgoBE> lista = new List<RasgoBE>();
            try
            {
                RasgoDA o_Rasgo = new RasgoDA(m_BaseDatos);
                return o_Rasgo.Consultar_PK(
                                                            m_RasgoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
