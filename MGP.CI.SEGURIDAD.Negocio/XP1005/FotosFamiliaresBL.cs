using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class FotosFamiliaresBL : BaseBL
    {
        const string Nombre_Clase = "FotosFamiliaresBL";
        private string m_BaseDatos = string.Empty;

        public FotosFamiliaresBL() {  }

        public bool Insertar(FotosFamiliaresBE e_FotosFamiliares)
        {
            try
            {
                FotosFamiliaresDA o_FotosFamiliares = new FotosFamiliaresDA();
                int resp = o_FotosFamiliares.Insertar(e_FotosFamiliares);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(FotosFamiliaresBE e_FotosFamiliares)
        {
            try
            {
                FotosFamiliaresDA o_FotosFamiliares = new FotosFamiliaresDA();
                int resp = o_FotosFamiliares.Actualizar(e_FotosFamiliares);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(FotosFamiliaresBE e_FotosFamiliares)
        {
            try
            {
                FotosFamiliaresDA o_FotosFamiliares = new FotosFamiliaresDA();
                int resp = o_FotosFamiliares.Anular(e_FotosFamiliares);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<FotosFamiliaresBE> Consultar_Lista()
        {
            List<FotosFamiliaresBE> lista = new List<FotosFamiliaresBE>();
            try
            {
                FotosFamiliaresDA o_FotosFamiliares = new FotosFamiliaresDA();
                return o_FotosFamiliares.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<FotosFamiliaresBE> Consultar_PK(
                              string m_FotoFamiliaresId
                              )
        {
            List<FotosFamiliaresBE> lista = new List<FotosFamiliaresBE>();
            try
            {
                FotosFamiliaresDA o_FotosFamiliares = new FotosFamiliaresDA();
                return o_FotosFamiliares.Consultar_PK(
                                                            m_FotoFamiliaresId
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
                FotosFamiliaresDA o_FotosFamiliares = new FotosFamiliaresDA();
                idMax = o_FotosFamiliares.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
