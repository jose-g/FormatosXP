using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class ReligionProfesadaBL : BaseBL
    {
        const string Nombre_Clase = "ReligionProfesadaBL";
        private string m_BaseDatos = string.Empty;

        public ReligionProfesadaBL() {  }

        public bool Insertar(ReligionProfesadaBE e_ReligionProfesada)
        {
            try
            {
                ReligionProfesadaDA o_ReligionProfesada = new ReligionProfesadaDA();
                int resp = o_ReligionProfesada.Insertar(e_ReligionProfesada);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(ReligionProfesadaBE e_ReligionProfesada)
        {
            try
            {
                ReligionProfesadaDA o_ReligionProfesada = new ReligionProfesadaDA();
                int resp = o_ReligionProfesada.Actualizar(e_ReligionProfesada);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(ReligionProfesadaBE e_ReligionProfesada)
        {
            try
            {
                ReligionProfesadaDA o_ReligionProfesada = new ReligionProfesadaDA();
                int resp = o_ReligionProfesada.Anular(e_ReligionProfesada);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ReligionProfesadaBE> Consultar_Lista()
        {
            List<ReligionProfesadaBE> lista = new List<ReligionProfesadaBE>();
            try
            {
                ReligionProfesadaDA o_ReligionProfesada = new ReligionProfesadaDA();
                return o_ReligionProfesada.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<ReligionProfesadaBE> Consultar_PK(
                              int m_ReligionProfesadaId
                              )
        {
            List<ReligionProfesadaBE> lista = new List<ReligionProfesadaBE>();
            try
            {
                ReligionProfesadaDA o_ReligionProfesada = new ReligionProfesadaDA();
                return o_ReligionProfesada.Consultar_PK(
                                                            m_ReligionProfesadaId
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
                ReligionProfesadaDA o_ReligionProfesada = new ReligionProfesadaDA();
                idMax = o_ReligionProfesada.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
