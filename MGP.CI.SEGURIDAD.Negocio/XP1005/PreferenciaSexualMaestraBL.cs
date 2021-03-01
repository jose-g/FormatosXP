using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class PreferenciaSexualMaestraBL : BaseBL
    {
        const string Nombre_Clase = "PreferenciaSexualMaestraBL";
        private string m_BaseDatos = string.Empty;

        public PreferenciaSexualMaestraBL() {  }

        public bool Insertar(PreferenciaSexualMaestraBE e_PreferenciaSexualMaestra)
        {
            try
            {
                PreferenciaSexualMaestraDA o_PreferenciaSexualMaestra = new PreferenciaSexualMaestraDA();
                int resp = o_PreferenciaSexualMaestra.Insertar(e_PreferenciaSexualMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(PreferenciaSexualMaestraBE e_PreferenciaSexualMaestra)
        {
            try
            {
                PreferenciaSexualMaestraDA o_PreferenciaSexualMaestra = new PreferenciaSexualMaestraDA();
                int resp = o_PreferenciaSexualMaestra.Actualizar(e_PreferenciaSexualMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(PreferenciaSexualMaestraBE e_PreferenciaSexualMaestra)
        {
            try
            {
                PreferenciaSexualMaestraDA o_PreferenciaSexualMaestra = new PreferenciaSexualMaestraDA();
                int resp = o_PreferenciaSexualMaestra.Anular(e_PreferenciaSexualMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PreferenciaSexualMaestraBE> Consultar_Lista()
        {
            List<PreferenciaSexualMaestraBE> lista = new List<PreferenciaSexualMaestraBE>();
            try
            {
                PreferenciaSexualMaestraDA o_PreferenciaSexualMaestra = new PreferenciaSexualMaestraDA();
                return o_PreferenciaSexualMaestra.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PreferenciaSexualMaestraBE> Consultar_PK(
                              int m_PreferenciaSexualMaestraId
                              )
        {
            List<PreferenciaSexualMaestraBE> lista = new List<PreferenciaSexualMaestraBE>();
            try
            {
                PreferenciaSexualMaestraDA o_PreferenciaSexualMaestra = new PreferenciaSexualMaestraDA();
                return o_PreferenciaSexualMaestra.Consultar_PK(
                                                            m_PreferenciaSexualMaestraId
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
                PreferenciaSexualMaestraDA o_PreferenciaSexualMaestra = new PreferenciaSexualMaestraDA();
                idMax = o_PreferenciaSexualMaestra.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
