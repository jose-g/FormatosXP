using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class NacionalidadBL : BaseBL
    {
        const string Nombre_Clase = "NacionalidadBL";
        private string m_BaseDatos = string.Empty;

        public NacionalidadBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public NacionalidadBL() { m_BaseDatos = "DIN_XP_SEGURIDAD"; }

        public bool Insertar(NacionalidadBE e_Nacionalidad)
        {
            try
            {
                NacionalidadDA o_Nacionalidad = new NacionalidadDA(m_BaseDatos);
                int resp = o_Nacionalidad.Insertar(e_Nacionalidad);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(NacionalidadBE e_Nacionalidad)
        {
            try
            {
                NacionalidadDA o_Nacionalidad = new NacionalidadDA(m_BaseDatos);
                int resp = o_Nacionalidad.Actualizar(e_Nacionalidad);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(NacionalidadBE e_Nacionalidad)
        {
            try
            {
                NacionalidadDA o_Nacionalidad = new NacionalidadDA(m_BaseDatos);
                int resp = o_Nacionalidad.Anular(e_Nacionalidad);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<NacionalidadBE> Consultar_Lista()
        {
            List<NacionalidadBE> lista = new List<NacionalidadBE>();
            try
            {
                NacionalidadDA o_Nacionalidad = new NacionalidadDA(m_BaseDatos);
                return o_Nacionalidad.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<NacionalidadBE> Consultar_PK(
                              int m_NacionalidadId
                              )
        {
            List<NacionalidadBE> lista = new List<NacionalidadBE>();
            try
            {
                NacionalidadDA o_Nacionalidad = new NacionalidadDA(m_BaseDatos);
                return o_Nacionalidad.Consultar_PK(
                                                            m_NacionalidadId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
