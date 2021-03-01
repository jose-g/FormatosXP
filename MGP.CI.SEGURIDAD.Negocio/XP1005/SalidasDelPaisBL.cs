using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class SalidasDelPaisBL : BaseBL
    {
        const string Nombre_Clase = "SalidasDelPaisBL";
        private string m_BaseDatos = string.Empty;

        public SalidasDelPaisBL() {  }

        public bool Insertar(SalidasDelPaisBE e_SalidasDelPais)
        {
            try
            {
                SalidasDelPaisDA o_SalidasDelPais = new SalidasDelPaisDA();
                int resp = o_SalidasDelPais.Insertar(e_SalidasDelPais);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(SalidasDelPaisBE e_SalidasDelPais)
        {
            try
            {
                SalidasDelPaisDA o_SalidasDelPais = new SalidasDelPaisDA();
                int resp = o_SalidasDelPais.Actualizar(e_SalidasDelPais);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(SalidasDelPaisBE e_SalidasDelPais)
        {
            try
            {
                SalidasDelPaisDA o_SalidasDelPais = new SalidasDelPaisDA();
                int resp = o_SalidasDelPais.Anular(e_SalidasDelPais);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<SalidasDelPaisBE> Consultar_Lista()
        {
            List<SalidasDelPaisBE> lista = new List<SalidasDelPaisBE>();
            try
            {
                SalidasDelPaisDA o_SalidasDelPais = new SalidasDelPaisDA();
                return o_SalidasDelPais.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<SalidasDelPaisBE> Consultar_PK(
                              int m_SalidasDelPaisId
                              )
        {
            List<SalidasDelPaisBE> lista = new List<SalidasDelPaisBE>();
            try
            {
                SalidasDelPaisDA o_SalidasDelPais = new SalidasDelPaisDA();
                return o_SalidasDelPais.Consultar_PK(
                                                            m_SalidasDelPaisId
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
                SalidasDelPaisDA o_SalidasDelPais = new SalidasDelPaisDA();
                idMax = o_SalidasDelPais.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
