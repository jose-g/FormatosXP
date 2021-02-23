using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class ProfesionesBL : BaseBL
    {
        const string Nombre_Clase = "ProfesionesBL";
        private string m_BaseDatos = string.Empty;

        public ProfesionesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public ProfesionesBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        protected internal bool Insertar(ProfesionesBE e_Profesiones)
        {
            try
            {
                ProfesionesDA o_Profesiones = new ProfesionesDA(m_BaseDatos);
                int resp = o_Profesiones.Insertar(e_Profesiones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(ProfesionesBE e_Profesiones)
        {
            try
            {
                ProfesionesDA o_Profesiones = new ProfesionesDA(m_BaseDatos);
                int resp = o_Profesiones.Actualizar(e_Profesiones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(ProfesionesBE e_Profesiones)
        {
            try
            {
                ProfesionesDA o_Profesiones = new ProfesionesDA(m_BaseDatos);
                int resp = o_Profesiones.Anular(e_Profesiones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ProfesionesBE> Consultar_Lista()
        {
            List<ProfesionesBE> lista = new List<ProfesionesBE>();
            try
            {
                ProfesionesDA o_Profesiones = new ProfesionesDA(m_BaseDatos);
                return o_Profesiones.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ProfesionesBE> Consultar_PK(
                              int m_ProfesionId
                              )
        {
            List<ProfesionesBE> lista = new List<ProfesionesBE>();
            try
            {
                ProfesionesDA o_Profesiones = new ProfesionesDA(m_BaseDatos);
                return o_Profesiones.Consultar_PK(
                                                            m_ProfesionId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
