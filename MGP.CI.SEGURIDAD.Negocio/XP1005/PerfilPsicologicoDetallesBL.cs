using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class PerfilPsicologicoDetallesBL : BaseBL
    {
        const string Nombre_Clase = "PerfilPsicologicoDetallesBL";
        private string m_BaseDatos = string.Empty;

        public PerfilPsicologicoDetallesBL() {  }

        public bool Insertar(PerfilPsicologicoDetallesBE e_PerfilPsicologicoDetalles)
        {
            try
            {
                PerfilPsicologicoDetallesDA o_PerfilPsicologicoDetalles = new PerfilPsicologicoDetallesDA();
                int resp = o_PerfilPsicologicoDetalles.Insertar(e_PerfilPsicologicoDetalles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(PerfilPsicologicoDetallesBE e_PerfilPsicologicoDetalles)
        {
            try
            {
                PerfilPsicologicoDetallesDA o_PerfilPsicologicoDetalles = new PerfilPsicologicoDetallesDA();
                int resp = o_PerfilPsicologicoDetalles.Actualizar(e_PerfilPsicologicoDetalles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(PerfilPsicologicoDetallesBE e_PerfilPsicologicoDetalles)
        {
            try
            {
                PerfilPsicologicoDetallesDA o_PerfilPsicologicoDetalles = new PerfilPsicologicoDetallesDA();
                int resp = o_PerfilPsicologicoDetalles.Anular(e_PerfilPsicologicoDetalles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PerfilPsicologicoDetallesBE> Consultar_Lista()
        {
            List<PerfilPsicologicoDetallesBE> lista = new List<PerfilPsicologicoDetallesBE>();
            try
            {
                PerfilPsicologicoDetallesDA o_PerfilPsicologicoDetalles = new PerfilPsicologicoDetallesDA();
                return o_PerfilPsicologicoDetalles.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PerfilPsicologicoDetallesBE> Consultar_PK(
                              int m_PerfilPsicologicoDetallesId
                              )
        {
            List<PerfilPsicologicoDetallesBE> lista = new List<PerfilPsicologicoDetallesBE>();
            try
            {
                PerfilPsicologicoDetallesDA o_PerfilPsicologicoDetalles = new PerfilPsicologicoDetallesDA();
                return o_PerfilPsicologicoDetalles.Consultar_PK(
                                                            m_PerfilPsicologicoDetallesId
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
                PerfilPsicologicoDetallesDA o_PerfilPsicologicoDetalles = new PerfilPsicologicoDetallesDA();
                idMax = o_PerfilPsicologicoDetalles.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
