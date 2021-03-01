using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class ReligionMaestraBL : BaseBL
    {
        const string Nombre_Clase = "ReligionMaestraBL";
        private string m_BaseDatos = string.Empty;

        public ReligionMaestraBL() {  }

        public bool Insertar(ReligionMaestraBE e_ReligionMaestra)
        {
            try
            {
                ReligionMaestraDA o_ReligionMaestra = new ReligionMaestraDA();
                int resp = o_ReligionMaestra.Insertar(e_ReligionMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(ReligionMaestraBE e_ReligionMaestra)
        {
            try
            {
                ReligionMaestraDA o_ReligionMaestra = new ReligionMaestraDA();
                int resp = o_ReligionMaestra.Actualizar(e_ReligionMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(ReligionMaestraBE e_ReligionMaestra)
        {
            try
            {
                ReligionMaestraDA o_ReligionMaestra = new ReligionMaestraDA();
                int resp = o_ReligionMaestra.Anular(e_ReligionMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ReligionMaestraBE> Consultar_Lista()
        {
            List<ReligionMaestraBE> lista = new List<ReligionMaestraBE>();
            try
            {
                ReligionMaestraDA o_ReligionMaestra = new ReligionMaestraDA();
                return o_ReligionMaestra.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ReligionMaestraBE> Consultar_PK(
                              int m_ReligionMaestraId
                              )
        {
            List<ReligionMaestraBE> lista = new List<ReligionMaestraBE>();
            try
            {
                ReligionMaestraDA o_ReligionMaestra = new ReligionMaestraDA();
                return o_ReligionMaestra.Consultar_PK(
                                                            m_ReligionMaestraId
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
                ReligionMaestraDA o_ReligionMaestra = new ReligionMaestraDA();
                idMax = o_ReligionMaestra.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
