using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class Observaciones1005DetallesBL : BaseBL
    {
        const string Nombre_Clase = "Observaciones1005DetallesBL";
        private string m_BaseDatos = string.Empty;

        public Observaciones1005DetallesBL() {  }

        public bool Insertar(Observaciones1005DetallesBE e_Observaciones1005Detalles)
        {
            try
            {
                Observaciones1005DetallesDA o_Observaciones1005Detalles = new Observaciones1005DetallesDA();
                int resp = o_Observaciones1005Detalles.Insertar(e_Observaciones1005Detalles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(Observaciones1005DetallesBE e_Observaciones1005Detalles)
        {
            try
            {
                Observaciones1005DetallesDA o_Observaciones1005Detalles = new Observaciones1005DetallesDA();
                int resp = o_Observaciones1005Detalles.Actualizar(e_Observaciones1005Detalles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(Observaciones1005DetallesBE e_Observaciones1005Detalles)
        {
            try
            {
                Observaciones1005DetallesDA o_Observaciones1005Detalles = new Observaciones1005DetallesDA();
                int resp = o_Observaciones1005Detalles.Anular(e_Observaciones1005Detalles);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Observaciones1005DetallesBE> Consultar_Lista()
        {
            List<Observaciones1005DetallesBE> lista = new List<Observaciones1005DetallesBE>();
            try
            {
                Observaciones1005DetallesDA o_Observaciones1005Detalles = new Observaciones1005DetallesDA();
                return o_Observaciones1005Detalles.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Observaciones1005DetallesBE> Consultar_PK(
                              int m_Observaciones1005DetallesId
                              )
        {
            List<Observaciones1005DetallesBE> lista = new List<Observaciones1005DetallesBE>();
            try
            {
                Observaciones1005DetallesDA o_Observaciones1005Detalles = new Observaciones1005DetallesDA();
                return o_Observaciones1005Detalles.Consultar_PK(
                                                            m_Observaciones1005DetallesId
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
                Observaciones1005DetallesDA o_Observaciones1005Detalles = new Observaciones1005DetallesDA();
                idMax = o_Observaciones1005Detalles.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
