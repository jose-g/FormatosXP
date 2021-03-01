using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class PaisesAfectosBL : BaseBL
    {
        const string Nombre_Clase = "PaisesAfectosBL";
        private string m_BaseDatos = string.Empty;

        public PaisesAfectosBL() {  }

        public bool Insertar(PaisesAfectosBE e_PaisesAfectos)
        {
            try
            {
                PaisesAfectosDA o_PaisesAfectos = new PaisesAfectosDA();
                int resp = o_PaisesAfectos.Insertar(e_PaisesAfectos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(PaisesAfectosBE e_PaisesAfectos)
        {
            try
            {
                PaisesAfectosDA o_PaisesAfectos = new PaisesAfectosDA();
                int resp = o_PaisesAfectos.Actualizar(e_PaisesAfectos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(PaisesAfectosBE e_PaisesAfectos)
        {
            try
            {
                PaisesAfectosDA o_PaisesAfectos = new PaisesAfectosDA();
                int resp = o_PaisesAfectos.Anular(e_PaisesAfectos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PaisesAfectosBE> Consultar_Lista()
        {
            List<PaisesAfectosBE> lista = new List<PaisesAfectosBE>();
            try
            {
                PaisesAfectosDA o_PaisesAfectos = new PaisesAfectosDA();
                return o_PaisesAfectos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PaisesAfectosBE> Consultar_PK(
                              int m_PaisesAfectosId
                              )
        {
            List<PaisesAfectosBE> lista = new List<PaisesAfectosBE>();
            try
            {
                PaisesAfectosDA o_PaisesAfectos = new PaisesAfectosDA();
                return o_PaisesAfectos.Consultar_PK(
                                                            m_PaisesAfectosId
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
                PaisesAfectosDA o_PaisesAfectos = new PaisesAfectosDA();
                idMax = o_PaisesAfectos.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
