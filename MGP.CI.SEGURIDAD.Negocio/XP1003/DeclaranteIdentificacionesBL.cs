using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class DeclaranteIdentificacionesBL : BaseBL
    {
        const string Nombre_Clase = "DeclaranteIdentificacionesBL";
        private string m_BaseDatos = string.Empty;

        public DeclaranteIdentificacionesBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public DeclaranteIdentificacionesBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(DeclaranteIdentificacionesBE e_DeclaranteIdentificaciones)
        {
            try
            {
                DeclaranteIdentificacionesDA o_DeclaranteIdentificaciones = new DeclaranteIdentificacionesDA(m_BaseDatos);
                int resp = o_DeclaranteIdentificaciones.Insertar(e_DeclaranteIdentificaciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(DeclaranteIdentificacionesBE e_DeclaranteIdentificaciones)
        {
            try
            {
                DeclaranteIdentificacionesDA o_DeclaranteIdentificaciones = new DeclaranteIdentificacionesDA(m_BaseDatos);
                int resp = o_DeclaranteIdentificaciones.Actualizar(e_DeclaranteIdentificaciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DeclaranteIdentificacionesBE e_DeclaranteIdentificaciones)
        {
            try
            {
                DeclaranteIdentificacionesDA o_DeclaranteIdentificaciones = new DeclaranteIdentificacionesDA(m_BaseDatos);
                int resp = o_DeclaranteIdentificaciones.Anular(e_DeclaranteIdentificaciones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DeclaranteIdentificacionesBE> Consultar_Lista()
        {
            List<DeclaranteIdentificacionesBE> lista = new List<DeclaranteIdentificacionesBE>();
            try
            {
                DeclaranteIdentificacionesDA o_DeclaranteIdentificaciones = new DeclaranteIdentificacionesDA(m_BaseDatos);
                return o_DeclaranteIdentificaciones.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DeclaranteIdentificacionesBE> Consultar_PK(
                              int m_DeclaranteIdentificacionId
                              )
        {
            List<DeclaranteIdentificacionesBE> lista = new List<DeclaranteIdentificacionesBE>();
            try
            {
                DeclaranteIdentificacionesDA o_DeclaranteIdentificaciones = new DeclaranteIdentificacionesDA(m_BaseDatos);
                return o_DeclaranteIdentificaciones.Consultar_PK(
                                                            m_DeclaranteIdentificacionId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
