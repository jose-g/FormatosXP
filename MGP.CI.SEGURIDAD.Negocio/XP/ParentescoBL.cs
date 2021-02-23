using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.AccesoDatos;
using MGP.CI.SEGURIDAD.Entidades;

namespace MGP.CI.SEGURIDAD.Negocio
{
    [Serializable]
    public partial class ParentescoBL : BaseBL
    {
        const string Nombre_Clase = "ParentescoBL";
        private string m_BaseDatos = string.Empty;

        public ParentescoBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public ParentescoBL() { }

        protected internal bool Insertar(ParentescoBE e_Parentesco)
        {
            try
            {
                ParentescoDA o_Parentesco = new ParentescoDA(m_BaseDatos);
                int resp = o_Parentesco.Insertar(e_Parentesco);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Actualizar(ParentescoBE e_Parentesco)
        {
            try
            {
                ParentescoDA o_Parentesco = new ParentescoDA(m_BaseDatos);
                int resp = o_Parentesco.Actualizar(e_Parentesco);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        protected internal bool Anular(ParentescoBE e_Parentesco)
        {
            try
            {
                ParentescoDA o_Parentesco = new ParentescoDA(m_BaseDatos);
                int resp = o_Parentesco.Anular(e_Parentesco);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ParentescoBE> Consultar_Lista()
        {
            List<ParentescoBE> lista = new List<ParentescoBE>();
            try
            {
                ParentescoDA o_Parentesco = new ParentescoDA(m_BaseDatos);
                return o_Parentesco.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ParentescoBE> Consultar_PK(
                              int m_ParentescoId
                              )
        {
            List<ParentescoBE> lista = new List<ParentescoBE>();
            try
            {
                ParentescoDA o_Parentesco = new ParentescoDA(m_BaseDatos);
                return o_Parentesco.Consultar_PK(
                                                            m_ParentescoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
