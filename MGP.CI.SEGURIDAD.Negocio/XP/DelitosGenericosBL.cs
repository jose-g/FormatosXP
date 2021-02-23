using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class DelitosGenericosBL : BaseBL
    {
        const string Nombre_Clase = "DelitosGenericosBL";
        private string m_BaseDatos = string.Empty;

        public DelitosGenericosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }

        protected internal bool Insertar(DelitosGenericosBE e_DelitosGenericos)
        {
            try
            {
                DelitosGenericosDA o_DelitosGenericos = new DelitosGenericosDA(m_BaseDatos);
                int resp = o_DelitosGenericos.Insertar(e_DelitosGenericos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(DelitosGenericosBE e_DelitosGenericos)
        {
            try
            {
                DelitosGenericosDA o_DelitosGenericos = new DelitosGenericosDA(m_BaseDatos);
                int resp = o_DelitosGenericos.Actualizar(e_DelitosGenericos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(DelitosGenericosBE e_DelitosGenericos)
        {
            try
            {
                DelitosGenericosDA o_DelitosGenericos = new DelitosGenericosDA(m_BaseDatos);
                int resp = o_DelitosGenericos.Anular(e_DelitosGenericos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DelitosGenericosBE> Consultar_Lista()
        {
            List<DelitosGenericosBE> lista = new List<DelitosGenericosBE>();
            try
            {
                DelitosGenericosDA o_DelitosGenericos = new DelitosGenericosDA(m_BaseDatos);
                return o_DelitosGenericos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DelitosGenericosBE> Consultar_PK(
                              int m_DelitoGenericoId
                              )
        {
            List<DelitosGenericosBE> lista = new List<DelitosGenericosBE>();
            try
            {
                DelitosGenericosDA o_DelitosGenericos = new DelitosGenericosDA(m_BaseDatos);
                return o_DelitosGenericos.Consultar_PK(
                                                            m_DelitoGenericoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
