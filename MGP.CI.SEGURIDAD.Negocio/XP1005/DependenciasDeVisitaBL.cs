using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class DependenciasDeVisitaBL : BaseBL
    {
        const string Nombre_Clase = "DependenciasDeVisitaBL";
        private string m_BaseDatos = string.Empty;

        public DependenciasDeVisitaBL() {  }

        public bool Insertar(DependenciasDeVisitaBE e_DependenciasDeVisita)
        {
            try
            {
                DependenciasDeVisitaDA o_DependenciasDeVisita = new DependenciasDeVisitaDA();
                int resp = o_DependenciasDeVisita.Insertar(e_DependenciasDeVisita);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(DependenciasDeVisitaBE e_DependenciasDeVisita)
        {
            try
            {
                DependenciasDeVisitaDA o_DependenciasDeVisita = new DependenciasDeVisitaDA();
                int resp = o_DependenciasDeVisita.Actualizar(e_DependenciasDeVisita);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DependenciasDeVisitaBE e_DependenciasDeVisita)
        {
            try
            {
                DependenciasDeVisitaDA o_DependenciasDeVisita = new DependenciasDeVisitaDA();
                int resp = o_DependenciasDeVisita.Anular(e_DependenciasDeVisita);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DependenciasDeVisitaBE> Consultar_Lista()
        {
            List<DependenciasDeVisitaBE> lista = new List<DependenciasDeVisitaBE>();
            try
            {
                DependenciasDeVisitaDA o_DependenciasDeVisita = new DependenciasDeVisitaDA();
                return o_DependenciasDeVisita.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DependenciasDeVisitaBE> Consultar_PK(
                              int m_DependenciasDeVisitaId
                              )
        {
            List<DependenciasDeVisitaBE> lista = new List<DependenciasDeVisitaBE>();
            try
            {
                DependenciasDeVisitaDA o_DependenciasDeVisita = new DependenciasDeVisitaDA();
                return o_DependenciasDeVisita.Consultar_PK(
                                                            m_DependenciasDeVisitaId
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
                DependenciasDeVisitaDA o_DependenciasDeVisita = new DependenciasDeVisitaDA();
                idMax = o_DependenciasDeVisita.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
