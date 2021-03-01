using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class PerfilPsicologico1005BL : BaseBL
    {
        const string Nombre_Clase = "PerfilPsicologico1005BL";
        private string m_BaseDatos = string.Empty;

        public PerfilPsicologico1005BL() {  }

        public bool Insertar(PerfilPsicologico1005BE e_PerfilPsicologico1005)
        {
            try
            {
                PerfilPsicologico1005DA o_PerfilPsicologico1005 = new PerfilPsicologico1005DA();
                int resp = o_PerfilPsicologico1005.Insertar(e_PerfilPsicologico1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(PerfilPsicologico1005BE e_PerfilPsicologico1005)
        {
            try
            {
                PerfilPsicologico1005DA o_PerfilPsicologico1005 = new PerfilPsicologico1005DA();
                int resp = o_PerfilPsicologico1005.Actualizar(e_PerfilPsicologico1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(PerfilPsicologico1005BE e_PerfilPsicologico1005)
        {
            try
            {
                PerfilPsicologico1005DA o_PerfilPsicologico1005 = new PerfilPsicologico1005DA();
                int resp = o_PerfilPsicologico1005.Anular(e_PerfilPsicologico1005);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PerfilPsicologico1005BE> Consultar_Lista()
        {
            List<PerfilPsicologico1005BE> lista = new List<PerfilPsicologico1005BE>();
            try
            {
                PerfilPsicologico1005DA o_PerfilPsicologico1005 = new PerfilPsicologico1005DA();
                return o_PerfilPsicologico1005.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PerfilPsicologico1005BE> Consultar_PK(
                              int m_PerfilPsicologico1005Id
                              )
        {
            List<PerfilPsicologico1005BE> lista = new List<PerfilPsicologico1005BE>();
            try
            {
                PerfilPsicologico1005DA o_PerfilPsicologico1005 = new PerfilPsicologico1005DA();
                return o_PerfilPsicologico1005.Consultar_PK(
                                                            m_PerfilPsicologico1005Id
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
                PerfilPsicologico1005DA o_PerfilPsicologico1005 = new PerfilPsicologico1005DA();
                idMax = o_PerfilPsicologico1005.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
