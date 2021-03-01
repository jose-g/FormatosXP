using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class Observaciones1005TipoBL : BaseBL
    {
        const string Nombre_Clase = "Observaciones1005TipoBL";
        private string m_BaseDatos = string.Empty;

        public Observaciones1005TipoBL() {  }

        public bool Insertar(Observaciones1005TipoBE e_Observaciones1005Tipo)
        {
            try
            {
                Observaciones1005TipoDA o_Observaciones1005Tipo = new Observaciones1005TipoDA();
                int resp = o_Observaciones1005Tipo.Insertar(e_Observaciones1005Tipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(Observaciones1005TipoBE e_Observaciones1005Tipo)
        {
            try
            {
                Observaciones1005TipoDA o_Observaciones1005Tipo = new Observaciones1005TipoDA();
                int resp = o_Observaciones1005Tipo.Actualizar(e_Observaciones1005Tipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(Observaciones1005TipoBE e_Observaciones1005Tipo)
        {
            try
            {
                Observaciones1005TipoDA o_Observaciones1005Tipo = new Observaciones1005TipoDA();
                int resp = o_Observaciones1005Tipo.Anular(e_Observaciones1005Tipo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Observaciones1005TipoBE> Consultar_Lista()
        {
            List<Observaciones1005TipoBE> lista = new List<Observaciones1005TipoBE>();
            try
            {
                Observaciones1005TipoDA o_Observaciones1005Tipo = new Observaciones1005TipoDA();
                return o_Observaciones1005Tipo.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<Observaciones1005TipoBE> Consultar_PK(
                              int m_Observaciones1005TipoId
                              )
        {
            List<Observaciones1005TipoBE> lista = new List<Observaciones1005TipoBE>();
            try
            {
                Observaciones1005TipoDA o_Observaciones1005Tipo = new Observaciones1005TipoDA();
                return o_Observaciones1005Tipo.Consultar_PK(
                                                            m_Observaciones1005TipoId
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
                Observaciones1005TipoDA o_Observaciones1005Tipo = new Observaciones1005TipoDA();
                idMax = o_Observaciones1005Tipo.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
