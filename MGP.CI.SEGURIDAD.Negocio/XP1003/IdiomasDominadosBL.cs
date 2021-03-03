using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class IdiomasDominadosBL : BaseBL
    {
        const string Nombre_Clase = "IdiomasDominadosBL";
        private string m_BaseDatos = string.Empty;

        public IdiomasDominadosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public IdiomasDominadosBL() { }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new IdiomasDominadosDA(m_BaseDatos)).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(IdiomasDominadosBE e_IdiomasDominados)
        {
            try
            {
                IdiomasDominadosDA o_IdiomasDominados = new IdiomasDominadosDA(m_BaseDatos);
                int resp = o_IdiomasDominados.Insertar(e_IdiomasDominados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(IdiomasDominadosBE e_IdiomasDominados)
        {
            try
            {
                IdiomasDominadosDA o_IdiomasDominados = new IdiomasDominadosDA(m_BaseDatos);
                int resp = o_IdiomasDominados.Actualizar(e_IdiomasDominados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(IdiomasDominadosBE e_IdiomasDominados)
        {
            try
            {
                IdiomasDominadosDA o_IdiomasDominados = new IdiomasDominadosDA(m_BaseDatos);
                int resp = o_IdiomasDominados.Anular(e_IdiomasDominados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<IdiomasDominadosBE> Consultar_Lista()
        {
            List<IdiomasDominadosBE> lista = new List<IdiomasDominadosBE>();
            try
            {
                IdiomasDominadosDA o_IdiomasDominados = new IdiomasDominadosDA(m_BaseDatos);
                return o_IdiomasDominados.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<IdiomasDominadosBE> Consultar_PK(
                              int m_IdiomasDominadosId
                              )
        {
            List<IdiomasDominadosBE> lista = new List<IdiomasDominadosBE>();
            try
            {
                IdiomasDominadosDA o_IdiomasDominados = new IdiomasDominadosDA(m_BaseDatos);
                return o_IdiomasDominados.Consultar_PK(
                                                            m_IdiomasDominadosId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<IdiomasDominadosBE> Consultar_FK(
                      int m_Fk_Id
                      )
        {
            List<IdiomasDominadosBE> lista = new List<IdiomasDominadosBE>();
            try
            {
                IdiomasDominadosDA o_IdiomasDominados = new IdiomasDominadosDA(m_BaseDatos);
                return o_IdiomasDominados.Consultar_FK(
                                                            m_Fk_Id
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
    }
}
