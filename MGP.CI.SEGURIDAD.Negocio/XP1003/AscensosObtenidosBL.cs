using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;


namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class AscensosObtenidosBL : BaseBL
    {
        const string Nombre_Clase = "AscensosObtenidosBL";
        private string m_BaseDatos = string.Empty;

        public AscensosObtenidosBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public AscensosObtenidosBL() { }
        public int GetMaxId()
        {
            int l = -1;
            try
            {
                l = (new AscensosObtenidosDA(m_BaseDatos)).GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return l;
        }
        public bool Insertar(AscensosObtenidosBE e_AscensosObtenidos)
        {
            try
            {
                AscensosObtenidosDA o_AscensosObtenidos = new AscensosObtenidosDA(m_BaseDatos);
                int resp = o_AscensosObtenidos.Insertar(e_AscensosObtenidos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(AscensosObtenidosBE e_AscensosObtenidos)
        {
            try
            {
                AscensosObtenidosDA o_AscensosObtenidos = new AscensosObtenidosDA(m_BaseDatos);
                int resp = o_AscensosObtenidos.Actualizar(e_AscensosObtenidos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(AscensosObtenidosBE e_AscensosObtenidos)
        {
            try
            {
                AscensosObtenidosDA o_AscensosObtenidos = new AscensosObtenidosDA(m_BaseDatos);
                int resp = o_AscensosObtenidos.Anular(e_AscensosObtenidos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<AscensosObtenidosBE> Consultar_Lista()
        {
            List<AscensosObtenidosBE> lista = new List<AscensosObtenidosBE>();
            try
            {
                AscensosObtenidosDA o_AscensosObtenidos = new AscensosObtenidosDA(m_BaseDatos);
                return o_AscensosObtenidos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<AscensosObtenidosBE> Consultar_PK(
                              int m_AscensosObtenidosId
                              )
        {
            List<AscensosObtenidosBE> lista = new List<AscensosObtenidosBE>();
            try
            {
                AscensosObtenidosDA o_AscensosObtenidos = new AscensosObtenidosDA(m_BaseDatos);
                return o_AscensosObtenidos.Consultar_PK(
                                                            m_AscensosObtenidosId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }
        public List<AscensosObtenidosBE> Consultar_FK(
                      int m_Fk_Id
                      )
        {
            List<AscensosObtenidosBE> lista = new List<AscensosObtenidosBE>();
            try
            {
                AscensosObtenidosDA o_AscensosObtenidos = new AscensosObtenidosDA(m_BaseDatos);
                return o_AscensosObtenidos.Consultar_FK(
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
