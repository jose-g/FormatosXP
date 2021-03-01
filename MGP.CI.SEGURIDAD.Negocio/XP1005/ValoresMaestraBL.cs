using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class ValoresMaestraBL : BaseBL
    {
        const string Nombre_Clase = "ValoresMaestraBL";
        private string m_BaseDatos = string.Empty;

        public ValoresMaestraBL() {  }

        public bool Insertar(ValoresMaestraBE e_ValoresMaestra)
        {
            try
            {
                ValoresMaestraDA o_ValoresMaestra = new ValoresMaestraDA();
                int resp = o_ValoresMaestra.Insertar(e_ValoresMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(ValoresMaestraBE e_ValoresMaestra)
        {
            try
            {
                ValoresMaestraDA o_ValoresMaestra = new ValoresMaestraDA();
                int resp = o_ValoresMaestra.Actualizar(e_ValoresMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(ValoresMaestraBE e_ValoresMaestra)
        {
            try
            {
                ValoresMaestraDA o_ValoresMaestra = new ValoresMaestraDA();
                int resp = o_ValoresMaestra.Anular(e_ValoresMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ValoresMaestraBE> Consultar_Lista()
        {
            List<ValoresMaestraBE> lista = new List<ValoresMaestraBE>();
            try
            {
                ValoresMaestraDA o_ValoresMaestra = new ValoresMaestraDA();
                return o_ValoresMaestra.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ValoresMaestraBE> Consultar_PK(
                              int m_ValoresMaestraId
                              )
        {
            List<ValoresMaestraBE> lista = new List<ValoresMaestraBE>();
            try
            {
                ValoresMaestraDA o_ValoresMaestra = new ValoresMaestraDA();
                return o_ValoresMaestra.Consultar_PK(
                                                            m_ValoresMaestraId
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
                ValoresMaestraDA o_ValoresMaestra = new ValoresMaestraDA();
                idMax = o_ValoresMaestra.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
