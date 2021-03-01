using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class ValoresDemostradosBL : BaseBL
    {
        const string Nombre_Clase = "ValoresDemostradosBL";
        private string m_BaseDatos = string.Empty;

        public ValoresDemostradosBL() {  }

        public bool Insertar(ValoresDemostradosBE e_ValoresDemostrados)
        {
            try
            {
                ValoresDemostradosDA o_ValoresDemostrados = new ValoresDemostradosDA();
                int resp = o_ValoresDemostrados.Insertar(e_ValoresDemostrados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(ValoresDemostradosBE e_ValoresDemostrados)
        {
            try
            {
                ValoresDemostradosDA o_ValoresDemostrados = new ValoresDemostradosDA();
                int resp = o_ValoresDemostrados.Actualizar(e_ValoresDemostrados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(ValoresDemostradosBE e_ValoresDemostrados)
        {
            try
            {
                ValoresDemostradosDA o_ValoresDemostrados = new ValoresDemostradosDA();
                int resp = o_ValoresDemostrados.Anular(e_ValoresDemostrados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ValoresDemostradosBE> Consultar_Lista()
        {
            List<ValoresDemostradosBE> lista = new List<ValoresDemostradosBE>();
            try
            {
                ValoresDemostradosDA o_ValoresDemostrados = new ValoresDemostradosDA();
                return o_ValoresDemostrados.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ValoresDemostradosBE> Consultar_PK(
                              int m_ValoresDemostradosId
                              )
        {
            List<ValoresDemostradosBE> lista = new List<ValoresDemostradosBE>();
            try
            {
                ValoresDemostradosDA o_ValoresDemostrados = new ValoresDemostradosDA();
                return o_ValoresDemostrados.Consultar_PK(
                                                            m_ValoresDemostradosId
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
                ValoresDemostradosDA o_ValoresDemostrados = new ValoresDemostradosDA();
                idMax = o_ValoresDemostrados.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
