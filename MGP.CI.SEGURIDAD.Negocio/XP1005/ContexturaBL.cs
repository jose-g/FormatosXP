using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class ContexturaBL : BaseBL
    {
        const string Nombre_Clase = "ContexturaBL";
        private string m_BaseDatos = string.Empty;

        public ContexturaBL() {  }

        public bool Insertar(ContexturaBE e_Contextura)
        {
            try
            {
                ContexturaDA o_Contextura = new ContexturaDA();
                int resp = o_Contextura.Insertar(e_Contextura);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(ContexturaBE e_Contextura)
        {
            try
            {
                ContexturaDA o_Contextura = new ContexturaDA();
                int resp = o_Contextura.Actualizar(e_Contextura);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(ContexturaBE e_Contextura)
        {
            try
            {
                ContexturaDA o_Contextura = new ContexturaDA();
                int resp = o_Contextura.Anular(e_Contextura);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ContexturaBE> Consultar_Lista()
        {
            List<ContexturaBE> lista = new List<ContexturaBE>();
            try
            {
                ContexturaDA o_Contextura = new ContexturaDA();
                return o_Contextura.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ContexturaBE> Consultar_PK(
                              int m_ContexturaId
                              )
        {
            List<ContexturaBE> lista = new List<ContexturaBE>();
            try
            {
                ContexturaDA o_Contextura = new ContexturaDA();
                return o_Contextura.Consultar_PK(
                                                            m_ContexturaId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public int GetMaxId()
        {
            int idMax = -1;
            try
            {
                ContexturaDA o_Contextura = new ContexturaDA();
                idMax = o_Contextura.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
