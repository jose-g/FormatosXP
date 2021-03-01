using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class BienesEconomicosMaestraBL : BaseBL
    {
        const string Nombre_Clase = "BienesEconomicosMaestraBL";
        private string m_BaseDatos = string.Empty;

        public BienesEconomicosMaestraBL() {  }

        public bool Insertar(BienesEconomicosMaestraBE e_BienesEconomicosMaestra)
        {
            try
            {
                BienesEconomicosMaestraDA o_BienesEconomicosMaestra = new BienesEconomicosMaestraDA();
                int resp = o_BienesEconomicosMaestra.Insertar(e_BienesEconomicosMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(BienesEconomicosMaestraBE e_BienesEconomicosMaestra)
        {
            try
            {
                BienesEconomicosMaestraDA o_BienesEconomicosMaestra = new BienesEconomicosMaestraDA();
                int resp = o_BienesEconomicosMaestra.Actualizar(e_BienesEconomicosMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(BienesEconomicosMaestraBE e_BienesEconomicosMaestra)
        {
            try
            {
                BienesEconomicosMaestraDA o_BienesEconomicosMaestra = new BienesEconomicosMaestraDA();
                int resp = o_BienesEconomicosMaestra.Anular(e_BienesEconomicosMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<BienesEconomicosMaestraBE> Consultar_Lista()
        {
            List<BienesEconomicosMaestraBE> lista = new List<BienesEconomicosMaestraBE>();
            try
            {
                BienesEconomicosMaestraDA o_BienesEconomicosMaestra = new BienesEconomicosMaestraDA();
                return o_BienesEconomicosMaestra.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<BienesEconomicosMaestraBE> Consultar_PK(
                              int m_BienesEconomicosMaestraId
                              )
        {
            List<BienesEconomicosMaestraBE> lista = new List<BienesEconomicosMaestraBE>();
            try
            {
                BienesEconomicosMaestraDA o_BienesEconomicosMaestra = new BienesEconomicosMaestraDA();
                return o_BienesEconomicosMaestra.Consultar_PK(
                                                            m_BienesEconomicosMaestraId
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
                BienesEconomicosMaestraDA o_BienesEconomicosMaestra = new BienesEconomicosMaestraDA();
                idMax = o_BienesEconomicosMaestra.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
