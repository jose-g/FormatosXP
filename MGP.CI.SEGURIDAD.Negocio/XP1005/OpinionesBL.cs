using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class OpinionesBL : BaseBL
    {
        const string Nombre_Clase = "OpinionesBL";
        private string m_BaseDatos = string.Empty;

        public OpinionesBL() {  }

        public bool Insertar(OpinionesBE e_Opiniones)
        {
            try
            {
                OpinionesDA o_Opiniones = new OpinionesDA();
                int resp = o_Opiniones.Insertar(e_Opiniones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(OpinionesBE e_Opiniones)
        {
            try
            {
                OpinionesDA o_Opiniones = new OpinionesDA();
                int resp = o_Opiniones.Actualizar(e_Opiniones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(OpinionesBE e_Opiniones)
        {
            try
            {
                OpinionesDA o_Opiniones = new OpinionesDA();
                int resp = o_Opiniones.Anular(e_Opiniones);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<OpinionesBE> Consultar_Lista()
        {
            List<OpinionesBE> lista = new List<OpinionesBE>();
            try
            {
                OpinionesDA o_Opiniones = new OpinionesDA();
                return o_Opiniones.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<OpinionesBE> Consultar_PK(
                              int m_OpinionesId
                              )
        {
            List<OpinionesBE> lista = new List<OpinionesBE>();
            try
            {
                OpinionesDA o_Opiniones = new OpinionesDA();
                return o_Opiniones.Consultar_PK(
                                                            m_OpinionesId
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
                OpinionesDA o_Opiniones = new OpinionesDA();
                idMax = o_Opiniones.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
