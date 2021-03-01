using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class AtencionesMedicasBL : BaseBL
    {
        const string Nombre_Clase = "AtencionesMedicasBL";
        private string m_BaseDatos = string.Empty;

        public AtencionesMedicasBL() {  }

        public bool Insertar(AtencionesMedicasBE e_AtencionesMedicas)
        {
            try
            {
                AtencionesMedicasDA o_AtencionesMedicas = new AtencionesMedicasDA();
                int resp = o_AtencionesMedicas.Insertar(e_AtencionesMedicas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(AtencionesMedicasBE e_AtencionesMedicas)
        {
            try
            {
                AtencionesMedicasDA o_AtencionesMedicas = new AtencionesMedicasDA();
                int resp = o_AtencionesMedicas.Actualizar(e_AtencionesMedicas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(AtencionesMedicasBE e_AtencionesMedicas)
        {
            try
            {
                AtencionesMedicasDA o_AtencionesMedicas = new AtencionesMedicasDA();
                int resp = o_AtencionesMedicas.Anular(e_AtencionesMedicas);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<AtencionesMedicasBE> Consultar_Lista()
        {
            List<AtencionesMedicasBE> lista = new List<AtencionesMedicasBE>();
            try
            {
                AtencionesMedicasDA o_AtencionesMedicas = new AtencionesMedicasDA();
                return o_AtencionesMedicas.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<AtencionesMedicasBE> Consultar_PK(
                              int m_AtencionesMedicasId
                              )
        {
            List<AtencionesMedicasBE> lista = new List<AtencionesMedicasBE>();
            try
            {
                AtencionesMedicasDA o_AtencionesMedicas = new AtencionesMedicasDA();
                return o_AtencionesMedicas.Consultar_PK(
                                                            m_AtencionesMedicasId
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
                AtencionesMedicasDA o_AtencionesMedicas = new AtencionesMedicasDA();
                idMax = o_AtencionesMedicas.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
