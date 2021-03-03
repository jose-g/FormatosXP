using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class CursosRealizadosBL : BaseBL
    {
        const string Nombre_Clase = "CursosRealizadosBL";
        private string m_BaseDatos = string.Empty;

        public CursosRealizadosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public CursosRealizadosBL() { }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new CursosRealizadosDA(m_BaseDatos)).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(CursosRealizadosBE e_CursosRealizados)
        {
            try
            {
                CursosRealizadosDA o_CursosRealizados = new CursosRealizadosDA(m_BaseDatos);
                int resp = o_CursosRealizados.Insertar(e_CursosRealizados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(CursosRealizadosBE e_CursosRealizados)
        {
            try
            {
                CursosRealizadosDA o_CursosRealizados = new CursosRealizadosDA(m_BaseDatos);
                int resp = o_CursosRealizados.Actualizar(e_CursosRealizados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(CursosRealizadosBE e_CursosRealizados)
        {
            try
            {
                CursosRealizadosDA o_CursosRealizados = new CursosRealizadosDA(m_BaseDatos);
                int resp = o_CursosRealizados.Anular(e_CursosRealizados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CursosRealizadosBE> Consultar_Lista()
        {
            List<CursosRealizadosBE> lista = new List<CursosRealizadosBE>();
            try
            {
                CursosRealizadosDA o_CursosRealizados = new CursosRealizadosDA(m_BaseDatos);
                return o_CursosRealizados.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CursosRealizadosBE> Consultar_PK(
                              int m_CursosRealizadosId
                              )
        {
            List<CursosRealizadosBE> lista = new List<CursosRealizadosBE>();
            try
            {
                CursosRealizadosDA o_CursosRealizados = new CursosRealizadosDA(m_BaseDatos);
                return o_CursosRealizados.Consultar_PK(
                                                            m_CursosRealizadosId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<CursosRealizadosBE> Consultar_FK(
                              int m_Fk_Id
                              )
        {
            List<CursosRealizadosBE> lista = new List<CursosRealizadosBE>();
            try
            {
                CursosRealizadosDA o_CursosRealizados = new CursosRealizadosDA(m_BaseDatos);
                return o_CursosRealizados.Consultar_FK(
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
