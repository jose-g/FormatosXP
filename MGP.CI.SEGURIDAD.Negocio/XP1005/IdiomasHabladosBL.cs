using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class IdiomasHabladosBL : BaseBL
    {
        const string Nombre_Clase = "IdiomasHabladosBL";
        private string m_BaseDatos = string.Empty;

        public IdiomasHabladosBL() {  }

        public bool Insertar(IdiomasHabladosBE e_IdiomasHablados)
        {
            try
            {
                IdiomasHabladosDA o_IdiomasHablados = new IdiomasHabladosDA();
                int resp = o_IdiomasHablados.Insertar(e_IdiomasHablados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(IdiomasHabladosBE e_IdiomasHablados)
        {
            try
            {
                IdiomasHabladosDA o_IdiomasHablados = new IdiomasHabladosDA();
                int resp = o_IdiomasHablados.Actualizar(e_IdiomasHablados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(IdiomasHabladosBE e_IdiomasHablados)
        {
            try
            {
                IdiomasHabladosDA o_IdiomasHablados = new IdiomasHabladosDA();
                int resp = o_IdiomasHablados.Anular(e_IdiomasHablados);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<IdiomasHabladosBE> Consultar_Lista()
        {
            List<IdiomasHabladosBE> lista = new List<IdiomasHabladosBE>();
            try
            {
                IdiomasHabladosDA o_IdiomasHablados = new IdiomasHabladosDA();
                return o_IdiomasHablados.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<IdiomasHabladosBE> Consultar_PK(
                              int m_IdiomasHabladosId
                              )
        {
            List<IdiomasHabladosBE> lista = new List<IdiomasHabladosBE>();
            try
            {
                IdiomasHabladosDA o_IdiomasHablados = new IdiomasHabladosDA();
                return o_IdiomasHablados.Consultar_PK(
                                                            m_IdiomasHabladosId
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
                IdiomasHabladosDA o_IdiomasHablados = new IdiomasHabladosDA();
                idMax = o_IdiomasHablados.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
