using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class DefectosMaestraBL : BaseBL
    {
        const string Nombre_Clase = "DefectosMaestraBL";
        private string m_BaseDatos = string.Empty;

        public DefectosMaestraBL() {  }

        public bool Insertar(DefectosMaestraBE e_DefectosMaestra)
        {
            try
            {
                DefectosMaestraDA o_DefectosMaestra = new DefectosMaestraDA();
                int resp = o_DefectosMaestra.Insertar(e_DefectosMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(DefectosMaestraBE e_DefectosMaestra)
        {
            try
            {
                DefectosMaestraDA o_DefectosMaestra = new DefectosMaestraDA();
                int resp = o_DefectosMaestra.Actualizar(e_DefectosMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DefectosMaestraBE e_DefectosMaestra)
        {
            try
            {
                DefectosMaestraDA o_DefectosMaestra = new DefectosMaestraDA();
                int resp = o_DefectosMaestra.Anular(e_DefectosMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DefectosMaestraBE> Consultar_Lista()
        {
            List<DefectosMaestraBE> lista = new List<DefectosMaestraBE>();
            try
            {
                DefectosMaestraDA o_DefectosMaestra = new DefectosMaestraDA();
                return o_DefectosMaestra.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DefectosMaestraBE> Consultar_PK(
                              int m_DefectosMaestraId
                              )
        {
            List<DefectosMaestraBE> lista = new List<DefectosMaestraBE>();
            try
            {
                DefectosMaestraDA o_DefectosMaestra = new DefectosMaestraDA();
                return o_DefectosMaestra.Consultar_PK(
                                                            m_DefectosMaestraId
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
                DefectosMaestraDA o_DefectosMaestra = new DefectosMaestraDA();
                idMax = o_DefectosMaestra.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
