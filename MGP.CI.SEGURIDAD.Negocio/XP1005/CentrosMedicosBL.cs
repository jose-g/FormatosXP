using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class CentrosMedicosBL : BaseBL
    {
        const string Nombre_Clase = "CentrosMedicosBL";
        private string m_BaseDatos = string.Empty;

        public CentrosMedicosBL() {  }

        public bool Insertar(CentrosMedicosBE e_CentrosMedicos)
        {
            try
            {
                CentrosMedicosDA o_CentrosMedicos = new CentrosMedicosDA();
                int resp = o_CentrosMedicos.Insertar(e_CentrosMedicos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(CentrosMedicosBE e_CentrosMedicos)
        {
            try
            {
                CentrosMedicosDA o_CentrosMedicos = new CentrosMedicosDA();
                int resp = o_CentrosMedicos.Actualizar(e_CentrosMedicos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(CentrosMedicosBE e_CentrosMedicos)
        {
            try
            {
                CentrosMedicosDA o_CentrosMedicos = new CentrosMedicosDA();
                int resp = o_CentrosMedicos.Anular(e_CentrosMedicos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CentrosMedicosBE> Consultar_Lista()
        {
            List<CentrosMedicosBE> lista = new List<CentrosMedicosBE>();
            try
            {
                CentrosMedicosDA o_CentrosMedicos = new CentrosMedicosDA();
                return o_CentrosMedicos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CentrosMedicosBE> Consultar_PK(
                              int m_CentrosMedicosId
                              )
        {
            List<CentrosMedicosBE> lista = new List<CentrosMedicosBE>();
            try
            {
                CentrosMedicosDA o_CentrosMedicos = new CentrosMedicosDA();
                return o_CentrosMedicos.Consultar_PK(
                                                            m_CentrosMedicosId
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
                CentrosMedicosDA o_CentrosMedicos = new CentrosMedicosDA();
                idMax = o_CentrosMedicos.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
