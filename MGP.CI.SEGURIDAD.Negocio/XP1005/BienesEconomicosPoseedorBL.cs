using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class BienesEconomicosPoseedorBL : BaseBL
    {
        const string Nombre_Clase = "BienesEconomicosPoseedorBL";
        private string m_BaseDatos = string.Empty;

        public BienesEconomicosPoseedorBL() {  }

        public bool Insertar(BienesEconomicosPoseedorBE e_BienesEconomicosPoseedor)
        {
            try
            {
                BienesEconomicosPoseedorDA o_BienesEconomicosPoseedor = new BienesEconomicosPoseedorDA();
                int resp = o_BienesEconomicosPoseedor.Insertar(e_BienesEconomicosPoseedor);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(BienesEconomicosPoseedorBE e_BienesEconomicosPoseedor)
        {
            try
            {
                BienesEconomicosPoseedorDA o_BienesEconomicosPoseedor = new BienesEconomicosPoseedorDA();
                int resp = o_BienesEconomicosPoseedor.Actualizar(e_BienesEconomicosPoseedor);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(BienesEconomicosPoseedorBE e_BienesEconomicosPoseedor)
        {
            try
            {
                BienesEconomicosPoseedorDA o_BienesEconomicosPoseedor = new BienesEconomicosPoseedorDA();
                int resp = o_BienesEconomicosPoseedor.Anular(e_BienesEconomicosPoseedor);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<BienesEconomicosPoseedorBE> Consultar_Lista()
        {
            List<BienesEconomicosPoseedorBE> lista = new List<BienesEconomicosPoseedorBE>();
            try
            {
                BienesEconomicosPoseedorDA o_BienesEconomicosPoseedor = new BienesEconomicosPoseedorDA();
                return o_BienesEconomicosPoseedor.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<BienesEconomicosPoseedorBE> Consultar_PK(
                              int m_BienesEconomicosPoseedorId
                              )
        {
            List<BienesEconomicosPoseedorBE> lista = new List<BienesEconomicosPoseedorBE>();
            try
            {
                BienesEconomicosPoseedorDA o_BienesEconomicosPoseedor = new BienesEconomicosPoseedorDA();
                return o_BienesEconomicosPoseedor.Consultar_PK(
                                                            m_BienesEconomicosPoseedorId
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
                BienesEconomicosPoseedorDA o_BienesEconomicosPoseedor = new BienesEconomicosPoseedorDA();
                idMax = o_BienesEconomicosPoseedor.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
