using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class InteresesHabitosViciosBL : BaseBL
    {
        const string Nombre_Clase = "InteresesHabitosViciosBL";
        private string m_BaseDatos = string.Empty;

        public InteresesHabitosViciosBL() {  }

        public bool Insertar(InteresesHabitosViciosBE e_InteresesHabitosVicios)
        {
            try
            {
                InteresesHabitosViciosDA o_InteresesHabitosVicios = new InteresesHabitosViciosDA();
                int resp = o_InteresesHabitosVicios.Insertar(e_InteresesHabitosVicios);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(InteresesHabitosViciosBE e_InteresesHabitosVicios)
        {
            try
            {
                InteresesHabitosViciosDA o_InteresesHabitosVicios = new InteresesHabitosViciosDA();
                int resp = o_InteresesHabitosVicios.Actualizar(e_InteresesHabitosVicios);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(InteresesHabitosViciosBE e_InteresesHabitosVicios)
        {
            try
            {
                InteresesHabitosViciosDA o_InteresesHabitosVicios = new InteresesHabitosViciosDA();
                int resp = o_InteresesHabitosVicios.Anular(e_InteresesHabitosVicios);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<InteresesHabitosViciosBE> Consultar_Lista()
        {
            List<InteresesHabitosViciosBE> lista = new List<InteresesHabitosViciosBE>();
            try
            {
                InteresesHabitosViciosDA o_InteresesHabitosVicios = new InteresesHabitosViciosDA();
                return o_InteresesHabitosVicios.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<InteresesHabitosViciosBE> Consultar_PK(
                              int m_InteresHabitosId
                              )
        {
            List<InteresesHabitosViciosBE> lista = new List<InteresesHabitosViciosBE>();
            try
            {
                InteresesHabitosViciosDA o_InteresesHabitosVicios = new InteresesHabitosViciosDA();
                return o_InteresesHabitosVicios.Consultar_PK(
                                                            m_InteresHabitosId
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
                InteresesHabitosViciosDA o_InteresesHabitosVicios = new InteresesHabitosViciosDA();
                idMax = o_InteresesHabitosVicios.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
