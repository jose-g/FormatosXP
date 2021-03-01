using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class DefectosDemostradoBL : BaseBL
    {
        const string Nombre_Clase = "DefectosDemostradoBL";
        private string m_BaseDatos = string.Empty;

        public DefectosDemostradoBL() {  }

        public bool Insertar(DefectosDemostradoBE e_DefectosDemostrado)
        {
            try
            {
                DefectosDemostradoDA o_DefectosDemostrado = new DefectosDemostradoDA();
                int resp = o_DefectosDemostrado.Insertar(e_DefectosDemostrado);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(DefectosDemostradoBE e_DefectosDemostrado)
        {
            try
            {
                DefectosDemostradoDA o_DefectosDemostrado = new DefectosDemostradoDA();
                int resp = o_DefectosDemostrado.Actualizar(e_DefectosDemostrado);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(DefectosDemostradoBE e_DefectosDemostrado)
        {
            try
            {
                DefectosDemostradoDA o_DefectosDemostrado = new DefectosDemostradoDA();
                int resp = o_DefectosDemostrado.Anular(e_DefectosDemostrado);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DefectosDemostradoBE> Consultar_Lista()
        {
            List<DefectosDemostradoBE> lista = new List<DefectosDemostradoBE>();
            try
            {
                DefectosDemostradoDA o_DefectosDemostrado = new DefectosDemostradoDA();
                return o_DefectosDemostrado.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<DefectosDemostradoBE> Consultar_PK(
                              int m_DefectosDemostradoId
                              )
        {
            List<DefectosDemostradoBE> lista = new List<DefectosDemostradoBE>();
            try
            {
                DefectosDemostradoDA o_DefectosDemostrado = new DefectosDemostradoDA();
                return o_DefectosDemostrado.Consultar_PK(
                                                            m_DefectosDemostradoId
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
                DefectosDemostradoDA o_DefectosDemostrado = new DefectosDemostradoDA();
                idMax = o_DefectosDemostrado.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
