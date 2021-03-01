using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class OpinionMaestraBL : BaseBL
    {
        const string Nombre_Clase = "OpinionMaestraBL";
        private string m_BaseDatos = string.Empty;

        public OpinionMaestraBL() {  }

        public bool Insertar(OpinionMaestraBE e_OpinionMaestra)
        {
            try
            {
                OpinionMaestraDA o_OpinionMaestra = new OpinionMaestraDA();
                int resp = o_OpinionMaestra.Insertar(e_OpinionMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(OpinionMaestraBE e_OpinionMaestra)
        {
            try
            {
                OpinionMaestraDA o_OpinionMaestra = new OpinionMaestraDA();
                int resp = o_OpinionMaestra.Actualizar(e_OpinionMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(OpinionMaestraBE e_OpinionMaestra)
        {
            try
            {
                OpinionMaestraDA o_OpinionMaestra = new OpinionMaestraDA();
                int resp = o_OpinionMaestra.Anular(e_OpinionMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<OpinionMaestraBE> Consultar_Lista()
        {
            List<OpinionMaestraBE> lista = new List<OpinionMaestraBE>();
            try
            {
                OpinionMaestraDA o_OpinionMaestra = new OpinionMaestraDA();
                return o_OpinionMaestra.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<OpinionMaestraBE> Consultar_PK(
                              int m_OpinionMaestraId
                              )
        {
            List<OpinionMaestraBE> lista = new List<OpinionMaestraBE>();
            try
            {
                OpinionMaestraDA o_OpinionMaestra = new OpinionMaestraDA();
                return o_OpinionMaestra.Consultar_PK(
                                                            m_OpinionMaestraId
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
                OpinionMaestraDA o_OpinionMaestra = new OpinionMaestraDA();
                idMax = o_OpinionMaestra.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
