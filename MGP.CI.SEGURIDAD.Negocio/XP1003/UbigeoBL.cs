using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.XP1003;
using MGP.CI.SEGURIDAD.AccesoDatos.XP1003;

namespace MGP.CI.SEGURIDAD.Negocio.XP1003
{
    [Serializable]
    public partial class UbigeoBL : BaseBL
    {
        const string Nombre_Clase = "UbigeoBL";
        private string m_BaseDatos = string.Empty;

        public UbigeoBL(string BaseDatos) { m_BaseDatos = BaseDatos; }
        public UbigeoBL() { }


        public bool Insertar(UbigeoBE e_Ubigeo)
        {
            try
            {
                UbigeoDA o_Ubigeo = new UbigeoDA(m_BaseDatos);
                int resp = o_Ubigeo.Insertar(e_Ubigeo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Actualizar(UbigeoBE e_Ubigeo)
        {
            try
            {
                UbigeoDA o_Ubigeo = new UbigeoDA(m_BaseDatos);
                int resp = o_Ubigeo.Actualizar(e_Ubigeo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(UbigeoBE e_Ubigeo)
        {
            try
            {
                UbigeoDA o_Ubigeo = new UbigeoDA(m_BaseDatos);
                int resp = o_Ubigeo.Anular(e_Ubigeo);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<UbigeoBE> Consultar_Lista()
        {
            List<UbigeoBE> lista = new List<UbigeoBE>();
            try
            {
                UbigeoDA o_Ubigeo = new UbigeoDA(m_BaseDatos);
                return o_Ubigeo.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<UbigeoBE> Consultar_PK(
                              int m_UbigeoId
                              )
        {
            List<UbigeoBE> lista = new List<UbigeoBE>();
            try
            {
                UbigeoDA o_Ubigeo = new UbigeoDA(m_BaseDatos);
                return o_Ubigeo.Consultar_PK(
                                                            m_UbigeoId
                                                            );
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

    }
}
