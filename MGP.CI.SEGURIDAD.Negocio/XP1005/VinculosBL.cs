using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class VinculosBL : BaseBL
    {
        const string Nombre_Clase = "VinculosBL";
        private string m_BaseDatos = string.Empty;

        public VinculosBL() {  }

        public bool Insertar(VinculosBE e_Vinculos)
        {
            try
            {
                VinculosDA o_Vinculos = new VinculosDA();
                int resp = o_Vinculos.Insertar(e_Vinculos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(VinculosBE e_Vinculos)
        {
            try
            {
                VinculosDA o_Vinculos = new VinculosDA();
                int resp = o_Vinculos.Actualizar(e_Vinculos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(VinculosBE e_Vinculos)
        {
            try
            {
                VinculosDA o_Vinculos = new VinculosDA();
                int resp = o_Vinculos.Anular(e_Vinculos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<VinculosBE> Consultar_Lista()
        {
            List<VinculosBE> lista = new List<VinculosBE>();
            try
            {
                VinculosDA o_Vinculos = new VinculosDA();
                return o_Vinculos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<VinculosBE> Consultar_PK(
                              int m_VinculoId
                              )
        {
            List<VinculosBE> lista = new List<VinculosBE>();
            try
            {
                VinculosDA o_Vinculos = new VinculosDA();
                return o_Vinculos.Consultar_PK(
                                                            m_VinculoId
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
                VinculosDA o_Vinculos = new VinculosDA();
                idMax = o_Vinculos.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
