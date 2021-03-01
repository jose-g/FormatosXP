using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class NivelesNumericos1005BL : BaseBL
    {
        const string Nombre_Clase = "NivelesNumericos1005BL";
        private string m_BaseDatos = string.Empty;

        public NivelesNumericos1005BL() {  }

        public bool Insertar(NivelesNumericos1005BE e_NivelesNumericos1005)
        {
            try
            {
                NivelesNumericos1005DA o_NivelesNumericos1005 = new NivelesNumericos1005DA();
                int resp = o_NivelesNumericos1005.Insertar(e_NivelesNumericos1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(NivelesNumericos1005BE e_NivelesNumericos1005)
        {
            try
            {
                NivelesNumericos1005DA o_NivelesNumericos1005 = new NivelesNumericos1005DA();
                int resp = o_NivelesNumericos1005.Actualizar(e_NivelesNumericos1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(NivelesNumericos1005BE e_NivelesNumericos1005)
        {
            try
            {
                NivelesNumericos1005DA o_NivelesNumericos1005 = new NivelesNumericos1005DA();
                int resp = o_NivelesNumericos1005.Anular(e_NivelesNumericos1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<NivelesNumericos1005BE> Consultar_Lista()
        {
            List<NivelesNumericos1005BE> lista = new List<NivelesNumericos1005BE>();
            try
            {
                NivelesNumericos1005DA o_NivelesNumericos1005 = new NivelesNumericos1005DA();
                return o_NivelesNumericos1005.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<NivelesNumericos1005BE> Consultar_PK(
                              int m_NivelesNumericosId
                              )
        {
            List<NivelesNumericos1005BE> lista = new List<NivelesNumericos1005BE>();
            try
            {
                NivelesNumericos1005DA o_NivelesNumericos1005 = new NivelesNumericos1005DA();
                return o_NivelesNumericos1005.Consultar_PK(
                                                            m_NivelesNumericosId
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
                NivelesNumericos1005DA o_NivelesNumericos1005 = new NivelesNumericos1005DA();
                idMax = o_NivelesNumericos1005.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
