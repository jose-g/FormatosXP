using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class ReligionBL : BaseBL
    {
        const string Nombre_Clase = "ReligionBL";
        private string m_BaseDatos = string.Empty;

        public ReligionBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(ReligionBE e_Religion)
        {
            try
            {
                ReligionDA o_Religion = new ReligionDA(m_BaseDatos);
                int resp = o_Religion.Insertar(e_Religion);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(ReligionBE e_Religion)
        {
            try
            {
                ReligionDA o_Religion = new ReligionDA(m_BaseDatos);
                int resp = o_Religion.Actualizar(e_Religion);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(ReligionBE e_Religion)
        {
            try
            {
                ReligionDA o_Religion = new ReligionDA(m_BaseDatos);
                int resp = o_Religion.Anular(e_Religion);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ReligionBE> Consultar_Lista()
        {
            List<ReligionBE> lista = new List<ReligionBE>();
            try
            {
                ReligionDA o_Religion = new ReligionDA(m_BaseDatos);
                return o_Religion.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ReligionBE> Consultar_PK(
                              int m_ReligionId
                              )
        {
            List<ReligionBE> lista = new List<ReligionBE>();
            try
            {
                ReligionDA o_Religion = new ReligionDA(m_BaseDatos);
                return o_Religion.Consultar_PK(
                                                            m_ReligionId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
