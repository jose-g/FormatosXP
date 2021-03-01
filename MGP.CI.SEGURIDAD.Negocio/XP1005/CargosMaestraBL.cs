using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class CargosMaestraBL : BaseBL
    {
        const string Nombre_Clase = "CargosMaestraBL";
        private string m_BaseDatos = string.Empty;

        public CargosMaestraBL() {  }

        public bool Insertar(CargosMaestraBE e_CargosMaestra)
        {
            try
            {
                CargosMaestraDA o_CargosMaestra = new CargosMaestraDA();
                int resp = o_CargosMaestra.Insertar(e_CargosMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(CargosMaestraBE e_CargosMaestra)
        {
            try
            {
                CargosMaestraDA o_CargosMaestra = new CargosMaestraDA();
                int resp = o_CargosMaestra.Actualizar(e_CargosMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(CargosMaestraBE e_CargosMaestra)
        {
            try
            {
                CargosMaestraDA o_CargosMaestra = new CargosMaestraDA();
                int resp = o_CargosMaestra.Anular(e_CargosMaestra);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CargosMaestraBE> Consultar_Lista()
        {
            List<CargosMaestraBE> lista = new List<CargosMaestraBE>();
            try
            {
                CargosMaestraDA o_CargosMaestra = new CargosMaestraDA();
                return o_CargosMaestra.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<CargosMaestraBE> Consultar_PK(
                              int m_CargosMaestraId
                              )
        {
            List<CargosMaestraBE> lista = new List<CargosMaestraBE>();
            try
            {
                CargosMaestraDA o_CargosMaestra = new CargosMaestraDA();
                return o_CargosMaestra.Consultar_PK(
                                                            m_CargosMaestraId
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
                CargosMaestraDA o_CargosMaestra = new CargosMaestraDA();
                idMax = o_CargosMaestra.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
