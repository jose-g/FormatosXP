using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class PreferenciaSexualProfesadaBL : BaseBL
    {
        const string Nombre_Clase = "PreferenciaSexualProfesadaBL";
        private string m_BaseDatos = string.Empty;

        public PreferenciaSexualProfesadaBL() {  }

        public bool Insertar(PreferenciaSexualProfesadaBE e_PreferenciaSexualProfesada)
        {
            try
            {
                PreferenciaSexualProfesadaDA o_PreferenciaSexualProfesada = new PreferenciaSexualProfesadaDA();
                int resp = o_PreferenciaSexualProfesada.Insertar(e_PreferenciaSexualProfesada);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(PreferenciaSexualProfesadaBE e_PreferenciaSexualProfesada)
        {
            try
            {
                PreferenciaSexualProfesadaDA o_PreferenciaSexualProfesada = new PreferenciaSexualProfesadaDA();
                int resp = o_PreferenciaSexualProfesada.Actualizar(e_PreferenciaSexualProfesada);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(PreferenciaSexualProfesadaBE e_PreferenciaSexualProfesada)
        {
            try
            {
                PreferenciaSexualProfesadaDA o_PreferenciaSexualProfesada = new PreferenciaSexualProfesadaDA();
                int resp = o_PreferenciaSexualProfesada.Anular(e_PreferenciaSexualProfesada);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PreferenciaSexualProfesadaBE> Consultar_Lista()
        {
            List<PreferenciaSexualProfesadaBE> lista = new List<PreferenciaSexualProfesadaBE>();
            try
            {
                PreferenciaSexualProfesadaDA o_PreferenciaSexualProfesada = new PreferenciaSexualProfesadaDA();
                return o_PreferenciaSexualProfesada.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PreferenciaSexualProfesadaBE> Consultar_PK(
                              int m_PreferenciaSexualProfesadaID
                              )
        {
            List<PreferenciaSexualProfesadaBE> lista = new List<PreferenciaSexualProfesadaBE>();
            try
            {
                PreferenciaSexualProfesadaDA o_PreferenciaSexualProfesada = new PreferenciaSexualProfesadaDA();
                return o_PreferenciaSexualProfesada.Consultar_PK(
                                                            m_PreferenciaSexualProfesadaID
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
                PreferenciaSexualProfesadaDA o_PreferenciaSexualProfesada = new PreferenciaSexualProfesadaDA();
                idMax = o_PreferenciaSexualProfesada.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
