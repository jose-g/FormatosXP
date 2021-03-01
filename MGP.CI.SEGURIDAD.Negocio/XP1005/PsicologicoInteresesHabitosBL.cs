using System;
using System.Collections.Generic;
using MGP.CI.SEGURIDAD.Entidades.X1005;
using MGP.CI.SEGURIDAD.AccesoDatos.X1005;

namespace MGP.CI.SEGURIDAD.Negocio.X1005
{
    [Serializable]
    public partial class PsicologicoInteresesHabitosBL : BaseBL
    {
        const string Nombre_Clase = "PsicologicoInteresesHabitosBL";
        private string m_BaseDatos = string.Empty;

        public PsicologicoInteresesHabitosBL() {  }

        public bool Insertar(PsicologicoInteresesHabitosBE e_PsicologicoInteresesHabitos)
        {
            try
            {
                PsicologicoInteresesHabitosDA o_PsicologicoInteresesHabitos = new PsicologicoInteresesHabitosDA();
                int resp = o_PsicologicoInteresesHabitos.Insertar(e_PsicologicoInteresesHabitos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public  bool Actualizar(PsicologicoInteresesHabitosBE e_PsicologicoInteresesHabitos)
        {
            try
            {
                PsicologicoInteresesHabitosDA o_PsicologicoInteresesHabitos = new PsicologicoInteresesHabitosDA();
                int resp = o_PsicologicoInteresesHabitos.Actualizar(e_PsicologicoInteresesHabitos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public bool Anular(PsicologicoInteresesHabitosBE e_PsicologicoInteresesHabitos)
        {
            try
            {
                PsicologicoInteresesHabitosDA o_PsicologicoInteresesHabitos = new PsicologicoInteresesHabitosDA();
                int resp = o_PsicologicoInteresesHabitos.Anular(e_PsicologicoInteresesHabitos);
                return (resp > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PsicologicoInteresesHabitosBE> Consultar_Lista()
        {
            List<PsicologicoInteresesHabitosBE> lista = new List<PsicologicoInteresesHabitosBE>();
            try
            {
                PsicologicoInteresesHabitosDA o_PsicologicoInteresesHabitos = new PsicologicoInteresesHabitosDA();
                return o_PsicologicoInteresesHabitos.Consultar_Lista();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
        }

        public List<PsicologicoInteresesHabitosBE> Consultar_PK(
                              int m_PsicologicoInteresesHabitosId
                              )
        {
            List<PsicologicoInteresesHabitosBE> lista = new List<PsicologicoInteresesHabitosBE>();
            try
            {
                PsicologicoInteresesHabitosDA o_PsicologicoInteresesHabitos = new PsicologicoInteresesHabitosDA();
                return o_PsicologicoInteresesHabitos.Consultar_PK(
                                                            m_PsicologicoInteresesHabitosId
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
                PsicologicoInteresesHabitosDA o_PsicologicoInteresesHabitos = new PsicologicoInteresesHabitosDA();
                idMax = o_PsicologicoInteresesHabitos.GetMaxId();
            }
            catch (Exception ex)
            {
                throw new Exception("Clase Business: " + Nombre_Clase + "\r\n" + "Descripción: " + ex.Message);
            }
            return idMax ;
        }

    }
}
