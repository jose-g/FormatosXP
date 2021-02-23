using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class VehiculoTiposBL : BaseBL
    {
        const string Nombre_Clase = "VehiculoTiposBL";
        private string m_BaseDatos = string.Empty;

        public VehiculoTiposBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        public VehiculoTiposBL() { }

        protected internal bool Insertar(VehiculoTiposBE e_VehiculoTipos)
        {
            try
            {
                VehiculoTiposDA o_VehiculoTipos = new VehiculoTiposDA(m_BaseDatos);
                int resp = o_VehiculoTipos.Insertar(e_VehiculoTipos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(VehiculoTiposBE e_VehiculoTipos)
        {
            try
            {
                VehiculoTiposDA o_VehiculoTipos = new VehiculoTiposDA(m_BaseDatos);
                int resp = o_VehiculoTipos.Actualizar(e_VehiculoTipos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(VehiculoTiposBE e_VehiculoTipos)
        {
            try
            {
                VehiculoTiposDA o_VehiculoTipos = new VehiculoTiposDA(m_BaseDatos);
                int resp = o_VehiculoTipos.Anular(e_VehiculoTipos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<VehiculoTiposBE> Consultar_Lista()
        {
            List<VehiculoTiposBE> lista = new List<VehiculoTiposBE>();
            try
            {
                VehiculoTiposDA o_VehiculoTipos = new VehiculoTiposDA(m_BaseDatos);
                return o_VehiculoTipos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<VehiculoTiposBE> Consultar_PK(
                              int m_VehiculoTipoId
                              )
        {
            List<VehiculoTiposBE> lista = new List<VehiculoTiposBE>();
            try
            {
                VehiculoTiposDA o_VehiculoTipos = new VehiculoTiposDA(m_BaseDatos);
                return o_VehiculoTipos.Consultar_PK(
                                                            m_VehiculoTipoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
