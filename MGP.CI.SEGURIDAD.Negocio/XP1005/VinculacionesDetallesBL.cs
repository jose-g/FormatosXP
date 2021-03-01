using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class VinculacionesDetallesBL : BaseBL
    {
        const string Nombre_Clase = "VinculacionesDetallesBL";
        private string m_BaseDatos = string.Empty;

        public VinculacionesDetallesBL() {  }

        public bool Insertar(VinculacionesDetallesBE e_VinculacionesDetalles)
        {
            try
            {
                VinculacionesDetallesDA o_VinculacionesDetalles = new VinculacionesDetallesDA();
                int resp = o_VinculacionesDetalles.Insertar(e_VinculacionesDetalles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(VinculacionesDetallesBE e_VinculacionesDetalles)
        {
            try
            {
                VinculacionesDetallesDA o_VinculacionesDetalles = new VinculacionesDetallesDA();
                int resp = o_VinculacionesDetalles.Actualizar(e_VinculacionesDetalles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(VinculacionesDetallesBE e_VinculacionesDetalles)
        {
            try
            {
                VinculacionesDetallesDA o_VinculacionesDetalles = new VinculacionesDetallesDA();
                int resp = o_VinculacionesDetalles.Anular(e_VinculacionesDetalles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<VinculacionesDetallesBE> Consultar_Lista()
        {
            List<VinculacionesDetallesBE> lista = new List<VinculacionesDetallesBE>();
            try
            {
                VinculacionesDetallesDA o_VinculacionesDetalles = new VinculacionesDetallesDA();
                return o_VinculacionesDetalles.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<VinculacionesDetallesBE> Consultar_PK(
                              int m_VinculacionesDetallesId
                              )
        {
            List<VinculacionesDetallesBE> lista = new List<VinculacionesDetallesBE>();
            try
            {
                VinculacionesDetallesDA o_VinculacionesDetalles = new VinculacionesDetallesDA();
                return o_VinculacionesDetalles.Consultar_PK(
                                                            m_VinculacionesDetallesId
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
                VinculacionesDetallesDA o_VinculacionesDetalles = new VinculacionesDetallesDA();
                idMax = o_VinculacionesDetalles.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
