using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class DelitosEspecificosBL : BaseBL
    {
        const string Nombre_Clase = "DelitosEspecificosBL";
        private string m_BaseDatos = string.Empty;

        public DelitosEspecificosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(DelitosEspecificosBE e_DelitosEspecificos)
        {
            try
            {
                DelitosEspecificosDA o_DelitosEspecificos = new DelitosEspecificosDA(m_BaseDatos);
                int resp = o_DelitosEspecificos.Insertar(e_DelitosEspecificos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(DelitosEspecificosBE e_DelitosEspecificos)
        {
            try
            {
                DelitosEspecificosDA o_DelitosEspecificos = new DelitosEspecificosDA(m_BaseDatos);
                int resp = o_DelitosEspecificos.Actualizar(e_DelitosEspecificos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(DelitosEspecificosBE e_DelitosEspecificos)
        {
            try
            {
                DelitosEspecificosDA o_DelitosEspecificos = new DelitosEspecificosDA(m_BaseDatos);
                int resp = o_DelitosEspecificos.Anular(e_DelitosEspecificos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DelitosEspecificosBE> Consultar_Lista()
        {
            List<DelitosEspecificosBE> lista = new List<DelitosEspecificosBE>();
            try
            {
                DelitosEspecificosDA o_DelitosEspecificos = new DelitosEspecificosDA(m_BaseDatos);
                return o_DelitosEspecificos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DelitosEspecificosBE> Consultar_PK(
                              string m_DelitoEspecificoId
                              )
        {
            List<DelitosEspecificosBE> lista = new List<DelitosEspecificosBE>();
            try
            {
                DelitosEspecificosDA o_DelitosEspecificos = new DelitosEspecificosDA(m_BaseDatos);
                return o_DelitosEspecificos.Consultar_PK(
                                                            m_DelitoEspecificoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
